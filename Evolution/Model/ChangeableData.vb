Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Public Class ChangeableData
    Implements IXmlSerializable

    Private _creatureData As List(Of String)
    Private _changeOperations As List(Of String)

    Public Sub New()
        _creatureData = New List(Of String)
        _changeOperations = New List(Of String)
    End Sub

    Public Property CreatureDatadefinition As List(Of String)
        Get
            Return _creatureData
        End Get
        Set(value As List(Of String))
            _creatureData = value
        End Set
    End Property

    Public Property ChangeOperations As List(Of String)
        Get
            Return _changeOperations
        End Get
        Set(value As List(Of String))
            _changeOperations = value
        End Set
    End Property

    Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml

        Dim was_empty As Boolean = reader.IsEmptyElement
        reader.Read()
        If Not was_empty Then
            reader.Read()
            Do While reader.NodeType <> Xml.XmlNodeType.EndElement
                Me.CreatureDatadefinition.Add(reader.ReadElementContentAsString)
                reader.MoveToContent()
            Loop
            reader.ReadEndElement()
            reader.Read()
            Do While reader.NodeType <> Xml.XmlNodeType.EndElement
                Me.ChangeOperations.Add(reader.ReadElementContentAsString)
                reader.MoveToContent()
            Loop
            reader.ReadEndElement()
        End If
    End Sub

    Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
        'For Each currCreatureDataItem In Me.CreatureDatadefinition
        '    writer.WriteStartElement("CreatureDataItem")
        '    currCreatureDataItem.WriteXml(writer)
        '    writer.WriteEndElement()
        'Next
    End Sub

    <ExcludeFromCodeCoverage()>
    Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
        Return Nothing
    End Function
End Class
