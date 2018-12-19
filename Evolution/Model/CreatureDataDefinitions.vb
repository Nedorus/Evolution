Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Public Class CreatureDataDefinitions
    Implements ICreatureDataDefinitions, IXmlSerializable

    Private _creatureData As List(Of String)
    Private _changeOperations As List(Of String)

    Public Sub New()
        _creatureData = New List(Of String)
        _changeOperations = New List(Of String)
    End Sub

    <ExcludeFromCodeCoverage()>
    Public Property CreatureDataDefinition As List(Of String) Implements ICreatureDataDefinitions.CreatureDataDefinition
        Get
            Return _creatureData
        End Get
        Set(value As List(Of String))
            _creatureData = value
        End Set
    End Property

    <ExcludeFromCodeCoverage()>
    Public Property ChangeOperations As List(Of String) Implements ICreatureDataDefinitions.ChangeOperations
        Get
            Return _changeOperations
        End Get
        Set(value As List(Of String))
            _changeOperations = value
        End Set
    End Property


#Region "IXMLSerializable"

    Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml

        Dim was_empty As Boolean = reader.IsEmptyElement
        reader.Read()
        If Not was_empty Then
            reader.Read()
            Do While reader.NodeType <> Xml.XmlNodeType.EndElement
                Me.CreatureDataDefinition.Add(reader.ReadElementContentAsString)
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
        writer.WriteStartElement("CreatureDataDefinition")
        For Each currCreatureDataItem In Me.CreatureDataDefinition
            writer.WriteElementString("CreatureDataItem", currCreatureDataItem.ToString)
        Next
        writer.WriteEndElement()
        writer.WriteStartElement("ChangeOperations")
        For Each currChangeOperator In Me.ChangeOperations
            writer.WriteElementString("ChangeOperator", currChangeOperator.ToString)
        Next
        writer.WriteEndElement()
    End Sub

    <ExcludeFromCodeCoverage()>
    Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
        Return Nothing
    End Function
#End Region

End Class
