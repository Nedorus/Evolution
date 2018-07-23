Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq
Imports Evolution

<TestClass()> Public Class XMLFileReaderTest

    <TestMethod()> Public Sub LoadXMLTest()
        'Arrange
        Dim mockedStreaReader As New Mock(Of System.IO.StreamReader)
        mockedStreaReader.Setup(Function(s) s.Read()).Returns("1")
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfo)(mockedStreaReader)
        'Akt
        Dim geneInfo As GeneInfo = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.AreEqual("", geneInfo.Value)


    End Sub

End Class