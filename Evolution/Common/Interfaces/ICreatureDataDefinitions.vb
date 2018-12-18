Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Public Interface ICreatureDataDefinitions

    Property CreatureDataDefinition As List(Of String)
    Property ChangeOperations As List(Of String)

End Interface
