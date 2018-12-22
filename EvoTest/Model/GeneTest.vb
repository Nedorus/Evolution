Imports System.Text
Imports Evolution
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class GeneTest

    <TestMethod()> Public Sub StartingSizeOKTest()
        'Arrange
        Dim gene As New Gene(256)

        'Act
        'nothing to do

        'Assert
        Assert.AreEqual(256, gene.Capacity)

    End Sub

    <TestMethod()>
    Public Sub TryToAddElementTest()
        'Arrange
        Dim geneSize As Integer = 255
        Dim geneValueToAdd As Integer = 42
        Dim gene As New Gene(geneSize)

        'Act
        Dim ex As InvalidOperationException = Assert.ThrowsException(Of InvalidOperationException)(Sub() gene.Add(geneValueToAdd))

        'Assert
        Assert.AreEqual(String.Format("Gene cannot hold more than {0} items", geneSize), ex.Message)

    End Sub

    <TestMethod()> Public Sub CapacityIncreaseTest()
        'Arrange
        Dim oldCapacity As Integer = 100
        Dim newCapacity As Integer = 110
        Dim gene As New Gene(oldCapacity)

        'Act
        gene.Capacity = newCapacity

        'Assert
        Assert.AreEqual(newCapacity, gene.Capacity)
        Assert.AreEqual(0, gene(oldCapacity + 1))
        Assert.AreEqual(0, gene(newCapacity - 1))

    End Sub

    <TestMethod()> Public Sub CapacityIncreaseNegativeValueTest()
        'Arrange
        Dim oldCapacity As Integer = 100
        Dim newCapacity As Integer = -110
        Dim gene As New Gene(oldCapacity)

        'Act
        gene.Capacity = newCapacity

        'Assert
        Assert.AreEqual(Math.Abs(newCapacity), gene.Capacity)
        Assert.AreEqual(0, gene(oldCapacity + 1))
        Assert.AreEqual(0, gene(Math.Abs(newCapacity) - 1))

    End Sub

    <TestMethod()> Public Sub CapacityDecreaseTest()
        'Arrange
        Dim oldCapacity As Integer = 100
        Dim newCapacity As Integer = 90
        Dim gene As New Gene(oldCapacity)
        Dim oldValueAtNewLimit As Integer = 42
        gene(newCapacity - 1) = oldValueAtNewLimit

        'Act
        gene.Capacity = newCapacity

        'Assert
        Assert.AreEqual(newCapacity, gene.Capacity)
        Assert.AreEqual(42, gene(newCapacity - 1))

    End Sub

    <TestMethod()> Public Sub DecreaseCapacityNegativeValue()
        'Arrange
        Dim oldCapacity As Integer = 100
        Dim newCapacity As Integer = -90
        Dim gene As New Gene(oldCapacity)
        Dim oldValueAtNewLimit As Integer = 42
        'This should calculate to 89
        gene(Math.Abs(newCapacity) - 1) = oldValueAtNewLimit

        'Act
        gene.Capacity = newCapacity

        'Assert
        Assert.AreEqual(Math.Abs(newCapacity), gene.Capacity)
        Assert.AreEqual(42, gene(Math.Abs(newCapacity) - 1))

    End Sub

End Class