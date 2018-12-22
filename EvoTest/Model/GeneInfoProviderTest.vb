Imports System.IO.Abstractions.TestingHelpers
Imports System.Text
Imports Evolution
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO.Abstractions
Imports Moq
Imports System.Collections.ObjectModel

<TestClass()> Public Class GeneInfoProviderTest

    Dim xmlTestDataProvider As XMLTestDataProvider = New XMLTestDataProvider()

    <TestMethod()> Public Sub GetGeneInfoByGeneValueTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfosComplex)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)
        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()

        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)

        'Act
        Dim geneInfoAdd5Energy As GeneInfo = geneInfoProvider.GetGeneInfoByGeneValue(0)
        Dim geneInfoNothingFound As GeneInfo = geneInfoProvider.GetGeneInfoByGeneValue(12345)

        'Assert
        Assert.AreEqual("Add5Energy", geneInfoAdd5Energy.Code)
        Assert.AreEqual(1, geneInfoAdd5Energy.Modifiers.Count)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.EnergyType1, geneInfoAdd5Energy.Modifiers(0).FirstArg.ReferenceString)
        Assert.AreEqual("Add5Energy", geneInfoNothingFound.Code)

    End Sub

    <TestMethod()> Public Sub GetGeneInfoByGeneCodeTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfosComplex)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)
        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()

        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)

        'Act
        Dim geneInfoAdd5Energy As GeneInfo = geneInfoProvider.GetGeneInfoByGeneCode("Add5Energy")
        Dim geneInfoNothingFound As GeneInfo = geneInfoProvider.GetGeneInfoByGeneCode("XYZ")

        'Assert
        Assert.AreEqual("Add5Energy", geneInfoAdd5Energy.Code)
        Assert.AreEqual(1, geneInfoAdd5Energy.Modifiers.Count)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.EnergyType1, geneInfoAdd5Energy.Modifiers(0).FirstArg.ReferenceString)
        Assert.AreEqual("Add5Energy", geneInfoNothingFound.Code)

    End Sub

    <TestMethod()> Public Sub GetAllMatchingCodeNamesTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfosComplex)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)
        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()

        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)

        'Act
        Dim foundCodeNamesWithAdd As Collection(Of String) = geneInfoProvider.GetAllMatchingCodeNames("Add")
        Dim foundCodeNamesWithSub As Collection(Of String) = geneInfoProvider.GetAllMatchingCodeNames("Sub")
        Dim foundCodeNamesWithXYZ As Collection(Of String) = geneInfoProvider.GetAllMatchingCodeNames("XYZ")

        'Assert
        Assert.AreEqual(2, foundCodeNamesWithAdd.Count)
        Assert.AreEqual("Add5Energy", foundCodeNamesWithAdd(0))
        Assert.AreEqual("AddTowGeneCodes", foundCodeNamesWithAdd(1))
        Assert.AreEqual(1, foundCodeNamesWithSub.Count)
        Assert.AreEqual("SubtractgeneCodeFromEnergy", foundCodeNamesWithSub(0))
        Assert.AreEqual(0, foundCodeNamesWithXYZ.Count)

    End Sub

End Class