Imports System.Xml.Serialization
Imports System.IO

Public Class GeneInfoProvider

    Public Const DEFAULT_GENE_VALUE = 0

    Shared _instance As GeneInfoProvider = Nothing
    Dim _geneInfos As List(Of GeneInfo)

    Private Sub New()
        _geneInfos = New GeneInfos
        InitializeGenesInfoFromXML()
    End Sub

    ''' <summary>
    ''' Resturns an instance of GeneInfoProvider according to the Singleton Pattern
    ''' </summary>
    ''' <returns>Instance of GeneInfoProvider</returns>
    Public Shared ReadOnly Property Instance As GeneInfoProvider
        Get
            If _instance Is Nothing Then
                _instance = New GeneInfoProvider
            End If
            Return _instance
        End Get
    End Property

    ''' <summary>
    ''' Returns new GeneInfo Object with a value based on the given GeneValue and Code, NumberOfArgs and Description matching the value given, 
    ''' </summary>
    ''' <param name="geneValue">An Integer used a a base to create the new GeneInfo Object. Values of 0-255 are allowed, otherwise the default Object for value 0 is returned.</param>
    ''' <returns>A new instance of GeneInfo based </returns>
    Public Function GetGeneInfoFromGeneValue(ByVal geneValue As Integer) As GeneInfo
        Dim geneInfoFound = From geneInfo As GeneInfo In _geneInfos
                            Where geneInfo.Value = geneValue


        Dim returnGeneInfo As GeneInfo
        If geneInfoFound.Count > 0 Then
            returnGeneInfo = CloneGeneInfo(geneInfoFound.ElementAt(0))
        Else
            returnGeneInfo = CloneGeneInfo(_geneInfos.Item(DEFAULT_GENE_VALUE))
        End If
        Return returnGeneInfo

    End Function

    ''' <summary>
    ''' Returns a new instance of type GeneInfo with properies based on the given Code
    ''' </summary>
    ''' <param name="geneCode">A string which is matched against Code of defined GeneInfo.</param>
    ''' <returns>A new instance of geneInfo</returns>
    Public Function GetGeneInfoFromGeneCode(ByVal geneCode As String) As GeneInfo
        Dim geneInfoFound = From geneInfo As GeneInfo In _geneInfos
                            Where geneInfo.Code = geneCode

        Dim returnGeneInfos As GeneInfo
        If geneInfoFound.Count > 0 Then
            returnGeneInfos = CloneGeneInfo(geneInfoFound.ElementAt(0))
        Else
            returnGeneInfos = CloneGeneInfo(_geneInfos.Item(DEFAULT_GENE_VALUE))
        End If
        Return returnGeneInfos
    End Function


    ''' <summary>
    ''' Return a list of valid gene codes that start with the given filterString. Case is ignored in the comparison.
    ''' </summary>
    ''' <param name="filterString"></param>
    ''' <returns>List of String</returns>
    Public Function GetAllMatchingCodeNames(Optional ByVal filterString As String = "") As List(Of String)
        Dim returnNames As New List(Of String)
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
    Public Function CloneGeneInfo(ByRef geneInfoToClone As GeneInfo) As GeneInfo
        Dim returnGeneInfo As New GeneInfo
        If geneInfoToClone IsNot Nothing Then
            returnGeneInfo.Value = geneInfoToClone.Value
            returnGeneInfo.Code = geneInfoToClone.Code
            returnGeneInfo.NumberOfArgs = geneInfoToClone.NumberOfArgs
            returnGeneInfo.Description = geneInfoToClone.Description
        End If
        Return returnGeneInfo
    End Function

#Region "Private Function"
    ''' <summary>
    ''' Deserializes a GeneInfos XML resource into the _geneInfos field 
    ''' </summary>
    Private Sub InitializeGenesInfoFromXML()
        Try
            Dim appPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6)
            appPath = appPath & Path.DirectorySeparatorChar & "Resources" & Path.DirectorySeparatorChar & "GeneInfos.xml"
            Dim xmlGenesInfoWriter As New XMLFileHandlerDAO(Of GeneInfos)
            _geneInfos = xmlGenesInfoWriter.LoadXML(appPath)
        Catch ex As Exception
            Debug.WriteLine("An Error ocurre: " & ex.Message)
        End Try

    End Sub

#End Region

End Class