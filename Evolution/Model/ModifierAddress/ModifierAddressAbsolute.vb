Public Class ModifierAddressAbsolute
    Inherits ModifierAddressBaseImpl

    Public Overrides ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue
        Get
            Return IModifierAddress.ReferenceTypeValue.Absolute
        End Get
    End Property

    Public Overrides Function GetValueByReferenceType(ByRef creature As Creature) As Integer
        Return ReferenceInteger
    End Function

End Class
