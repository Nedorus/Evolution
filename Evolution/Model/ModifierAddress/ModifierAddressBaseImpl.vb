Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Evolution

Public MustInherit Class ModifierAddressBaseImpl
    Implements IModifierAddress

    Private _referenceInteger As Integer
    Private _referenceCreatureData As ICreatureDataDefinitions.CreatureData

    Public Sub New()
        _referenceInteger = 0
        _referenceCreatureData = ICreatureDataDefinitions.CreatureData.Undefined
    End Sub

    Public Sub New(ByVal referenceInteger As Integer, ByVal referenceCreatureData As ICreatureDataDefinitions.CreatureData)
        _referenceInteger = referenceInteger
        _referenceCreatureData = referenceCreatureData
    End Sub

    Public Overridable ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue Implements IModifierAddress.ReferenceType
        Get
            Return IModifierAddress.ReferenceTypeValue.Undefined
        End Get
    End Property


    Public Overridable Property ReferenceInteger As Integer Implements IModifierAddress.ReferenceInteger
        Get
            Return _referenceInteger
        End Get
        Set(value As Integer)
            _referenceInteger = value
        End Set
    End Property

    Public Overridable Property ReferenceCreatureData As ICreatureDataDefinitions.CreatureData Implements IModifierAddress.ReferenceCreatureData
        Get
            Return _referenceCreatureData
        End Get
        Set(value As ICreatureDataDefinitions.CreatureData)
            _referenceCreatureData = value
        End Set
    End Property

    Public MustOverride Function GetValueByReferenceType(ByRef creature As Creature) As Integer Implements IModifierAddress.GetValueByReferenceType

#Region "IXMLSerializable"

    Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
        reader.ReadStartElement()
        reader.MoveToContent()
        'Me.ReferenceType = DirectCast([Enum].Parse(GetType(IModifierAddress.ReferenceTypeValue), reader.ReadElementContentAsString), IModifierAddress.ReferenceTypeValue)
        Me.ReferenceInteger = reader.ReadElementContentAsInt
        Dim was_empty As Boolean = reader.IsEmptyElement
        If Not was_empty Then
            Me.ReferenceCreatureData = DirectCast([Enum].Parse(GetType(ICreatureDataDefinitions.CreatureData), reader.ReadElementContentAsString), ICreatureDataDefinitions.CreatureData)
        Else
            Me.ReferenceCreatureData = ICreatureDataDefinitions.CreatureData.Undefined
            reader.ReadElementContentAsString()
        End If
    End Sub

    Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
        If writer IsNot Nothing Then
            writer.WriteStartElement("ModifierAddressAbsolute")

            writer.WriteElementString("ReferenceInteger", _referenceInteger)
            writer.WriteElementString("ReferenceCreatureData", [Enum].GetName(GetType(ICreatureDataDefinitions.CreatureData), _referenceCreatureData))

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
