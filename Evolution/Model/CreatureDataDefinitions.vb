Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Public Class CreatureDataDefinitions
    Implements ICreatureDataDefinitions

    Private _creatureData As List(Of ICreatureDataDefinitions.CreatureData)
    Private _changeOperations As List(Of ICreatureDataDefinitions.ChangeOperator)

    Public Sub New()
        _creatureData = New List(Of ICreatureDataDefinitions.CreatureData)
        _creatureData.AddRange([Enum].GetValues(GetType(ICreatureDataDefinitions.CreatureData)))

        _changeOperations = New List(Of ICreatureDataDefinitions.ChangeOperator)
        _changeOperations.AddRange([Enum].GetValues(GetType(ICreatureDataDefinitions.ChangeOperator)))
    End Sub

    Public Overridable Function GetCreatureDataDefinition() As List(Of ICreatureDataDefinitions.CreatureData) Implements ICreatureDataDefinitions.GetCreatureDataDefinition
        Return _creatureData
    End Function

    Public Overridable Function GetChangeOperations() As List(Of ICreatureDataDefinitions.ChangeOperator) Implements ICreatureDataDefinitions.GetChangeOperations
        Return _changeOperations
    End Function

End Class
