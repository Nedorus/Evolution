Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class GeneralFunctions

    Public Shared Function CleanFileName(ByVal pFileName As String, Optional ByVal pUseFileChars As Boolean = True) As String
        Dim returnString As String = pFileName
        If pFileName Is Nothing OrElse pFileName = "" OrElse pFileName = "0" Then
            returnString = "Unknown"
        End If
        Dim badChars() As Char
        If pUseFileChars Then
            badChars = Path.GetInvalidFileNameChars()
        Else
            badChars = Path.GetInvalidPathChars()
        End If
        For Each currChar In badChars
            returnString = returnString.Replace(CType(currChar, String), "")
        Next
        Return returnString
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsFileNameSafe(ByVal pText As String) As Boolean
        Dim returnVal As Boolean = True

        For Each currChar In Path.GetInvalidPathChars()
            If pText.Contains(CType(currChar, String)) Then
                returnVal = False
                Exit For
            End If
        Next
        For Each currChar In Path.GetInvalidFileNameChars
            If pText.Contains(CType(currChar, String)) Then
                returnVal = False
                Exit For
            End If
        Next

        Return returnVal
    End Function

    ''' <summary>
    ''' Creates a random String consting only of upper case, lower case and number ASCII chars.
    ''' </summary>
    ''' <param name="pLength">The length of the string to be created.</param>
    ''' <returns>random string of length pLength</returns>
    ''' <remarks></remarks>
    Public Shared Function RandomString(ByVal pLength As Integer) As String
        Dim returnString As String = ""

        Dim r As Random = RandomGenerator.Instance.Random()
        Dim charRescourceString As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"

        For i As Integer = 1 To pLength
            Dim rndIndex As Integer = r.Next(0, charRescourceString.Length - 1)
            returnString = returnString & charRescourceString.Substring(rndIndex, 1)
        Next

        Return returnString
    End Function

    Public Shared Function RandomUID(ByVal pLength As Integer) As String
        Dim returnString As String = ""

        Dim r As Random = RandomGenerator.Instance.Random
        Dim charRescourceString As String = "0123456789"

        For i As Integer = 1 To pLength
            Dim rndIndex As Integer = r.Next(0, charRescourceString.Length - 1)
            returnString = returnString & charRescourceString.Substring(rndIndex, 1)
        Next

        Return returnString
    End Function

    Public Shared Function RandomNumber(ByVal pLength As Integer) As String
        Dim returnString As String = ""

        Dim r As Random = RandomGenerator.Instance.Random
        Dim charRescourceString As String = "0123456789"

        For i As Integer = 1 To pLength
            Dim rndIndex As Integer = r.Next(0, charRescourceString.Length - 1)
            returnString = returnString & charRescourceString.Substring(rndIndex, 1)
        Next

        Return returnString
    End Function

    Public Shared Function MD5Hash(ByVal pString As String) As String
        Dim returnString As String = ""

        Dim MD5 As New MD5CryptoServiceProvider
        Dim byteData As Byte()
        Dim byteHash As Byte()
        Dim tmpString As String = ""

        byteData = Encoding.UTF8.GetBytes(pString)
        byteHash = MD5.ComputeHash(byteData)
        For i As Integer = 0 To byteHash.Length - 1
            tmpString = Hex(byteHash(i))
            If Len(tmpString) = 1 Then tmpString = "0" & tmpString
            returnString += tmpString
        Next

        Return returnString
    End Function

End Class
