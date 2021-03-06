﻿Imports System.IO

Public Class FileNameCleaner

    Const NULL_OR_EMPTY_PATH_RESULT As String = "Unknown"

    Public Shared Function CleanFileName(ByVal fileName As String, Optional ByVal useOnlyPathBadChars As Boolean = True) As String
        Dim returnString As String = fileName
        If fileName Is Nothing OrElse fileName = "" OrElse fileName = "0" Then
            returnString = NULL_OR_EMPTY_PATH_RESULT
        End If

        For Each currChar In GetBadCharakters(useOnlyPathBadChars)
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
        'as Path.GetInvalidPathChars() is a true Subset of Path.GetInvalidFileNameChars
        'only this is needed
        Dim index As Integer = 0
        Dim length As Integer = Path.GetInvalidFileNameChars.Count
        While returnVal AndAlso index < length
            If pText.Contains(CType(Path.GetInvalidFileNameChars(index), String)) Then
                returnVal = False
            End If
            index += 1
        End While

        Return returnVal

    End Function

    Private Shared Function GetBadCharakters(ByVal useOnlyPathBadChars As Boolean) As Char()

        Dim badChars As Char()

        If useOnlyPathBadChars Then
            badChars = Path.GetInvalidPathChars()
        Else
            badChars = Path.GetInvalidFileNameChars()
        End If

        Return badChars
    End Function

End Class
