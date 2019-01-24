Public Class ModifierAddressRelative
    Inherits ModifierAddressBaseImpl

    Public Overrides ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue
        Get
            Return IModifierAddress.ReferenceTypeValue.Relative
        End Get
    End Property

    Public Overrides Function GetValueByReferenceType(ByRef creature As Creature) As Integer
        Return GetValueFromCreatureByReferenceString(creature)
    End Function



    Private Function GetValueFromCreatureByReferenceString(ByRef creature As Creature) As Integer
        Dim returnVal As Integer = 0
        If creature.ContainsKey(ReferenceCreatureData) Then
            returnVal = creature(ReferenceCreatureData)
        ElseIf ICreatureDataDefinitions.CreatureData.GeneCode = ReferenceCreatureData Then
            returnVal = GetValueFromCreatureGene(creature, ReferenceInteger)
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
