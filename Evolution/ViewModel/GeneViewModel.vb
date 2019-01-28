Imports System.Collections.ObjectModel

Public Class GeneViewModel
    Inherits BindableBase

    Private _index As Integer
    Private _geneInfo As GeneInfo
    Private _selectedGeneCodeComboBoxIsopen As Boolean
    Private _geneInfoProvider As GeneInfoProviderImpl
    Private _randomStringAndUIDGenerator As RandomStringAndUidGenerator

    Public Sub New(ByVal randomStringAndUidGenerator As RandomStringAndUidGenerator)
        _geneInfoProvider = New GeneInfoProviderImpl()
        _index = 0
        _geneInfo = New GeneInfo()
        _randomStringAndUIDGenerator = randomStringAndUidGenerator
    End Sub

    Public Sub New(ByVal index As Integer)
        _geneInfoProvider = New GeneInfoProviderImpl()
        _index = index
        _geneInfo = New GeneInfo(_index, _randomStringAndUIDGenerator.RandomString(4), _randomStringAndUIDGenerator.RandomNumberString(1), _randomStringAndUIDGenerator.RandomString(15))
    End Sub

    Public Sub New(ByVal index As Integer, ByVal geneInfo As GeneInfo)
        _index = index
        _geneInfoProvider = New GeneInfoProviderImpl()
        If geneInfo IsNot Nothing Then
            _geneInfo = _geneInfoProvider.CloneGeneInfo(geneInfo)
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
            MyBase.SetProperty(Of Boolean)(_selectedGeneCodeComboBoxIsopen, value, "SelectedGeneCodeComboBoxIsOpen")
        End Set
    End Property

    Public ReadOnly Property FilteredCodeList As Collection(Of String)
        Get
            Return _geneInfoProvider.GetAllMatchingCodeNames(_geneInfo.Code)
        End Get
    End Property

End Class
