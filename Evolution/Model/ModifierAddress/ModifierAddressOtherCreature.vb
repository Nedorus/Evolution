Imports Evolution

Public Class ModifierAddressOtherCreature
    Inherits ModifierAddressBaseImpl

    Public Overrides ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue
        Get
            Return IModifierAddress.ReferenceTypeValue.OtherCreature
        End Get
    End Property


    'TODO define how to access other creatures
    ''' <summary>
    ''' OtherCreature (unfinished Def)
    ''' write a value to another creature If that ceature Is Within a radius smaler than ReferenceInteger
    '''    Undefined -> do nothing
    '''    GeneCode -> returns 1 if otherCreature.geneCode.Equals(thisCreature.GeneCode) else 0
    '''    Other -> returns that value from OtherCreature
    ''' </summary>
    ''' <param name="creature"></param>
    ''' <param name="newValue"></param>
    Public Overrides Sub SetValueByReferenceType(creature As Creature, newValue As Integer)
        'do something cool here?
    End Sub

    'TODO define how to access other creatures
    ''' <summary>
    ''' OtherCreature (unfinished Def)
    ''' returns a value Of another creature If that ceature Is With a radius smaler than ReferenceInteger
    '''    Undefined -> return 0
    '''    GeneCode -> returns 1 if otherCreature.geneCode.Equals(thisCreature.GeneCode) else 0
    '''    Other -> returns that value from OtherCreature
    ''' </summary>
    ''' <param name="creature"></param>
    ''' <returns></returns>
    Public Overrides Function GetValueByReferenceType(ByRef creature As Creature) As Integer
        Return ReferenceInteger
    End Function

End Class
