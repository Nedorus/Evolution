Imports System.Text
Imports Evolution
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class GeneInfoFactoryTest

    <TestMethod()> Public Sub GendeInfosTest()
        'Arrange
        Dim geneInfoFactory As GeneInfoFactory = GeneInfoFactory.Instance

        'Act

        'Assert
        Assert.AreEqual(8, geneInfoFactory.GeneInfos.Count)
        Assert.AreEqual(2, geneInfoFactory.GeneInfos(0).Modifiers.Count)
        Assert.AreEqual(1, geneInfoFactory.GeneInfos(1).Value)
        Assert.AreEqual(2, geneInfoFactory.GeneInfos(2).NumberOfArgs)
        Assert.AreEqual("Consumes an amount of rescource refered to by the first arg of type refered to by the second arg", geneInfoFactory.GeneInfos(3).Description)
        Assert.AreEqual("JMPREL", geneInfoFactory.GeneInfos(7).Code)

    End Sub

End Class