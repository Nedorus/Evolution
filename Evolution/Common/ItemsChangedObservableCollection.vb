Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel

Public Class ItemsChangedObservableCollection(Of T As INotifyPropertyChanged)
    Inherits ObservableCollection(Of T)

    Public Sub New()

    End Sub

    Protected Overrides Sub OnCollectionChanged(e As NotifyCollectionChangedEventArgs)
        Dim oldItemlist As IList(Of T) = ConvertToIList(e.OldItems)
        Dim newItemlist As IList(Of T) = ConvertToIList(e.NewItems)

        Select Case e.Action
            Case NotifyCollectionChangedAction.Add
                RegisterPropertyChanged(newItemlist)
            Case NotifyCollectionChangedAction.Remove
                UnRegisterPropertyChanged(oldItemlist)
            Case NotifyCollectionChangedAction.Replace
                UnRegisterPropertyChanged(oldItemlist)
                RegisterPropertyChanged(newItemlist)
            Case Else
                MyBase.OnCollectionChanged(e)
        End Select
        MyBase.OnCollectionChanged(e)
    End Sub

    Public Sub RegisterPropertyChanged(items As IList(Of T))
        For Each curritem In items
            AddHandler curritem.PropertyChanged, AddressOf ItemPropertyChanged
        Next
    End Sub

    Public Sub UnRegisterPropertyChanged(items As IList(Of T))
        For Each curritem In items
            RemoveHandler curritem.PropertyChanged, AddressOf ItemPropertyChanged
        Next
    End Sub

    Private Sub ItemPropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
        MyBase.OnCollectionChanged(New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
    End Sub

    Private Function ConvertToIList(sourceList As IList) As IList(Of T)
        If sourceList IsNot Nothing Then
            Dim returnList As IList(Of T) = New List(Of T)

            For Each currItem In sourceList
                If TypeOf currItem Is T Then
                    returnList.Add(currItem)
                End If
            Next
            Return returnList
        Else
            Return Nothing
        End If
    End Function

End Class
