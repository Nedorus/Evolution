Class MainWindow
    Private _viewModel As ViewModel
    Private _genesInfo As GeneInfos
    Private _oldSelectedGeneIndex As Integer

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Setup(New ViewModel())

    End Sub


    Friend Sub New(ByRef viewModel As ViewModel)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        Setup(viewModel)
    End Sub

    Public Property ViewModel As ViewModel
        Get
            Return _viewModel
        End Get
        Set(value As ViewModel)
            _viewModel = value
        End Set
    End Property

    Private Sub GenesListView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles GenesListView.SelectionChanged

        If IsNewSelectedIndexDifferent(TryCast(sender, ListView)) Then
            RememberNewSelectedIndex(TryCast(sender, ListView))
            GenesListView.ItemTemplateSelector = New GenesListViewDataTemplateSelector()
        End If

    End Sub

    Private Sub SelectedGeneCodeTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)

    End Sub

    Private Sub SelectedGeneCodeComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)

    End Sub

    Private Function IsNewSelectedIndexDifferent(ByRef listView As ListView)
        Return listView IsNot Nothing AndAlso listView.SelectedIndex <> _oldSelectedGeneIndex
    End Function

    Private Sub RememberNewSelectedIndex(ByRef listView As ListView)
        If listView IsNot Nothing Then
            _oldSelectedGeneIndex = listView.SelectedIndex
        End If

    End Sub

    Private Sub Setup(viewModel As ViewModel)
        If viewModel IsNot Nothing Then
            _viewModel = viewModel
        Else
            _viewModel = New ViewModel
        End If
        _oldSelectedGeneIndex = -1
        Me.DataContext = Me.ViewModel
        For Each listViewItem As ListViewItem In Me.GenesListView.Items
            listViewItem.DataContext = TryCast(Me.FindResource("regularItem"), DataTemplate)
        Next
        Dim geneInfoProvider As New GeneInfoProviderImpl()
        System.Console.WriteLine("DEBUG - Start")
        System.Console.WriteLine("Count:" & geneInfoProvider.GeneInfos.Count())
        System.Console.WriteLine("DEBUG - Stop")

        Me.ViewModel.Genes.Add(New GeneViewModel(0))
        Me.ViewModel.Genes.Add(New GeneViewModel(1))
        Me.ViewModel.Genes.Add(New GeneViewModel(2))
        Me.ViewModel.Genes.Add(New GeneViewModel(3))
        Me.ViewModel.Genes.Add(New GeneViewModel(40))
        Me.ViewModel.Genes.Add(New GeneViewModel(41))
        Me.ViewModel.Genes.Add(New GeneViewModel(42))
        Me.ViewModel.Genes.Add(New GeneViewModel(43))
    End Sub

End Class
