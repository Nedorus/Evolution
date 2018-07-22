Imports System.Xml.Serialization
Imports System.IO

Public Class XMLFileHandlerDAO(Of T)

#Region "Constructors"

    Public Sub New()

    End Sub

#End Region

    Public Function SaveXML(ByVal pObjectToSerialize As T, ByVal pPathToXML As String) As Boolean
        Dim returnVal As Boolean = False
        Dim xmlFileStreamWriter As System.IO.StreamWriter
        Dim serialize As XmlSerializer = New XmlSerializer(GetType(T))
        Try
            xmlFileStreamWriter = My.Computer.FileSystem.OpenTextFileWriter(pPathToXML, False)

            'Save the setting to the file
            Try
                serialize.Serialize(xmlFileStreamWriter, pObjectToSerialize)
                returnVal = True
            Catch ex As Exception
                LogMessageHNDLR.Instance.Err("Something bad happened: " & ex.Message & ex.Source)
            End Try

            xmlFileStreamWriter.Close()
        Catch ex As Exception
            LogMessageHNDLR.Instance.Err("Something bad happened: " & ex.Message & ex.Source)
        End Try

        Return returnVal
    End Function

    Public Function LoadXML(ByVal pPathToXML As String) As T
        Dim returnChapters As T
        Dim serialize As XmlSerializer = New XmlSerializer(GetType(T))
        Dim xmlFileStreamReader As System.IO.StreamReader
        Try
            xmlFileStreamReader = My.Computer.FileSystem.OpenTextFileReader(pPathToXML, System.Text.Encoding.UTF8)
            Try
                returnChapters = CType(serialize.Deserialize(xmlFileStreamReader), T)
            Catch ex As Exception
                LogMessageHNDLR.Instance.Err("Something bad happened: " & ex.Message & ex.Source)
            End Try
            xmlFileStreamReader.Close()
        Catch ex As FileNotFoundException
            LogMessageHNDLR.Instance.Err("The specified file " & pPathToXML & " could not be found! " & ex.Message & ex.Source)
        Catch ex As Exception
            LogMessageHNDLR.Instance.Err("Something bad happened: " & ex.Message & ex.Source)
        End Try

        Return returnChapters
    End Function
End Class