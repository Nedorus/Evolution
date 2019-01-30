
Imports System.Xml
Imports Evolution.Modifier

Namespace ModifierAddress

    Public Interface IModifierAddressFactory

        Function NewModifierAddress() As IModifierAddress
        Function NewModifierAddress(ByVal referenceTypeValue As IModifierAddress.ReferenceTypeValue) As IModifierAddress
        Function NewModifierAddress(ByVal referenceTypeValue As IModifierAddress.ReferenceTypeValue, ByVal referenceInteger As Integer, ByVal referenceCreatureData As ICreatureDataDefinitions.CreatureData) As IModifierAddress

        Function XmLDeserializeModifierAddress(reader As XmlReader) As IModifierAddress

    End Interface

End Namespace
