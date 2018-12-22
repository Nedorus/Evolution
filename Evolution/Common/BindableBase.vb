Imports System
Imports System.ComponentModel
Imports System.Diagnostics.CodeAnalysis
Imports System.Linq.Expressions
Imports System.Runtime.CompilerServices


Public MustInherit Class BindableBase
    Implements INotifyPropertyChanged

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Function SetProperty(Of T)(ByRef storage As T, ByVal value As T, <CallerMemberName> ByVal Optional propertyName As String = Nothing) As Boolean
        Dim returnVal As Boolean = False
        If Object.Equals(storage, value) Then
            returnVal = False
        Else
            storage = value
            OnPropertyChanged(propertyName)
            returnVal = True
        End If
        Return returnVal
    End Function

    Public Sub OnPropertyChanged(<CallerMemberName> ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class