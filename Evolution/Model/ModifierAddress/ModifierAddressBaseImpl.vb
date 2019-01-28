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
    Public MustOverride Sub SetValueByReferenceType(creature As Creature, newValue As Integer) Implements IModifierAddress.SetValueByReferenceType

    Protected Function GetValueFromCreatureGene(ByRef creature As Creature, ByVal index As Integer)
        index = index Mod creature.Gene.Count
        Return creature.Gene(index)
    End Function

    Protected Sub SetValueToCreatureGene(ByRef creature As Creature, ByVal index As Integer, newTargetValue As Integer)
        index = index Mod creature.Gene.Count
        creature.Gene(index) = newTargetValue
    End Sub

#Region "IXMLSerializable"

    Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
        'empty because parent object (Modiefier) has to implement the reading due to polymorphism
    End Sub

    Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
        If writer IsNot Nothing Then
            writer.WriteStartElement("ModifierAddress")
            writer.WriteElementString("ReferenceType", [Enum].GetName(GetType(IModifierAddress.ReferenceTypeValue), Me.ReferenceType))
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
