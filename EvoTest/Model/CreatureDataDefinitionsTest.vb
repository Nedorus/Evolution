Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Evolution
Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers

<TestClass()> Public Class CreatureDataDefinitionsTest
    Private Enum XMLTypeSelector
        Good
        Bad
        Empty
    End Enum

    <TestMethod()> Public Sub LoadXmlTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "ChangeableData.xml"
        Dim mockedFilesSystem As MockFileSystem = BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTypeSelector.Good)
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
        Dim mockedFilesSystem As MockFileSystem = BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTypeSelector.Good)
        Dim xmlCreatureDataDefinitionsWriter As New XMLFileWriter(Of Evolution.CreatureDataDefinitions)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)
        Dim creatureDataDefinitions As CreatureDataDefinitions = New CreatureDataDefinitions()
        creatureDataDefinitions.CreatureDataDefinition.Add("GeneCode")
        creatureDataDefinitions.CreatureDataDefinition.Add("ProgramCounter")
        creatureDataDefinitions.CreatureDataDefinition.Add("EnergyType1")
        creatureDataDefinitions.CreatureDataDefinition.Add("XPosition")
        creatureDataDefinitions.CreatureDataDefinition.Add("YPosition")
        creatureDataDefinitions.ChangeOperations.Add("Add")
        creatureDataDefinitions.ChangeOperations.Add("Subtract")

        Dim expectedFileContent As String = GetXMLFileContent()

        'Act
        xmlCreatureDataDefinitionsWriter.SaveXML(creatureDataDefinitions)
        Dim actualFileContent As String = mockedFilesSystem.GetFile(pathToMockedXML & "\" & filenameMockedXML).TextContents()

        'Assert
        Debug.WriteLine("Compare: " & String.Compare(expectedFileContent, actualFileContent))
        Assert.AreEqual(expectedFileContent, actualFileContent)

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
<CreatureDataDefinitions>
  <CreatureDataDefinition>
    <CreatureDataItem>GeneCode</CreatureDataItem>
    <CreatureDataItem>ProgramCounter</CreatureDataItem>
    <CreatureDataItem>EnergyType1</CreatureDataItem>
    <CreatureDataItem>XPosition</CreatureDataItem>
    <CreatureDataItem>YPosition</CreatureDataItem>
  </CreatureDataDefinition>
  <ChangeOperations>
    <ChangeOperator>Add</ChangeOperator>
    <ChangeOperator>Subtract</ChangeOperator>
  </ChangeOperations>
</CreatureDataDefinitions>"
    End Function

    Private Function GetBadXMLFileContent() As String
        Return "<?xml version=""1.0"" encoding=""utf-8""?>
<ChangeableData>THIS IS JUNK!"
    End Function

    Private Function GetEmptyXMLFileContent() As String
        Return "<?xml version=""1.0"" encoding=""utf-8""?>
<ChangeableData/>"
    End Function

End Class