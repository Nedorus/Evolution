Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Evolution

Namespace ModifierAddress

    Public MustInherit Class ModifierAddressBaseImpl
        Implements IModifierAddress

        Private _referenceInteger As Integer
        Private _referenceCreatureData As ICreatureDataDefinitions.CreatureData


        Public MustOverride ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue Implements IModifierAddress.ReferenceType

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

        <ExcludeFromCodeCoverage()>
        Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
            'empty because parent object (Modiefier) has to implement the reading due to polymorphism
        End Sub

        Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
            writer.WriteStartElement("ModifierAddress")
            writer.WriteElementString("ReferenceType", [Enum].GetName(GetType(IModifierAddress.ReferenceTypeValue), Me.ReferenceType))
            writer.WriteElementString("ReferenceInteger", _referenceInteger)
            writer.WriteElementString("ReferenceCreatureData", [Enum].GetName(GetType(ICreatureDataDefinitions.CreatureData), _referenceCreatureData))
            writer.WriteEndElement()
        End Sub

        <ExcludeFromCodeCoverage()>
        Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
            Throw New NotImplementedException()
        End Function

#End Region



    End Class

End Namespace
