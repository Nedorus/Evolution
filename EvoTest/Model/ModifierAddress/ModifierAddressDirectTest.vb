Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports Evolution
Imports Evolution.ModifierAddress

<TestClass()> Public Class ModifierAddressDirectTest

    <TestMethod()> Public Sub ReferenceTypeTest()
        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddDirect As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct)

        Dim expected As IModifierAddress.ReferenceTypeValue = IModifierAddress.ReferenceTypeValue.Direct

        'Act

        'Assert
        Assert.AreEqual(expected, modAddDirect.ReferenceType)

    End Sub

    <TestMethod()> Public Sub SetValueByReferenceTypeTest()

        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddDirectUndef As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct)
        modAddDirectUndef.ReferenceInteger = 47
        modAddDirectUndef.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Undefined

        Dim modAddDirectGeneCode As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct)
        modAddDirectGeneCode.ReferenceInteger = 11
        modAddDirectGeneCode.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.GeneCode

        Dim modAddDirectMineral As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct)
        modAddDirectMineral.ReferenceInteger = 17
        modAddDirectMineral.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Mineral

        Dim creature1 As New Creature()
        Dim creature2 As New Creature()
        creature2(ICreatureDataDefinitions.CreatureData.GeneCounter) = 5
        Dim creature3 As New Creature()


        'Act
        modAddDirectUndef.SetValueByReferenceType(creature1, 11)
        modAddDirectGeneCode.SetValueByReferenceType(creature2, 13)
        modAddDirectMineral.SetValueByReferenceType(creature3, 19)

        'Assert
        'All values of creatue1 must be unchanged
        For Each creatureDataName In [Enum].GetNames(GetType(ICreatureDataDefinitions.CreatureData))
            Dim creatureData As ICreatureDataDefinitions.CreatureData = DirectCast([Enum].Parse(GetType(ICreatureDataDefinitions.CreatureData), creatureDataName), ICreatureDataDefinitions.CreatureData)

            If creatureData <> ICreatureDataDefinitions.CreatureData.GeneCode Then
                Assert.AreEqual(0, creature1(creatureData), String.Format("Checked: {0}", creatureDataName))
            End If
        Next
        For index = 0 To creature1.Gene.Count - 1
            Assert.AreEqual(0, creature1.Gene(index), String.Format("Checked index: {0}", index))
        Next

        'Creature2 Gene has changed at position 5 and GgeneCounter was increased
        Assert.AreEqual(13, creature2.Gene(5))
        Assert.AreEqual(6, creature2(ICreatureDataDefinitions.CreatureData.GeneCounter))

        'creature3 has a new Mineral value of 19
        Assert.AreEqual(19, creature3(ICreatureDataDefinitions.CreatureData.Mineral))

    End Sub

    <TestMethod()> Public Sub GetValueByReferenceTypeTest()

        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddDirectUndef As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct)
        modAddDirectUndef.ReferenceInteger = 47
        modAddDirectUndef.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Undefined

        Dim modAddDirectGeneCode As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct)
        modAddDirectGeneCode.ReferenceInteger = 11
        modAddDirectGeneCode.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.GeneCode

        Dim modAddDirectMineral As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct)
        modAddDirectMineral.ReferenceInteger = 17
        modAddDirectMineral.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Mineral

        Dim creature1 As New Creature()
        Dim creature2 As New Creature()
        creature2(ICreatureDataDefinitions.CreatureData.GeneCounter) = 5
        creature2.Gene(5) = 47
        Dim creature3 As New Creature()
        creature3(ICreatureDataDefinitions.CreatureData.Mineral) = 11


        'Act
        Dim resultUndef As Integer = modAddDirectUndef.GetValueByReferenceType(creature1)
        Dim resultGeneCode As Integer = modAddDirectGeneCode.GetValueByReferenceType(creature2)
        Dim resultMineral As Integer = modAddDirectMineral.GetValueByReferenceType(creature3)

        'Assert
        'All values of creatue1 must be unchanged
        Assert.AreEqual(0, resultUndef)

        'Creature2 has 47 in the GeneCode at position 5
        Assert.AreEqual(47, resultGeneCode)
        Assert.AreEqual(6, creature2(ICreatureDataDefinitions.CreatureData.GeneCounter))

        'creature3 has a new Mineral value of 11
        Assert.AreEqual(11, resultMineral)


    End Sub

End Class