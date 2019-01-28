Imports System.Diagnostics.CodeAnalysis
Imports System.Runtime.Serialization
Imports System.Security.Permissions
Imports Evolution

<SerializableAttribute> Public Class Creature
    Implements IDictionary(Of ICreatureDataDefinitions.CreatureData, Integer)

    Private ReadOnly _dictionary As Dictionary(Of ICreatureDataDefinitions.CreatureData, Integer)
    Private ReadOnly _gene As Gene
    Private ReadOnly _creatureDatadefinitions As ICreatureDataDefinitions

    Public Sub New()
        _gene = New Gene(256)
        _dictionary = New Dictionary(Of ICreatureDataDefinitions.CreatureData, Integer)
        InitializeFromDefinition()
    End Sub

    Public Sub New(ByVal gene As Gene)
        _gene = gene
        _dictionary = New Dictionary(Of ICreatureDataDefinitions.CreatureData, Integer)
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
                _dictionary.Add(dataDefintion, 0)
            End If
        Next
    End Sub

#Region "IDictionary"

    Default Public Property Item(key As ICreatureDataDefinitions.CreatureData) As Integer Implements IDictionary(Of ICreatureDataDefinitions.CreatureData, Integer).Item
        Get
            If Not _dictionary.ContainsKey(key) Then
                _dictionary.Add(key, 0)
            End If
            Return _dictionary(key)
        End Get
        Set(value As Integer)
            If Not _dictionary.ContainsKey(key) Then
                _dictionary.Add(key, 0)
            End If
            _dictionary(key) = value
        End Set
    End Property

    Public ReadOnly Property Keys As ICollection(Of ICreatureDataDefinitions.CreatureData) Implements IDictionary(Of ICreatureDataDefinitions.CreatureData, Integer).Keys
        Get
            Return _dictionary.Keys
        End Get
    End Property

    Public ReadOnly Property Values As ICollection(Of Integer) Implements IDictionary(Of ICreatureDataDefinitions.CreatureData, Integer).Values
        Get
            Return _dictionary.Values
        End Get
    End Property

    Public ReadOnly Property Count As Integer Implements ICollection(Of KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)).Count
        Get
            Return _dictionary.Count
        End Get
    End Property

    Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)).IsReadOnly
        Get
            Return False
        End Get
    End Property

    Public Sub Add(key As ICreatureDataDefinitions.CreatureData, value As Integer) Implements IDictionary(Of ICreatureDataDefinitions.CreatureData, Integer).Add
        If Not _dictionary.ContainsKey(key) Then
            _dictionary.Add(key, value)
        Else
            _dictionary(key) = value
        End If
    End Sub

    Public Sub Add(item As KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)) Implements ICollection(Of KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)).Add
        If Not _dictionary.ContainsKey(item.Key) Then
            _dictionary.Add(item.Key, item.Value)
        Else
            _dictionary(item.Key) = item.Value
        End If
    End Sub

    Public Sub Clear() Implements ICollection(Of KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)).Clear
        _dictionary.Clear()
    End Sub

    Public Sub CopyTo(array() As KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer), arrayIndex As Integer) Implements ICollection(Of KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)).CopyTo
        Dim d = TryCast(_dictionary, ICollection(Of KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)))
        d.CopyTo(array, arrayIndex)
    End Sub

    Public Function ContainsKey(key As ICreatureDataDefinitions.CreatureData) As Boolean Implements IDictionary(Of ICreatureDataDefinitions.CreatureData, Integer).ContainsKey
        Return _dictionary.ContainsKey(key)
    End Function

    Public Function Remove(key As ICreatureDataDefinitions.CreatureData) As Boolean Implements IDictionary(Of ICreatureDataDefinitions.CreatureData, Integer).Remove
        Return _dictionary.Remove(key)
    End Function

    Public Function Remove(item As KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)) As Boolean Implements ICollection(Of KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)).Remove
        Return _dictionary.Remove(item.Key)
    End Function

    Public Function TryGetValue(key As ICreatureDataDefinitions.CreatureData, ByRef value As Integer) As Boolean Implements IDictionary(Of ICreatureDataDefinitions.CreatureData, Integer).TryGetValue
        Return _dictionary.TryGetValue(key, value)
    End Function

    Public Function Contains(item As KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)) As Boolean Implements ICollection(Of KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)).Contains
        Return _dictionary.Contains(item)
    End Function

    Public Function GetEnumerator() As IEnumerator(Of KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)) Implements IEnumerable(Of KeyValuePair(Of ICreatureDataDefinitions.CreatureData, Integer)).GetEnumerator
        Return _dictionary.GetEnumerator()
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return TryCast(_dictionary.GetEnumerator(), System.Collections.IEnumerator)
    End Function

#End Region

End Class
