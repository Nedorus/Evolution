Public Class DynamicCreature
    Inherits Dictionary(Of String, Integer)

    Private _gene As Gene

    Public Sub New(creatureDataDefinitions As ICreatureDataDefinitions)
        For Each dataDefintion In creatureDataDefinitions.CreatureDataDefinition
            Me.Add(dataDefintion, 0)
        Next
    End Sub

End Class
