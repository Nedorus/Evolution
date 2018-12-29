Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO.Abstractions.TestingHelpers
Imports Evolution
Imports System.IO.Abstractions
Imports Moq

<TestClass()> Public Class CreatureTest

    <TestMethod()> Public Sub CreatureSetupTest()
        'Arrange
        Dim creature As New Creature()
        Dim creatureData As Integer() = System.Enum.GetValues(GetType(ICreatureDataDefinitions.CreatureData))
        Dim expectedLength As Integer = creatureData.Length - 2 'GeneCode and Undefined should not be there!

        'Act
        creature(ICreatureDataDefinitions.CreatureData.GeneCounter) = 2
        creature(ICreatureDataDefinitions.CreatureData.Sunlight) = 3
        creature.Gene(0) = 5
        creature.Gene(1) = 7

        'Assert
        'Undefined
        Assert.IsFalse(creature.ContainsKey(ICreatureDataDefinitions.CreatureData.Undefined))
        'GeneCode
        Assert.IsFalse(creature.ContainsKey(ICreatureDataDefinitions.CreatureData.GeneCode))
        'GeneCounter
        Assert.IsTrue(creature.ContainsKey(ICreatureDataDefinitions.CreatureData.GeneCounter))
        'Sunlight
        Assert.IsTrue(creature.ContainsKey(ICreatureDataDefinitions.CreatureData.Sunlight))
        'XPosition
        Assert.IsTrue(creature.ContainsKey(ICreatureDataDefinitions.CreatureData.XPosition))
        'YPosition
        Assert.IsTrue(creature.ContainsKey(ICreatureDataDefinitions.CreatureData.YPosition))
        Assert.AreEqual(expectedLength, creature.Count)
        Assert.AreEqual(2, creature(ICreatureDataDefinitions.CreatureData.GeneCounter))
        Assert.AreEqual(3, creature(ICreatureDataDefinitions.CreatureData.Sunlight))
        Assert.AreEqual(5, creature.Gene(0))
        Assert.AreEqual(7, creature.Gene(1))

    End Sub

    <TestMethod()> Public Sub CreatureInitializeWithGeneTest()
        'Arrange
        Dim gene As New Gene(5)
        gene(0) = 2
        gene(1) = 3
        gene(2) = 5
        gene(3) = 7
        gene(4) = 11

        'Act
        Dim creature As New Creature(gene)

        'Assert
        Assert.AreEqual(gene, creature.Gene)

    End Sub


End Class