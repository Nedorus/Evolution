Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Evolution

Public Class CreatureDataDefinitions
    Implements ICreatureDataDefinitions

    Private _creatureData As List(Of ICreatureDataDefinitions.CreatureData)
    Private _modifierOperators As List(Of IModifier.ModifierOperator)
    Private _referenceValues As List(Of IModifierAddress.ReferenceTypeValue)

    Public Sub New()
        _creatureData = New List(Of ICreatureDataDefinitions.CreatureData)
        _creatureData.AddRange([Enum].GetValues(GetType(ICreatureDataDefinitions.CreatureData)))

        _modifierOperators = New List(Of IModifier.ModifierOperator)
        _modifierOperators.AddRange([Enum].GetValues(GetType(IModifier.ModifierOperator)))
        _referenceValues.AddRange([Enum].GetValues(GetType(IModifierAddress.ReferenceTypeValue)))
    End Sub

    Public Overridable Function GetCreatureDataDefinition() As List(Of ICreatureDataDefinitions.CreatureData) Implements ICreatureDataDefinitions.GetCreatureDataDefinition
        Return _creatureData
    End Function

    Public Overridable Function GetModifierOperators() As List(Of IModifier.ModifierOperator) Implements ICreatureDataDefinitions.GetModifierOperators
        Return _modifierOperators
    End Function

    Public Function GetReferenceTypeValues() As List(Of IModifierAddress.ReferenceTypeValue) Implements ICreatureDataDefinitions.GetReferenceTypeValues
        Return _referenceValues
    End Function
End Class
