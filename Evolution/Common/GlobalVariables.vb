Public Class GlobalVariables

    Private Shared _instance As GlobalVariables = Nothing
    Private _random As Random

    Private Sub New()
        _random = New Random()
    End Sub

    Public Shared ReadOnly Property Instance As GlobalVariables
        Get
            If (_instance Is Nothing) Then
                _instance = New GlobalVariables
            End If
            Return _instance
        End Get
    End Property

    Public ReadOnly Property RandomArgNumber As Integer
        Get
            Return _random.Next(1, 4)
        End Get
    End Property

    Public ReadOnly Property GeneDetailsProvider As GeneInfoProvider
        Get
            Return GeneInfoProvider.Instance
        End Get
    End Property


End Class
