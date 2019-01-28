Imports Evolution

Public Class ModifierAddressAbsolute
    Inherits ModifierAddressBaseImpl

    Public Overrides ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue
        Get
            Return IModifierAddress.ReferenceTypeValue.Absolute
        End Get
    End Property

    ''' <summary>
    ''' Absolute
    '''   Do nothing
    ''' </summary>
    ''' <param name="creature"></param>
    Public Overrides Sub SetValueByReferenceType(creature As Creature, newValue As Integer)
        'nothinbg to do here
    End Sub

    ''' <summary>
    ''' Absolute
    ''' returns the value given In ReferenceInteger
    '''    ignores CreatureData
    ''' </summary>
    ''' <param name="creature"></param>
    ''' <returns></returns>
    Public Overrides Function GetValueByReferenceType(ByRef creature As Creature) As Integer
        Return ReferenceInteger
    End Function


End Class
