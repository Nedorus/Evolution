Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Evolution

Public Class ModifierAddress
    Implements IModifierAddress

    Private _referenceType As IModifierAddress.ReferenceTypeValue
    Private _referenceInteger As Integer
    Private _referenceString As ICreatureDataDefinitions.CreatureData

    Public Sub New()
        _referenceInteger = 0
        _referenceString = ICreatureDataDefinitions.CreatureData.Undefined
        _referenceType = IModifierAddress.ReferenceTypeValue.Undefined
    End Sub

    Public Sub New(ByVal referenceType As IModifierAddress.ReferenceTypeValue, ByVal referenceInteger As Integer, ByVal referenceString As ICreatureDataDefinitions.CreatureData)
        _referenceType = referenceType
        _referenceInteger = referenceInteger
        _referenceString = referenceString
    End Sub

    Public Property ReferenceType As IModifierAddress.ReferenceTypeValue Implements IModifierAddress.ReferenceType
        Get
            Return _referenceType
        End Get
        Set(value As IModifierAddress.ReferenceTypeValue)
            _referenceType = value
        End Set
    End Property

    Public Property ReferenceInteger As Integer Implements IModifierAddress.ReferenceInteger
        Get
            Return _referenceInteger
        End Get
        Set(value As Integer)
            _referenceInteger = value
        End Set
    End Property

    Public Property ReferenceString As ICreatureDataDefinitions.CreatureData Implements IModifierAddress.ReferenceString
        Get
            Return _referenceString
        End Get
        Set(value As ICreatureDataDefinitions.CreatureData)
            _referenceString = value
        End Set
    End Property

#Region "IXMLSerializable"

    Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
        reader.ReadStartElement()
        reader.MoveToContent()
        Me.ReferenceType = DirectCast([Enum].Parse(GetType(IModifierAddress.ReferenceTypeValue), reader.ReadElementContentAsString), IModifierAddress.ReferenceTypeValue)
        Me.ReferenceInteger = reader.ReadElementContentAsInt
        Dim was_empty As Boolean = reader.IsEmptyElement
        If Not was_empty Then
            Me.ReferenceString = DirectCast([Enum].Parse(GetType(ICreatureDataDefinitions.CreatureData), reader.ReadElementContentAsString), ICreatureDataDefinitions.CreatureData)
        Else
            Me.ReferenceString = ICreatureDataDefinitions.CreatureData.Undefined
            reader.ReadElementContentAsString()
        End If
    End Sub

    Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
        If writer IsNot Nothing Then
            writer.WriteStartElement("ModifierAddress")

            writer.WriteElementString("ReferenceType", [Enum].GetName(GetType(IModifierAddress.ReferenceTypeValue), _referenceType))
            writer.WriteElementString("ReferenceInteger", _referenceInteger)
            writer.WriteElementString("ReferenceString", [Enum].GetName(GetType(ICreatureDataDefinitions.CreatureData), _referenceString))

            writer.WriteEndElement()
        Else
            Dim writerIsNullException As New NullReferenceException("The writer object passed was Nothing!")
            Throw writerIsNullException
        End If
    End Sub

    <ExcludeFromCodeCoverage()>
    Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
        Throw New NotImplementedException()
    End Function

#End Region

End Class
