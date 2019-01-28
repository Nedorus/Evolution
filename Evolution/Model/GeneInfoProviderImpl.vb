Imports System.Xml.Serialization
Imports System.IO
Imports System.IO.Abstractions
Imports System.Diagnostics.CodeAnalysis

Imports log4net
Imports Evolution
Imports System.Collections.ObjectModel

Public Class GeneInfoProviderImpl
    Implements IGeneInfoProvider

    Public Const DEFAULT_GENE_VALUE = 0

    Dim _appPath As String
    Dim _geneInfos As GeneInfos
    Dim _xmlGenesInfoReader As XMLFileReader(Of GeneInfos)


    Public Sub New()
        _geneInfos = New GeneInfos
        '_appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6)
        '_appPath = _appPath & Path.DirectorySeparatorChar & "Resources" & Path.DirectorySeparatorChar & "GeneInfos.xml"
        '_xmlGenesInfoReader = New XMLFileReader(Of GeneInfos)(_appPath)
        'InitializeGenesInfoFromXML()
    End Sub

    Public Sub New(geneInfos As GeneInfos)
        _geneInfos = geneInfos
    End Sub

    Public ReadOnly Property GeneInfos As GeneInfos Implements IGeneInfoProvider.GeneInfos
        Get
            Return _geneInfos
        End Get
    End Property

    Public ReadOnly Property PathToGeneInfoXML As String
        Get
            Return _appPath
        End Get
    End Property

    Public Sub ReloadGeneInfosFromSource(ByRef pathToXML As String)
        _appPath = pathToXML
        _xmlGenesInfoReader = New XMLFileReader(Of GeneInfos)(_appPath)
        InitializeGenesInfoFromXML()
    End Sub

    ''' <summary>
    ''' Returns GeneInfo Object with a value based on the given GeneValue and Code, NumberOfArgs and Description matching the value given, 
    ''' </summary>
    ''' <param name="geneValue">An Integer used as a base to create the new GeneInfo Object. Values of 0-255 are allowed, otherwise the default Object for value 0 is returned.</param>
    ''' <returns>A new instance of GeneInfo based </returns>
    Public Function GetGeneInfoByGeneValue(ByVal geneValue As Integer) As GeneInfo Implements IGeneInfoProvider.GetGeneInfoByGeneValue
        Dim geneInfoFound = From geneInfo As GeneInfo In _geneInfos
                            Where geneInfo.Value = geneValue


        Dim returnGeneInfo As GeneInfo
        If geneInfoFound.Count > 0 Then
            returnGeneInfo = geneInfoFound.ElementAt(0)
        Else
            returnGeneInfo = _geneInfos.Item(DEFAULT_GENE_VALUE)
        End If
        Return returnGeneInfo

    End Function

    ''' <summary>
    ''' Returns GeneInfo Object with properies based on the given geneCode
    ''' </summary>
    ''' <param name="geneCode">A string which is matched against Code of defined GeneInfo.</param>
    ''' <returns>A new instance of geneInfo</returns>
    Public Function GetGeneInfoByGeneCode(ByVal geneCode As String) As GeneInfo Implements IGeneInfoProvider.GetGeneInfoByGeneCode
        Dim geneInfoFound = From geneInfo As GeneInfo In _geneInfos
                            Where geneInfo.Code = geneCode

        Dim returnGeneInfos As GeneInfo
        If geneInfoFound.Count > 0 Then
            returnGeneInfos = geneInfoFound.ElementAt(0)
        Else
            returnGeneInfos = _geneInfos.Item(DEFAULT_GENE_VALUE)
        End If
        Return returnGeneInfos
    End Function


    ''' <summary>
    ''' Return a list of valid gene codes that start with the given filterString. Case is ignored in the comparison.
    ''' </summary>
    ''' <param name="filterString"></param>
    ''' <returns>List of String</returns>
    Public Function GetAllMatchingCodeNames(Optional ByVal filterString As String = "") As Collection(Of String) Implements IGeneInfoProvider.GetAllMatchingCodeNames
        Dim returnNames As New Collection(Of String)
        Dim filteredNames = From geneInfos As GeneInfo In _geneInfos
                            Where geneInfos.Code.ToLower.StartsWith(filterString.ToLower)
                            Order By geneInfos.Value
                            Select geneInfos.Code Distinct

        For Each name In filteredNames
            returnNames.Add(name)
        Next
        Return returnNames
    End Function

    ''' <summary>
    ''' Returns a new GeneInfo object with properties equal to the given geneInfoToClone
    ''' </summary>
    ''' <param name="geneInfoToClone">A GeneInfo object to be cloned.</param>
    ''' <returns>Returns a new GeneInfo object.</returns>
    Public Function CloneGeneInfo(ByRef geneInfoToClone As GeneInfo) As GeneInfo Implements IGeneInfoProvider.CloneGeneInfo
        Dim returnGeneInfo As New GeneInfo
        If geneInfoToClone IsNot Nothing Then
            returnGeneInfo.Value = geneInfoToClone.Value
            returnGeneInfo.Code = geneInfoToClone.Code
            returnGeneInfo.NumberOfArgs = geneInfoToClone.NumberOfArgs
            returnGeneInfo.Description = geneInfoToClone.Description
            returnGeneInfo.Modifiers = geneInfoToClone.Modifiers
        End If
        Return returnGeneInfo
    End Function

#Region "Private Function"
    ''' <summary>
    ''' Deserializes a GeneInfos XML resource into the _geneInfos field 
    ''' </summary>
    Private Sub InitializeGenesInfoFromXML()
        _geneInfos = _xmlGenesInfoReader.LoadXML()
    End Sub

#End Region

End Class