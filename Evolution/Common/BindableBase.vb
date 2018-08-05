Imports System
Imports System.ComponentModel
Imports System.Diagnostics.CodeAnalysis
Imports System.Linq.Expressions
Imports System.Runtime.CompilerServices

Public MustInherit Class BindableBase
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Function SetProperty(Of T)(ByRef storage As T, ByVal value As T, <CallerMemberName> ByVal Optional propertyName As String = Nothing) As Boolean
        If Object.Equals(storage, value) Then Return False
        storage = value
        OnPropertyChanged(propertyName)
        Return True
    End Function

    Protected Sub OnPropertyChanged(<CallerMemberName> ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class