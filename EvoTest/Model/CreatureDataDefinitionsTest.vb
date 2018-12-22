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
        Assert.AreEqual(expectedCreatureDataCount, creatureDataDefinitions.GetCreatureDataDefinition().Count, String.Format("CreatureData should be {0} but was {1}.", expectedCreatureDataCount, creatureDataDefinitions.GetCreatureDataDefinition().Count))
        Assert.AreEqual(expectedChangeOperatorCount, creatureDataDefinitions.GetChangeOperations().Count, String.Format("ChangeOperations should be {0} but was {1}.", expectedChangeOperatorCount, creatureDataDefinitions.GetChangeOperations().Count))

    End Sub


End Class