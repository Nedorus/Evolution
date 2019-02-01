Imports Evolution

Namespace ModifierAddress

    Public Class ModifierAddressIndirect
        Inherits ModifierAddressBaseImpl

        Public Overrides ReadOnly Property ReferenceType As IModifierAddress.ReferenceTypeValue
            Get
                Return IModifierAddress.ReferenceTypeValue.Indirect
            End Get
        End Property

        ''' <summary>
        ''' Indirect
        ''' write to GenCode using an index depending On CreatureData
        '''    Undefined -> use 0 as index
        '''    GeneCode -> use value found in GeneCode at index GeneCounter as index and increase GeneCounter
        '''    GeneCounter -> use that value as index and increase GeneCounter
        '''    Other -> use that value as index
        ''' </summary>
        ''' <param name="creature"></param>
        ''' <param name="newValue"></param>
        Public Overrides Sub SetValueByReferenceType(creature As Creature, newValue As Integer)

            Dim index As Integer = 0

            Select Case Me.ReferenceCreatureData
                Case ICreatureDataDefinitions.CreatureData.Undefined
                    index = 0
                Case ICreatureDataDefinitions.CreatureData.GeneCode
                    index = creature(ICreatureDataDefinitions.CreatureData.GeneCounter)
                    index = GetValueFromCreatureGene(creature, index)
                    creature(ICreatureDataDefinitions.CreatureData.GeneCounter) += 1
                Case ICreatureDataDefinitions.CreatureData.GeneCounter
                    index = creature(ICreatureDataDefinitions.CreatureData.GeneCounter)
                    creature(ICreatureDataDefinitions.CreatureData.GeneCounter) += 1
                Case Else
                    index = creature(Me.ReferenceCreatureData)
            End Select

            ' now go indirect
            SetValueToCreatureGene(creature, index, newValue)
        End Sub

        ''' <summary>
        ''' Indirect
        ''' returns the GeneCode value Using an index stored In GeneCode at an Index depending On CreatureData
        '''    Undefined -> use 0 as index
        '''    GeneCode -> use value found in GeneCode at index GeneCounter as index and increase GeneCounter
        '''    GeneCounter -> use that value as index and increase GeneCounter and increase GeneCounter
        '''    Other -> use that value as index
        ''' </summary>
        ''' <param name="creature"></param>
        ''' <returns></returns>
        Public Overrides Function GetValueByReferenceType(ByRef creature As Creature) As Integer

            Dim returnVal As Integer = 0
            Dim index As Integer = 0

            'Which index is to be used?
            Select Case Me.ReferenceCreatureData
                Case ICreatureDataDefinitions.CreatureData.Undefined
                    index = 0
                Case ICreatureDataDefinitions.CreatureData.GeneCode
                    index = creature(ICreatureDataDefinitions.CreatureData.GeneCounter)
                    index = GetValueFromCreatureGene(creature, index)
                    creature(ICreatureDataDefinitions.CreatureData.GeneCounter) += 1
                Case ICreatureDataDefinitions.CreatureData.GeneCounter
                    index = creature(ICreatureDataDefinitions.CreatureData.GeneCounter)
                    creature(ICreatureDataDefinitions.CreatureData.GeneCounter) += 1
                Case Else
                    index = creature(Me.ReferenceCreatureData)
            End Select

            ' now go indirect
            returnVal = GetValueFromCreatureGene(creature, index)
            Return returnVal

        End Function

    End Class

End Namespace

