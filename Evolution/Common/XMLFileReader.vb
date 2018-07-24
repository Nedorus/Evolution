Imports System.Xml.Serialization
Imports System.IO
Imports System.Diagnostics.CodeAnalysis


Public Class XMLFileReader(Of T)
    Private _xmlFileStreamReader As System.IO.StreamReader

#Region "Constructors"

    Public Sub New(ByRef xmlFileStreamReader As System.IO.StreamReader)
        _xmlFileStreamReader = xmlFileStreamReader
    End Sub

    Public Sub New(ByRef pathToXML)
        _xmlFileStreamReader = My.Computer.FileSystem.OpenTextFileReader(pathToXML, System.Text.Encoding.UTF8)
    End Sub

#End Region



    Public Function LoadXML() As T
        Dim returnChapters As T
        Dim serialize As XmlSerializer = New XmlSerializer(GetType(T))

        Try
            returnChapters = CType(serialize.Deserialize(_xmlFileStreamReader), T)
            _xmlFileStreamReader.Close()
        Catch ex As FileNotFoundException
            LogMessageHNDLR.Instance.Err("The specified file could not be found! " & ex.Message & ex.Source)
        Catch ex As Exception
            LogMessageHNDLR.Instance.Err("Something bad happened: " & ex.Message & ex.Source)
        End Try

        Return returnChapters
    End Function
End Class