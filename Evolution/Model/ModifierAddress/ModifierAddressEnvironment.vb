Imports Evolution

Public Class ModifierAddressEnvironment
    Inherits ModifierAddressBaseImpl

    Public Overrides ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue
        Get
            Return IModifierAddress.ReferenceTypeValue.Environment
        End Get
    End Property

    'TODO define how the World works
    ''' <summary>
    ''' Environment (unfinished Def)
    ''' write to world depending On CreatureData
    '''    Undefined, XPosition, YPosition, GeneCode, GeneCounter  -> do nothing
    '''    Other -> write that value to the world
    ''' </summary>
    ''' <param name="creature"></param>
    ''' <param name="newValue"></param>
    Public Overrides Sub SetValueByReferenceType(creature As Creature, newValue As Integer)
        'do something cool here?
    End Sub

    'TODO define how the World works
    ''' <summary>
    ''' Environment (unfinished Def)
    ''' returns the value stored In the world depending On CreatureData
    '''    Undefined, XPosition, YPosition -> return 0
    '''    GeneCode, GeneCounter -> return this creatures index/id
    '''    Other -> return that value from world
    ''' </summary>
    ''' <param name="creature"></param>
    ''' <returns></returns>
    Public Overrides Function GetValueByReferenceType(ByRef creature As Creature) As Integer
        Dim returnVal As Integer = 0
        Select Case Me.ReferenceCreatureData
            Case ICreatureDataDefinitions.CreatureData.Undefined, ICreatureDataDefinitions.CreatureData.XPosition, ICreatureDataDefinitions.CreatureData.YPosition
                returnVal = 0
            Case ICreatureDataDefinitions.CreatureData.GeneCode, ICreatureDataDefinitions.CreatureData.GeneCounter
                'returnVal = creature.GetWorld().GetCreatureIndex()
            Case Else
                'Dim world As World = creature.GetWorld().GetEnvironmentValue(creature, Me.ReferenceCreatureData)
        End Select

        Return ReferenceInteger
    End Function

End Class
