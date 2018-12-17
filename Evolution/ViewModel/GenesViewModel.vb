Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class GenesViewModel
    Inherits ItemsChangedObservableCollection(Of GeneViewModel)

    Public Sub New()
        For i = 0 To 255
            Dim randomGeneInfo As GeneInfo = GeneInfoFactory.Instance.GetGeneInfoByGeneValue(RandomGenerator.Instance.Random.Next(0, 9))
        Next

    End Sub

End Class
