Public Class GenesListViewDataTemplateSelector
    Inherits DataTemplateSelector

    Private parentListView As ListView

    Public Overrides Function SelectTemplate(item As Object, container As DependencyObject) As DataTemplate

        Dim returnDataTemplate As DataTemplate = Nothing
        Dim currentItem As GeneViewModel = TryCast(item, GeneViewModel)

        parentListView = GetParentByType(TryCast(container, FrameworkElement), GetType(ListView))

        Return GetDataTemplateForHighLightedItems(currentItem)

    End Function

    Private Function GetDataTemplateForHighLightedItems(ByRef currentItem As GeneViewModel) As DataTemplate

        Dim returnDataTemplate As DataTemplate = parentListView.FindResource("regularItem")
        Dim indexOfCurrentItem As Integer = GetIndexOfItem(currentItem)
        Dim indexOfSelectedItem As Integer = parentListView.SelectedIndex
        Dim numberOfArgsToHighlight As Integer = GetSelectedItemNumberOfArgs()

        If indexOfCurrentItem = indexOfSelectedItem Then
            returnDataTemplate = parentListView.FindResource("selectedItem")
        ElseIf indexOfCurrentItem > indexOfSelectedItem AndAlso indexOfCurrentItem <= (indexOfSelectedItem + numberOfArgsToHighlight) Then
            returnDataTemplate = parentListView.FindResource("usedAsDataBySelectedItem")
        Else
            returnDataTemplate = parentListView.FindResource("regularItem")
        End If
        Return returnDataTemplate
    End Function

    Private Function GetIndexOfItem(ByRef geneViewModel As GeneViewModel) As Integer
        Dim returnIndex As Integer = -1
        If parentListView IsNot Nothing Then
            returnIndex = parentListView.Items.IndexOf(geneViewModel)
        End If
        Return returnIndex
    End Function

    Private Function GetSelectedItemNumberOfArgs() As Integer
        Dim currentItem As GeneViewModel = Nothing
        If parentListView IsNot Nothing Then
            currentItem = TryCast(parentListView.SelectedItem, GeneViewModel)
        End If
        If currentItem IsNot Nothing Then
            Return currentItem.NumberOfArgs
        Else
            Return 0
        End If

    End Function

    Private Function IsSomethingSelected() As Boolean
        Return parentListView IsNot Nothing AndAlso parentListView.SelectedIndex > -1
    End Function

    Private Function GetParentByType(ByRef frameWorkElement As FrameworkElement, ByRef type As Type) As DependencyObject

        Dim returnDepObject As DependencyObject

        If frameWorkElement Is Nothing Then
            returnDepObject = Nothing
        ElseIf frameWorkElement.GetType() = type Then
            returnDepObject = frameWorkElement
        Else
            returnDepObject = GetParentByType(VisualTreeHelper.GetParent(frameWorkElement), type)
        End If

        Return returnDepObject

    End Function

End Class
