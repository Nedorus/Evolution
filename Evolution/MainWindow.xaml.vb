﻿Class MainWindow
    Private _viewModel As ViewModel
    Private _genesInfo As GeneInfos
    Private _logMessageHandler As LogMessageHNDLR
    Private _oldSelectedGeneIndex As Integer

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        _logMessageHandler = LogMessageHNDLR.Instance
        _logMessageHandler.LogDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6) & "\log\"
        _viewModel = New ViewModel()
        _oldSelectedGeneIndex = -1
        Me.DataContext = Me.ViewModel
        For Each listViewItem As ListViewItem In Me.GenesListView.Items
            listViewItem.DataContext = TryCast(Me.FindResource("regularItem"), DataTemplate)
        Next
    End Sub

    Public Property ViewModel As ViewModel
        Get
            Return _viewModel
        End Get
        Set(value As ViewModel)
            _viewModel = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Logger As LogMessageHNDLR
        Get
            Return _logMessageHandler
        End Get
    End Property

    Private Sub GenesListView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles GenesListView.SelectionChanged

        If IsNewSelectedIndexDifferent(TryCast(sender, ListView)) Then
            RememberNewSelectedIndex(TryCast(sender, ListView))
            GenesListView.ItemTemplateSelector = New GenesListViewDataTemplateSelector()
        End If

    End Sub

    Private Sub SelectedGeneCodeTextBox_TextChanged(sender As Object, e As TextChangedEventArgs)
        Debug.WriteLine("Have Event: " & TryCast(sender, TextBox).Text)
    End Sub

    Private Sub SelectedGeneCodeComboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If TryCast(sender, ComboBox).SelectedIndex >= 0 Then
            Debug.WriteLine("Chose {0}.", TryCast(sender, ComboBox).SelectedValue.ToString)
        Else
            Debug.WriteLine("Chose nothing.")
        End If
    End Sub

    Private Function IsNewSelectedIndexDifferent(ByRef listView As ListView)
        Return listView IsNot Nothing AndAlso listView.SelectedIndex <> _oldSelectedGeneIndex
    End Function

    Private Sub RememberNewSelectedIndex(ByRef listView As ListView)
        If listView IsNot Nothing Then
            _oldSelectedGeneIndex = listView.SelectedIndex
        End If

    End Sub
End Class