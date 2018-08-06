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

    <TestMethod()>
    Public Sub ItemChangedTestTest()
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
        Assert.AreEqual("Neu", colUnderTest.Item(0).First)
        Assert.IsFalse(itemChanged)
        Assert.IsTrue(colchanged)
        itemChanged = False
        colchanged = False

    End Sub

    <TestMethod()>
    Public Sub CollectionChangedAddItemTest()
        'Arrange
        Dim colUnderTest As ItemsChangedObservableCollection(Of TwoProperties) = New ItemsChangedObservableCollection(Of TwoProperties)()
        AddHandler colUnderTest.CollectionChanged, AddressOf HasCollectionChanged
        colUnderTest.Add(New TwoProperties)
        colUnderTest.Item(0).First = "Hallo"
        colUnderTest.Item(0).Second = 1
        colchanged = False
        itemChanged = False

        'Akt
        colUnderTest.Add(New TwoProperties)

        'Assert
        Assert.AreEqual(2, colUnderTest.Count)
        Assert.IsFalse(itemChanged)
        Assert.IsTrue(colchanged)
        colchanged = False
        itemChanged = False
    End Sub

    <TestMethod()>
    Public Sub CollectionChangedAddNothingItemTest()
        'Arrange
        Dim colUnderTest As ItemsChangedObservableCollection(Of TwoProperties) = New ItemsChangedObservableCollection(Of TwoProperties)()
        AddHandler colUnderTest.CollectionChanged, AddressOf HasCollectionChanged
        colUnderTest.Add(New TwoProperties)
        colUnderTest.Item(0).First = "Hallo"
        colUnderTest.Item(0).Second = 1
        colchanged = False
        itemChanged = False

        'Akt
        colUnderTest.Add(Nothing)

        'Assert
        Assert.AreEqual(2, colUnderTest.Count)
        Assert.IsFalse(itemChanged)
        Assert.IsTrue(colchanged)
        colchanged = False
        itemChanged = False

    End Sub

    <TestMethod()>
    Public Sub CollectionChangedRemoveItemTest()
        'Arrange
        Dim colUnderTest As ItemsChangedObservableCollection(Of TwoProperties) = New ItemsChangedObservableCollection(Of TwoProperties)()
        AddHandler colUnderTest.CollectionChanged, AddressOf HasCollectionChanged
        colUnderTest.Add(New TwoProperties)
        colUnderTest.Add(New TwoProperties)
        colUnderTest.Item(0).First = "Hallo"
        colUnderTest.Item(0).Second = 1
        colUnderTest.Item(1).First = "Welt"
        colUnderTest.Item(1).Second = 2
        colchanged = False
        itemChanged = False

        'Akt
        colUnderTest.RemoveAt(0)

        'Assert
        Assert.AreEqual(1, colUnderTest.Count)
        Assert.AreEqual("Welt", colUnderTest.Item(0).First)
        Assert.IsFalse(itemChanged)
        Assert.IsTrue(colchanged)
        colchanged = False
        itemChanged = False

    End Sub

    <TestMethod()>
    Public Sub CollectionChangedReplaceItemTest()
        'Arrange
        Dim colUnderTest As ItemsChangedObservableCollection(Of TwoProperties) = New ItemsChangedObservableCollection(Of TwoProperties)()
        AddHandler colUnderTest.CollectionChanged, AddressOf HasCollectionChanged
        colUnderTest.Add(New TwoProperties)
        colUnderTest.Add(New TwoProperties)
        colUnderTest.Item(0).First = "Hallo"
        colUnderTest.Item(0).Second = 1
        colUnderTest.Item(1).First = "Welt"
        colUnderTest.Item(1).Second = 2
        colchanged = False
        itemChanged = False

        'Akt
        Dim newTwoProps As New TwoProperties
        newTwoProps.First = "What"
        newTwoProps.Second = 3
        colUnderTest.Item(0) = newTwoProps

        'Assert
        Assert.AreEqual(2, colUnderTest.Count)
        Assert.AreEqual("What", colUnderTest.Item(0).First)
        Assert.IsFalse(itemChanged)
        Assert.IsTrue(colchanged)
        colchanged = False
        itemChanged = False
    End Sub

    <TestMethod()>
    Public Sub CollectionChangedItemMovedTest()
        'Arrange
        Dim colUnderTest As ItemsChangedObservableCollection(Of TwoProperties) = New ItemsChangedObservableCollection(Of TwoProperties)()
        AddHandler colUnderTest.CollectionChanged, AddressOf HasCollectionChanged
        colUnderTest.Add(New TwoProperties)
        colUnderTest.Add(New TwoProperties)
        colUnderTest.Add(New TwoProperties)
        colUnderTest.Item(0).First = "Hallo"
        colUnderTest.Item(0).Second = 1
        colUnderTest.Item(1).First = "Welt"
        colUnderTest.Item(1).Second = 2
        colchanged = False
        itemChanged = False

        'Akt
        colUnderTest.Move(0, 1)

        'Assert
        Assert.AreEqual("Hallo", colUnderTest.Item(1).First)
        Assert.AreEqual("Welt", colUnderTest.Item(0).First)
        Assert.IsFalse(itemChanged)
        Assert.IsTrue(colchanged)
        colchanged = False
        itemChanged = False
    End Sub

    <ExcludeFromCodeCoverage()>
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