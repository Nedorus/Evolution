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

        modAddRelative1 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct)
        modAddRelative2 = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 3, ICreatureDataDefinitions.CreatureData.CarbonDioxide)

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

        Assert.AreEqual(modAddRelative1.ReferenceType, IModifierAddress.ReferenceTypeValue.Direct)
        Assert.AreEqual(modAddRelative2.ReferenceType, IModifierAddress.ReferenceTypeValue.Direct)
        Assert.IsInstanceOfType(modAddRelative1, GetType(ModifierAddressDirect))
        Assert.IsInstanceOfType(modAddRelative2, GetType(ModifierAddressDirect))

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
        Dim modAddFact As New ModifierAddressFactoryImpl()

        Dim creature As Creature = New Creature()
        creature.Gene(0) = 1
        creature.Gene(1) = 2
        creature.Gene(2) = 19
        creature.Gene(3) = 5
        creature.Gene(4) = 8
        creature.Gene(5) = 13
        creature.Gene(6) = 7
        creature.Gene(7) = 34
        creature.Gene(8) = 55
        creature(ICreatureDataDefinitions.CreatureData.Carbon) = 6
        creature(ICreatureDataDefinitions.CreatureData.GeneCounter) = 2

        Dim modAddUndefined As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Undefined)

        Dim modAddAbsolute1 As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Absolute, 47, ICreatureDataDefinitions.CreatureData.Undefined)
        Dim modAddAbsolute2 As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Absolute, 11, ICreatureDataDefinitions.CreatureData.Carbon)

        Dim modAddRelative1 As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 3, ICreatureDataDefinitions.CreatureData.Undefined)
        Dim modAddRelative2 As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 8, ICreatureDataDefinitions.CreatureData.GeneCode)
        Dim modAddRelative3 As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 3, ICreatureDataDefinitions.CreatureData.GeneCounter)
        Dim modAddRelative4 As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 3, ICreatureDataDefinitions.CreatureData.Carbon)

        Dim modAddIndirect1 As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect, 4, ICreatureDataDefinitions.CreatureData.Undefined)
        Dim modAddIndirect2 As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect, 4, ICreatureDataDefinitions.CreatureData.GeneCode)
        Dim modAddIndirect3 As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect, 4, ICreatureDataDefinitions.CreatureData.GeneCounter)
        Dim modAddIndirect4 As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect, 4, ICreatureDataDefinitions.CreatureData.Carbon)

        'Dim modAddEnvironment As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Environment)
        'Dim modAddOtherCreature As IModifierAddress = modAddFact.NewModifierAddress(IModifierAddress.ReferenceTypeValue.OtherCreature)

        'Act
        Dim undefined As Integer = modAddUndefined.GetValueByReferenceType(creature)

        Dim absolute1 As Integer = modAddAbsolute1.GetValueByReferenceType(creature)
        Dim absolute2 As Integer = modAddAbsolute2.GetValueByReferenceType(creature)

        Dim relative1 As Integer = modAddRelative1.GetValueByReferenceType(creature)
        Dim relative2 As Integer = modAddRelative2.GetValueByReferenceType(creature)
        Dim relative3 As Integer = modAddRelative3.GetValueByReferenceType(creature)
        Dim relative4 As Integer = modAddRelative4.GetValueByReferenceType(creature)

        Dim indirect1 As Integer = modAddIndirect1.GetValueByReferenceType(creature)
        Dim indirect2 As Integer = modAddIndirect2.GetValueByReferenceType(creature)
        Dim indirect3 As Integer = modAddIndirect3.GetValueByReferenceType(creature)
        Dim indirect4 As Integer = modAddIndirect4.GetValueByReferenceType(creature)

        'Dim environment As Integer = modAddEnvironment.GetValueByReferenceType(creature)
        'Dim otherCreature As Integer = modAddOtherCreature.GetValueByReferenceType(creature)

        'Assert
        Assert.AreEqual(0, undefined)

        Assert.AreEqual(47, absolute1)
        Assert.AreEqual(11, absolute2)

        Assert.AreEqual(0, relative1)
        Assert.AreEqual(19, relative2)
        Assert.AreEqual(3, relative3)
        Assert.AreEqual(6, relative4)

        Assert.AreEqual(1, indirect1)
        Assert.AreEqual(13, indirect2)
        Assert.AreEqual(8, indirect3)
        Assert.AreEqual(7, indirect4)

    End Sub

End Class