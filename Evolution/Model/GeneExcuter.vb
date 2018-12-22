Imports Evolution

Public Class GeneExcuter

    Private _geneInfoProvider As IGeneInfoProvider
    Private _creature As Creature
    Private _geneInfo As GeneInfo
    Private _currGeneCounter As Integer
    Private _currModifier As IModifier

    Public Sub New(geneInfoProvider As IGeneInfoProvider)
        _geneInfoProvider = geneInfoProvider
    End Sub

    Public Sub ExecuteCurrentGeneCode(ByRef creature As Creature)
        _creature = creature
        _currGeneCounter = creature(ICreatureDataDefinitions.CreatureData.GeneCounter)
        _geneInfo = _geneInfoProvider.GetGeneInfoByGeneValue(_creature.Gene(_currGeneCounter))
        For Each modifier As IModifier In _geneInfo.Modifiers
            _currModifier = modifier
            HandleCurrentModifier()
            _currGeneCounter += 1
        Next
        creature(ICreatureDataDefinitions.CreatureData.GeneCounter) = _currGeneCounter
    End Sub

    Private Sub HandleCurrentModifier()
        Dim firstArgValue As Integer = GetValueByReferenceType(_currModifier.FirstArg)
        Dim secondArgValue As Integer = GetValueByReferenceType(_currModifier.SecondArg)
        Dim targetValue As Integer = CalculateValuefromChangeOperator(firstArgValue, secondArgValue)

        SetTargetValueByReferenceType(targetValue)
    End Sub

#Region "Fetch actual values from creature based on Arg-Desciptors"

    Private Function GetValueByReferenceType(ByRef modifierAddress As IModifierAddress) As Integer

        Dim returnval As Integer = 0

        Select Case modifierAddress.ReferenceType
            Case IModifierAddress.ReferenceTypeValue.Absolute
                returnval = modifierAddress.ReferenceInteger
            Case IModifierAddress.ReferenceTypeValue.Relative
                returnval = GetValueFromCreatureByReferenceString(modifierAddress)
            Case IModifierAddress.ReferenceTypeValue.Indirect
                Dim index As Integer = GetValueFromCreatureByReferenceString(modifierAddress)
                returnval = GetValueFromCreatureGene(index)
            Case Else
                returnval = 0
        End Select

        Return returnval

    End Function

    Private Sub SetTargetValueByReferenceType(newTargetValue As Integer)
        Select Case _currModifier.Target.ReferenceType
            Case IModifierAddress.ReferenceTypeValue.Absolute
                'do Nothing!
            Case IModifierAddress.ReferenceTypeValue.Indirect
                Dim index As Integer = GetValueFromCreatureByReferenceString(_currModifier.Target)
                SetValueFromCreatureGene(index, newTargetValue)
            Case IModifierAddress.ReferenceTypeValue.Relative
                SetValueInCreatureByReferenceString(newTargetValue)
            Case Else
                'Do Nothing?
        End Select
    End Sub

    ' TODO: Refactor this!
    Private Sub SetValueInCreatureByReferenceString(newTargetValue As Integer)
        If _creature.ContainsKey(_currModifier.Target.ReferenceString) Then
            _creature(_currModifier.Target.ReferenceString) = newTargetValue
        ElseIf _currModifier.Target.ReferenceString = ICreatureDataDefinitions.CreatureData.GeneCode Then
            _currGeneCounter += 1
            SetValueFromCreatureGene(_currGeneCounter, newTargetValue)
        ElseIf _currModifier.Target.ReferenceString <> ICreatureDataDefinitions.CreatureData.Undefined Then
            _creature.Add(_currModifier.Target.ReferenceString, newTargetValue)
        End If
    End Sub

    Private Function GetValueFromCreatureByReferenceString(ByRef arg As IModifierAddress) As Integer
        Dim returnVal As Integer = 0
        If _creature.ContainsKey(arg.ReferenceString) Then
            returnVal = _creature(arg.ReferenceString)
        ElseIf arg.ReferenceString = ICreatureDataDefinitions.CreatureData.GeneCode Then
            _currGeneCounter += 1
            returnVal = GetValueFromCreatureGene(_currGeneCounter)
        ElseIf arg.ReferenceString <> ICreatureDataDefinitions.CreatureData.Undefined Then
            _creature.Add(arg.ReferenceString, 0)
            returnVal = _creature(arg.ReferenceString)
        End If
        Return returnVal
    End Function

    Private Sub SetValueFromCreatureGene(index As Integer, newTargetValue As Integer)
        index = index Mod _creature.Gene.Count
        _creature.Gene(index) = newTargetValue
    End Sub

    Private Function GetValueFromCreatureGene(ByVal index As Integer)
        index = index Mod _creature.Gene.Count
        Return _creature.Gene(index)
    End Function

    Private Function CalculateValuefromChangeOperator(firstArgValue As Integer, secondArgValue As Integer) As Integer
        Dim returnVal As Integer

        Select Case _currModifier.ChangeOperator
            Case ICreatureDataDefinitions.ChangeOperator.Add
                returnVal = firstArgValue + secondArgValue
            Case ICreatureDataDefinitions.ChangeOperator.Subtract
                returnVal = firstArgValue - secondArgValue
            Case Else
                returnVal = 0
        End Select

        Return returnVal

    End Function

#End Region

End Class
