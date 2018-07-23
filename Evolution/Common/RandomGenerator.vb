Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Diagnostics.CodeAnalysis

<ExcludeFromCodeCoverage()>
Public Class RandomGenerator

    Private Shared privInstance As RandomGenerator
    Private Shared privRandom As Random

    Public ReadOnly Property Random As Random
        Get
            Return privRandom
        End Get
    End Property


    Private Sub New()
        privRandom = New Random()
    End Sub

    Public Shared ReadOnly Property Instance As RandomGenerator
        Get
            If privInstance Is Nothing Then
                privInstance = New RandomGenerator()
            End If
            Return privInstance
        End Get
    End Property

End Class
