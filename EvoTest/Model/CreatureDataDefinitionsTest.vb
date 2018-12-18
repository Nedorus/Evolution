Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Evolution
Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers

<TestClass()> Public Class CreatureDataDefinitionsTest

    Dim xmlTestDataProvider As XMLTestDataProvider = New XMLTestDataProvider()

    <TestMethod()> Public Sub LoadXmlTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "ChangeableData.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.CreatureDataDefinitions)
        Dim xmlGeneInfoReader As New XMLFileReader(Of CreatureDataDefinitions)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        'Akt
        Dim creatureDataDefinitions As CreatureDataDefinitions = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.AreEqual(5, creatureDataDefinitions.CreatureDataDefinition.Count, "CreatureData should be 5 but was: " & creatureDataDefinitions.CreatureDataDefinition.Count)
        Assert.AreEqual(2, creatureDataDefinitions.ChangeOperations.Count, "ChangeOperations should be 2 but was: " & creatureDataDefinitions.ChangeOperations.Count)

    End Sub

    <TestMethod()> Public Sub SaveXMLTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "CreatureDataDefinitions.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.CreatureDataDefinitions)
        Dim xmlCreatureDataDefinitionsWriter As New XMLFileWriter(Of Evolution.CreatureDataDefinitions)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)
        Dim creatureDataDefinitions As CreatureDataDefinitions = New CreatureDataDefinitions()
        creatureDataDefinitions.CreatureDataDefinition.Add("GeneCode")
        creatureDataDefinitions.CreatureDataDefinition.Add("ProgramCounter")
        creatureDataDefinitions.CreatureDataDefinition.Add("EnergyType1")
        creatureDataDefinitions.CreatureDataDefinition.Add("XPosition")
        creatureDataDefinitions.CreatureDataDefinition.Add("YPosition")
        creatureDataDefinitions.ChangeOperations.Add("Add")
        creatureDataDefinitions.ChangeOperations.Add("Subtract")

        Dim expectedFileContent As String = xmlTestDataProvider.GetXMLFileContent(XMLTestDataProvider.TestDataKey.CreatureDataDefinitions)

        'Act
        xmlCreatureDataDefinitionsWriter.SaveXML(creatureDataDefinitions)
        Dim actualFileContent As String = mockedFilesSystem.GetFile(pathToMockedXML & "\" & filenameMockedXML).TextContents()

        'Assert
        Debug.WriteLine("Compare: " & String.Compare(expectedFileContent, actualFileContent))
        Assert.AreEqual(expectedFileContent, actualFileContent)

    End Sub

End Class