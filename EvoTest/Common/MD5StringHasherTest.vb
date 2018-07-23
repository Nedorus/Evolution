Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Evolution

<TestClass()> Public Class MD5StringHasherTest

    <TestMethod()> Public Sub HashUsingMD5Test()

        'Arrange
        Dim md5Hasher As New MD5StringHasher(New Security.Cryptography.MD5CryptoServiceProvider)
        Dim stringToBeHashed As String = "This is a String to be hashed"
        Dim changedStringToBeHashed As String = stringToBeHashed & "1"

        'expected result from https://www.md5-generator.de/
        Dim expectedHashedResult As String = "374f2253966939381c909cd258cbd6b1"
        Dim expectedChangedHashedResult As String = "58b33b8b2dff20b79611700d6dc663bb"

        'Akt
        Dim actualHashedResult As String = md5Hasher.HashUsingMD5(stringToBeHashed)
        Dim actualChangedHashedResult As String = md5Hasher.HashUsingMD5(changedStringToBeHashed)

        'Assert
        Assert.AreEqual(expectedHashedResult, actualHashedResult)
        Assert.AreEqual(expectedChangedHashedResult, actualChangedHashedResult)

    End Sub

End Class