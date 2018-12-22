Public Class Gene
    Inherits List(Of Integer)

    Private _capacity As Integer

    Public Overloads Property Capacity As Integer
        Get
            Return _capacity
        End Get
        Set(ByVal value As Integer)
            Dim newVal As Integer = Math.Abs(value)
            If newVal < _capacity Then
                RemoveExcessiveContent(newVal)
                _capacity = newVal
            Else
                _capacity = newVal
                AddExtraContent()
            End If
        End Set
    End Property

    Public Sub New(ByVal capacity As Integer)
        _capacity = capacity
        For index = 0 To _capacity - 1
            Me.Add(0)
        Next
    End Sub

    Public Shadows Sub Add(item As Integer)
        If Me.Count >= Me.Capacity Then
            Dim message As String =
                    String.Format("Gene cannot hold more than {0} items", Capacity)
            Throw New InvalidOperationException(message)
        Else
            MyBase.Add(item)
        End If
    End Sub

    Private Sub AddExtraContent()
        While Me.Count < _capacity
            Me.Add(0)
        End While
    End Sub

    Private Sub RemoveExcessiveContent(newCapacity As Integer)
        While Me.Count > newCapacity
            Me.RemoveAt(Me.Count - 1)
        End While
    End Sub

End Class
