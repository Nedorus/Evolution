Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Evolution

<TestClass()>
Public Class FileNameCleanerTest

    Private testContextInstance As TestContext

    '''<summary>
    '''Ruft den Textkontext mit Informationen über
    '''den aktuellen Testlauf sowie Funktionalität für diesen auf oder legt diese fest.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "Zusätzliche Testattribute"
    '
    ' Sie können beim Schreiben der Tests folgende zusätzliche Attribute verwenden:
    '
    ' Verwenden Sie ClassInitialize, um vor Ausführung des ersten Tests in der Klasse Code auszuführen.
    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    ' End Sub
    '
    ' Verwenden Sie ClassCleanup, um nach Ausführung aller Tests in einer Klasse Code auszuführen.
    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    ' End Sub
    '
    ' Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
    ' <TestInitialize()> Public Sub MyTestInitialize()
    ' End Sub
    '
    ' Mit TestCleanup können Sie nach jedem Test Code ausführen.
    ' <TestCleanup()> Public Sub MyTestCleanup()
    ' End Sub
    '
#End Region

    <TestMethod()>
    Public Sub CleanEmptyOrNullPathTest()
        'Arrange
        Dim emptyPath As String = ""
        Dim nullPath As String = Nothing

        Dim expectedEmptyOrNullPath = "Unknown"

        'Akt
        Dim actualCleanedEmptyPath As String = FileNameCleaner.CleanFileName(emptyPath, True)
        Dim actualCleanedEmptyFile As String = FileNameCleaner.CleanFileName(emptyPath, False)
        Dim actualCleanedNullPath As String = FileNameCleaner.CleanFileName(nullPath, True)
        Dim actualCleanedNullFile As String = FileNameCleaner.CleanFileName(nullPath, False)

        'Assert
        Assert.AreEqual(expectedEmptyOrNullPath, actualCleanedEmptyPath)
        Assert.AreEqual(expectedEmptyOrNullPath, actualCleanedEmptyFile)
        Assert.AreEqual(expectedEmptyOrNullPath, actualCleanedNullPath)
        Assert.AreEqual(expectedEmptyOrNullPath, actualCleanedNullFile)



    End Sub

    <TestMethod()>
    Public Sub CleanBadPathCharsTest()
        'Arrange
        Dim pathContainsNoBadChars As String = "C:\path\"
        Dim pathContainsBadFileChars As String = "C:*\path\?"
        Dim pathContainsBadPathChars As String = "C:\pa|th\<anotherFolder>\"
        Dim pathContainsBadFilePathChars As String = "C:\pa|th\<an*therFolder?>\"

        Dim expectedCleanedNoBadChars As String = pathContainsNoBadChars
        Dim expectedCleanedWithBadFileChars As String = "C:*\path\?"
        Dim expectedCleanedWithBadPathChars As String = "C:\path\anotherFolder\"
        Dim expectedCleanedWithBadFilePathChars As String = "C:\path\an*therFolder?\"

        'Act
        Dim actualCleanedNoBadChars As String = FileNameCleaner.CleanFileName(pathContainsNoBadChars, True)
        Dim actualCleanedWithBadFileChars As String = FileNameCleaner.CleanFileName(pathContainsBadFileChars, True)
        Dim actualCleanedWithBadPathChars As String = FileNameCleaner.CleanFileName(pathContainsBadPathChars, True)
        Dim actualCleanedWithBadFilePathChars As String = FileNameCleaner.CleanFileName(pathContainsBadFilePathChars, True)

        'Assert
        Assert.AreEqual(expectedCleanedNoBadChars, actualCleanedNoBadChars)
        Assert.AreEqual(expectedCleanedWithBadFileChars, actualCleanedWithBadFileChars)
        Assert.AreEqual(expectedCleanedWithBadPathChars, actualCleanedWithBadPathChars)
        Assert.AreEqual(expectedCleanedWithBadFilePathChars, actualCleanedWithBadFilePathChars)

    End Sub

    <TestMethod()>
    Public Sub CleanBadFileCharsTest()
        'Arrange
        Dim pathContainsNoBadChars As String = "filename.exe"
        Dim pathContainsBadFileChars As String = "fi?len\ame.exe"
        Dim pathContainsBadPathChars As String = "file<name>.exe"
        Dim pathContainsBadFilePathChars As String = "fi?le<name>.e/xe"

        Dim expectedCleanedNoBadChars As String = pathContainsNoBadChars
        Dim expectedCleanedWithBadFileChars As String = pathContainsNoBadChars
        Dim expectedCleanedWithBadPathChars As String = pathContainsNoBadChars
        Dim expectedCleanedWithBadFilePathChars As String = pathContainsNoBadChars


        'Act
        Dim actualCleanedNoBadChars As String = FileNameCleaner.CleanFileName(pathContainsNoBadChars, False)
        Dim actualCleanedWithBadFileChars As String = FileNameCleaner.CleanFileName(pathContainsBadFileChars, False)
        Dim actualCleanedWithBadPathChars As String = FileNameCleaner.CleanFileName(pathContainsBadPathChars, False)
        Dim actualCleanedWithBadFilePathChars As String = FileNameCleaner.CleanFileName(pathContainsBadFilePathChars, False)

        'Assert
        Assert.AreEqual(expectedCleanedNoBadChars, actualCleanedNoBadChars)
        Assert.AreEqual(expectedCleanedWithBadFileChars, actualCleanedWithBadFileChars)
        Assert.AreEqual(expectedCleanedWithBadPathChars, actualCleanedWithBadPathChars)
        Assert.AreEqual(expectedCleanedWithBadFilePathChars, actualCleanedWithBadFilePathChars)


    End Sub

    '"<>|:*?\///

    'Dim expectedCleanedPath As String = ""
    'Dim expectedCleanedFileName As String = ""
    'Dim pathContainsNoBadChars As String = "C:\path\filename.exe"
    'Dim fileNameContainsNoBadChars As String = "my_filename.exe"
    'Dim pathContainsBadPathChars As String = ""
    'Dim pathContainsBadFileChars As String = ""
    'Dim fileNameContainsBadPathChars As String = ""
    'Dim fileNameContainsBadFileChars As String = ""

End Class
