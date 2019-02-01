Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Evolution
Imports Evolution.ModifierAddress

<TestClass()> Public Class ModifierAddressEnvironmentTest

    <TestMethod()> Public Sub ReferenceTypeTest()
        'Arrange
        Dim modAddFactory As New ModifierAddressFactoryImpl()
        Dim modAddDirect As IModifierAddress = modAddFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Environment)

        Dim expected As IModifierAddress.ReferenceTypeValue = IModifierAddress.ReferenceTypeValue.Environment

        'Act

        'Assert
        Assert.AreEqual(expected, modAddDirect.ReferenceType)

    End Sub
    <TestMethod()> Public Sub SetValueByReferenceTypeTest()

        'Arrange


        'Act


        'Assert
        Assert.Inconclusive("Functinality needs to be implemented!")

    End Sub

    <TestMethod()> Public Sub GetValueByReferenceTypeTest()

        'Arrange


        'Act


        'Assert
        Assert.Inconclusive("Functinality needs to be implemented!")

    End Sub

End Class