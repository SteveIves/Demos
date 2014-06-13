VERSION 5.00
Object = "{DB797681-40E0-11D2-9BD5-0060082AE372}#4.0#0"; "XceedZip.dll"
Begin VB.UserControl Zipper 
   ClientHeight    =   705
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   675
   ScaleHeight     =   705
   ScaleWidth      =   675
   Begin XceedZipLibCtl.XceedZip XceedZip1 
      Left            =   120
      Top             =   120
      BasePath        =   ""
      CompressionLevel=   6
      EncryptionPassword=   ""
      RequiredFileAttributes=   0
      ExcludedFileAttributes=   24
      FilesToProcess  =   ""
      FilesToExclude  =   ""
      MinDateToProcess=   2
      MaxDateToProcess=   2958465
      MinSizeToProcess=   0
      MaxSizeToProcess=   0
      SplitSize       =   0
      PreservePaths   =   -1  'True
      ProcessSubfolders=   0   'False
      SkipIfExisting  =   0   'False
      SkipIfNotExisting=   0   'False
      SkipIfOlderDate =   0   'False
      SkipIfOlderVersion=   0   'False
      TempFolder      =   ""
      UseTempFile     =   -1  'True
      UnzipToFolder   =   ""
      ZipFilename     =   ""
      SpanMultipleDisks=   2
      ExtraHeaders    =   10
      ZipOpenedFiles  =   0   'False
      BackgroundProcessing=   0   'False
      SfxBinrayModule =   ""
      SfxDefaultPassword=   ""
      SfxDefaultUnzipToFolder=   ""
      SfxExistingFileBehavior=   0
      SfxReadmeFile   =   ""
      SfxExecuteAfter =   ""
      SfxInstallMode  =   0   'False
      SfxProgramGroup =   ""
      SfxProgramGroupItems=   ""
      SfxExtensionsToAssociate=   ""
      SfxIconFilename =   ""
   End
End
Attribute VB_Name = "Zipper"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public Function Zip(ByVal Directory As String, ByVal Files As String, ByVal ZipFile As String) As Boolean
    
    Dim Result As xcdError
    
    XceedZip1.ZipFilename = ZipFile
    XceedZip1.BasePath = Directory
    XceedZip1.FilesToProcess = Files
    
    Result = XceedZip1.Zip

    If (Result <> xerSuccess) Then
        Zip = False
    Else
        Zip = True
    End If

End Function
