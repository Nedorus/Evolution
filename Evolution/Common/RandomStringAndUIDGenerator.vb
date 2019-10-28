Imports System.IO


Public Class RandomStringAndUidGenerator

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
        Dim charRescourceString As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"

        Return RandomString(pLength, charRescourceString)

    End Function

    Public Function RandomString(ByVal pLength As Integer, ByVal pCandicatesToChooseFrom As String) As String
        Dim returnString As New System.Text.StringBuilder
        Dim charRescourceString As String = pCandicatesToChooseFrom

        For i As Integer = 1 To pLength
            Dim rndIndex As Integer = _random.Next(0, charRescourceString.Length - 1)
            returnString.Append(charRescourceString.Substring(rndIndex, 1))
        Next

        Return returnString.ToString()
    End Function


    Public Function RandomUID(ByVal pLength As Integer) As String
        Dim charRescourceString As String = "0123456789"

        Return RandomString(pLength, charRescourceString)

    End Function

    Public Function RandomNumberString(ByVal pLength As Integer) As String
        Dim charRescourceString As String = "0123456789"

        Return RandomString(pLength, charRescourceString)

    End Function

    Public Function RandomNumber(ByVal pMax As Integer) As Integer
        Return _random.Next(0, pMax)
    End Function

End Class
