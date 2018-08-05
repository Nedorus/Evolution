Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers
Imports System.Diagnostics.CodeAnalysis
Imports Evolution
Imports System.ComponentModel
Imports System.Collections.Specialized

<TestClass()> Public Class ItemsChangedObservableCollectionTest
    Private colchanged As Boolean = False
    Private itemChanged As Boolean = False

    <TestMethod()> Public Sub OnCollectionChangedTest()
        'Arrange
        Dim colUnderTest As ItemsChangedObservableCollection(Of TwoProperties) = New ItemsChangedObservableCollection(Of TwoProperties)()
        AddHandler colUnderTest.CollectionChanged, AddressOf HasCollectionChanged
        colUnderTest.Add(New TwoProperties)
        colUnderTest.Item(0).First = "Hallo"
        colUnderTest.Item(0).Second = 1
        colchanged = False
        itemChanged = False

        'Akt
        colUnderTest.Item(0).First = "Neu"

        'Assert
        Assert.IsTrue(itemChanged)
        Assert.IsFalse(colchanged)
        itemChanged = False
        colchanged = False

        'Akt
        colUnderTest.Add(New TwoProperties())

        'Assert
        Assert.IsTrue(colchanged)
        Assert.IsFalse(itemChanged)
        itemChanged = False
        colchanged = False

    End Sub

    Private Sub HasCollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If TypeOf sender Is TwoProperties Then
            itemChanged = True
        ElseIf TypeOf sender Is ItemsChangedObservableCollection(Of TwoProperties) Then
            colchanged = True
        Else
            Assert.Fail()
        End If
    End Sub

    <ExcludeFromCodeCoverage()>
    Class TwoProperties
        Inherits BindableBase

        Private _first As String = ""
        Private _second As Integer = 0

        Friend Sub New()

        End Sub

        Public Property First As String
            Get
                Return _first
            End Get
            Set(value As String)
                MyBase.SetProperty(Of String)(_first, value, "First")
            End Set
        End Property

        Public Property Second As Integer
            Get
                Return _second
            End Get
            Set(value As Integer)
                MyBase.SetProperty(Of Integer)(_second, value, "Second")
            End Set
        End Property
    End Class
End Class