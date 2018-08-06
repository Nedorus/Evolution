Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Evolution

<TestClass()> Public Class MainWindowTest

    <TestMethod()> Public Sub PropertyViewModelTest()
        'Arrange
        'Dim mockedVieModel 
        Dim _mainWindow As Evolution.MainWindow = New Evolution.MainWindow()
        _mainWindow.ViewModel.Genes.Add(New GeneViewModel(New RandomStringAndUIDGenerator(New Random())))

        'Akt
        _mainWindow.ViewModel.Genes.Item(0).Code = "HELL"

        'Assert
        Assert.AreEqual("HELL", _mainWindow.ViewModel.Genes.Item(0).Code)

    End Sub

End Class