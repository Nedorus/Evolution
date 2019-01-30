Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Evolution
Imports Evolution.ModifierAddress
Imports Evolution.Modifier

Namespace Modifier

    Public Class ModifierAdd
        Inherits ModifierBaseImpl

        Public Overrides ReadOnly Property ChangeOperator As IModifier.ModifierOperator
            Get
                Return IModifier.ModifierOperator.Add
            End Get
        End Property

    End Class

End Namespace
