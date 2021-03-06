﻿Imports System
Imports System.Type
Imports System.Activator
Imports System.Runtime.InteropServices
Imports Inventor
Imports System.IO
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class ChangeableFeature
    Public feature As PartFeature = Nothing 'фича
    Public distance As Double = 0 'эталонное значение параметра distance
    Public availableValues As New List(Of Double) 'коллекция (числа, в мм): все доступные значения. Изначально пустая.

    'статическое поле, доступно через класс, а не объект (пример: ChangeableFeature.index) 
    'это поле означает номер индекс в массиве oPartFeature.FeatureDimensions(1).Parameter._Value
    'для большинства feature это 1 (первый номер, с массивах Inventor нумерация начинается с 1), но есть исключения
    Public Shared index As Integer = 1

    'конструктор
    Public Sub New(ByVal Feature As PartFeature, ByVal Distance As Double)
        Me.feature = Feature
        Me.distance = Distance
    End Sub

    Public Sub PrintAll()
        Dim str As String = ""
        str &= "feature name: " & feature.Name & vbCrLf
        str &= "distance: " & distance & vbCrLf
        str &= "available values count: " & availableValues.Count & vbCrLf
        str &= "available values: " & vbCrLf

        For d As Double = 0 To availableValues.Count - 1
            str &= (d + 1) & ") " & availableValues(d) & vbCrLf
        Next

        MsgBox(str)
    End Sub

    'For Each cf As ChangeableFeature In changeableFeatures
    '    cf.PrintAll()
    'Next
End Class
