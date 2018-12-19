Imports System.Diagnostics.CodeAnalysis

Public Class Creature
    Private _gene As Gene
    Private _geneCounter As Integer
    Private _Position As Point

    Public Sub New()
        _gene = New Gene()
        _geneCounter = 0
        _Position = New Point(0, 0)
    End Sub

    Public Sub New(ByVal gene As Gene, Optional ByVal geneCounter As Integer = 0, Optional ByVal position As Point = Nothing)
        _gene = gene
        _geneCounter = geneCounter
        If position = Nothing Then
            _Position = New Point(0, 0)
        Else
            _Position = position
        End If
    End Sub

    <ExcludeFromCodeCoverage()>
    Public Property Gene As Gene
        Get
            Return _gene
        End Get
        Set(value As Gene)
            _gene = value
        End Set
    End Property

    <ExcludeFromCodeCoverage()>
    Public Property GeneCounter As Integer
        Get
            Return _geneCounter
        End Get
        Set(value As Integer)
            _geneCounter = value
        End Set
    End Property

    <ExcludeFromCodeCoverage()>
    Public Property Position As Point
        Get
            Return _Position
        End Get
        Set(value As Point)
            _Position = value
        End Set
    End Property

End Class
