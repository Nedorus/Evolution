Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Evolution

<TestClass()> Public Class ModifierAddressFactoryImplTest

    <TestMethod()> Public Sub ReferenceTypePropertyTest()
        'Arrange
        Dim modAddFact As New ModifierAddressFactoryImpl()
        Dim modAddAbsolute1 As IModifierAddress
        Dim modAddAbsolute2 As IModifierAddress

        Dim modAddUndefined1 As IModifierAddress
        Dim modAddUndefined2 As IModifierAddress

        Dim modAddRelative1 As IModifierAddress
        Dim modAddRelative2 As IModifierAddress

        Dim modAddIndirect1 As IModifierAddress
        Dim modAddIndirect2 As IModifierAddress

        Dim modAddEnvironment1 As IModifierAddress
        Dim modAddEnvironment2 As IModifierAddress

        Dim modAddOtherCreature1 As IModifierAddress
        Dim modAddOtherCreature2 As IModifierAddress

        'Act
        modAddAbsolute1 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Absolute)
        modAddAbsolute2 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Absolute, 1, ICreatureDataDefinitions.CreatureData.GeneCode)

        modAddUndefined1 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Undefined)
        modAddUndefined2 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Undefined, 2, ICreatureDataDefinitions.CreatureData.Carbon)

        modAddRelative1 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Relative)
        modAddRelative2 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Relative, 3, ICreatureDataDefinitions.CreatureData.CarbonDioxide)

        modAddIndirect1 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)
        modAddIndirect2 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect, 4, ICreatureDataDefinitions.CreatureData.GeneCounter)

        modAddEnvironment1 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Environment)
        modAddEnvironment2 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Environment, 5, ICreatureDataDefinitions.CreatureData.Mineral)

        modAddOtherCreature1 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.OtherCreature)
        modAddOtherCreature2 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.OtherCreature, 6, ICreatureDataDefinitions.CreatureData.Sunlight)

        'Assert
        Assert.AreEqual(modAddAbsolute1.ReferenceType, IModifierAddress.ReferenceTypeValue.Absolute)
        Assert.AreEqual(modAddAbsolute2.ReferenceType, IModifierAddress.ReferenceTypeValue.Absolute)
        Assert.IsInstanceOfType(modAddAbsolute1, GetType(ModifierAddressAbsolute))
        Assert.IsInstanceOfType(modAddAbsolute2, GetType(ModifierAddressAbsolute))


        Assert.AreEqual(modAddUndefined1.ReferenceType, IModifierAddress.ReferenceTypeValue.Undefined)
        Assert.AreEqual(modAddUndefined2.ReferenceType, IModifierAddress.ReferenceTypeValue.Undefined)
        Assert.IsInstanceOfType(modAddUndefined1, GetType(ModifierAddressUndefined))
        Assert.IsInstanceOfType(modAddUndefined2, GetType(ModifierAddressUndefined))

        Assert.AreEqual(modAddRelative1.ReferenceType, IModifierAddress.ReferenceTypeValue.Relative)
        Assert.AreEqual(modAddRelative2.ReferenceType, IModifierAddress.ReferenceTypeValue.Relative)
        Assert.IsInstanceOfType(modAddRelative1, GetType(ModifierAddressRelative))
        Assert.IsInstanceOfType(modAddRelative2, GetType(ModifierAddressRelative))

        Assert.AreEqual(modAddIndirect1.ReferenceType, IModifierAddress.ReferenceTypeValue.Indirect)
        Assert.AreEqual(modAddIndirect2.ReferenceType, IModifierAddress.ReferenceTypeValue.Indirect)
        Assert.IsInstanceOfType(modAddIndirect1, GetType(ModifierAddressIndirect))
        Assert.IsInstanceOfType(modAddIndirect2, GetType(ModifierAddressIndirect))

        Assert.AreEqual(modAddEnvironment1.ReferenceType, IModifierAddress.ReferenceTypeValue.Environment)
        Assert.AreEqual(modAddEnvironment2.ReferenceType, IModifierAddress.ReferenceTypeValue.Environment)
        Assert.IsInstanceOfType(modAddEnvironment1, GetType(ModifierAddressEnvironment))
        Assert.IsInstanceOfType(modAddEnvironment2, GetType(ModifierAddressEnvironment))

        Assert.AreEqual(modAddOtherCreature1.ReferenceType, IModifierAddress.ReferenceTypeValue.OtherCreature)
        Assert.AreEqual(modAddOtherCreature2.ReferenceType, IModifierAddress.ReferenceTypeValue.OtherCreature)
        Assert.IsInstanceOfType(modAddOtherCreature1, GetType(ModifierAddressOtherCreature))
        Assert.IsInstanceOfType(modAddOtherCreature2, GetType(ModifierAddressOtherCreature))

    End Sub

    <TestMethod()> Public Sub GetValueByReferenceTypeTest()
        'Arrange
        Dim creature As Creature = New Creature()
        creature.Gene.Add(1)
        creature.Gene.Add(2)
        creature.Gene.Add(3)
        creature.Gene.Add(5)
        creature.Gene.Add(8)
        creature.Gene.Add(13)
        creature.Gene.Add(21)
        creature.Gene.Add(34)
        creature.Gene.Add(55)

        creature(ICreatureDataDefinitions.CreatureData.GeneCounter) = 3

        'Act


        'Assert

    End Sub

End Class