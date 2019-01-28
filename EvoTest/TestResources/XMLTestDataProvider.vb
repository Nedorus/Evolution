Imports System.IO.Abstractions
Imports System.IO.Abstractions.TestingHelpers

Public Class XMLTestDataProvider

    Enum TestDataKey
        GeneInfos
        GeneInfosEmpty
        GeneInfosBroken
        GeneInfosComplex
        GeneInfoAdd5Energy
        GeneInfoStoreAndReadTests
        Add5PlausEnergyStoreInGeneCode
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
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>2</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>3</ReferenceInteger>
          <ReferenceCreatureData>XPosition</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
      <Modifier>
        <ChangeOperator>Subtract</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>5</ReferenceInteger>
          <ReferenceCreatureData>GeneCounter</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>7</ReferenceInteger>
          <ReferenceCreatureData>YPosition</ReferenceCreatureData>
        </ModifierAddress>
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
        <ChangeOperator>Undefined</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Undefined</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Undefined</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Undefined</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
</GeneInfos>"},
            {TestDataKey.GeneInfosComplex, "<?xml version=""1.0"" encoding=""utf-8""?>
<GeneInfos>
  <GeneInfo>
    <Value>0</Value>
    <Code>Add5Energy</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Add 5 Sunlight and store it in Sunlight</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>5</ReferenceInteger>
          <ReferenceCreatureData />
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
  <GeneInfo>
    <Value>1</Value>
    <Code>SubtractgeneCodeFromEnergy</Code>
    <NumberOfArgs>1</NumberOfArgs>
    <Description>Subtract what you find in the GeneCode from Sunlight and store it in Sunlight</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Subtract</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
  <GeneInfo>
    <Value>2</Value>
    <Code>AddTowGeneCodes</Code>
    <NumberOfArgs>3</NumberOfArgs>
    <Description>Add what you find in the GeneCode to what you find in the GeneCode and store it in the Indirect geneCode-Address that you find in the GeneCode.</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Indirect</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Indirect</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
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
    <CreatureDataItem>GeneCounter</CreatureDataItem>
    <CreatureDataItem>Sunlight</CreatureDataItem>
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
<CreatureDataDefinitions>THIS IS JUNK!"},
            {TestDataKey.GeneInfoAdd5Energy, "<?xml version=""1.0"" encoding=""utf-8""?>
<GeneInfos>
  <GeneInfo>
    <Value>0</Value>
    <Code>Add5Energy</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Add 5 to Sunlight and store it in Sunlight</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>5</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
</GeneInfos>"},
            {TestDataKey.Add5PlausEnergyStoreInGeneCode, "<?xml version=""1.0"" encoding=""utf-8""?>
<GeneInfos>
  <GeneInfo>
    <Value>0</Value>
    <Code>Add5PlausEnergyStoreInGeneCode</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Add 5 to Sunlight and store it in GeneCode</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Indirect</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>5</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
</GeneInfos>"},
            {TestDataKey.GeneInfoStoreAndReadTests, "<?xml version=""1.0"" encoding=""utf-8""?>
<GeneInfos>
  <GeneInfo>
    <Value>0</Value>
    <Code>GeneInfoStoreRelativeExtra</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Store in Sunlight</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>1</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>2</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
  <GeneInfo>
    <Value>1</Value>
    <Code>GeneInfoStoreRelativeGeneCode</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Store in GeneCode</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>3</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>4</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
  <GeneInfo>
    <Value>2</Value>
    <Code>GeneInfoStoreIndirectExtra</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Store in Address refered to by Sunlight</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Indirect</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>5</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>6</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
  <GeneInfo>
    <Value>3</Value>
    <Code>GeneInfoStoreIndirectGeneCode</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Store in Address refered to by GeneCode</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Indirect</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>7</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>8</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
  <GeneInfo>
    <Value>4</Value>
    <Code>GeneInfoStoreAbsolute</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Store in Absolute</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>9</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>10</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
  <GeneInfo>
    <Value>5</Value>
    <Code>GeneInfoReadRelative</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Reads values relative from Sunlight and GeneCode</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>11</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>12</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
  <GeneInfo>
    <Value>6</Value>
    <Code>GeneInfoReadIndirect</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>Reads values indirect from Sunlight and GeneCode</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Direct</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Indirect</ReferenceType>
          <ReferenceInteger>13</ReferenceInteger>
          <ReferenceCreatureData>Sunlight</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Indirect</ReferenceType>
          <ReferenceInteger>14</ReferenceInteger>
          <ReferenceCreatureData>GeneCode</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
  <GeneInfo>
    <Value>7</Value>
    <Code>GeneInfoStoreUndefined</Code>
    <NumberOfArgs>0</NumberOfArgs>
    <Description>tries to store in a undefined place</Description>
    <Modifiers>
      <Modifier>
        <ChangeOperator>Add</ChangeOperator>
        <ModifierAddress>
          <ReferenceType>Undefined</ReferenceType>
          <ReferenceInteger>0</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>3</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
        <ModifierAddress>
          <ReferenceType>Absolute</ReferenceType>
          <ReferenceInteger>4</ReferenceInteger>
          <ReferenceCreatureData>Undefined</ReferenceCreatureData>
        </ModifierAddress>
      </Modifier>
    </Modifiers>
  </GeneInfo>
</GeneInfos>"}
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
