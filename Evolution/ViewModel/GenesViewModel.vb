Imports System.Collections.ObjectModel
Imports System.ComponentModel

Public Class GenesViewModel
    Inherits ObservableCollection(Of GeneViewModel)

    Public Sub New()
        For i = 0 To 255
            Dim randomGeneInfo As GeneInfo = GeneInfoProvider.Instance.GetGeneInfoFromGeneValue(RandomGenerator.Instance.Random.Next(0, 9))
            MyBase.Add(New GeneViewModel(i, randomGeneInfo))
            AddHandler MyBase.Item(i).PropertyChanged, AddressOf MemberPropertyChanged
        Next

    End Sub

    Private Sub MemberPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        MyBase.OnPropertyChanged(e)
    End Sub
End Class
