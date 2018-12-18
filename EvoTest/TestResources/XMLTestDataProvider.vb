Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers

Public Class XMLTestDataProvider

    Enum TestDataKey
        GeneInfos
        GeneInfosEmpty
        GeneInfosBroken
        CreatureDataDefinitions
        CreatureDataDefinitionsEmpty
        CreatureDataDefinitionsBroken
    End Enum


    Private _testDataDictionary As Dictionary(Of TestDataKey, String)

    Friend Sub New()
        _testDataDictionary = New Dictionary(Of TestDataKey, String) From {
            {TestDataKey.GeneInfos, "<?xml version=""1.0"" encoding=""utf-8""?>
<GeneInfos>
  <GeneInfo>
    <Value>0</Value>
    <Code>NULL</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Nothing happens</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <Target>EnergyType1</Target>
        <FirstArg>GeneCode</FirstArg>
        <SecondArg>XPosition</SecondArg>
      </Modifier>
      <Modifier>
        <ChangeOperator>Subtract</ChangeOperator>
        <Target>GeneCodeRelative</Target>
        <FirstArg>ProgramCounterRelative</FirstArg>
        <SecondArg>YPosition</SecondArg>
      </Modifier>
    </Modifiers>
  </GeneInfo>
  <GeneInfo>
    <Value>1</Value>
    <Code>ADD</Code>
    <NumberOfArgs>2</NumberOfArgs>
    <Description>Mocked description number two</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator />
        <Target />
        <FirstArg />
        <SecondArg />
      </Modifier>
    </Modifiers>
  </GeneInfo>
</GeneInfos>"},
            {TestDataKey.GeneInfosEmpty, "<?xml version=""1.0"" encoding=""utf-8""?>
<GeneInfos/>"},
            {TestDataKey.GeneInfosBroken, "<?xml version=""1.0"" encoding=""utf-8""?>
<GeneInfos>THIS IS JUNK!"},
            {TestDataKey.CreatureDataDefinitions, "<?xml version=""1.0"" encoding=""utf-8""?>
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
</CreatureDataDefinitions>"},
            {TestDataKey.CreatureDataDefinitionsEmpty, "<?xml version=""1.0"" encoding=""utf-8""?>
<CreatureDataDefinitions/>"},
            {TestDataKey.CreatureDataDefinitionsBroken, "<?xml version=""1.0"" encoding=""utf-8""?>
<CreatureDataDefinitions>THIS IS JUNK!"}
}
    End Sub


    Friend Function BuildFileSystem(ByVal path As String, ByVal filename As String, selectedXMLType As String) As IFileSystem
        Dim myFileSystemFactory As New FileSystemMockFactory()
        myFileSystemFactory.AddTextFile(path, filename, GetXMLFileContent(selectedXMLType))
        Return myFileSystemFactory.MockedFileSystem
    End Function

    Friend Function GetXMLFileContent(selectedXMLType As String) As String
        Return _testDataDictionary.Item(selectedXMLType)
    End Function

End Class
