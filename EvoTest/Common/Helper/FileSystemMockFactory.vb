Imports System.Diagnostics.CodeAnalysis
Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers
Imports Evolution

<ExcludeFromCodeCoverage()>
Public Class FileSystemMockFactory
    Private _mockedFileSystem As MockFileSystem

    Public Sub New()
        _mockedFileSystem = New MockFileSystem()
    End Sub

    Public ReadOnly Property MockedFileSystem As IFileSystem
        Get
            Return _mockedFileSystem
        End Get
    End Property


    Public Sub AddTextFile(ByRef path As String, ByRef filename As String, ByRef content As String)
        If Not _mockedFileSystem.Directory.Exists(path) Then
            AddDirectory(path)
        End If
        _mockedFileSystem.File.WriteAllText(path & "\" & filename, content)
    End Sub

    Public Sub AddDirectory(ByRef path As String)
        Dim directoryNames As String() = path.Split("\")
        Dim currentDirectory As DirectoryInfoBase = _mockedFileSystem.Directory.CreateDirectory(directoryNames(0))
        For i = 1 To directoryNames.Length() - 1
            currentDirectory = currentDirectory.CreateSubdirectory(directoryNames(i))
        Next

    End Sub

End Class
