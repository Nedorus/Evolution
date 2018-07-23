﻿Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Evolution
Imports System.ComponentModel

<TestClass()> Public Class BindableBaseTest

    <TestMethod()> Public Sub RaiseEventTest()
        'Arrange
        Dim subject As New TestBindableBaseExtension()
        Dim observer As New ParentWithListener(subject)

        Dim expectedResult As String = "SomeField"

        'Akt
        subject.SomeField = "newVal"

        'Assert
        Assert.AreEqual(expectedResult, observer.EventRaised)


    End Sub

    Private Class TestBindableBaseExtension
        Inherits BindableBase

        Private _someField As String

        Public Property SomeField As String
            Get
                Return _someField
            End Get
            Set(value As String)
                MyBase.SetProperty(Of String)(_someField, value, "SomeField")
            End Set
        End Property

    End Class

    Private Class ParentWithListener
        Private _subject As TestBindableBaseExtension
        Private _eventRaised As String

        Public Sub New(ByRef subject As TestBindableBaseExtension)
            _subject = subject
            AddHandler _subject.PropertyChanged, AddressOf HandleEventRaised
            _eventRaised = ""
        End Sub

        Public Property EventRaised As String
            Get
                Return _eventRaised
            End Get
            Set(value As String)
                _eventRaised = value
            End Set
        End Property

        Private Sub HandleEventRaised(ByVal sender As System.Object, ByVal e As PropertyChangedEventArgs)
            _eventRaised = e.PropertyName
        End Sub

    End Class
End Class