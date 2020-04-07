'Класс с дополнительной техничсекой информацией по текущей задаче
Imports System
Imports System.Type
Imports System.Activator
Imports System.Runtime.InteropServices
Imports Inventor
Imports System.IO
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class TaskInfo
    Public isReady As Boolean = False 'готова ли задача? (по умолчанию - нет)
    Public placeOfRightAnswer As String = -1 'номер правильного ответа (от 1 до 4)
    Public savePath As String = IO.Path.Combine(Directory.GetCurrentDirectory(), "Screens") 'расположение папки со скринами
    Public isGenerationFailing As Boolean = False 'произошла ли ошибка при генерации задачи?
    Public oDoc As PartDocument = Nothing 'текущий документ детали, для которого генерируется задача
    Public changeableFeatures As New List(Of ChangeableFeature) 'коллекция "изменяемые фичи"
    Public selectedFeature As ChangeableFeature = Nothing 'выбранная для применения изменений фича

    'имена изображений, используемых в текущей генерируемой задаче
    Public currentImageFrontName As String = ""
    Public currentImageTopName As String = ""
    Public currentImageLeftName As String = ""
    Public currentImageWrong1Name As String = ""
    Public currentImageWrong2Name As String = ""
    Public currentImageWrong3Name As String = ""

    'параметры минимального/максимального изменения параметра feature и шаг изменений
    'пример: min: 5мм, max: 20mm, change: 1mm. Значит все рассматриваемые новые варианты значений параметра будут в
    'диапазоне: [parametr-20; paramter-5][parametr+5; parametr+20] и шаг в этом диапазоне будет 1мм (ожидается ~30 вариантов)
    'делить на 10 необходимо, так как Inventor работает с сантиметрами (а на форме вводятся миллиметры)
    Public minChangeValue As Double = 0
    Public maxChangeValue As Double = 0
    Public changeStep As Double = 0

    'вернуть все поля класса (кроме savePath) в изначальное состояние. Также очистить PictureBox-es
    Public Sub Restart()
        isReady = False
        placeOfRightAnswer = -1
        isGenerationFailing = False
        oDoc = Nothing
        changeableFeatures.Clear()
        selectedFeature = Nothing

        currentImageFrontName = ""
        currentImageTopName = ""
        currentImageLeftName = ""
        currentImageWrong1Name = ""
        currentImageWrong2Name = ""
        currentImageWrong3Name = ""

        Form1.pbFront.Image = Nothing
        Form1.pbFront.Refresh()
        Form1.pbTop.Image = Nothing
        Form1.pbTop.Refresh()
        Form1.pbVariant1.Image = Nothing
        Form1.pbVariant1.Refresh()
        Form1.pbVariant2.Image = Nothing
        Form1.pbVariant2.Refresh()
        Form1.pbVariant3.Image = Nothing
        Form1.pbVariant3.Refresh()
        Form1.pbVariant4.Image = Nothing
        Form1.pbVariant4.Refresh()

        minChangeValue = (Form1.nudMinChangeValue.Value / 10)
        maxChangeValue = (Form1.nudMaxChangeValue.Value / 10)
        changeStep = (Form1.nudChangeStep.Value / 10)
    End Sub
End Class
