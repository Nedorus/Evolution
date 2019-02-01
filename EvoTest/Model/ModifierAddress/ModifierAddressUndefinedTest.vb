Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports Evolution
Imports Evolution.ModifierAddress

<TestClass()> Public Class ModifierAddressUndefinedTest

    <TestMethod()> Public Sub ReferenceTypeTest()
        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddUndef As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Undefined)

        Dim expected As IModifierAddress.ReferenceTypeValue = IModifierAddress.ReferenceTypeValue.Undefined

        'Act

        'Assert
        Assert.AreEqual(expected, modAddUndef.ReferenceType)


    End Sub

    <TestMethod()> Public Sub SetValueByReferenceTypeTest()
        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddUndef As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Undefined)
        modAddUndef.ReferenceInteger = 47
        modAddUndef.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Carbon
        Dim creature As New Creature()


        'Act
        modAddUndef.SetValueByReferenceType(creature, 50)

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
        Dim modAddUndef As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Undefined)
        modAddUndef.ReferenceInteger = 47
        modAddUndef.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Carbon
        Dim creature As New Creature()
        Dim expected As Integer = 0
        Dim actual As Integer = 0

        'Act
        actual = modAddUndef.GetValueByReferenceType(creature)

        'Assert
        Assert.AreEqual(expected, actual)

    End Sub

End Class