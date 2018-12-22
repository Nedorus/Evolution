Imports System.Diagnostics.CodeAnalysis
Imports System.Runtime.Serialization
Imports System.Security.Permissions

<SerializableAttribute> Public Class Creature
    Inherits Dictionary(Of ICreatureDataDefinitions.CreatureData, Integer)

    Private ReadOnly _gene As Gene
    Private ReadOnly _creatureDatadefinitions As ICreatureDataDefinitions

#Region "Must implement this due to Dictionary implementing Iserializable"

    <ExcludeFromCodeCoverage()>
    Protected Sub New(info As SerializationInfo, context As StreamingContext)
        MyBase.New(info, context)
        InitializeFromDefinition()
    End Sub

    '<SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter:=True)>
    <ExcludeFromCodeCoverage()>
    Overrides Sub GetObjectData(info As SerializationInfo, context As StreamingContext)
        MyBase.GetObjectData(info, context)
        info.AddValue("gene", _gene)
    End Sub

#End Region

    Public Sub New()
        _gene = New Gene(256)
        InitializeFromDefinition()
    End Sub

    Public Sub New(ByVal gene As Gene)
        _gene = gene
        InitializeFromDefinition()
    End Sub

    Public ReadOnly Property Gene As Gene
        Get
            Return _gene
        End Get
    End Property

    Private Sub InitializeFromDefinition()
        For Each dataDefintion In System.Enum.GetValues(GetType(ICreatureDataDefinitions.CreatureData))
            If dataDefintion <> ICreatureDataDefinitions.CreatureData.GeneCode AndAlso dataDefintion <> ICreatureDataDefinitions.CreatureData.Undefined Then
                Me.Add(dataDefintion, 0)
            End If
        Next
    End Sub

End Class
