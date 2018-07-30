Public Class GeneViewModel
    Inherits BindableBase

    Private _index As Integer
    Private _geneInfo As GeneInfo
    Private _selectedGeneCodeComboBoxIsopen As Boolean
    Private _randomStringAndUIDGenerator As RandomStringAndUIDGenerator

    Public Sub New(ByVal randomStringAndUIDGenerator As RandomStringAndUIDGenerator)
        _index = 0
        _geneInfo = New GeneInfo()
        _randomStringAndUIDGenerator = randomStringAndUIDGenerator
    End Sub

    Public Sub New(ByRef index As Integer, Optional ByRef geneInfo As GeneInfo = Nothing)
        _index = index
        If geneInfo IsNot Nothing Then
            _geneInfo = GeneInfoProvider.Instance.CloneGeneInfo(geneInfo)
        Else
            _geneInfo = New GeneInfo(_index, _randomStringAndUIDGenerator.RandomString(4), _randomStringAndUIDGenerator.RandomNumberString(1), _randomStringAndUIDGenerator.RandomString(15))
        End If
    End Sub

    Public Property Index As Integer
        Get
            Return _index
        End Get
        Set(value As Integer)
            MyBase.SetProperty(Of Integer)(_index, value, "Index")
        End Set
    End Property

    Public Property Value As Integer
        Get
            Return _geneInfo.Value
        End Get
        Set(value As Integer)
            MyBase.SetProperty(Of Integer)(_geneInfo.Value, value, "Value")
        End Set
    End Property

    Public Property Code As String
        Get
            Return _geneInfo.Code
        End Get
        Set(value As String)
            MyBase.SetProperty(Of String)(_geneInfo.Code, value, "Code")
        End Set
    End Property

    Public Property NumberOfArgs As Integer
        Get
            Return _geneInfo.NumberOfArgs
        End Get
        Set(value As Integer)
            MyBase.SetProperty(Of Integer)(_geneInfo.NumberOfArgs, value, "NumberOfArgs")
        End Set
    End Property

    Public Property Description As String
        Get
            Return _geneInfo.Description
        End Get
        Set(value As String)
            MyBase.SetProperty(Of String)(_geneInfo.Description, value, "Description")
        End Set
    End Property

    Public Property SelectedGeneCodeComboBoxIsopen As Boolean
        Get
            Return _selectedGeneCodeComboBoxIsopen
        End Get
        Set(value As Boolean)
            MyBase.SetProperty(Of Boolean)(_selectedGeneCodeComboBoxIsopen, value, "SelectedGeneCodeComboBoxIsopen")
            Debug.WriteLine("SelectedGeneCodeComboBoxIsopen is open: {0}", _selectedGeneCodeComboBoxIsopen)
        End Set
    End Property

    Public ReadOnly Property FilteredCodeList As List(Of String)
        Get
            Return GeneInfoProvider.Instance.GetAllMatchingCodeNames(_geneInfo.Code)
        End Get
    End Property

End Class
