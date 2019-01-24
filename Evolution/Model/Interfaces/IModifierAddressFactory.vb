Public Interface IModifierAddressFactory

    Function NewModifierAddress(ByVal referenceTypeValue As IModifierAddress.ReferenceTypeValue) As IModifierAddress
    Function NewModifierAddress(ByVal referenceTypeValue As IModifierAddress.ReferenceTypeValue, ByVal referenceInteger As Integer, ByVal referenceCreatureData As ICreatureDataDefinitions.CreatureData) As IModifierAddress

End Interface
