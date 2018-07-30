Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Evolution


<TestClass()> Public Class RandomStringAndUIDGeneratorTest

    <TestMethod()> Public Sub RandomUIDTest()
        'Arrange
        Dim randomGenerator As RandomStringAndUIDGenerator = New RandomStringAndUIDGenerator(New Random())
        Dim uidLength10 As Integer = 10
        Dim uidlength25 As Integer = 25

        'Akt
        Dim actualUIDWithLength10_1 As String = randomGenerator.RandomUID(uidLength10)
        Dim actualUIDWithLength10_2 As String = randomGenerator.RandomUID(uidLength10)
        Dim actualUIDWithLength25 As String = randomGenerator.RandomUID(uidlength25)

        'Assert
        Assert.AreEqual(actualUIDWithLength25.Length(), uidlength25)
        Assert.AreEqual(actualUIDWithLength10_1.Length(), uidLength10)
        Assert.AreEqual(actualUIDWithLength10_2.Length(), uidLength10)
        Assert.AreNotEqual(actualUIDWithLength10_1, actualUIDWithLength10_2)

    End Sub

    <TestMethod()> Public Sub RandomStringTest()
        'Arrange
        Dim randomGenerator As RandomStringAndUIDGenerator = New RandomStringAndUIDGenerator(New Random())
        Dim stringLength10 As Integer = 10
        Dim stringLength25 As Integer = 25

        'Akt
        Dim actualStringWithLength10_1 As String = randomGenerator.RandomString(stringLength10)
        Dim actualStringWithLength10_2 As String = randomGenerator.RandomString(stringLength10)
        Dim actualStringWithLength25 As String = randomGenerator.RandomString(stringLength25)

        'Assert
        Assert.AreEqual(actualStringWithLength25.Length(), stringLength25)
        Assert.AreEqual(actualStringWithLength10_1.Length(), stringLength10)
        Assert.AreEqual(actualStringWithLength10_2.Length(), stringLength10)
        Assert.AreNotEqual(actualStringWithLength10_1, actualStringWithLength10_2)

    End Sub

    <TestMethod()> Public Sub RandomNumberStringTest()
        'Arrange
        Dim randomGenerator As RandomStringAndUIDGenerator = New RandomStringAndUIDGenerator(New Random())
        Dim numberSringLength10 As Integer = 10
        Dim numberStringtringLength25 As Integer = 25

        'Akt
        Dim actualNumberStringWithLength10_1 As String = randomGenerator.RandomNumberString(numberSringLength10)
        Dim actualNumberStringWithLength10_2 As String = randomGenerator.RandomNumberString(numberSringLength10)
        Dim actualNumberStringWithLength25 As String = randomGenerator.RandomNumberString(numberStringtringLength25)

        'Assert
        Assert.AreEqual(actualNumberStringWithLength25.Length(), numberStringtringLength25)
        Assert.AreEqual(actualNumberStringWithLength10_1.Length(), numberSringLength10)
        Assert.AreEqual(actualNumberStringWithLength10_2.Length(), numberSringLength10)
        Assert.AreNotEqual(actualNumberStringWithLength10_1, actualNumberStringWithLength10_2)

    End Sub



End Class