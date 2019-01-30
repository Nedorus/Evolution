Namespace Modifier
    Friend Class ModiefierSubtract
        Inherits ModifierBaseImpl

        Public Overrides ReadOnly Property ChangeOperator As IModifier.ModifierOperator
            Get
                Return IModifier.ModifierOperator.Subtract
            End Get
        End Property
    End Class
End Namespace
