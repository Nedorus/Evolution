Imports System.Xml
Imports Evolution
Imports Evolution.Modifier

Namespace ModifierAddress

    Public Class ModifierAddressFactoryImpl
        Implements IModifierAddressFactory

        Public Function NewModifierAddress() As IModifierAddress Implements IModifierAddressFactory.NewModifierAddress
            Return New ModifierAddressUndefined()
        End Function

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
                Case IModifierAddress.ReferenceTypeValue.Direct
                    Return New ModifierAddressDirect
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

        Public Function XmLDeserializeModifierAddress(reader As XmlReader) As IModifierAddress Implements IModifierAddressFactory.XmLDeserializeModifierAddress
            Dim modifierAddress As IModifierAddress
            Dim referenceValue As IModifierAddress.ReferenceTypeValue
            Dim referenceInteger As Integer
            Dim referenceCreatureData As ICreatureDataDefinitions.CreatureData


            referenceValue = DirectCast([Enum].Parse(GetType(IModifierAddress.ReferenceTypeValue), reader.ReadElementContentAsString), IModifierAddress.ReferenceTypeValue)
            referenceInteger = reader.ReadElementContentAsInt
            If Not reader.IsEmptyElement Then
                referenceCreatureData = DirectCast([Enum].Parse(GetType(ICreatureDataDefinitions.CreatureData), reader.ReadElementContentAsString), ICreatureDataDefinitions.CreatureData)
            Else
                referenceCreatureData = ICreatureDataDefinitions.CreatureData.Undefined
                reader.ReadElementContentAsString()
            End If
            modifierAddress = Me.NewModifierAddress(referenceValue, referenceInteger, referenceCreatureData)

            Return modifierAddress
        End Function
    End Class

End Namespace

