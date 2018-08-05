Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Evolution
Imports System.ComponentModel
Imports System.Diagnostics.CodeAnalysis

<TestClass()> Public Class BindableBaseTest

    <TestMethod()> Public Sub RaiseEventTest()
        'Arrange
        Const UNCHANGED_VALUE As String = "nothing happened"
        Dim subject As New TestBindableBaseExtension()
        Dim observer As New ParentWithListener(subject)

        Dim expectedResult As String = "SomeField"

        'Akt
        observer.EventRaised = UNCHANGED_VALUE
        subject.SomeField = "newVal"
        Dim actualResult As String = observer.EventRaised
        'Assert
        Assert.AreEqual("newVal", subject.SomeField)
        Assert.AreEqual(expectedResult, actualResult)
    End Sub

    <TestMethod()> Public Sub RaiseEventNoChangeTest()
        'Arrange
        Const UNCHANGED_VALUE As String = "nothing happened"
        Dim subject As New TestBindableBaseExtension()
        Dim observer As New ParentWithListener(subject)

        Dim expectedResult As String = UNCHANGED_VALUE

        'Akt
        subject.SomeField = "newVal"
        observer.EventRaised = UNCHANGED_VALUE
        subject.SomeField = "newVal"

        Dim actualResult As String = observer.EventRaised

        'Assert
        Assert.AreEqual("newVal", subject.SomeField)
        Assert.AreEqual(expectedResult, actualResult)
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