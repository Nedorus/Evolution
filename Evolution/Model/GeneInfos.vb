Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Public Class GeneInfos
    Inherits List(Of GeneInfo)
    Implements IXmlSerializable

    Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
        Dim geneInfo_serializer As New XmlSerializer(GetType(GeneInfo))

        Dim was_empty As Boolean = reader.IsEmptyElement
        reader.Read()
        If Not was_empty Then
            Do While reader.NodeType <> Xml.XmlNodeType.EndElement
                Dim readGeneInfo As GeneInfo = DirectCast(geneInfo_serializer.Deserialize(reader), GeneInfo)
                reader.ReadEndElement()
                Me.Add(readGeneInfo)
                reader.MoveToContent()
            Loop
            reader.ReadEndElement()
        End If

    End Sub

    Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
        For Each currGeneInfo In Me
            writer.WriteStartElement("GeneInfo")
            currGeneInfo.WriteXml(writer)
            writer.WriteEndElement()
        Next
    End Sub

    Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
        Return Nothing
    End Function
End Class
