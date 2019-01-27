Public Class ModifierAddressIndirect
    Inherits ModifierAddressBaseImpl

    Public Overrides ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue
        Get
            Return IModifierAddress.ReferenceTypeValue.Indirect
        End Get
    End Property

    Public Overrides Function GetValueByReferenceType(ByRef creature As Creature) As Integer
        Dim index As Integer = GetValueFromCreatureByReferenceString(creature)
        Dim returnval = GetValueFromCreatureGene(creature, index)
        Return returnval
    End Function

    Private Function GetValueFromCreatureByReferenceString(ByRef creature As Creature) As Integer
        Dim returnVal As Integer = 0
        If creature.ContainsKey(ReferenceCreatureData) Then
            returnVal = creature(ReferenceCreatureData)
        ElseIf ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.GeneCode Then
            returnVal = GetValueFromCreatureGene(creature, creature(ICreatureDataDefinitions.CreatureData.GeneCounter))
            creature(ICreatureDataDefinitions.CreatureData.GeneCounter) += 1
        ElseIf ReferenceCreatureData <> ICreatureDataDefinitions.CreatureData.Undefined Then
            creature.Add(ReferenceCreatureData, 0)
            returnVal = creature(ReferenceCreatureData)
        End If
        Return returnVal
    End Function

    Private Function GetValueFromCreatureGene(ByRef creature As Creature, ByVal index As Integer)
        index = index Mod creature.Gene.Count
        Return creature.Gene(index)
    End Function

End Class
