Imports System.IO


Public Class RandomStringAndUIDGenerator

    Private _random As Random

    Public Sub New(random As Random)
        _random = random
    End Sub


    ''' <summary>
    ''' Creates a random String consting only of upper case, lower case and number ASCII chars.
    ''' </summary>
    ''' <param name="pLength">The length of the string to be created.</param>
    ''' <returns>random string of length pLength</returns>
    ''' <remarks></remarks>
    Public Function RandomString(ByVal pLength As Integer) As String
        Dim returnString As String = ""
        Dim charRescourceString As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"

        For i As Integer = 1 To pLength
            Dim rndIndex As Integer = _random.Next(0, charRescourceString.Length - 1)
            returnString = returnString & charRescourceString.Substring(rndIndex, 1)
        Next

        Return returnString
    End Function

    Public Function RandomUID(ByVal pLength As Integer) As String
        Dim returnString As String = ""
        Dim charRescourceString As String = "0123456789"

        For i As Integer = 1 To pLength
            Dim rndIndex As Integer = _random.Next(0, charRescourceString.Length - 1)
            returnString = returnString & charRescourceString.Substring(rndIndex, 1)
        Next

        Return returnString
    End Function

    Public Function RandomNumber(ByVal pLength As Integer) As String
        Dim returnString As String = ""
        Dim charRescourceString As String = "0123456789"

        For i As Integer = 1 To pLength
            Dim rndIndex As Integer = _random.Next(0, charRescourceString.Length - 1)
            returnString = returnString & charRescourceString.Substring(rndIndex, 1)
        Next

        Return returnString
    End Function

End Class
