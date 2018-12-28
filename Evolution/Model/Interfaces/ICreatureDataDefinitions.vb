Public Interface ICreatureDataDefinitions

    Enum CreatureData
        Undefined
        GeneCode
        GeneCounter
        EnergyType1
        XPosition
        YPosition
    End Enum

    'Enum ChangeOperator
    '    Undefined
    '    Add
    '    Subtract
    'End Enum

    Function GetChangeOperations() As List(Of IModifier.ModifierOperator)
    Function GetCreatureDataDefinition() As List(Of CreatureData)
End Interface
