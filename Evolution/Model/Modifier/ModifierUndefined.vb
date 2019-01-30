Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Evolution.ModifierAddress

Namespace Modifier
    Friend Class ModifierUndefined
        Inherits ModifierBaseImpl

        Public Overrides ReadOnly Property ChangeOperator As IModifier.ModifierOperator
            Get
                Return IModifier.ModifierOperator.Undefined
            End Get
        End Property

    End Class
End Namespace
