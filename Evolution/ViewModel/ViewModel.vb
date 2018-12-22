
Imports System.Diagnostics.CodeAnalysis

Public Class ViewModel
    Inherits BindableBase
    Private ReadOnly _genes As GenesViewModel
    Private _selectedGeneCodeComboBoxIsopen As Boolean

    Public Sub New()
        MyBase.New()
        _genes = New GenesViewModel()
        _selectedGeneCodeComboBoxIsopen = False
    End Sub


    <ExcludeFromCodeCoverage()>
    Public ReadOnly Property Genes As GenesViewModel
        Get
            Return _genes
        End Get
        'Set(value As GenesViewModel)
        '    MyBase.SetProperty(Of GenesViewModel)(_genes, value, "Genes")
        'End Set
    End Property

    <ExcludeFromCodeCoverage()>
    Public Property SelectedGeneCodeComboBoxIsOpen As Boolean
        Get
            Return _selectedGeneCodeComboBoxIsopen
        End Get
        Set(value As Boolean)
            MyBase.SetProperty(Of Boolean)(_selectedGeneCodeComboBoxIsopen, value, "SelectedGeneCodeComboBoxIsOpen")
        End Set
    End Property

End Class
