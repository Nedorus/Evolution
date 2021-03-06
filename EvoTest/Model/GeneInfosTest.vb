﻿Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers
Imports Evolution
Imports Evolution.ModifierAddress
Imports Evolution.Modifier

<TestClass()> Public Class GeneInfosTest

    Dim xmlTestDataProvider As XMLTestDataProvider = New XMLTestDataProvider()

    <TestMethod()> Public Sub LoadXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfos)
        Dim xmlGeneInfoReader As New XMLFileReader(Of Evolution.GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        'Akt
        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.AreEqual(2, geneInfos.Count)
        Assert.AreEqual("NULL", geneInfos(0).Code)
        Assert.AreEqual(0, geneInfos(0).Value)
        Assert.AreEqual(0, geneInfos(0).NumberOfArgs)
        Assert.AreEqual("Nothing happens", geneInfos(0).Description)
        Assert.AreEqual(2, geneInfos(0).Modifiers.Count)
        Assert.AreEqual(IModifier.ModifierOperator.Subtract, geneInfos(0).Modifiers(1).ChangeOperator)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.GeneCode, geneInfos(0).Modifiers(1).Target.ReferenceCreatureData)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.GeneCounter, geneInfos(0).Modifiers(1).FirstArg.ReferenceCreatureData)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.YPosition, geneInfos(0).Modifiers(1).SecondArg.ReferenceCreatureData)

        Assert.AreEqual("ADD", geneInfos(1).Code)
        Assert.AreEqual(1, geneInfos(1).Value)
        Assert.AreEqual(2, geneInfos(1).NumberOfArgs)
        Assert.AreEqual("Mocked description number two", geneInfos(1).Description)
        Assert.AreEqual(1, geneInfos(1).Modifiers.Count)
        Assert.AreEqual(IModifier.ModifierOperator.Undefined, geneInfos(1).Modifiers(0).ChangeOperator)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.Undefined, geneInfos(1).Modifiers(0).Target.ReferenceCreatureData)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.Undefined, geneInfos(1).Modifiers(0).FirstArg.ReferenceCreatureData)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.Undefined, geneInfos(1).Modifiers(0).SecondArg.ReferenceCreatureData)
    End Sub

    <TestMethod()> Public Sub LoadFileNotFoundXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfos)
        Dim xmlGeneInfoReader As New XMLFileReader(Of Evolution.GeneInfos)(pathToMockedXML & "\" & "Some Other FileName", mockedFilesSystem)

        'Akt
        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.IsNull(geneInfos)
    End Sub

    <TestMethod()> Public Sub LoadBadXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfosBroken)
        Dim xmlGeneInfoReader As New XMLFileReader(Of Evolution.GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        'Akt
        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.IsNull(geneInfos)
    End Sub

    <TestMethod()> Public Sub LoadEmptyXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfosEmpty)
        Dim xmlGeneInfoReader As New XMLFileReader(Of Evolution.GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        'Akt
        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.AreEqual(0, geneInfos.Count)

    End Sub

    <TestMethod()>
    Public Sub SaveXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfos)
        Dim xmlGeneInfoWriter As New XMLFileWriter(Of Evolution.GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As New Evolution.GeneInfos()
        Dim geneInfo1 As New GeneInfo(0, "NULL", 0, "Nothing happens")
        Dim modifierAddressFactory As New ModifierAddressFactoryImpl()
        Dim modifierFactory As Evolution.Modifier.IModifierFactory = New Evolution.Modifier.ModifierFactoryImpl()

        geneInfo1.Modifiers.Add(modifierFactory.NewModifier(IModifier.ModifierOperator.Add,
                                             modifierAddressFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 0, ICreatureDataDefinitions.CreatureData.Sunlight),
                                             modifierAddressFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 2, ICreatureDataDefinitions.CreatureData.GeneCode),
                                             modifierAddressFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 3, ICreatureDataDefinitions.CreatureData.XPosition)))
        geneInfo1.Modifiers.Add(modifierFactory.NewModifier(IModifier.ModifierOperator.Subtract,
                                             modifierAddressFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 0, ICreatureDataDefinitions.CreatureData.GeneCode),
                                             modifierAddressFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 5, ICreatureDataDefinitions.CreatureData.GeneCounter),
                                             modifierAddressFactory.NewModifierAddress(IModifierAddress.ReferenceTypeValue.Direct, 7, ICreatureDataDefinitions.CreatureData.YPosition)))
        Dim geneInfo2 As New GeneInfo(1, "ADD", 2, "Mocked description number two")
        geneInfo2.Modifiers.Add(modifierFactory.NewModifier())
        geneInfos.Add(geneInfo1)
        geneInfos.Add(geneInfo2)

        Dim expectedFileContent As String = xmlTestDataProvider.GetXMLFileContent(XMLTestDataProvider.TestDataKey.GeneInfos)

        'Akt
        xmlGeneInfoWriter.SaveXML(geneInfos)
        Dim actualFileContent As String = mockedFilesSystem.GetFile(pathToMockedXML & "\" & filenameMockedXML).TextContents()

        'Assert
        Assert.AreEqual(IModifier.ModifierOperator.Undefined, geneInfo2.Modifiers(0).ChangeOperator)
        Assert.AreEqual(expectedFileContent, actualFileContent)

    End Sub

End Class