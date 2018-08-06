Public Class ViewModel
    Inherits BindableBase
    Private _genes As GenesViewModel
    Private _searchText As String
    Private _selectedGeneCodeComboBoxIsopen As Boolean

    Public Sub New()
        MyBase.New()
        _genes = New GenesViewModel()
        _searchText = ""
    End Sub


    Public Property Genes As GenesViewModel
        Get
            Return _genes
        End Get
        Set(value As GenesViewModel)
            MyBase.SetProperty(Of GenesViewModel)(_genes, value, "Genes")
        End Set
    End Property

    Public Property SelectedGeneCodeComboBoxIsOpen As Boolean
        Get
            Return _selectedGeneCodeComboBoxIsopen
        End Get
        Set(value As Boolean)
            MyBase.SetProperty(Of Boolean)(_selectedGeneCodeComboBoxIsopen, value, "SelectedGeneCodeComboBoxIsOpen")
        End Set
    End Property

    'Public Property SearchText As String
    '    Get
    '        Return _searchText
    '    End Get
    '    Set(value As String)
    '        MyBase.SetProperty(Of String)(_searchText, value, "SearchText")
    '        Debug.WriteLine("Current value in ComboBox is {0} " & Me._searchText)
    '        Me.SelectedGeneCodeComboBoxIsOpen = True
    '        MyBase.OnPropertyChanged("FilteredCodeList")
    '    End Set
    'End Property


End Class
