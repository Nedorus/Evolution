Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Evolution

Public Class Modifier
    Implements IModifier

    Private _changeOperator As IModifier.ModifierOperator
    Private _target As IModifierAddress
    Private _firstArg As IModifierAddress
    Private _secondArg As IModifierAddress

    Public Sub New()
        _changeOperator = IModifier.ModifierOperator.Undefined
        _target = New ModifierAddress()
        _firstArg = New ModifierAddress()
        _secondArg = New ModifierAddress()
    End Sub

    Public Sub New(changeOperator As IModifier.ModifierOperator, target As IModifierAddress, firstArg As IModifierAddress, secondArg As IModifierAddress)
        _changeOperator = changeOperator
        _target = target
        _firstArg = firstArg
        _secondArg = secondArg
    End Sub


    Public Property ChangeOperator As IModifier.ModifierOperator Implements IModifier.ChangeOperator
        Get
            Return _changeOperator
        End Get
        Set(value As IModifier.ModifierOperator)
            _changeOperator = value
        End Set
    End Property

    Public Property Target As IModifierAddress Implements IModifier.Target
        Get
            Return _target
        End Get
        Set(value As IModifierAddress)
            _target = value
        End Set
    End Property

    Public Property FirstArg As IModifierAddress Implements IModifier.FirstArg
        Get
            Return _firstArg
        End Get
        Set(value As IModifierAddress)
            _firstArg = value
        End Set
    End Property

    Public Property SecondArg As IModifierAddress Implements IModifier.SecondArg
        Get
            Return _secondArg
        End Get
        Set(value As IModifierAddress)
            _secondArg = value
        End Set
    End Property

    Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml

        Dim modifierAddress_serializer As New XmlSerializer(GetType(ModifierAddress))

        reader.ReadStartElement()
        reader.MoveToContent()
        Dim was_empty As Boolean = reader.IsEmptyElement
        If Not was_empty Then
            Me.ChangeOperator = DirectCast([Enum].Parse(GetType(IModifier.ModifierOperator), reader.ReadElementContentAsString), IModifier.ModifierOperator)
        Else
            Me.ChangeOperator = IModifier.ModifierOperator.Undefined
            reader.ReadElementContentAsString()
        End If

        'Me.Target = reader.ReadElementContentAsString
        Me.Target = DirectCast(modifierAddress_serializer.Deserialize(reader), ModifierAddress)
        reader.ReadEndElement()

        'Me.FirstArg = reader.ReadElementContentAsString
        Me.FirstArg = DirectCast(modifierAddress_serializer.Deserialize(reader), ModifierAddress)
        reader.ReadEndElement()

        'Me.SecondArg = reader.ReadElementContentAsString
        Me.SecondArg = DirectCast(modifierAddress_serializer.Deserialize(reader), ModifierAddress)
        reader.ReadEndElement()


    End Sub

    Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
        writer.WriteStartElement("Modifier")
        writer.WriteElementString("ChangeOperator", [Enum].GetName(GetType(IModifier.ModifierOperator), Me.ChangeOperator))

        Target.WriteXml(writer)
        FirstArg.WriteXml(writer)
        SecondArg.WriteXml(writer)

        writer.WriteEndElement()
    End Sub

    <ExcludeFromCodeCoverage()>
    Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
        Return Nothing
    End Function
End Class
