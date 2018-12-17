Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Evolution
Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers

<TestClass()> Public Class ChangebleDataTest
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
        Dim xmlGeneInfoReader As New XMLFileReader(Of ChangeableData)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        'Akt
        Dim changeableData As ChangeableData = xmlGeneInfoReader.LoadXML()

        'Assert
        Assert.AreEqual(5, changeableData.CreatureDatadefinition.Count, "CreatureData should be 5 but was: " & changeableData.CreatureDatadefinition.Count)
        Assert.AreEqual(2, changeableData.ChangeOperations.Count, "ChangeOperations should be 2 but was: " & changeableData.ChangeOperations.Count)

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
        Return "<?xml version=""1.0"" encoding=""utf-8"" ?>
<ChangeableData>
  <CreatureDataDefinition>
    <CreatureDataItem>GeneCode</CreatureDataItem>
    <CreatureDataItem>ProgramCounter</CreatureDataItem>
    <CreatureDataItem> EnergyType1</CreatureDataItem>
    <CreatureDataItem>XPosition</CreatureDataItem>
    <CreatureDataItem>YPosition </CreatureDataItem>
  </CreatureDataDefinition>
  <ChangeOperations>
    <ChangeOperator>Add</ChangeOperator>
    <ChangeOperator>Subtract</ChangeOperator>
  </ChangeOperations>
</ChangeableData>"
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