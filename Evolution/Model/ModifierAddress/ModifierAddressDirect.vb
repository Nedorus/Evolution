Imports Evolution

Namespace ModifierAddress

    Public Class ModifierAddressDirect
        Inherits ModifierAddressBaseImpl

        Public Overrides ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue
            Get
                Return IModifierAddress.ReferenceTypeValue.Direct
            End Get
        End Property

        ''' <summary>
        ''' Direct
        ''' write the value specified by CreatureData (for GeneCode use ReferenceInteger as Index)
        '''    Undefined -> do nothing
        '''    GeneCode -> use GeneCounter as index and set GeneCode there and increase GeneCounter
        '''    Other -> set that value
        ''' </summary>
        ''' <param name="creature"></param>
        Public Overrides Sub SetValueByReferenceType(creature As Creature, newValue As Integer)
            Select Case Me.ReferenceCreatureData
                Case ICreatureDataDefinitions.CreatureData.Undefined
                'do nothing
                Case ICreatureDataDefinitions.CreatureData.GeneCode
                    Dim index As Integer = creature(ICreatureDataDefinitions.CreatureData.GeneCounter)
                    SetValueToCreatureGene(creature, index, newValue)
                    creature(ICreatureDataDefinitions.CreatureData.GeneCounter) += 1
                Case Else
                    creature(Me.ReferenceCreatureData) = newValue
            End Select
        End Sub

        ''' <summary>
        ''' Direct
        ''' returns the value specified by CreatureData (for GeneCode use GeneCounter as Index)
        '''    Undefined -> return 0
        '''    GeneCode -> use GeneCounter as index and increase GeneCounter
        '''    Other -> use that value
        ''' </summary>
        ''' <param name="creature"></param>
        ''' <returns></returns>
        Public Overrides Function GetValueByReferenceType(ByRef creature As Creature) As Integer

            Dim returnVal As Integer = 0

            'Which index is to be used?
            Select Case Me.ReferenceCreatureData
                Case ICreatureDataDefinitions.CreatureData.Undefined
                    returnVal = 0
                Case ICreatureDataDefinitions.CreatureData.GeneCode
                    Dim index As Integer = creature(ICreatureDataDefinitions.CreatureData.GeneCounter)
                    returnVal = GetValueFromCreatureGene(creature, index)
                    creature(ICreatureDataDefinitions.CreatureData.GeneCounter) += 1
                Case Else
                    returnVal = creature(Me.ReferenceCreatureData)
            End Select

            Return returnVal
        End Function

    End Class

End Namespace

