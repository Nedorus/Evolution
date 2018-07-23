Imports System.Xml.Serialization
Imports System.IO
Imports System.Diagnostics.CodeAnalysis

Public Class XMLFileWriter(Of T)

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


End Class
