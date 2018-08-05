Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel

Public Class ItemsChangedObservableCollection(Of T As INotifyPropertyChanged)
    Inherits ObservableCollection(Of T)

    Public Sub New()

    End Sub

    Protected Overrides Sub OnCollectionChanged(e As NotifyCollectionChangedEventArgs)
        Select Case e.Action
            Case NotifyCollectionChangedAction.Add
                RegisterPropertyChanged(e.NewItems)
            Case NotifyCollectionChangedAction.Remove
                UnRegisterPropertyChanged(e.OldItems)
            Case NotifyCollectionChangedAction.Replace
                UnRegisterPropertyChanged(e.OldItems)
                RegisterPropertyChanged(e.NewItems)
            Case Else
                MyBase.OnCollectionChanged(e)
        End Select
        MyBase.OnCollectionChanged(e)
    End Sub

    Protected Sub RegisterPropertyChanged(items As IList(Of T))
        For Each curritem In items
            If curritem IsNot Nothing Then
                AddHandler curritem.PropertyChanged, AddressOf ItemPropertyChanged
            End If
        Next
    End Sub

    Protected Sub UnRegisterPropertyChanged(items As IList(Of T))
        For Each curritem In items
            If curritem IsNot Nothing Then
                RemoveHandler curritem.PropertyChanged, AddressOf ItemPropertyChanged
            End If
        Next
    End Sub

    Private Sub ItemPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        MyBase.OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
    End Sub
End Class
