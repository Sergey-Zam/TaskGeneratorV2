﻿Imports System
Imports System.Type
Imports System.Activator
Imports System.Runtime.InteropServices
Imports Inventor
Imports System.IO
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class Form1
    Dim _invApp As Inventor.Application 'переменная типа Inventor.Application Используется для доступа к объекту Inventor Application
    Dim _started As Boolean = False 'Данная логическая переменная служит индикатором, был ли данный сеанс Inventor создан нашей программой
    Dim _taskInfo As TaskInfo = New TaskInfo() 'Класс с дополнительной техничсекой информацией по текущему заданию
    Dim _msgTaskGeneration As CustomMessage 'сообщение о том, что задание пока генерируется (это долгий процесс)

    Public Sub New()
        ' Этот вызов является обязательным для конструктора.
        InitializeComponent()

        'здесь размещается любой инициализирующий код.
        Try
            'пытаемся получить ссылку на запущенный Inventor
            _invApp = Marshal.GetActiveObject("Inventor.Application") 'После выполнения этой строки переменная _invApp будет содержать ссылку на объект типа Inventor.Application. Функция GetActiveObject помогает нам найти существующий сеанс Inventor. 
        Catch ex As Exception
            'если не удалось получить ссылку (например, Inventor не запущен), то код ниже попытается создать новый сеанс Inventor.
            Try
                Dim invAppType As Type = GetTypeFromProgID("Inventor.Application")
                _invApp = CreateInstance(invAppType)
                _invApp.Visible = True
                _started = True
            Catch ex2 As Exception
                MsgBox(ex2.ToString())
                MsgBox("Ошибка: не удалось ни найти, ни создать сеанс Inventor")
            End Try
        End Try
    End Sub

    'функция запускается, как только форма загружена.
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'объявление переменных для сообщений
        _msgTaskGeneration = New CustomMessage("Идет процесс генерирования задания")
        'выбрать первое значение по умолчанию для combo box view
        cbView.SelectedIndex = 0
    End Sub

    'вызов фунции из кнопки "сгенерировать новое задание"
    Private Sub Run()
        _msgTaskGeneration.Show() 'показать сообщение

        _taskInfo.Restart() 'очистить старые значения от прошлой генерации

        CheckNumericValues() 'проверить, правильно ли пользователем введены входные значения в numericUpDowns

        If _taskInfo.isGenerationFailing = False Then
            GetActiveDocument() 'получить открытый документ в Inventor
        End If

        If _taskInfo.isGenerationFailing = False Then
            GetRightVariants() 'получение изображений правильных вариантов
        End If

        If _taskInfo.isGenerationFailing = False Then
            BuildingPossiblePartChanges() 'Построение списка возможных вариантов изменений детали
        End If

        If _taskInfo.isGenerationFailing = False Then
            GetWrongVariants() 'получение изображений неправильных вариантов
        End If

        If _taskInfo.isGenerationFailing = False Then
            PlacingStaticVariants() 'размещение на форме изображений правильных вариантов
        End If

        If _taskInfo.isGenerationFailing = False Then
            PlacingDynamicVariants() 'размещение на форме изображений неправильных вариантов
        End If

        'конец работы
        _msgTaskGeneration.Hide() 'скрыть сообщение

        'вывод, выдать сообщение
        If _taskInfo.isGenerationFailing = False Then
            MsgBox("Задание успешно сгенерировано")
            _taskInfo.isReady = True
        Else
            MsgBox("Задание не было сгенерировано, повторите для другой детали")
        End If
    End Sub

    'вспомогательная функция: проверить, правильно ли пользователем введены входные значения в numericUpDowns
    Private Sub CheckNumericValues()
        If _taskInfo.minChangeValue >= _taskInfo.maxChangeValue Then
            MsgBox("Значение минимального изменения параметра должно быть меньше значения максимального изменения параметра")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End If

        If _taskInfo.changeStep >= _taskInfo.minChangeValue Then
            MsgBox("Значение шага изменения параметра должно быть меньше значения минимального изменения параметра")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End If
    End Sub

    'вспомогательная функция: получить открытый документ в Inventor
    Private Sub GetActiveDocument()
        If _invApp.Documents.Count = 0 Then 'если не открыто ни 1 документа
            MsgBox("Ошибка: надо открыть хотя бы один документ в Inventor")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End If

        If _invApp.ActiveDocument.DocumentType <> DocumentTypeEnum.kPartDocumentObject Then 'если тип открытого документа не деталь
            MsgBox("Ошибка: открытый документ должен быть деталью")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End If

        _taskInfo.oDoc = _invApp.ActiveDocument 'документ получен
        Dim oSurfaceBodies As SurfaceBodies = _taskInfo.oDoc.ComponentDefinition.SurfaceBodies
        If oSurfaceBodies.Count <> 1 Then
            MsgBox("Ошибка: деталь должна содержать одно твердое тело")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End If

        Dim oPartFeatures As PartFeatures = _taskInfo.oDoc.ComponentDefinition.Features 'получить вообще все features
        If oPartFeatures.Count = 0 Then
            MsgBox("Ошибка: деталь не содержит ни одной features.")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End If

        For Each partFeature As PartFeature In oPartFeatures
            If partFeature.Suppressed = True Then
                MsgBox("Ошибка: в детали содержатся подавленные features.")
                _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
                Exit Sub
            End If
        Next
    End Sub

    'вспомогательная функция: получение изображений правильных вариантов
    Private Sub GetRightVariants()
        'установить тему с белым фоном (удобно при получении снимков)
        _invApp.ColorSchemes.Item("Presentation").Activate() 'this color scheme contains a white background
        _invApp.ColorSchemes.BackgroundType = BackgroundTypeEnum.kOneColorBackgroundType

        'получить вид спереди - Front
        If _taskInfo.isGenerationFailing = False Then
            TurnToView(ViewOrientationTypeEnum.kFrontViewOrientation)
        End If
        If _taskInfo.isGenerationFailing = False Then
            MakeAndSaveScreenshot("Front", _taskInfo.currentImageFrontName)
        End If

        'получить вид сверху - Top
        If _taskInfo.isGenerationFailing = False Then
            TurnToView(ViewOrientationTypeEnum.kTopViewOrientation)
        End If
        If _taskInfo.isGenerationFailing = False Then
            MakeAndSaveScreenshot("Top", _taskInfo.currentImageTopName)
        End If

        'получить правильный вид - Correct (по умолчанию это вид слева Left)
        If _taskInfo.isGenerationFailing = False Then
            TurnToView(_taskInfo.viewOrientation)
        End If
        If _taskInfo.isGenerationFailing = False Then
            MakeAndSaveScreenshot("Correct", _taskInfo.currentImageCorrectName)
        End If
    End Sub

    'вспомогательная функция: получение изображений неправильных вариантов
    Private Sub GetWrongVariants()
        'получить неправильный вариант Wrong1
        If _taskInfo.isGenerationFailing = False Then
            TurnToView(_taskInfo.viewOrientation) 'установить тот же вид, что и для снимка Correct
            PartChange() 'изменить деталь
        End If
        If _taskInfo.isGenerationFailing = False Then
            MakeAndSaveScreenshot("Wrong1", _taskInfo.currentImageWrong1Name) 'сделать и сохранить скрин
        End If
        If _taskInfo.isGenerationFailing = False Then
            PartRecovery() 'вернуть деталь в изначальное состояние
        End If

        'получить неправильный вариант Wrong2
        If _taskInfo.isGenerationFailing = False Then
            TurnToView(_taskInfo.viewOrientation) 'установить тот же вид, что и для снимка Correct
            PartChange() 'изменить деталь
        End If
        If _taskInfo.isGenerationFailing = False Then
            MakeAndSaveScreenshot("Wrong2", _taskInfo.currentImageWrong2Name) 'сделать и сохранить скрин
        End If
        If _taskInfo.isGenerationFailing = False Then
            PartRecovery() 'вернуть деталь в изначальное состояние
        End If

        'получить неправильный вариант Wrong3
        If _taskInfo.isGenerationFailing = False Then
            TurnToView(_taskInfo.viewOrientation) 'установить тот же вид, что и для снимка Correct
            PartChange() 'изменить деталь
        End If
        If _taskInfo.isGenerationFailing = False Then
            MakeAndSaveScreenshot("Wrong3", _taskInfo.currentImageWrong3Name) 'сделать и сохранить скрин
        End If
        If _taskInfo.isGenerationFailing = False Then
            PartRecovery() 'вернуть деталь в изначальное состояние
        End If
    End Sub

    'вспомогательная функция: поворот детали на определенный вид
    Private Sub TurnToView(ByVal viewOrientationTypeEnum As ViewOrientationTypeEnum)
        'попытка открыть вид (на экране должна быть открыта деталь или сборка)
        Dim v As View
        Try
            v = _invApp.ActiveView
        Catch ex As Exception
            MsgBox("Ошибка: в Inventor должен быть открыт хотя бы один вид")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End Try

        'вид получен 
        v.GoHome() 'установить на домашний вид
        Dim camera As Camera = v.Camera 'инициализация камеры

        'установить вид камеры: Front - спереди
        camera.ViewOrientationType = viewOrientationTypeEnum
        camera.Fit()
        camera.Apply() 'view update too
    End Sub

    'вспомогательная функция: сделать и сохранить снимок вида
    Private Sub MakeAndSaveScreenshot(ByVal description As String, ByRef currentImageName As String)
        Dim v As View = _invApp.ActiveView 'считать активный вид (сейчас должен быть доступен)

        'Динамическое получение ширины и высоты вида. Стандарт: (1024, 768), но тогда возможны поетри части изображения
        Dim width = v.Width
        Dim height = v.Height
        Dim name = description & " " & DateTime.Now.ToString("yyyy/MM/dd HH.mm.ss") & ".bmp"
        v.SaveAsBitmap(_taskInfo.savePath & "\" & name, width, height) 'старые скрины с теми же именами будут удалены!
        currentImageName = name
    End Sub

    'вспомогательная функция: Построение списка возможных вариантов изменений детали
    Private Sub BuildingPossiblePartChanges()
        Dim oPartFeatures As New List(Of PartFeature) 'список фич, с которыми идет работа

        ChangeableFeature.index = 1 'для большинства feature, изменяемый параметр стоит под первым номером в массиве

        'Если выбран вариант изменять Extrude
        If rbExtrude.Checked Then
            For Each oExtrudeFeature As ExtrudeFeature In _taskInfo.oDoc.ComponentDefinition.Features.ExtrudeFeatures
                oPartFeatures.Add(oExtrudeFeature)
            Next
        End If

        'Если выбран вариант изменять Chamfer
        If rbChamfer.Checked Then
            For Each oChamferFeature As ChamferFeature In _taskInfo.oDoc.ComponentDefinition.Features.ChamferFeatures
                oPartFeatures.Add(oChamferFeature)
            Next
        End If

        'Если выбран вариант изменять Fillet
        If rbFillet.Checked Then
            For Each oFilletFeature As FilletFeature In _taskInfo.oDoc.ComponentDefinition.Features.FilletFeatures
                oPartFeatures.Add(oFilletFeature)
            Next
        End If

        'Если выбран вариант изменять Hole
        If rbHole.Checked Then
            For Each oHoleFeature As HoleFeature In _taskInfo.oDoc.ComponentDefinition.Features.HoleFeatures
                oPartFeatures.Add(oHoleFeature)
            Next
        End If

        'Если выбран вариант изменять Shell
        If rbShell.Checked Then
            For Each oShellFeature As ShellFeature In _taskInfo.oDoc.ComponentDefinition.Features.ShellFeatures
                oPartFeatures.Add(oShellFeature)
            Next
        End If

        'Если выбран вариант изменять Emboss
        If rbEmboss.Checked Then
            For Each oEmbossFeature As EmbossFeature In _taskInfo.oDoc.ComponentDefinition.Features.EmbossFeatures
                oPartFeatures.Add(oEmbossFeature)
            Next
        End If

        'Если выбран вариант изменять Revolve
        If rbRevolve.Checked Then
            For Each oRevolveFeature As RevolveFeature In _taskInfo.oDoc.ComponentDefinition.Features.RevolveFeatures
                oPartFeatures.Add(oRevolveFeature)
            Next
        End If

        'Если выбран вариант изменять Thicken
        If rbThicken.Checked Then
            For Each oThickenFeature As ThickenFeature In _taskInfo.oDoc.ComponentDefinition.Features.ThickenFeatures
                oPartFeatures.Add(oThickenFeature)
            Next
        End If

        'Если выбран вариант изменять FaceDraft
        If rbFaceDraft.Checked Then
            'дополнительное изменение введенных параметров
            _taskInfo.minChangeValue /= 10
            _taskInfo.maxChangeValue /= 10
            _taskInfo.changeStep /= 10

            For Each oFaceDraftFeature As FaceDraftFeature In _taskInfo.oDoc.ComponentDefinition.Features.FaceDraftFeatures
                oPartFeatures.Add(oFaceDraftFeature)
            Next
        End If

        'Если выбран вариант изменять Thread
        If rbThread.Checked Then
            'для данного типа feature, изменяемый параметр стоит под вторым номером в массиве
            ChangeableFeature.index = 2

            For Each oThreadFeature As ThreadFeature In _taskInfo.oDoc.ComponentDefinition.Features.ThreadFeatures
                oPartFeatures.Add(oThreadFeature)
            Next
        End If

        'Если выбран вариант изменять CircularPattern
        If rbCircularPattern.Checked Then
            'для данного типа feature, изменяемый параметр стоит под вторым номером в массиве
            ChangeableFeature.index = 2

            For Each oCircularPatternFeature As CircularPatternFeature In _taskInfo.oDoc.ComponentDefinition.Features.CircularPatternFeatures
                oPartFeatures.Add(oCircularPatternFeature)
            Next
        End If

        'Если выбран вариант изменять RectangularPattern
        If rbRectangularPattern.Checked Then
            'для данного типа feature, изменяемый параметр стоит под вторым номером в массиве
            ChangeableFeature.index = 2

            For Each oRectangularPatternFeature As RectangularPatternFeature In _taskInfo.oDoc.ComponentDefinition.Features.RectangularPatternFeatures
                oPartFeatures.Add(oRectangularPatternFeature)
            Next
        End If

        'Если выбран вариант изменять Rib
        If rbRib.Checked Then
            For Each oRibFeature As RibFeature In _taskInfo.oDoc.ComponentDefinition.Features.RibFeatures
                oPartFeatures.Add(oRibFeature)
            Next
        End If

        'ДАЛЕЕ ОБЩИЙ КОД ДЛЯ РАЗНЫХ ТИПОВ ФИЧ
        FindChangeableFeatures(oPartFeatures)

        If _taskInfo.isGenerationFailing = True Then 'дальнейшая генерация невозможна
            Exit Sub
        End If

        'Проверить: если в коллекции фич "изменяемые фичи" ноль элементов, дальнейшая работа невозможна
        If _taskInfo.changeableFeatures.Count = 0 Then
            MsgBox("Ошибка: ни одну из features невозможно изменить.")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End If

        'теперь работаем с коллекцией "изменяемые фичи". необходимо найти все возможные варианты значений
        'параметра distance (в ограниченном диапазоне, шаг 1мм)
        'Проходим по коллекции "изменяемые фичи", работаем с каждой конкретной фичей
        For Each cf As ChangeableFeature In _taskInfo.changeableFeatures
            'Получаем нижнюю границу диапазона при вычитании: Вычитаем из поля disctance 20мм
            Dim minBottom As Double = cf.distance - _taskInfo.maxChangeValue
            'Получаем верхнюю границу диапазона при вычитании: Вычитаем из поля disctance 5мм
            Dim maxBottom As Double = cf.distance - _taskInfo.minChangeValue
            'Проходим по диапазону min-max, и все числа сохраняем в поле доступные значения
            For index As Double = minBottom To maxBottom Step _taskInfo.changeStep
                cf.availableValues.Add(index)
            Next

            'Получаем нижнюю границу диапазона при прибавлении: Прибавляем к полю disctance 5мм
            Dim minTop As Double = cf.distance + _taskInfo.minChangeValue
            'Получаем верхнюю границу диапазона при прибавлении: Прибавляем к полю disctance 20мм
            Dim maxTop As Double = cf.distance + _taskInfo.maxChangeValue
            'Проходим по диапазону min-max, и все числа сохраняем в поле доступные значения
            For index As Double = minTop To maxTop Step _taskInfo.changeStep
                cf.availableValues.Add(index)
            Next
        Next

        'у всех "изменяемых фич" надо почистить поле-коллекцию "все доступные значения" от не подходящих значений
        _taskInfo.RemoveWrongValuesFromAvailableValues()

        'теперь необходимо проверить каждый вариант доступных значений применим ли он к детали?
        'Проходим по коллекции "изменяемые фичи", работаем с каждой конкретной фичей
        For Each cf As ChangeableFeature In _taskInfo.changeableFeatures
            'Проходим по коллекции "все доступные значения", работаем с каждым конкретным значением
            For Each d As Double In cf.availableValues
                Dim isOk As Boolean 'показывает, успешно ли произошло преобразование размера в модели в inventor
                'Изменяем параметр 'distance' текущей фичи на текущее доступное значение (у детали в inventor)
                'и проверяем 1) возможно ли это изменение И 2) не стала ли хоть одна фича "подавленной" из-за изменения
                isOk = ChangeParamDistInFeatureInInventor(cf.feature, d)

                'Если условие 1 или 2 НЕ собоюдено (изменение произошло с ошибкой или фича(и) подавлена(ы))
                If isOk = False Then
                    'присвоить текущему значению (в коллекции) -1000 (оно больше не подходит)
                    d = -1000
                End If

                'Восстанавливаем параметр distance (у детали в inventor) в изначальное значение.
                ChangeParamDistInFeatureInInventor(cf.feature, cf.distance)
            Next
        Next

        'у всех "изменяемых фич" надо почистить поле-коллекцию "все доступные значения" от не подходящих значений
        _taskInfo.RemoveWrongValuesFromAvailableValues()

        'теперь в коллекции "изменяемые фичи" должны остаться только те элементы, у которых коллекция: доступные значения не пустая.
        'Проходим по коллекции "изменяемые фичи", работаем с каждой конкретной фичей
        For i As Integer = _taskInfo.changeableFeatures.Count - 1 To 0 Step -1
            'Если поле "все доступные значения" имеет ноль элементов, удалить фичу из коллекции "изменяемые фичи"
            If _taskInfo.changeableFeatures(i).availableValues.Count = 0 Then
                _taskInfo.changeableFeatures.RemoveAt(i)
                Continue For
            End If
        Next

        'Проверить: если в коллекции фич "изменяемые фичи" ноль элементов, дальнейшая работа невозможна
        If _taskInfo.changeableFeatures.Count = 0 Then
            MsgBox("Ошибка: ни одну из features невозможно изменить.")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End If
    End Sub

    'вспомогательная функция: найти изменяемые фичи (для фич выбранного пользователем типа)
    Private Sub FindChangeableFeatures(ByVal oPartFeatures As List(Of PartFeature))
        'Проверить: если в коллекции фич ноль элементов, дальнейшая работа невозможна
        If oPartFeatures.Count = 0 Then
            MsgBox("Ошибка: деталь не содержит ни одной feature выбранного типа.")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End If

        'Проходим по коллекции фич, работаем с каждой конкретной фичей
        For Each oPartFeature As PartFeature In oPartFeatures
            'для теста
            Dim str As String = oPartFeature.Name & " (Count: " & oPartFeature.FeatureDimensions.Count & ")" & vbCrLf
            For Each fd As FeatureDimension In oPartFeature.FeatureDimensions
                str &= fd.Parameter._Value.ToString & vbCrLf
            Next
            MsgBox(str)

            'необходимый параметр distance обычно стоит первым в коллекции FeatureDimensions
            Try
                Dim distance As Double = oPartFeature.FeatureDimensions(ChangeableFeature.index).Parameter._Value
                'Параметр distance не нулевой? Если да, фича изменяема. Добавить ее в пока пустую коллекцию "изменяемые фичи"
                If distance <> 0 Then
                    _taskInfo.changeableFeatures.Add(New ChangeableFeature(oPartFeature, distance))
                End If
            Catch
                MsgBox("Ошибка: невозможно получить значение изменяемого параметра для данной feature")
                _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
                Exit Sub
            End Try
        Next
    End Sub

    'вспомогательная функция: изменение параметров детали
    Private Sub PartChange()
        'Dim del_string As String = ""

        'выбор фичи, у которой будем менять параметр, и выбор значения этого параметра
        'случайно выбираем номер фичи из коллекции "изменяемые фичи"
        Dim numOfFeature As Integer = GetRandom(0, _taskInfo.changeableFeatures.Count) 'здесь не нужно вычитать 1, random не включает верхнее значение
        _taskInfo.selectedFeature = _taskInfo.changeableFeatures(numOfFeature)

        'del_string &= "выбрана фича: " & _taskInfo.selectedFeature.feature.Name & vbCrLf &
        '    "со значением: " & _taskInfo.selectedFeature.distance & vbCrLf &
        '   " //а по _Value: " & _taskInfo.selectedFeature.feature.FeatureDimensions(1).Parameter._Value & vbCrLf

        'Случайно выбираем номер варианта из поля "все доступные значения" выбранной фичи
        Dim numOfValue As Integer = GetRandom(0, _taskInfo.selectedFeature.availableValues.Count)
        Dim selectedValue As Double = _taskInfo.selectedFeature.availableValues(numOfValue)

        'del_string &= "выбрано новое значение: " & selectedValue & vbCrLf

        'Изменяем параметр 'distance' выбранной фичи на выбранное значение (у детали в inventor).
        ChangeParamDistInFeatureInInventor(_taskInfo.selectedFeature.feature, selectedValue)

        'del_string &= "после применения нового значение, значение стало: " & _taskInfo.selectedFeature.feature.FeatureDimensions(1).Parameter._Value
        'MsgBox(del_string)
    End Sub

    'вспомогательная функция: восстановление детали в изначальное состояние
    Private Sub PartRecovery()
        'Восстанавливаем параметр distance (у детали в inventor) в изначальное значение.
        ChangeParamDistInFeatureInInventor(_taskInfo.selectedFeature.feature, _taskInfo.selectedFeature.distance)
    End Sub

    'вспомогательная функция: размещение на форме изображений вариантов Front и Top
    Private Sub PlacingStaticVariants()
        Dim Front As Image
        Dim Top As Image

        Try
            Front = Image.FromFile(_taskInfo.savePath & "\" & _taskInfo.currentImageFrontName)
            Top = Image.FromFile(_taskInfo.savePath & "\" & _taskInfo.currentImageTopName)
        Catch ex As Exception
            MsgBox("Ошибка: не удалось найти изображения видов детали (для дано)")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End Try

        'размещение на форме
        pbFront.Image = Front
        pbTop.Image = Top
    End Sub

    'вспомогательная функция: размещение на форме изображений варианта Correct и трех неправильных вариантов
    Private Sub PlacingDynamicVariants()
        Dim Correct As Image
        Dim Wrong1 As Image
        Dim Wrong2 As Image
        Dim Wrong3 As Image

        Try
            Correct = Image.FromFile(_taskInfo.savePath & "\" & _taskInfo.currentImageCorrectName)
            Wrong1 = Image.FromFile(_taskInfo.savePath & "\" & _taskInfo.currentImageWrong1Name)
            Wrong2 = Image.FromFile(_taskInfo.savePath & "\" & _taskInfo.currentImageWrong2Name)
            Wrong3 = Image.FromFile(_taskInfo.savePath & "\" & _taskInfo.currentImageWrong3Name)
        Catch ex As Exception
            MsgBox("Ошибка: не удалось найти изображения видов детали (для вариантов ответа)")
            _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
            Exit Sub
        End Try

        'pbVariant1.Image = Correct
        'pbVariant2.Image = Wrong1
        'pbVariant3.Image = Wrong2
        'pbVariant4.Image = Wrong3

        Dim numbers As New List(Of Integer) 'лист с числам номерами возможных вариантов размещения
        numbers.Add(1)
        numbers.Add(2)
        numbers.Add(3)
        numbers.Add(4) 'номеров возможных вариантов размещения четыре

        'выбираем номер правильного ответа (Correct)
        Dim r As Integer = GetRandom(0, numbers.Count) '0-3
        _taskInfo.placeOfRightAnswer = numbers(r) '1-4
        numbers.RemoveAt(r) 'удалить выбранный номер

        'выбираем номер для Wrong1
        r = GetRandom(0, numbers.Count)
        Dim placeOfWrong1 = numbers(r)
        numbers.RemoveAt(r) 'удалить выбранный номер

        'выбираем номер для Wrong2
        r = GetRandom(0, numbers.Count)
        Dim placeOfWrong2 = numbers(r)
        numbers.RemoveAt(r) 'удалить выбранный номер

        'выбираем номер для Wrong3
        r = GetRandom(0, numbers.Count)
        Dim placeOfWrong3 = numbers(r)
        numbers.RemoveAt(r) 'удалить выбранный номер

        'размещение на форме Correct
        Select Case _taskInfo.placeOfRightAnswer
            Case 1
                pbVariant1.Image = Correct
            Case 2
                pbVariant2.Image = Correct
            Case 3
                pbVariant3.Image = Correct
            Case 4
                pbVariant4.Image = Correct
            Case Else
                MsgBox("Ошибка: не удалось разместить правильный ответ")
                _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
                Exit Sub
        End Select

        'размещение на форме Wrong1
        Select Case placeOfWrong1
            Case 1
                pbVariant1.Image = Wrong1
            Case 2
                pbVariant2.Image = Wrong1
            Case 3
                pbVariant3.Image = Wrong1
            Case 4
                pbVariant4.Image = Wrong1
            Case Else
                MsgBox("Ошибка: не удалось разместить правильный ответ")
                _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
                Exit Sub
        End Select

        'размещение на форме Wrong2
        Select Case placeOfWrong2
            Case 1
                pbVariant1.Image = Wrong2
            Case 2
                pbVariant2.Image = Wrong2
            Case 3
                pbVariant3.Image = Wrong2
            Case 4
                pbVariant4.Image = Wrong2
            Case Else
                MsgBox("Ошибка: не удалось разместить правильный ответ")
                _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
                Exit Sub
        End Select

        'размещение на форме Wrong3
        Select Case placeOfWrong3
            Case 1
                pbVariant1.Image = Wrong3
            Case 2
                pbVariant2.Image = Wrong3
            Case 3
                pbVariant3.Image = Wrong3
            Case 4
                pbVariant4.Image = Wrong3
            Case Else
                MsgBox("Ошибка: не удалось разместить правильный ответ")
                _taskInfo.isGenerationFailing = True 'дальнейшая генерация невозможна
                Exit Sub
        End Select
    End Sub

    'пользователем выбран вариант ответа 1
    Private Sub pbVariant1_Click(sender As Object, e As EventArgs) Handles pbVariant1.Click
        If _taskInfo.isReady = True Then
            CheckAnswer(1)
        End If
    End Sub

    'пользователем выбран вариант ответа 2
    Private Sub pbVariant2_Click(sender As Object, e As EventArgs) Handles pbVariant2.Click
        If _taskInfo.isReady = True Then
            CheckAnswer(2)
        End If
    End Sub

    'пользователем выбран вариант ответа 3
    Private Sub pbVariant3_Click(sender As Object, e As EventArgs) Handles pbVariant3.Click
        If _taskInfo.isReady = True Then
            CheckAnswer(3)
        End If
    End Sub

    'пользователем выбран вариант ответа 4
    Private Sub pbVariant4_Click(sender As Object, e As EventArgs) Handles pbVariant4.Click
        If _taskInfo.isReady = True Then
            CheckAnswer(4)
        End If
    End Sub

    'проверка: правильный ли дан ответ
    Private Sub CheckAnswer(ByVal answer As Integer)
        If answer = _taskInfo.placeOfRightAnswer Then
            MsgBox("Ответ правильный")
        Else
            MsgBox("Ответ неправильный")
        End If
    End Sub

    'произошло изменение значение в combo box "сторона правильного вида"
    Private Sub cbView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbView.SelectedIndexChanged
        lblView.Text = cbView.Text
    End Sub

    'вспомогательная функция: иземенить параметр ExtrudeFeature в модели в инвентор на указанный 
    'определить: 1-удается ли сделать это преобразование в инвентор?
    ' 2-изменился ли параметр "подавлено" у какой либо фичи (не только Extrude) в инвенторе на положительный?
    Private Function ChangeParamDistInFeatureInInventor(ByVal feature As PartFeature, ByVal newDistance As Double)
        '1-удается ли сделать это преобразование в инвентор?
        Try
            feature.FeatureDimensions(ChangeableFeature.index).Parameter._Value = newDistance
            _taskInfo.oDoc.Update()
        Catch ex As Exception
            Return False
        End Try

        '2-изменился ли параметр "подавлено" у какой либо фичи (вообще, любого типа) в инвенторе на положительный?
        Dim oPartFeatures As PartFeatures = _taskInfo.oDoc.ComponentDefinition.Features 'получить вообще все features
        For Each partFeature As PartFeature In oPartFeatures
            If partFeature.Suppressed = True Then
                Return False
            End If
        Next

        '3-ошибок нет
        Return True
    End Function

    'вспомогательная функция: random. Мin - включительно, Max - НЕ включительно.
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

    'при закрытии формы, программа попытается удалить старые изображения из папки Screens (иначе со временем снимков может скопиться очень много)
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        For Each deleteFile In Directory.GetFiles(_taskInfo.savePath, "*.bmp", SearchOption.TopDirectoryOnly)
            Try
                IO.File.Delete(deleteFile)
            Catch ex As Exception
                Continue For
            End Try
        Next
    End Sub

    'ФУНКЦИИ ВЕРХНЕГО МЕНЮ
    'Скрыть/показать верхнюю панель - настройки
    Private Sub ShowHideOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowHideOptionsToolStripMenuItem.Click
        PanelTop.Visible = Not PanelTop.Visible
    End Sub

    'Сгенерировать новое задание
    Private Sub RunToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RunToolStripMenuItem.Click
        Run()
    End Sub

    'Экспорт задания в PDF
    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        If _taskInfo.isReady = True Then
            PanelTop.Visible = False 'убрать панель настроек с экрана (если есть)

            'Screen of form
            Dim frm = Form.ActiveForm
            Dim bmp As Bitmap = New Bitmap(frm.Width, frm.Height)
            frm.DrawToBitmap(bmp, New Rectangle(0, 0, bmp.Width, bmp.Height))
            'bmp.Save("C:\Users\Сергей\Desktop\test.bmp")
            'дополнительно: установить разрешение для изменения размера формы (если не умещается в pdf)
            bmp.SetResolution(bmp.Width * 0.12, bmp.Height * 0.12) 'чем больше множители, тем меньше изображение

            'To pdf
            Dim doc As New PdfDocument()
            Dim oPage As New PdfPage()
            'отступы в pdf, также помогают уместить изображение
            oPage.TrimMargins.Left = 20
            oPage.TrimMargins.Top = 30
            oPage.TrimMargins.Right = 20
            doc.Pages.Add(oPage)
            Dim xgr As XGraphics = XGraphics.FromPdfPage(oPage)
            Dim strm As MemoryStream = New MemoryStream()
            bmp.Save(strm, System.Drawing.Imaging.ImageFormat.Png)
            Dim xfoto As XImage = XImage.FromStream(strm)
            xgr.DrawImage(xfoto, 0, 0)
            Dim savefiledialog1 As New SaveFileDialog
            savefiledialog1.FileName = "Task " & DateTime.Now.ToString("yyyy/MM/dd HH.mm.ss")
            savefiledialog1.Filter = ("PDF File|*.pdf")
            If savefiledialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                doc.Save(savefiledialog1.FileName)
                doc.Close()
            End If
            xfoto.Dispose()
        Else
            MsgBox("Сначала необходимо сгенерировать задание")
        End If
    End Sub

    'Выход - Закрыть форму
    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    'Показать инструкции
    Private Sub InstructionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstructionsToolStripMenuItem.Click
        Dim text As String = "1. Откройте в Inventor деталь, для которой будет генерироваться задание" & vbCrLf &
            "2. При необходимости выберите нужные настройки (включить отображение настроек можно через меню)" & vbCrLf &
            "3. Сгенерируйте задание" & vbCrLf &
            "4. Экспортируйте задание"
        MsgBox(text, vbOKOnly + vbInformation, "Инструкции")
    End Sub

End Class
