Imports System.IO.Abstractions.TestingHelpers
Imports System.Text
Imports Evolution
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.IO.Abstractions
Imports Moq

<TestClass()> Public Class GeneExcuterTest

    Dim xmlTestDataProvider As XMLTestDataProvider = New XMLTestDataProvider()

    <TestMethod()> Public Sub AddAbsoluteValToRelExtraVal()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfosComplex)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature(ICreatureDataDefinitions.CreatureData.GeneCounter) = 0
        creature(ICreatureDataDefinitions.CreatureData.Carbon) = 0
        creature.Gene(0) = 0
        creature.Gene(1) = 1
        creature.Gene(2) = 3
        creature.Gene(3) = 2
        creature.Gene(4) = 2
        creature.Gene(5) = 7
        creature.Gene(6) = 9

        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.Sunlight, geneInfoProvider.GetGeneInfoByGeneValue(0).Modifiers(0).Target.ReferenceCreatureData)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.Sunlight, geneInfoProvider.GetGeneInfoByGeneValue(0).Modifiers(0).FirstArg.ReferenceCreatureData)
        Assert.AreEqual(5, geneInfoProvider.GetGeneInfoByGeneValue(0).Modifiers(0).SecondArg.ReferenceInteger)
        Assert.AreEqual(1, creature(ICreatureDataDefinitions.CreatureData.GeneCounter))
        Assert.AreEqual(5, creature(ICreatureDataDefinitions.CreatureData.Sunlight))

    End Sub

    <TestMethod()> Public Sub SubtractRelativeGeneCodeFromRelativeExtraTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfosComplex)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature(ICreatureDataDefinitions.CreatureData.GeneCounter) = 1
        creature(ICreatureDataDefinitions.CreatureData.Sunlight) = 0
        creature.Gene(0) = 0
        creature.Gene(1) = 1
        creature.Gene(2) = 3
        creature.Gene(3) = 2
        creature.Gene(4) = 2
        creature.Gene(5) = 7
        creature.Gene(6) = 9

        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.Sunlight, geneInfoProvider.GetGeneInfoByGeneValue(1).Modifiers(0).Target.ReferenceCreatureData)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.Sunlight, geneInfoProvider.GetGeneInfoByGeneValue(1).Modifiers(0).FirstArg.ReferenceCreatureData)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.GeneCode, geneInfoProvider.GetGeneInfoByGeneValue(1).Modifiers(0).SecondArg.ReferenceCreatureData)
        Assert.AreEqual(3, creature(ICreatureDataDefinitions.CreatureData.GeneCounter))
        Assert.AreEqual(-3, creature(ICreatureDataDefinitions.CreatureData.Sunlight))

    End Sub


    <TestMethod()> Public Sub AddRelativeGeneCodeToIndirectGeneCodeStoreIndirectTest()
        'Arrange

        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfosComplex)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature(ICreatureDataDefinitions.CreatureData.GeneCounter) = 3
        creature(ICreatureDataDefinitions.CreatureData.Sunlight) = 0
        creature.Gene(0) = 0
        creature.Gene(1) = 1
        creature.Gene(2) = 3
        creature.Gene(3) = 2
        creature.Gene(4) = 1
        creature.Gene(5) = 2
        creature.Gene(6) = 9

        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.GeneCode, geneInfoProvider.GetGeneInfoByGeneValue(2).Modifiers(0).Target.ReferenceCreatureData)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.GeneCode, geneInfoProvider.GetGeneInfoByGeneValue(2).Modifiers(0).FirstArg.ReferenceCreatureData)
        Assert.AreEqual(ICreatureDataDefinitions.CreatureData.GeneCode, geneInfoProvider.GetGeneInfoByGeneValue(2).Modifiers(0).SecondArg.ReferenceCreatureData)
        Assert.AreEqual(7, creature(ICreatureDataDefinitions.CreatureData.GeneCounter))
        Assert.AreEqual(3, creature.Gene(9))

    End Sub

    <TestMethod()> Public Sub AutoCreateUndefinedOnStoreTest()
        'Arrange

        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfoAdd5Energy)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature(ICreatureDataDefinitions.CreatureData.GeneCounter) = 0
        creature(ICreatureDataDefinitions.CreatureData.Sunlight) = 3
        creature.Gene(0) = 0
        creature.Gene(1) = 4

        'Act
        creature.Remove(ICreatureDataDefinitions.CreatureData.Sunlight)
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(8, creature.Count)
        Assert.IsTrue(creature.ContainsKey(ICreatureDataDefinitions.CreatureData.Sunlight))
        Assert.AreEqual(9, creature(ICreatureDataDefinitions.CreatureData.Sunlight))

    End Sub

    <TestMethod()> Public Sub AutoCreateUndefinedOnReadTest()
        'Arrange

        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.Add5PlausEnergyStoreInGeneCode)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature(ICreatureDataDefinitions.CreatureData.GeneCounter) = 0
        creature(ICreatureDataDefinitions.CreatureData.Sunlight) = 3
        creature.Gene(0) = 0
        creature.Gene(1) = 4

        'Act
        creature.Remove(ICreatureDataDefinitions.CreatureData.Sunlight)
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.IsTrue(creature.ContainsKey(ICreatureDataDefinitions.CreatureData.GeneCounter))
        Assert.IsTrue(creature.ContainsKey(ICreatureDataDefinitions.CreatureData.XPosition))
        Assert.IsTrue(creature.ContainsKey(ICreatureDataDefinitions.CreatureData.YPosition))
        Assert.AreEqual(5, creature.Gene(4))

    End Sub

    <TestMethod()> Public Sub ExecuterStoreAndReadGeneInfoStoreRelativeExtraTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfoStoreAndReadTests)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature.Gene(0) = 0

        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(3, creature(ICreatureDataDefinitions.CreatureData.Sunlight))

    End Sub


    <TestMethod()> Public Sub ExecuterStoreAndReadGeneInfoStoreRelativeGeneCodeTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfoStoreAndReadTests)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature.Gene(0) = 1
        creature.Gene(1) = 2

        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(7, creature.Gene(1))

    End Sub


    <TestMethod()> Public Sub ExecuterStoreAndReadGeneInfoStoreIndirectExtraTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfoStoreAndReadTests)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature.Gene(0) = 2
        Dim targetAddress As Integer = 3
        creature(ICreatureDataDefinitions.CreatureData.Sunlight) = targetAddress

        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(11, creature.Gene(targetAddress))


    End Sub


    <TestMethod()> Public Sub ExecuterStoreAndReadGeneInfoStoreIndirectGeneCodeTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfoStoreAndReadTests)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature.Gene(0) = 3
        Dim targetAddress As Integer = 5
        creature.Gene(1) = targetAddress

        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(15, creature.Gene(targetAddress))

    End Sub


    <TestMethod()> Public Sub ExecuterStoreAndReadGeneInfoStoreAbsoluteTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfoStoreAndReadTests)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature.Gene(0) = 4
        Dim targetAddress As Integer = 5
        creature.Gene(1) = targetAddress

        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(0, creature.Gene(targetAddress))

    End Sub


    <TestMethod()> Public Sub ExecuterStoreAndReadGeneInfoReadRelativeTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfoStoreAndReadTests)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature(ICreatureDataDefinitions.CreatureData.Sunlight) = 11
        creature.Gene(0) = 5
        creature.Gene(1) = 12

        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(23, creature(ICreatureDataDefinitions.CreatureData.Sunlight))

    End Sub


    <TestMethod()> Public Sub ExecuterStoreAndReadGeneInfoReadIndirectTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfoStoreAndReadTests)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        Dim firstArgAddr As Integer = 10
        Dim secondArgAddr As Integer = 20
        creature(ICreatureDataDefinitions.CreatureData.Sunlight) = firstArgAddr
        creature.Gene(0) = 6
        creature.Gene(1) = secondArgAddr
        creature.Gene(firstArgAddr) = 13
        creature.Gene(secondArgAddr) = 14


        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(27, creature(ICreatureDataDefinitions.CreatureData.Sunlight))

    End Sub


    <TestMethod()> Public Sub ExecuterStoreAndReadGeneInfoStoreUndefinedTest()
        'Arrange
        Dim pathToMockedXML As String = "C:\xmlDirectory"
        Dim filenameMockedXML As String = "GeneInfos.xml"
        Dim mockedFilesSystem As MockFileSystem = xmlTestDataProvider.BuildFileSystem(pathToMockedXML, filenameMockedXML, selectedXMLType:=XMLTestDataProvider.TestDataKey.GeneInfoStoreAndReadTests)
        Dim xmlGeneInfoReader As New XMLFileReader(Of GeneInfos)(pathToMockedXML & "\" & filenameMockedXML, mockedFilesSystem)

        Dim geneInfos As Evolution.GeneInfos = xmlGeneInfoReader.LoadXML()
        Dim geneInfoProvider As New GeneInfoProvider(geneInfos)
        Dim geneExecuter As New GeneExcuter(geneInfoProvider)

        Dim creature As New Creature()
        creature(ICreatureDataDefinitions.CreatureData.Sunlight) = 0
        creature.Gene(0) = 7


        'Act
        geneExecuter.ExecuteCurrentGeneCode(creature)

        'Assert
        Assert.AreEqual(8, creature.Count)
        Assert.AreEqual(0, creature(ICreatureDataDefinitions.CreatureData.Sunlight))
        Assert.AreEqual(1, creature(ICreatureDataDefinitions.CreatureData.GeneCounter))
        Assert.AreEqual(0, creature(ICreatureDataDefinitions.CreatureData.XPosition))
        Assert.AreEqual(0, creature(ICreatureDataDefinitions.CreatureData.YPosition))
        Assert.AreEqual(256, creature.Gene.Count)
        For i = 1 To creature.Gene.Count - 1
            Assert.AreEqual(0, creature.Gene(i))
        Next

    End Sub


End Class