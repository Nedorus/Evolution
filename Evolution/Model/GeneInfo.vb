Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports System.Diagnostics.CodeAnalysis

Public Class GeneInfo
    Implements IXmlSerializable

    Private _geneValue As Integer
    Private _geneCode As String
    Private _geneNumberOfArgs As Integer
    Private _geneDescription As String
    Private _geneAction As List(Of Modifier)

    Public Sub New()

    End Sub

    Public Sub New(geneValue As Integer, geneCode As String, geneNumberOfArgs As Integer, geneDescription As String)
        _geneValue = geneValue
        _geneCode = geneCode
        _geneNumberOfArgs = geneNumberOfArgs
        _geneDescription = geneDescription
        _geneAction = New List(Of Modifier)
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

#Region "IXMLSerializable"

    Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
        reader.ReadStartElement()
        reader.MoveToContent()
        Me.Value = reader.ReadElementContentAsInt
        Me.Code = reader.ReadElementContentAsString
        Me.NumberOfArgs = reader.ReadElementContentAsInt
        Me.Description = reader.ReadElementContentAsString
    End Sub

    Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
        writer.WriteElementString("Value", Value.ToString)
        writer.WriteElementString("Code", Code)
        writer.WriteElementString("NumberOfArgs", NumberOfArgs.ToString)
        writer.WriteElementString("Description", Description)
    End Sub

    <ExcludeFromCodeCoverage()>
    Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
        Return Nothing
    End Function

#End Region

End Class
