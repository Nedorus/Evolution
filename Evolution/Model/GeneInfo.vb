Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports System.Diagnostics.CodeAnalysis
Imports Evolution.Modifier

Public Class GeneInfo
    Implements IXmlSerializable

    Private _geneValue As Integer
    Private _geneCode As String
    Private _geneNumberOfArgs As Integer
    Private _geneDescription As String
    Private _modifiers As List(Of IModifier)

    Public Sub New()
        _modifiers = New List(Of IModifier)
    End Sub

    Public Sub New(geneValue As Integer, geneCode As String, geneNumberOfArgs As Integer, geneDescription As String)
        _geneValue = geneValue
        _geneCode = geneCode
        _geneNumberOfArgs = geneNumberOfArgs
        _geneDescription = geneDescription
        _modifiers = New List(Of IModifier)
    End Sub

    Public Property Value As Integer
        Get
            Return _geneValue
        End Get
        Set(value As Integer)
            _geneValue = value
        End Set
    End Property

    Public Property Code As String
        Get
            Return _geneCode
        End Get
        Set(value As String)
            _geneCode = value
        End Set
    End Property

    Public Property NumberOfArgs As Integer
        Get
            Return _geneNumberOfArgs
        End Get
        Set(value As Integer)
            _geneNumberOfArgs = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return _geneDescription
        End Get
        Set(value As String)
            _geneDescription = value
        End Set
    End Property

    Public Property Modifiers As List(Of IModifier)
        Get
            Return _modifiers
        End Get
        Set(value As List(Of IModifier))
            _modifiers = value
        End Set
    End Property

#Region "IXMLSerializable"

    Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml

        Dim modifiers_serializer As New XmlSerializer(GetType(Evolution.Modifier.ModifierBaseImpl))
        Dim modifierFactory As New ModifierFactoryImpl()

        reader.ReadStartElement()
        reader.MoveToContent()
        Me.Value = reader.ReadElementContentAsInt
        Me.Code = reader.ReadElementContentAsString
        Me.NumberOfArgs = reader.ReadElementContentAsInt
        Me.Description = reader.ReadElementContentAsString
        Dim was_empty As Boolean = reader.IsEmptyElement
        reader.ReadStartElement("Modifiers")
        If Not was_empty Then
            Do While reader.NodeType <> Xml.XmlNodeType.EndElement
                Dim modifier As IModifier

                If Not reader.IsEmptyElement Then
                    reader.ReadStartElement()
                    reader.MoveToContent()
                    modifier = modifierFactory.XmlDeserializeModifier(reader)
                Else
                    modifier = modifierFactory.NewModifier()
                End If
                reader.ReadEndElement()
                Me.Modifiers.Add(modifier)
                reader.MoveToContent()
            Loop
            reader.ReadEndElement()
        End If
    End Sub

    Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
        writer.WriteStartElement("GeneInfo")

        writer.WriteElementString("Value", Value.ToString)
        writer.WriteElementString("Code", Code)
        writer.WriteElementString("NumberOfArgs", NumberOfArgs.ToString)
        writer.WriteElementString("Description", Description)

        writer.WriteStartElement("Modifiers")
        Dim modifierFactory As New ModifierFactoryImpl()

        For Each currModifier In Me.Modifiers
            currModifier.WriteXml(writer)
        Next
        writer.WriteEndElement()

        writer.WriteEndElement()
    End Sub

    <ExcludeFromCodeCoverage()>
    Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
        Return Nothing
    End Function

#End Region

End Class
