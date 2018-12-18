Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Evolution

Public Class Modifier
    Implements IModifier

    Private _changeOperator As String
    Private _target As String
    Private _firstArg As String
    Private _secondArg As String

    Public Sub New()

    End Sub

    Public Sub New(changeOperator As String, target As String, firstArg As String, secondArg As String)
        _changeOperator = changeOperator
        _target = target
        _firstArg = firstArg
        _secondArg = secondArg
    End Sub


    Public Property ChangeOperator As String Implements IModifier.ChangeOperator
        Get
            Return _changeOperator
        End Get
        Set(value As String)
            _changeOperator = value
        End Set
    End Property

    Public Property Target As String Implements IModifier.Target
        Get
            Return _target
        End Get
        Set(value As String)
            _target = value
        End Set
    End Property

    Public Property FirstArg As String Implements IModifier.FirstArg
        Get
            Return _firstArg
        End Get
        Set(value As String)
            _firstArg = value
        End Set
    End Property

    Public Property SecondArg As String Implements IModifier.SecondArg
        Get
            Return _secondArg
        End Get
        Set(value As String)
            _secondArg = value
        End Set
    End Property

    Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
        reader.ReadStartElement()
        reader.MoveToContent()
        Me.ChangeOperator = reader.ReadElementContentAsString
        Me.Target = reader.ReadElementContentAsString
        Me.FirstArg = reader.ReadElementContentAsString
        Me.SecondArg = reader.ReadElementContentAsString
    End Sub

    Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
        writer.WriteElementString("ChangeOperator", ChangeOperator)
        writer.WriteElementString("Target", Target)
        writer.WriteElementString("FirstArg", FirstArg)
        writer.WriteElementString("SecondArg", SecondArg)
    End Sub

    <ExcludeFromCodeCoverage()>
    Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
        Return Nothing
    End Function
End Class
