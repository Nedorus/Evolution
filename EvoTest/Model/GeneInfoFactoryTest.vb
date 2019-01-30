Imports System.IO.Abstractions.TestingHelpers
Imports System.Text
Imports Evolution
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO.Abstractions
Imports Moq
Imports Evolution.ModifierAddress

<TestClass()> Public Class GeneInfoFactoryTest

    Dim xmlTestDataProvider As XMLTestDataProvider = New XMLTestDataProvider()

    <TestMethod()> Public Sub GeneInfosDeserializerTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfosComplex)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)
        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoFactory As New GeneInfoProviderImpl(geneInfos)

        'Act

        'Assert
        Assert.AreEqual(3, geneInfoFactory.GeneInfos.Count)
        Assert.AreEqual(1, geneInfoFactory.GeneInfos(0).Modifiers.Count)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.Undefined, geneInfoFactory.GeneInfos(0).Modifiers(0).SecondArg.ReferenceCreatureData)
        Assert.AreEqual(IModifierAddress.ReferenceTypeValue.Absolute, geneInfoFactory.GeneInfos(0).Modifiers(0).SecondArg.ReferenceType)
        Assert.AreEqual(1, geneInfoFactory.GeneInfos(1).Value)
        Assert.AreEqual(3, geneInfoFactory.GeneInfos(2).NumberOfArgs)
        Assert.AreEqual("Add what you find in the GeneCode to what you find in the GeneCode and store it in the Indirect geneCode-Address that you find in the GeneCode.", geneInfoFactory.GeneInfos(2).Description)
        Assert.AreEqual("AddTowGeneCodes", geneInfoFactory.GeneInfos(2).Code)

    End Sub

End Class