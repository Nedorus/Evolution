Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Evolution
Imports Evolution.ModifierAddress

<TestClass()> Public Class ModifierAddressFactoryImplTest

    <TestMethod()> Public Sub NewModifierAddressNoParamTest()
        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddress As IModifierAddress

        'Act
        modAddress = modAddFactory.NewModifierAddress()

        'Assert
        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressUndefined), modAddress.GetType())

    End Sub

    <TestMethod()> Public Sub NewModifierAddressWithReferenceTypeTest()
        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()

        Dim modAddressAbs As IModifierAddress
        Dim modAddressUndef As IModifierAddress
        Dim modAddressDirect As IModifierAddress
        Dim modAddressIndirect As IModifierAddress
        Dim modAddressEnv As IModifierAddress
        Dim modAddressCreatue As IModifierAddress


        'Act
        modAddressAbs = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Absolute)
        modAddressCreatue = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.OtherCreature)
        modAddressDirect = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct)
        modAddressEnv = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Environment)
        modAddressIndirect = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect)
        modAddressUndef = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Undefined)

        'Assert
        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressAbsolute), modAddressAbs.GetType())
        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressOtherCreature), modAddressCreatue.GetType())
        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressDirect), modAddressDirect.GetType())
        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressEnvironment), modAddressEnv.GetType())
        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressIndirect), modAddressIndirect.GetType())
        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressUndefined), modAddressUndef.GetType())

    End Sub

    <TestMethod()> Public Sub NewModifierAddressAllParamsTest()
        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()

        Dim modAddressAbs As IModifierAddress
        Dim modAddressUndef As IModifierAddress
        Dim modAddressDirect As IModifierAddress
        Dim modAddressIndirect As IModifierAddress
        Dim modAddressEnv As IModifierAddress
        Dim modAddressCreatue As IModifierAddress

        Dim referenceInterger As Integer = 42
        Dim referenceCreatureData As ICreatureDataDefinitions.CreatureData = ICreatureDataDefinitions.CreatureData.CarbonDioxide

        'Act
        modAddressAbs = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Absolute, referenceInterger, referenceCreatureData)
        modAddressCreatue = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.OtherCreature, referenceInterger, referenceCreatureData)
        modAddressDirect = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, referenceInterger, referenceCreatureData)
        modAddressEnv = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Environment, referenceInterger, referenceCreatureData)
        modAddressIndirect = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Indirect, referenceInterger, referenceCreatureData)
        modAddressUndef = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Undefined, referenceInterger, referenceCreatureData)



        'Assert
        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressAbsolute), modAddressAbs.GetType())
        Assert.AreEqual(42, modAddressAbs.ReferenceInteger)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.CarbonDioxide, modAddressAbs.ReferenceCreatureData)

        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressOtherCreature), modAddressCreatue.GetType())
        Assert.AreEqual(42, modAddressCreatue.ReferenceInteger)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.CarbonDioxide, modAddressCreatue.ReferenceCreatureData)

        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressDirect), modAddressDirect.GetType())
        Assert.AreEqual(42, modAddressDirect.ReferenceInteger)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.CarbonDioxide, modAddressDirect.ReferenceCreatureData)

        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressEnvironment), modAddressEnv.GetType())
        Assert.AreEqual(42, modAddressEnv.ReferenceInteger)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.CarbonDioxide, modAddressEnv.ReferenceCreatureData)

        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressIndirect), modAddressIndirect.GetType())
        Assert.AreEqual(42, modAddressIndirect.ReferenceInteger)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.CarbonDioxide, modAddressIndirect.ReferenceCreatureData)

        Assert.AreEqual(GetType(Evolution.ModifierAddress.ModifierAddressUndefined), modAddressUndef.GetType())
        Assert.AreEqual(42, modAddressUndef.ReferenceInteger)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.CarbonDioxide, modAddressUndef.ReferenceCreatureData)

    End Sub

End Class