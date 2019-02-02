Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports Evolution
Imports Evolution.ModifierAddress


<TestClass()> Public Class ModifierAddressIndirectTest

    <TestMethod()> Public Sub ReferenceTypeTest()
        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddDirect As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)

        Dim expected As IModifierAddress.ReferenceTypeValue = IModifierAddress.ReferenceTypeValue.Indirect

        'Act

        'Assert
        Assert.AreEqual(expected, modAddDirect.ReferenceType)

    End Sub

    <TestMethod()> Public Sub SetValueByReferenceTypeTest()

        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddIndirectUndef As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)
        modAddIndirectUndef.ReferenceInteger = 47
        modAddIndirectUndef.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Undefined

        Dim modAddIndirectGeneCode As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)
        modAddIndirectGeneCode.ReferenceInteger = 11
        modAddIndirectGeneCode.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.GeneCode

        Dim modAddIndirectOxy As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)
        modAddIndirectOxy.ReferenceInteger = 17
        modAddIndirectOxy.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Oxygen

        Dim modAddIndirectGeneCounter As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)
        modAddIndirectGeneCounter.ReferenceInteger = 17
        modAddIndirectGeneCounter.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.GeneCounter

        Dim creatureUndef As New Creature()
        Dim creatureGeneCode As New Creature()
        creatureGeneCode(ICreatureDataDefinitions.CreatureData.GeneCounter) = 5
        creatureGeneCode.Gene(5) = 12
        Dim creatureOxy As New Creature()
        creatureOxy(ICreatureDataDefinitions.CreatureData.Oxygen) = 47
        Dim creatureGeneCounter As New Creature()
        creatureGeneCounter(ICreatureDataDefinitions.CreatureData.GeneCounter) = 5
        creatureGeneCounter.Gene(5) = 12



        'Act
        modAddIndirectUndef.SetValueByReferenceType(creatureUndef, 11)
        modAddIndirectGeneCode.SetValueByReferenceType(creatureGeneCode, 13)
        modAddIndirectOxy.SetValueByReferenceType(creatureOxy, 19)
        modAddIndirectGeneCounter.SetValueByReferenceType(creatureGeneCounter, 23)

        'Assert
        'The Gene at index 0 must be changed to 11
        Assert.AreEqual(11, creatureUndef.Gene(0))

        'Creature2 Gene has changed at position 5 and GgeneCounter was increased
        Assert.AreEqual(13, creatureGeneCode.Gene(12))
        Assert.AreEqual(12, creatureGeneCode.Gene(5))
        Assert.AreEqual(6, creatureGeneCode(ICreatureDataDefinitions.CreatureData.GeneCounter))

        'creature3 has a new Gene value where Mineral points to (Gene(47))
        Assert.AreEqual(47, creatureOxy(ICreatureDataDefinitions.CreatureData.Oxygen))
        Assert.AreEqual(19, creatureOxy.Gene(47))

        'creatureGeneCounter should have a GeneCounter of 6
        Assert.AreEqual(23, creatureGeneCounter.Gene(5))
        Assert.AreEqual(0, creatureGeneCounter.Gene(12))
        Assert.AreEqual(6, creatureGeneCounter(ICreatureDataDefinitions.CreatureData.GeneCounter))

    End Sub

    <TestMethod()> Public Sub GetValueByReferenceTypeTest()

        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddIndirectUndef As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)
        modAddIndirectUndef.ReferenceInteger = 47
        modAddIndirectUndef.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Undefined

        Dim modAddIndirectGeneCode As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)
        modAddIndirectGeneCode.ReferenceInteger = 11
        modAddIndirectGeneCode.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.GeneCode

        Dim modAddIndirectOxy As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)
        modAddIndirectOxy.ReferenceInteger = 17
        modAddIndirectOxy.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Sunlight

        Dim modAddIndirectGeneCounter As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)
        modAddIndirectGeneCounter.ReferenceInteger = 17
        modAddIndirectGeneCounter.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.GeneCounter

        Dim creatureUndef As New Creature()
        creatureUndef.Gene(0) = 8

        Dim creatureGeneCode As New Creature()
        creatureGeneCode(ICreatureDataDefinitions.CreatureData.GeneCounter) = 5
        creatureGeneCode.Gene(5) = 12
        creatureGeneCode.Gene(12) = 42

        Dim creatureOxy As New Creature()
        creatureOxy(ICreatureDataDefinitions.CreatureData.Sunlight) = 47
        creatureOxy.Gene(47) = 11

        Dim creatureGeneCounter As New Creature()
        creatureGeneCounter(ICreatureDataDefinitions.CreatureData.GeneCounter) = 42
        creatureGeneCounter.Gene(42) = 23
        creatureGeneCounter.Gene(23) = 123



        'Act
        Dim resultUndef As Integer = modAddIndirectUndef.GetValueByReferenceType(creatureUndef)
        Dim resultGeneCode As Integer = modAddIndirectGeneCode.GetValueByReferenceType(creatureGeneCode)
        Dim resultSun As Integer = modAddIndirectOxy.GetValueByReferenceType(creatureOxy)
        Dim resultGeneCounter As Integer = modAddIndirectGeneCounter.GetValueByReferenceType(creatureGeneCounter)

        'Assert
        'The Gene at index 0 must be changed to 11
        Assert.AreEqual(8, resultUndef)

        'Creature2 Gene has changed at position 5 and GeneCounter was increased
        Assert.AreEqual(42, resultGeneCode)
        Assert.AreEqual(12, creatureGeneCode.Gene(5))
        Assert.AreEqual(6, creatureGeneCode(ICreatureDataDefinitions.CreatureData.GeneCounter))

        'creature3 has a new Gene value where Mineral points to (Gene(47))
        Assert.AreEqual(11, resultSun)

        'Creature4 Gene has changed at position 5 and GeneCounter was increased
        Assert.AreEqual(23, resultGeneCounter)
        Assert.AreEqual(123, creatureGeneCounter.Gene(23))
        Assert.AreEqual(43, creatureGeneCounter(ICreatureDataDefinitions.CreatureData.GeneCounter))



    End Sub

End Class