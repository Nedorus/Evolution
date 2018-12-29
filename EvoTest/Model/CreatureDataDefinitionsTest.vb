Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Evolution
Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers
Imports System.Xml

<TestClass()> Public Class CreatureDataDefinitionsTest

    Dim xmlTestDataProvider As XMLTestDataProvider = New XMLTestDataProvider()

    <TestMethod()>
    Public Sub CreateCreatureDataDefTest()
        'Arrange
        Dim creatureDataDefinitions As New CreatureDataDefinitions
        Dim expectedCreatureDataCount As Integer = 6
        Dim expectedChangeOperatorCount As Integer = 3
        'Akt

        'Assert
        Assert.IsTrue(creatureDataDefinitions.GetCreatureDataDefinition().Contains(ICreatureDataDefinitions.CreatureData.GeneCounter))
        Assert.IsTrue(creatureDataDefinitions.GetCreatureDataDefinition().Contains(ICreatureDataDefinitions.CreatureData.GeneCode))
        Assert.IsTrue(creatureDataDefinitions.GetCreatureDataDefinition().Contains(ICreatureDataDefinitions.CreatureData.Undefined))
        Assert.AreEqual(expectedChangeOperatorCount, creatureDataDefinitions.GetModifierOperators().Count, String.Format("ChangeOperations should be {0} but was {1}.", expectedChangeOperatorCount, creatureDataDefinitions.GetModifierOperators().Count))

    End Sub


End Class