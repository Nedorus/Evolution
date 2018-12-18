Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Public Interface IModifier
    Inherits IXmlSerializable

    Property ChangeOperator As String
    Property Target As String
    Property FirstArg As String
    Property SecondArg As String





End Interface
