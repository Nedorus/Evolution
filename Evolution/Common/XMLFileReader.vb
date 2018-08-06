Imports System.Xml.Serialization
Imports System.IO
Imports System.IO.Abstractions
Imports System.Diagnostics.CodeAnalysis
Imports log4net


Public Class XMLFileReader(Of T)
    Private _xmlFileStreamReader As StreamReader
    Private _fileSystem As IFileSystem
    Private ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

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
            log.Error("The specified file could not be found! " & ex.Message & ex.Source)
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
            log.Error("Something bad happened: " & ex.Message & ex.Source)
        End Try

        Return returnChapters
    End Function
End Class