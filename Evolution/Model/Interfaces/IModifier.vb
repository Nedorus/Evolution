Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Public Interface IModifier
    Inherits IXmlSerializable

    Property ChangeOperator As ICreatureDataDefinitions.ChangeOperator
    Property Target As IModifierAddress
    Property FirstArg As IModifierAddress
    Property SecondArg As IModifierAddress





End Interface
