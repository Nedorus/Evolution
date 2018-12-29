Public Interface ICreatureDataDefinitions

    Enum CreatureData
        Undefined
        GeneCode
        GeneCounter
        Sunlight
        Mineral
        Oxygen
        Carbon
        CarbonDioxide
        XPosition
        YPosition
    End Enum

    Function GetModifierOperators() As List(Of IModifier.ModifierOperator)
    Function GetReferenceTypeValues() As List(Of IModifierAddress.ReferenceTypeValue)
    Function GetCreatureDataDefinition() As List(Of CreatureData)
End Interface
