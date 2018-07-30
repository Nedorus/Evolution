Imports System.Xml.Serialization
Imports System.IO
Imports System.Diagnostics.CodeAnalysis
Imports System.IO.Abstractions



Public Class XMLFileWriter(Of T)
    Private _xmlFileStreamWriter As StreamWriter
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
            _xmlFileStreamWriter = _fileSystem.File.CreateText(pathToXML)
        Catch ex As System.IO.FileNotFoundException
            LogMessageHNDLR.Instance.Err("The specified file could not be found! " & ex.Message & ex.Source)
        End Try
    End Sub

#End Region

    Public Function SaveXML(ByVal pObjectToSerialize As T) As Boolean
        Dim returnVal As Boolean = False
        Dim serialize As XmlSerializer = New XmlSerializer(GetType(T))
        Try
            '_xmlFileStreamWriter = My.Computer.FileSystem.OpenTextFileWriter(pPathToXML, False)

            'Save the setting to the file
            serialize.Serialize(_xmlFileStreamWriter, pObjectToSerialize)
            returnVal = True
            _xmlFileStreamWriter.Close()
        Catch ex As Exception
            LogMessageHNDLR.Instance.Err("Something bad happened: " & ex.Message & ex.Source)
        End Try

        Return returnVal
    End Function


End Class
