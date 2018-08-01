Imports System.Xml.Serialization
Imports System.IO
Imports System.Diagnostics
Imports System.Diagnostics.CodeAnalysis
Imports log4net

Public Enum LogLevels
    VERBOSE = 10
    DEBUG = 20
    INFO = 30
    WARN = 40
    ERRORS = 50
    SILENT = 100
End Enum


<ExcludeFromCodeCoverage()>
Public Class LogMessageHNDLR

    Shared _instance As LogMessageHNDLR
    Private _logFilePath As String
    Private _logFileName As String
    Private _logLevel As LogLevels

    Private Sub New(ByVal pLogFilePath As String, Optional ByVal pLogFileName As String = "LogFile.txt")
        _logFilePath = pLogFilePath
        _logFileName = pLogFileName
    End Sub

    Public Property LogDir As String
        Get
            Return _logFilePath
        End Get
        Set(ByVal value As String)
            _logFilePath = value
        End Set
    End Property

    Public Property LogFileName As String
        Get
            Return _logFileName
        End Get
        Set(ByVal value As String)
            _logFileName = value
        End Set
    End Property

    Public Property LogLevel As LogLevels
        Get
            Return _logLevel
        End Get
        Set(ByVal value As LogLevels)
            _logLevel = value
        End Set
    End Property

    Public Shared ReadOnly Property Instance() As LogMessageHNDLR
        Get
            If _instance Is Nothing Then
                _instance = New LogMessageHNDLR("\log\", "debuglog.txt") With {
                    .LogLevel = LogLevels.DEBUG
                }
            End If
            Return _instance
        End Get
    End Property

    Public Sub WriteLog(ByVal pMessage As String, Optional ByVal pSource As StackTrace = Nothing, Optional ByVal pLogLevel As LogLevels = LogLevels.VERBOSE)
        If pLogLevel < LogLevels.SILENT And pLogLevel >= _logLevel Then
            Dim logSource As String
            Dim source As StackTrace
            If pSource Is Nothing Then
                source = New StackTrace()
                logSource = source.GetFrame(2).GetMethod().DeclaringType.Name & "." & source.GetFrame(2).GetMethod().Name
            Else
                source = pSource
                logSource = source.GetFrame(0).GetMethod().DeclaringType.Name & "." & source.GetFrame(0).GetMethod().Name
            End If
            Dim csvSep As String = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator
            Dim logMess As String = pMessage
            Dim logLine As String = ""

            logMess = logMess.Replace("""", "'")
            If logMess.Contains(csvSep) Then
                logMess = """" & logMess & """"
            End If

            logSource = logSource.Replace("""", "'")
            If logSource.Contains(csvSep) Then
                logSource = """" & logSource & """"
            End If


            Dim loggerFileWrite As System.IO.StreamWriter
            Try
                Dim append As Boolean = True
                Dim logTarget As String = _logFilePath & Path.DirectorySeparatorChar & _logFileName
                If Not My.Computer.FileSystem.FileExists(logTarget) Then
                    'Dim myPath As Path = _logFileName
                    Dim myPath As String = Path.GetDirectoryName(logTarget)
                    If Not My.Computer.FileSystem.DirectoryExists(myPath) Then
                        My.Computer.FileSystem.CreateDirectory(myPath)
                    End If
                    Dim f As System.IO.FileStream = File.Create(logTarget)
                    f.Close()
                End If
                Dim logTimeString As String = My.Computer.Clock.GmtTime.ToString
                loggerFileWrite = My.Computer.FileSystem.OpenTextFileWriter(logTarget, True)
                For Each currLine In Split(logMess, vbCrLf)
                    logLine = logTimeString & csvSep & pLogLevel.ToString & csvSep & logSource & csvSep & currLine
                    loggerFileWrite.WriteLine(logLine)
                    If _logLevel = LogLevels.VERBOSE And pLogLevel = LogLevels.VERBOSE Then
                        For i = 0 To source.FrameCount - 1
                            loggerFileWrite.WriteLine(logTimeString & csvSep & pLogLevel.ToString & csvSep & source.GetFrame(i).GetMethod().DeclaringType.Name & "." & source.GetFrame(i).GetMethod().Name)
                        Next
                    End If
                Next
                loggerFileWrite.Close()
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("Something went wrong while logging: " & ex.Message & "Original message to log was: " & logLine)
                Throw ex
            End Try
        End If
    End Sub

    Public Sub Verbose(ByVal pMessage As String)
        WriteLog(pMessage, pLogLevel:=LogLevels.VERBOSE)
    End Sub

    Public Sub Debug(ByVal pMessage As String)
        WriteLog(pMessage, pLogLevel:=LogLevels.DEBUG)
    End Sub

    Public Sub Info(ByVal pMessage As String)
        WriteLog(pMessage, pLogLevel:=LogLevels.INFO)
    End Sub

    Public Sub Warn(ByVal pMessage As String)
        WriteLog(pMessage, pLogLevel:=LogLevels.WARN)
    End Sub

    Public Sub Err(ByVal pMessage As String)
        WriteLog(pMessage, pLogLevel:=LogLevels.ERRORS)
    End Sub

End Class