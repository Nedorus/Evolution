Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports Evolution
Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers

<TestClass()> Public Class XMLFileWriterTest
    Private ReadOnly log As log4net.ILog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    <TestMethod()>
    Public Sub SaveXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = BuildFileSystem(pathToMockedXML, filenameMockedXML)
        Dim xmlGeneInfoWriter As New XMLFileWriter(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim testGeneInfos As New GeneInfos()
        Dim testGeneInfo1 As New GeneInfo(0, "NULL", 0, "Nothing happens")
        Dim testGeneInfo2 As New GeneInfo(1, "ADD", 2, "Mocked description number two")
        testGeneInfos.Add(testGeneInfo1)
        testGeneInfos.Add(testGeneInfo2)

        Dim expectedFileContent As String = GetXMLFileContent()

        'Akt
        xmlGeneInfoWriter.SaveXML(testGeneInfos)
        Dim actualFileContent As String = mockedFilesSystem.GetFile(pathToMockedXML & "\" & filenameMockedXML).TextContents()

        'Assert
        Debug.WriteLine("Compare: " & String.Compare(expectedFileContent, actualFileContent))
        Assert.AreEqual(expectedFileContent, actualFileContent)
    End Sub

    Private Function BuildFileSystem(ByVal path As String, ByVal filename As String) As IFileSystem
        Dim myFileSystemFactory As New FileSystemMockFactory()
        myFileSystemFactory.AddTextFile(path, filename, GetXMLFileContent())

        Return myFileSystemFactory.MockedFileSystem
    End Function


    Private Function GetXMLFileContent() As String
        Return "<?xml version=""1.0"" encoding=""utf-8""?>
<GeneInfos>
  <GeneInfo>
    <Value>0</Value>
    <Code>NULL</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Nothing happens</Description>
  </GeneInfo>
  <GeneInfo>
    <Value>1</Value>
    <Code>ADD</Code>
    <NumberOfArgs>2</NumberOfArgs>
    <Description>Mocked description number two</Description>
  </GeneInfo>
</GeneInfos>"
    End Function
End Class
