Imports Evolution

Public Class ModifierAddressFactoryImpl
    Implements IModifierAddressFactory

    Public Sub New()

    End Sub

    Public Function NewModifierAddress(referenceTypeValue As IModifierAddress.ReferenceTypeValue) As IModifierAddress Implements IModifierAddressFactory.NewModifierAddress
        Select Case referenceTypeValue
            Case IModifierAddress.ReferenceTypeValue.Absolute
                Return New ModifierAddressAbsolute()
            Case IModifierAddress.ReferenceTypeValue.Environment
                Return New ModifierAddressEnvironment()
            Case IModifierAddress.ReferenceTypeValue.Indirect
                Return New ModifierAddressIndirect()
            Case IModifierAddress.ReferenceTypeValue.OtherCreature
                Return New ModifierAddressOtherCreature()
            Case IModifierAddress.ReferenceTypeValue.Relative
                Return New ModifierAddressRelative
            Case IModifierAddress.ReferenceTypeValue.Undefined
                Return New ModifierAddressUndefined()
            Case Else
                Return New ModifierAddressUndefined()
        End Select
    End Function

    Public Function NewModifierAddress(ByVal referenceTypeValue As IModifierAddress.ReferenceTypeValue, ByVal referenceInteger As Integer, ByVal referenceCreatureData As ICreatureDataDefinitions.CreatureData) As IModifierAddress Implements IModifierAddressFactory.NewModifierAddress
        Dim returnModifierAddress As IModifierAddress = NewModifierAddress(referenceTypeValue)
        returnModifierAddress.ReferenceInteger = referenceInteger
        returnModifierAddress.ReferenceCreatureData = referenceCreatureData
        Return returnModifierAddress
    End Function


End Class
