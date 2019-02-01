Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports Evolution
Imports Evolution.ModifierAddress

<TestClass()> Public Class ModifierAddressAbsoluteTest

    <TestMethod()> Public Sub ReferenceTypeTest()
        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddAbs As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Absolute)

        Dim expected As IModifierAddress.ReferenceTypeValue = IModifierAddress.ReferenceTypeValue.Absolute

        'Act

        'Assert
        Assert.AreEqual(expected, modAddAbs.ReferenceType)


    End Sub

    <TestMethod()> Public Sub SetValueByReferenceTypeTest()
        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddAbs As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Absolute)
        modAddAbs.ReferenceInteger = 47
        modAddAbs.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Carbon
        Dim creature As New Creature()


        'Act
        modAddAbs.SetValueByReferenceType(creature, 50)

        'Assert
        For Each creatureDataName In [Enum].GetNames(GetType(ICreatureDataDefinitions.CreatureData))
            Dim creatureData As ICreatureDataDefinitions.CreatureData = DirectCast([Enum].Parse(GetType(ICreatureDataDefinitions.CreatureData), creatureDataName), ICreatureDataDefinitions.CreatureData)

            If creatureData <> ICreatureDataDefinitions.CreatureData.GeneCode Then
                Assert.AreEqual(0, creature(creatureData), String.Format("Checked: {0}", creatureDataName))
            End If
        Next
        For index = 0 To creature.Gene.Count - 1
            Assert.AreEqual(0, creature.Gene(index), String.Format("Checked index: {0}", index))
        Next

    End Sub

    <TestMethod()> Public Sub GetValueByReferenceTypeTest()

        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddAbs As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Absolute)
        modAddAbs.ReferenceInteger = 47
        modAddAbs.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Carbon
        Dim creature As New Creature()
        Dim expected As Integer = 47
        Dim actual As Integer = 0

        'Act
        actual = modAddAbs.GetValueByReferenceType(creature)

        'Assert
        Assert.AreEqual(expected, actual)

    End Sub

End Class