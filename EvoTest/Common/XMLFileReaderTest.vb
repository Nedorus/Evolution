Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Evolution
Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers


<TestClass()> Public Class XMLFileReaderTest
    Private Enum XMLTypeSelector
        Good
        Bad
        Empty
    End Enum

    <TestMethod()> Public Sub LoadXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTypeSelector.Good)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        'Akt
        Dim geneInfos As GeneInfos = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.AreEqual(2, geneInfos.Count)
        Assert.AreEqual("NULL", geneInfos(0).Code)
        Assert.AreEqual(0, geneInfos(0).Value)
        Assert.AreEqual(0, geneInfos(0).NumberOfArgs)
        Assert.AreEqual("Nothing happens", geneInfos(0).Description)

        Assert.AreEqual("ADD", geneInfos(1).Code)
        Assert.AreEqual(1, geneInfos(1).Value)
        Assert.AreEqual(2, geneInfos(1).NumberOfArgs)
        Assert.AreEqual("Mocked description number two", geneInfos(1).Description)
    End Sub

    <TestMethod()> Public Sub LoadFileNotFoundXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTypeSelector.Good)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & "Some Other FileName", mockedFilesSystem)

        'Akt
        Dim geneInfos As GeneInfos = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.IsNull(geneInfos)
    End Sub

    <TestMethod()> Public Sub LoadBadXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTypeSelector.Bad)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        'Akt
        Dim geneInfos As GeneInfos = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.IsNull(geneInfos)
    End Sub

    <TestMethod()> Public Sub LoadEmptyXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTypeSelector.Empty)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        'Akt
        Dim geneInfos As GeneInfos = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.AreEqual(0, geneInfos.Count)

    End Sub

    Private Function BuildFileSystem(ByVal path As String, ByVal filename As String, Optional ByVal selectedXMLType As XMLTypeSelector = XMLTypeSelector.Good) As IFileSystem
        Dim myFileSystemFactory As New FileSystemMockFactory()
        Select Case selectedXMLType
            Case XMLTypeSelector.Good
                myFileSystemFactory.AddTextFile(path, filename, GetXMLFileContent())
            Case XMLTypeSelector.Bad
                myFileSystemFactory.AddTextFile(path, filename, GetBadXMLFileContent())
            Case XMLTypeSelector.Empty
                myFileSystemFactory.AddTextFile(path, filename, GetEmptyXMLFileContent())
        End Select

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

    Private Function GetBadXMLFileContent() As String
        Return "<?xml version=""1.0"" encoding=""utf-8""?>
<GeneInfos>THIS IS JUNK!"
    End Function

    Private Function GetEmptyXMLFileContent() As String
        Return "<?xml version=""1.0"" encoding=""utf-8""?>
<GeneInfos/>"
    End Function

End Class