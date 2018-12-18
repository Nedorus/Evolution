Public Class DynamicCreature
    Inherits Dictionary(Of String, Integer)


    Private _creatureDataDefinition As ICreatureDataDefinitions
    Private _gene As Gene

    Public Sub New(creatureDataDefinition As ICreatureDataDefinitions)
        _creatureDataDefinition = creatureDataDefinition
        For Each dataDefintion In _creatureDataDefinition.CreatureDataDefinition
            Me.Add(dataDefintion, 0)
        Next
    End Sub

End Class
