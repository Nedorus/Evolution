Imports System.Text
Imports Evolution
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

<TestClass()> Public Class DynamicCreatureTest

    <TestMethod()> Public Sub ConstructorTest()
        'Arrange
        Dim mockedCreatureDataDefinition As Mock(Of ICreatureDataDefinitions) = New Mock(Of ICreatureDataDefinitions)
        mockedCreatureDataDefinition.Setup(Function(x) x.CreatureDataDefinition()).Returns(Function() New List(Of String)(New String() {"one", "two", "three"}))
        Dim dynamicCreature = New DynamicCreature(mockedCreatureDataDefinition.Object)

        'Act


        'Assert
        Assert.AreEqual(3, dynamicCreature.Count)
        Assert.AreEqual(0, dynamicCreature("one"))
        Assert.AreEqual(0, dynamicCreature("two"))
        Assert.AreEqual(0, dynamicCreature("three"))


    End Sub

End Class