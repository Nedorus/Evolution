Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports Evolution
Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers


<TestClass()> Public Class XMLFileReaderTest

    <TestMethod()> Public Sub LoadXMLTest()
        'Arrange
        'Dim testvar As New System.IO.Abstractions.TestingHelpers.MockFile()
        'testvar
        Dim mockedStreamReader As New Mock(Of System.IO.StreamReader)
        mockedStreamReader.Setup(Function(s) s.Read()).Returns("1")
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfo)(mockedStreamReader)
        'Akt
        Dim geneInfo As GeneInfo = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.AreEqual("", geneInfo.Value)


    End Sub

    Private Function BuildFileSystem()
        Dim mockedFileSystem As New MockFileSystem()
        '        Dim roootDirectory = result.Directory.CreateDirectory(@"C:\");
        'var dailyFtpDirectory = roootDirectory.CreateSubdirectory("DailyFtp");
        'var dataDirectory = dailyFtpDirectory.CreateSubdirectory("Data");
        'var outputDirectory = dailyFtpDirectory.CreateSubdirectory("Output");

        Return mockedFileSystem
    End Function

End Class