Imports Evolution

Public Class ModifierAddressUndefined
    Inherits ModifierAddressBaseImpl

    Public Overrides ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue
        Get
            Return IModifierAddress.ReferenceTypeValue.Undefined
        End Get
    End Property

    ''' <summary>
    ''' Undefined
    '''  do nothing
    ''' </summary>
    ''' <param name="creature"></param>
    ''' <param name="newValue"></param>
    Public Overrides Sub SetValueByReferenceType(creature As Creature, newValue As Integer)
        'do nothing per Defenition
    End Sub

    ''' <summary>
    ''' Undefined
    '''    return 0
    ''' </summary>
    ''' <param name="creature"></param>
    ''' <returns></returns>
    Public Overrides Function GetValueByReferenceType(ByRef creature As Creature) As Integer
        Return 0
    End Function


End Class
