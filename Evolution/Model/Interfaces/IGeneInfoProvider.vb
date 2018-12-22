Imports System.Collections.ObjectModel

Public Interface IGeneInfoProvider

    ReadOnly Property GeneInfos As GeneInfos
    Function GetGeneInfoByGeneValue(ByVal geneValue As Integer) As GeneInfo
    Function GetGeneInfoByGeneCode(ByVal geneCode As String) As GeneInfo
    Function GetAllMatchingCodeNames(Optional ByVal filterString As String = "") As Collection(Of String)
    Function CloneGeneInfo(ByRef geneInfoToClone As GeneInfo) As GeneInfo


End Interface
