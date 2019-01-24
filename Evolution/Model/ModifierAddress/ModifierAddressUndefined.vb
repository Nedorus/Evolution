Public Class ModifierAddressUndefined
    Inherits ModifierAddressBaseImpl

    Public Overrides ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue
        Get
            Return IModifierAddress.ReferenceTypeValue.Undefined
        End Get
    End Property

    Public Overrides Function GetValueByReferenceType(ByRef creature As Creature) As Integer
        Return 0
    End Function

End Class
