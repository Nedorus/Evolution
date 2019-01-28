Imports Evolution

Public Class GeneExcuter

    Private _geneInfoProvider As IGeneInfoProvider
    Private _creature As Creature
    Private _geneInfo As GeneInfo
    Private _currModifier As IModifier

    Public Sub New(geneInfoProvider As IGeneInfoProvider)
        _geneInfoProvider = geneInfoProvider
    End Sub

    Public Sub ExecuteCurrentGeneCode(ByRef creature As Creature)
        _creature = creature
        _geneInfo = _geneInfoProvider.GetGeneInfoByGeneValue(_creature.Gene(_creature(ICreatureDataDefinitions.CreatureData.GeneCounter)))
        _creature(ICreatureDataDefinitions.CreatureData.GeneCounter) += 1
        For Each modifier As IModifier In _geneInfo.Modifiers
            _currModifier = modifier
            HandleCurrentModifier()
        Next
    End Sub

    Private Sub HandleCurrentModifier()
        Dim firstArgValue As Integer = _currModifier.FirstArg.GetValueByReferenceType(_creature)
        Dim secondArgValue As Integer = _currModifier.SecondArg.GetValueByReferenceType(_creature)
        Dim targetValue As Integer = CalculateValuefromChangeOperator(firstArgValue, secondArgValue)

        _currModifier.Target.SetValueByReferenceType(_creature, targetValue)
    End Sub

#Region "Fetch actual values from creature based on Arg-Desciptors"

    Private Function CalculateValuefromChangeOperator(firstArgValue As Integer, secondArgValue As Integer) As Integer
        Dim returnVal As Integer

        Select Case _currModifier.ChangeOperator
            Case IModifier.ModifierOperator.Add
                returnVal = firstArgValue + secondArgValue
            Case IModifier.ModifierOperator.Subtract
                returnVal = firstArgValue - secondArgValue
            Case Else
                returnVal = 0
        End Select

        Return returnVal

    End Function

#End Region

End Class
