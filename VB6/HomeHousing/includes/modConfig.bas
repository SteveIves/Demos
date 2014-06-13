Attribute VB_Name = "modConfig"
'-------------------------------------------------------------------------
' This module provides common sets of configuration constants
' for the entire application
'-------------------------------------------------------------------------
Option Explicit

' User ids
Public Const giUNKNOWN_ID As Integer = 3   ' 3 for access  7 for sql

' Screen IDs
Public Const gsLOGON_SCREEN_ID As String = "log"
Public Const gsMESSAGE_SCREEN_ID As String = "message"
Public Const gsMAIN_SCREEN_ID As String = "main"
Public Const gsCREATE_SCHEME_SCREEN_ID As String = "create"
Public Const gsEDIT_BASIC_SCHEME_SCREEN_ID As String = "basic"
Public Const gsEDIT_SITE_SCREEN_ID As String = "site"
Public Const gsEDIT_PROPERTIES_SCREEN_ID As String = "prop"
Public Const gsEDIT_CONSULTANT_SCHEME_SCREEN_ID As String = "scheme_consultant"
Public Const gsEDIT_CONTRACTOR_SCHEME_SCREEN_ID As String = "scheme_contractor"
Public Const gsEDIT_GROUP_COSTS_SCREEN_ID As String = "group_costs"
Public Const gsEDIT_COSTS_SCREEN_ID As String = "costs"
Public Const gsEDIT_EST_COSTS_SCREEN_ID As String = "est_costs"
Public Const gsEDIT_FUNDING_SCREEN_ID As String = "funding"
Public Const gsSELECT_SCHEME_SCREEN_ID As String = "select"

' Database connections
' sql
Public Const gsDB_CONN_STRING As String = "DSN=SQLDevelopment;DATABASE=HomeHousing;UID=sa;PWD="
'access
'Public Const gsDB_CONN_STRING As String = "DSN=AccessDevelopment;"

' User table names
Public Const gsUSER_TABLE_NAME As String = "Users"
Public Const gsUSER_ID As String = "UserID"
Public Const gsREAL_NAME As String = "RealName"
Public Const gsUSERNAME As String = "Username"
Public Const gsPASSWORD As String = "Password"
' Scheme system table names
Public Const gsSCHEME_SYSTEM_TABLE_NAME As String = "SchemeSystemData"
Public Const gsSCHEME_TABLE_NAME As String = "Scheme"
Public Const gsSCHEME_SYS_ID As String = "SchemeID"


' Navigation values - all unique strings (! must be lower case  !)
Public Const gsGOTO_MAIN_SCREEN As String = "go_main"
Public Const gsGOTO_CREATE_SCHEME_SCREEN As String = "go_create"
Public Const gsATTEMPT_CREATE As String = "attempt_create"
Public Const gsATTEMPT_BASIC_UPDATE As String = "attempt_basic_update"
Public Const gsGOTO_SELECT_SCREEN As String = "go_select"
Public Const gsATTEMPT_SITE_UPDATE As String = "attempt_site_update"
Public Const gsATTEMPT_COST_UPDATE As String = "attempt_cost_update"
Public Const gsGOTO_COSTS_SCREEN As String = "go_costs"


' button bar values
Public Const gsGOTO_BASIC_SCHEME_SCREEN As String = "go_basic"
Public Const gsGOTO_SITE_SCREEN As String = "go_site"
Public Const gsGOTO_PROPERTIES_SCREEN As String = "go_prop"
Public Const gsGOTO_CONSULTANT_SCHEME_SCREEN As String = "go_scheme_consultant"
Public Const gsGOTO_CONTRACTOR_SCHEME_SCREEN As String = "go_scheme_contractor"
Public Const gsGOTO_GROUP_COSTS_SCREEN As String = "go_group_costs"
Public Const gsGOTO_FUNDING_SCREEN As String = "go_funding"


' Misc
Public Const gsSCHEME_OPTION_LIST As String = "10000"

Enum FieldType
    WebTextBox = 0
    WebRadioButton = 1
    WebDropDown = 2
    WebMultiLine = 3
    WebSpecial = 4
End Enum

Enum DbType
    Number = 0
    Text = 1
End Enum

Enum SchemeUpdateType
    Insert = 0
    Append = 1
End Enum

Enum StatusTypes
    SameAsDatabase = 0
    ChangedButNotCommittedToDB = 1
End Enum
