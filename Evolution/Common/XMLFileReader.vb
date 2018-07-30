Imports System.Xml.Serialization
Imports System.IO
Imports System.IO.Abstractions
Imports System.Diagnostics.CodeAnalysis


Public Class XMLFileReader(Of T)
    Private _xmlFileStreamReader As StreamReader
    Private _fileSystem As IFileSystem

#Region "Constructors"
    <ExcludeFromCodeCoverage()>
    Public Sub New(ByRef pathToXML As String)
        Me.New(pathToXML, New FileSystem())
    End Sub

    <ExcludeFromCodeCoverage()>
    Public Sub New(ByRef pathToXML As String, ByVal fileSystem As IFileSystem)
        _fileSystem = fileSystem
        Try
            _xmlFileStreamReader = _fileSystem.File.OpenText(pathToXML)
        Catch ex As FileNotFoundException
            LogMessageHNDLR.Instance.Err("The specified file could not be found! " & ex.Message & ex.Source)
        End Try
    End Sub

#End Region

    Public Function LoadXML() As T
        Dim returnChapters As T
        Dim serialize As XmlSerializer = New XmlSerializer(GetType(T))

        Try
            returnChapters = CType(serialize.Deserialize(_xmlFileStreamReader), T)
            _xmlFileStreamReader.Close()
        Catch ex As Exception
            LogMessageHNDLR.Instance.Err("Something bad happened: " & ex.Message & ex.Source)
        End Try

        Return returnChapters
    End Function
End Class