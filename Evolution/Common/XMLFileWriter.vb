Imports System.Xml.Serialization
Imports System.IO
Imports System.Diagnostics.CodeAnalysis
Imports System.IO.Abstractions



Public Class XMLFileWriter(Of T)
    Private _xmlFileStreamWriter As StreamWriter
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
            _xmlFileStreamWriter = _fileSystem.File.CreateText(pathToXML)
        Catch ex As System.IO.FileNotFoundException
            LogMessageHNDLR.Instance.Err("The specified file could not be found! " & ex.Message & ex.Source)
        End Try
    End Sub

#End Region

    Public Function SaveXML(ByVal pObjectToSerialize As T) As Boolean
        Dim returnVal As Boolean = False
        Dim serialize As XmlSerializer = New XmlSerializer(GetType(T))

        'Save the setting to the file
        serialize.Serialize(_xmlFileStreamWriter, pObjectToSerialize)
        returnVal = True
        _xmlFileStreamWriter.Close()
        Return returnVal
    End Function


End Class
