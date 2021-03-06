﻿Imports System.Security.Cryptography
Imports System.Text

Public Class MD5StringHasher

    Private _md5 As MD5CryptoServiceProvider

    Public Sub New(ByVal md5 As MD5CryptoServiceProvider)
        _md5 = md5
    End Sub

    Public Function HashUsingMD5(ByVal pString As String) As String
        Dim returnString As New System.Text.StringBuilder

        Dim byteData As Byte()
        Dim byteHash As Byte()
        Dim tmpString As String = ""

        byteData = Encoding.UTF8.GetBytes(pString)
        byteHash = _md5.ComputeHash(byteData)
        For i As Integer = 0 To byteHash.Length - 1
            tmpString = Hex(byteHash(i))
            If Len(tmpString) = 1 Then tmpString = "0" & tmpString
            returnString.Append(tmpString)
        Next

        Return returnString.ToString().ToLower()
    End Function

End Class
