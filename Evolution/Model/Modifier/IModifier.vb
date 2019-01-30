Imports System.Diagnostics.CodeAnalysis
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Evolution.ModifierAddress

Namespace Modifier

    Public Interface IModifier
        Inherits IXmlSerializable

        Enum ModifierOperator
            Undefined
            Add
            Subtract
        End Enum

        ReadOnly Property ChangeOperator As IModifier.ModifierOperator
        Property Target As IModifierAddress
        Property FirstArg As IModifierAddress
        Property SecondArg As IModifierAddress

    End Interface

End Namespace
