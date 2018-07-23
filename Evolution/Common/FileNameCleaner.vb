Imports System.IO

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

    Private Shared Function GetBadCharakters(ByVal useOnlyPathBadChars As Boolean) As Char()

        Dim badChars() As Char

        If useOnlyPathBadChars Then
            badChars = Path.GetInvalidPathChars()
        Else
            badChars = Path.GetInvalidFileNameChars()
        End If

        Return badChars
    End Function

End Class
