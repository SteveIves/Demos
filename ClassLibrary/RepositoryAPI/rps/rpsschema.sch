
;  SYNERGY DATA LANGUAGE OUTPUT
;
;  REPOSITORY     : C:\Development\SynPSG\ChronoTrack\rps\rpsmain.ism
;                 : C:\Development\SynPSG\ChronoTrack\rps\rpstext.ism
;                 : Version 9.1.5b
;
;  GENERATED      : 14-JAN-2010, 15:42:33
;                 : Version 9.3.1
;  EXPORT OPTIONS : [ALL-K-R-A]


Format F_PRICE   Type NUMERIC   "$$$,$$$,$$X.XX"

Template T_BOOLEAN   Type DECIMAL   Size 1   Coerced Type BOOLEAN
   Description "Boolean"
   Report Heading "Boolean"   Report Just LEFT   Input Just LEFT   Checkbox
   Range 0 1

Template T_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date"
   Prompt "Date"   Help "H_Date"
   Info Line "Enter a date in the format XX/XX/XXXX"   Format "#01  MM/DD/YYYY"
   Report Heading "Date"   Blankifzero
   Drill Method "date_drill"

Template T_PHONE   Type ALPHA   Size 20
   Description "Phone Number"
   Prompt "Phone #"   Help "H_Phone"   Info Line "Enter phone number"
   Report Heading "Phone #"   Report Just RIGHT   Input Just RIGHT

Template T_USERNAME   Type ALPHA   Size 15
   Description "User Name"
   Prompt "Username"   Help "H_UserName"
   Info Line "Enter or select a username"   Report Heading "Username"
   Uppercase
   Required
   Drill Method "user_drill"   Change Method "user_change"

Template T_ACTIVITYTYPE   Type DECIMAL   Size 2
   Description "Type of activity"
   Prompt "Activity Type"   Help "H_ActivityType"
   Info Line "Select the type of activity"   Report Heading "Activity Type"
   Report Just LEFT   Input Just LEFT
   Selection List 0 0 0  Entries "On Site", "Assigned", "Requested", "Travel",
         "Vacation", "Sick"
   Enumerated 9 0 1

Template T_ACTIVITY_NUMBER   Type DECIMAL   Size 4
   Description "Activity number (sequence in project)"
   Prompt "Activity #"
   Info Line "Enter or select a project activity sequence number"
   Report Heading "Activity #"   Blankifzero
   Required
   Drill Method "activity_drill"   Change Method "activity_change"

Template T_ADDRESS   Type ALPHA   Size 30
   Description "Address line"
   Prompt "Address"   Help "H_Address"   Info Line "Enter the address"
   Report Heading "Address"

Template T_ADDRESSTYPE   Type DECIMAL   Size 2
   Description "Address Type"
   Prompt "Address Type"   Help "H_AddressType"
   Info Line "Select the appropriate address type"
   Report Heading "Address Type"   Report Just LEFT   Input Just LEFT
   Selection List 0 0 0  Entries "Mail", "Site"
   Enumerated 4 0 1

Template T_ATTACHMENT_NUMBER   Type DECIMAL   Size 3
   Description "Attachment # (sequence in project task)"
   Prompt "Attachment #"
   Info Line "Enter or select a project task attachment number"
   Report Heading "Attachment #"   Blankifzero
   Required
   Drill Method "attachment_drill"   Change Method "attachment_change"

Template T_CONTACT   Type DECIMAL   Size 3
   Description "Contact ID"
   Prompt "Contact ID"   Info Line "Enter or select a contact ID"
   Report Heading "Contact ID"   Blankifzero
   Required
   Drill Method "contact_drill"   Change Method "contact_change"

Template T_CONTRACT   Type ALPHA   Size 10
   Description "Contract Number"
   Prompt "Contract #"   Help "H_ContractNo"
   Info Line "Enter the contract number"   Report Heading "Contract #"
   Uppercase
   Required
   Drill Method "contract_drill"   Change Method "contract_change"

Template T_COUNTRYCODE   Type ALPHA   Size 2
   Description "2-letter country code"
   Prompt "Country"   Help "H_CountryCode"   Info Line "2-letter country code"
   Report Heading "Country"
   Uppercase
   Required
   Drill Method "country_drill"   Change Method "country_change"

Template T_CURRENCY   Type ALPHA   Size 2
   Description "Currency Code"
   Prompt "Currency Code"   Help "H_CurrencyCode"   Info Line "Currency code"
   Report Heading "Currency"

Template T_CUSTNO   Type ALPHA   Size 10
   Description "Customer Number"
   Prompt "Customer #"   Help "H_CustNo"   Info Line "Enter customer number"
   Report Heading "Customer #"
   Uppercase
   Required
   Drill Method "customer_drill"   Change Method "customer_change"

Template T_CUSTOMER_NAME   Type ALPHA   Size 40
   Description "Company name"
   Prompt "Company"   Info Line "Enter the customers company name"
   Report Heading "Company"
   Required

Template T_DATETIME   Type USER   Size 14   Stored NUMERIC
   User Type "^CLASS^=YYYYMMDDHHMISS"
   Description "DateTime"

Template T_DATE_READONLY   Parent T_DATE
   Readonly
   Required
   Nodrill Method

Template T_DAY_COLUMN   Type ALPHA   Size 1
   Description "Day column type for gantt chart"

Template T_DESCRIPTION   Type ALPHA   Size 60
   Description "Short description"
   Prompt "Description"   Info Line "Enter a short description of this item"
   Report Heading "Description"
   Required

Template T_DOCUMENTTYPE   Type DECIMAL   Size 2
   Description "Document type"
   Prompt "Document Type"   Help "H_DocumentType"
   Info Line "Select the type of document"   Report Heading "Document Type"
   Report Just LEFT   Input Just LEFT
   Selection List 0 0 0  Entries "Contract", "Project", "Screen Shot",
         "Reference"
   Enumerated 11 0 1

Template T_EMAIL   Type ALPHA   Size 70
   Description "Email Address"
   Prompt "Email"   Help "H_Email"   Info Line "Enter an email address"
   Report Heading "Email"
   Required
   Change Method "email_change"

Template T_EXPENSETYPE   Type ALPHA   Size 10
   Description "Expense Type"
   Prompt "Expense Type"   Help "H_ExpenseType"
   Info Line "Enter the expense type code"   Report Heading "Expense Type"
   Uppercase
   Required
   Drill Method "expense_type_drill"   Change Method "expense_type_change"

Template T_EXPENSE_NUMBER   Type DECIMAL   Size 6
   Description "Expense # (sequence in project)"
   Prompt "Expense #"
   Info Line "Enter or select a project expense sequence number"
   Report Heading "Expense #"   Blankifzero
   Required
   Drill Method "expense_drill"   Change Method "expense_change"

Template T_FEETYPE   Type DECIMAL   Size 2
   Description "Fee Type"
   Prompt "Fee Type"   Help "H_FeeType"
   Info Line "Select the appropriate fee type"   Report Heading "Fee Type"
   Report Just LEFT   Input Just LEFT
   Selection List 0 0 0  Entries "Hourly", "Daily", "Flat Rate", "Travel",
         "Lodging"
   Enumerated 9 0 1
   Drill Method "fee_type_drill"   Change Method "fee_type_change"

Template T_FILEPATH   Type ALPHA   Size 255
   Description "File Path"
   Prompt "File location"   Help "H_FilePath"
   Info Line "Enter the full path and name of the file"   Report Heading "File"
   View Length 60
   Drill Method "file_drill"   Change Method "file_change"

Template T_FIRST_NAME   Type ALPHA   Size 30
   Description "First name"
   Prompt "First Name"   Help "H_Name"
   Info Line "Enter the persons first name"   Report Heading "First Name"
   Required

Template T_FRIENDLY_NAME   Type ALPHA   Size 60
   Description "Friendly name (e.g. First Last)"
   Prompt "Friendly Name"

Template T_GRFA   Type ALPHA   Size 22   Script Noview   Report Noview
   Description "Unique GRFA field"

Template T_IN_TRAVEL_DAYS   Type DECIMAL   Size 1
   Description "Inbound travel days"

Template T_JOB_TITLE   Type ALPHA   Size 30
   Description "Job Title"
   Prompt "Job Title"   Info Line "Enter the persons job title"
   Report Heading "Job Title"

Template T_KEY_OVERLAY   Type ALPHA   Size 1   Script Noview   Report Noview
   Nonamelink
   Description "Key overlay"

Template T_LAST_NAME   Type ALPHA   Size 30
   Description "Last name"
   Prompt "Last Name"   Help "H_Name"   Info Line "Enter the persons last name"
   Report Heading "Last Name"
   Uppercase
   Required

Template T_LOCATION_NUMBER   Type DECIMAL   Size 2
   Description "Customer location number"
   Prompt "Location #"   Report Heading "Location #"   Blankifzero
   Required
   Drill Method "location_drill"   Change Method "location_change"

Template T_NOTETYPE   Type DECIMAL   Size 2
   Description "Note Type"
   Prompt "Note Type"   Help "H_NoteType"
   Info Line "Select the type of note you are entering"
   Report Heading "Note Type"   Report Just LEFT   Input Just LEFT
   Selection List 0 0 0  Entries "General", "Diary", "Recommendation"
   Enumerated 14 0 1

Template T_NOTE_NUMBER   Type DECIMAL   Size 4
   Description "Project note number (sequence)"
   Prompt "Note #"   Info Line "Enter or select a project note sequence number"
   Report Heading "Note #"   Blankifzero
   Required
   Drill Method "note_drill"   Change Method "note_change"

Template T_OUT_TRAVEL_DAYS   Type DECIMAL   Size 1
   Description "Outbound travel days"

Template T_PASSWORD   Type ALPHA   Size 15   Report Noview
   Description "User password"
   Prompt "Password"   Help "H_Password"   Info Line "Enter user password"
   Report Heading "Password"
   Noecho   Noechochr "*"
   Required

Template T_PHONE_MOBILE   Parent T_PHONE
   Description "Mobile phone number"
   Prompt "Mobile Phone"   Info Line "Enter mobile phone number"
   Report Heading "Mobile Phone"

Template T_PHONE_OFFICE   Parent T_PHONE
   Description "Office phone number"
   Prompt "Office Phone"   Info Line "Enter office phone number"
   Report Heading "Office Phone"

Template T_PRICE   Type DECIMAL   Size 11   Precision 2
   Description "Price or amount"
   Prompt "Price"   Help "H_Price"   Info Line "Enter the price"
   Format F_PRICE   Report Heading "Price"   Input Just LEFT
   Negative

Template T_PROJECT   Type DECIMAL   Size 8
   Description "Project number"
   Prompt "Project #"   Help "H_ProjectNumber"
   Info Line "Enter or select a customer project number"
   Report Heading "Project #"   Report Just LEFT   Input Just LEFT
   Blankifzero
   Required
   Drill Method "project_drill"   Change Method "project_change"

Template T_PROJECTSTATUS   Type DECIMAL   Size 2
   Description "Project Status"
   Prompt "Project Status"   Help "H_ProjectStatus"
   Info Line "Select the current project status"
   Report Heading "Project Status"   Report Just LEFT   Input Just LEFT
   Selection List 0 0 0  Entries "Created", "Quoted", "Signed",
         "Implementation", "Post-project", "Completed"
   Enumerated 14 0 1
   Change Method "project_status_change"

Template T_PROJECT_TYPE   Type DECIMAL   Size 2
   Description "type of project/request"

Template T_REPLICATION_KEY   Type ALPHA   Size 20   Script Noview
   Report Noview   Nonamelink
   Description "SQL Replication Timestamp"

Template T_REQUEST   Type DECIMAL   Size 6
   Description "Request number"
   Prompt "Request #"   Help "H_RequestNumber"
   Info Line "Enter or select a work request number"
   Report Heading "Request #"   Report Just LEFT   Input Just LEFT
   Blankifzero
   Required
   Drill Method "request_drill"   Change Method "request_change"

Template T_SPARE_SPACE   Type ALPHA   Size 1   Script Noview   Report Noview
   Nonamelink
   Description "Spare space"

Template T_SQL_TIMESTAMP   Type ALPHA   Size 20   Script Noview   Report Noview
   Nonamelink
   Description "SQL Replication Timestamp"

Template T_STATE   Type ALPHA   Size 2
   Description "Address State"
   Prompt "State"   Help "H_State"   Info Line "Enter the State (US only)"
   Report Heading "State"
   Uppercase
   Drill Method "state_drill"   Change Method "state_change"

Template T_STATE_NAME   Type ALPHA   Size 30
   Description "State name"
   Prompt "Name"   Report Heading "Name"

Template T_TASKTYPE   Type DECIMAL   Size 3
   Description "Type of Project Task"
   Prompt "Type"   Help "H_TaskType"   Info Line "Select the type of task"
   Report Heading "Task Type"   Report Just LEFT   Input Just LEFT
   Required
   Selection List 0 0 0  Entries "Pre-project", "Implementation",
         "Post-Project", "PSG Time", "Beta Testing", "Development Doc Review",
         "Marketing Doc Review", "Vacation", "Illness", "Sales Trip",
         "Training and Education"
   Enumerated 22 0 1
   Change Method "task_type_change"

Template T_TASK_NUMBER   Type DECIMAL   Size 3
   Description "Task number"
   Prompt "Task #"   Info Line "Enter or select a task number"
   Report Heading "Task #"   Blankifzero
   Required
   Drill Method "task_drill"   Change Method "task_change"

Template T_TIME   Type TIME   Size 4   Stored HHMM
   Description "Time"
   Prompt "Time"   Help "H_Time"   Info Line "Enter the time"
   Format "#02  24:MM"   Report Heading "Time"   Blankifzero

Template T_USERNAME_READONLY   Parent T_USERNAME
   Readonly
   Nodrill Method   Nochange Method

Template T_USERTYPE   Parent T_BOOLEAN
   Description "User type (multiple selections allowed)"
   Help "H_USERTYPE"
   Info Line "Identifies user as the given type (multiple selections ok)"
   Report Heading "User Type"
   Change Method "user_type_change"

Template T_ZIP   Type ALPHA   Size 10
   Description "Zip Code"
   Prompt "Zip Code"   Help "H_Zip"   Info Line "Enter the Zip or Postal Code"
   Report Heading "Zip Code"
   Uppercase

Structure USER   DBL ISAM
   Description "User records"

Field SYNERGYGRFA   Template T_GRFA

Field USER_ID   Template T_USERNAME

Field PASSWORD   Template T_PASSWORD

Field INACTIVE   Template T_USERTYPE
   Description "User is inactive"
   Prompt "Inactive"   Report Heading "Inavtive"

Field FIRST_NAME   Template T_FIRST_NAME

Field LAST_NAME   Template T_LAST_NAME
   User Text "@CODEGEN_DISPLAY_FIELD"

Field TITLE   Template T_JOB_TITLE

Field SPARE_DATA   Type ALPHA   Size 134   Script Noview   Report Noview

Field OFFICE_PHONE   Template T_PHONE_OFFICE

Field MOBILE_PHONE   Template T_PHONE_MOBILE

Field EMAIL   Template T_EMAIL

Field IS_EMPLOYEE   Template T_USERTYPE
   Description "Is user an employee?"
   Prompt "Employee"   Report Heading "Employee"

Field IS_MANAGER   Template T_USERTYPE
   Description "Is user a manager?"
   Prompt "Manager"   Report Heading "Manager"

Field IS_CONSULTANT   Template T_USERTYPE
   Description "Is user a consultant?"
   Prompt "Consultant"   Report Heading "Consultant"

Field PICTURE_FILE   Template T_FILEPATH
   Description "Path to contact image file"
   Prompt "Picture"   Report Heading "Picture File"

Field FRIENDLY_NAME   Template T_FRIENDLY_NAME

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Field ADDR1   Template T_ADDRESS
   Description "Address line 1"
   Info Line "Enter the first address line"   Report Heading "Address 1"

Field ADDR2   Template T_ADDRESS
   Noprompt   Info Line "Enter the second address line"
   Report Heading "Address 2"

Field ADDR3   Template T_ADDRESS
   Noprompt   Info Line "Enter the third address line"
   Report Heading "Address 3"

Field ADDR4   Template T_ADDRESS
   Noprompt   Info Line "Enter the fourth address line"
   Report Heading "Address 4"

Field STATE   Template T_STATE

Field ZIP   Template T_ZIP

Field COUNTRY_ID   Template T_COUNTRYCODE

Field ENCRYPT_FILLER   Type ALPHA   Size 2

Field ADDRESS_DATA   Type ALPHA   Size 134   Overlay ADDR1:0

Field ENCRYPTED_DATA   Type ALPHA   Size 136   Overlay ADDR1:0

Key USER_KEY0   ACCESS   Order ASCENDING   Dups NO   Compress INDEX RECORD KEY
   Segment FIELD   USER_ID

Key USER_KEY1   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   Compress INDEX RECORD KEY   Krf 001
   Description "Users by email address"
   Segment FIELD   EMAIL

Key USER_KEY2   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 002
   Description "Users by last name"
   Segment FIELD   LAST_NAME

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 003
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Relation  1   USER USER_KEY0   CONSULTANT_FEE CONSULTANT_FEE_KEY0

Structure REQUEST   DBL ISAM
   Description "Project Request record"

Field SYNERGYGRFA   Template T_GRFA

Field REQUEST_ID   Template T_REQUEST

Field CUSTOMER_ID   Template T_CUSTNO

Field CONTACT_ID   Template T_CONTACT
   Description "Customer contact ID"
   Prompt "Contact #"   Report Heading "Contact #"

Field PROJECT_ID   Template T_PROJECT
   Description "Existing project number (if known)"
   Prompt "Existing Project #"
   Info Line "Enter existing project number, if known"
   Norequired

Field WORK_LOCATION_ID   Template T_LOCATION_NUMBER
   Description "Customer location for deliverables"
   Prompt "Location For Work"
   Norequired

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short description (for lists)"
   Info Line "Enter a short description of this request"
   User Text "@CODEGEN_DISPLAY_FIELD"

Field RESOURCE   Template T_USERNAME
   Description "User Name of requested resource"
   Prompt "Consultant"
   Info Line "Enter username of requested consultant, employee, etc."
   Report Heading "Consultant"
   Norequired

Field START_DATE   Template T_DATE
   Description "Requested start date"
   Prompt "Start Date"   Report Heading "Start Date"

Field END_DATE   Template T_DATE
   Description "Requested end date"
   Prompt "End Date"   Report Heading "End Date"

Field START_TIME   Template T_TIME
   Description "Start time (if single day)"
   Prompt "Start Time"   Info Line "Enter the requested start time"
   Report Heading "Start Time"

Field END_TIME   Template T_TIME
   Description "End time (if single day)"
   Prompt "End Time"   Info Line "Enter the requested end time"
   Report Heading "End Time"

Field CREATED_BY   Template T_USERNAME
   Description "Request created by (username)"
   Prompt "Requested By"   Report Heading "Created By"   Noreadonly

Field CREATED_DATE   Template T_DATE_READONLY
   Description "Date request created"
   Prompt "Created"   Report Heading "Created"

Field TEXT   Type ALPHA   Size 700   Script Noview
   Description "Description of planned activity"
   Prompt "Detail"   Info Line "Enter a description of the planned activity"
   Report Heading "Detail"
   Required

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key REQUEST_KEY0   ACCESS   Order ASCENDING   Dups NO
   Compress INDEX RECORD KEY
   Segment FIELD   REQUEST_ID

Key REQUEST_KEY1   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 001
   Description "Requests by start date"
   Segment FIELD   START_DATE

Key REQUEST_KEY2   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 002
   Description "Requests by originator and date"
   Segment FIELD   CREATED_BY
   Segment FIELD   CREATED_DATE

Key REQUEST_KEY3   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 003
   Description "Requests by customer and start date"
   Segment FIELD   RESOURCE
   Segment FIELD   START_DATE

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 004
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure CUSTOMER_LOCATION   DBL ISAM
   Description "Customer location record"
   User Text "@ALIAS=LOCATION;"

Field SYNERGYGRFA   Template T_GRFA

Field CUSTOMER_ID   Template T_CUSTNO

Field LOCATION_ID   Template T_LOCATION_NUMBER

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Description (e.g. New York Office)"
   Info Line "Enter a short description of this location"
   User Text "@CODEGEN_DISPLAY_FIELD"

Field ADDR1   Template T_ADDRESS
   Description "Address line 1"
   Info Line "Enter the first address line"   Report Heading "Address 1"

Field ADDR2   Template T_ADDRESS
   Noprompt   Info Line "Enter the second address line"
   Report Heading "Address 2"

Field ADDR3   Template T_ADDRESS
   Noprompt   Info Line "Enter the third address line"
   Report Heading "Address 3"

Field ADDR4   Template T_ADDRESS
   Noprompt   Info Line "Enter the fourth address line"
   Report Heading "Address 4"

Field STATE   Template T_STATE

Field ZIP   Template T_ZIP

Field COUNTRY_ID   Template T_COUNTRYCODE
   Report Heading "Country Code"

Field PHONE   Template T_PHONE_OFFICE

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key CUSTOMER_LOCATION_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   CUSTOMER_ID
   Segment FIELD   LOCATION_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure APPUSER_OPTIONS   USER DEFINED
   Description "Application User Options"
   User Text "@NOCODEGEN"

Field DEFAULT_USER_NAME   Template T_USERNAME

Field DISPLAY_TRANSACTION_VIEWER   Type INTEGER   Size 1
   Description "set to display transaction viewer"

Field DEFAULT_VIEW_STATE   Type INTEGER   Size 1
   Description "default view to display"

Field HISTORY_MONTHS_TO_LOAD   Type INTEGER   Size 1
   Description "number of history monthsto load"

Structure CONSULTANT_FEE   DBL ISAM
   Description "Consultant fee structures"

Field SYNERGYGRFA   Template T_GRFA

Field USER_ID   Template T_USERNAME
   Description "Consultant username"
   Prompt "Consultant"   Info Line "Enter consultant username"

Field FEE_TYPE_ID   Template T_FEETYPE

Field COST   Template T_PRICE
   Description "Cost of consultant, by fee type"
   Prompt "Cost"
   Info Line "Enter the cost of the consultant for the selected fee type"
   Report Heading "Cost"

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key CONSULTANT_FEE_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   USER_ID
   Segment FIELD   FEE_TYPE_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure CONSULTANT_FEE_SUMMARY   USER DEFINED
   Description "Consultant fee structures (web)"
   User Text "@NOCODEGEN"

Field USER_ID   Template T_USERNAME
   Description "Consultant username"
   Prompt "Consultant"   Info Line "Enter consultant username"

Field FEE_TYPE_ID   Template T_FEETYPE

Field DESCRIPTION   Type ALPHA   Size 35
   Description "Description"

Field COST   Template T_PRICE
   Description "Cost of consultant, by fee type"
   Prompt "Cost"
   Info Line "Enter the cost of the consultant for the selected fee type"
   Report Heading "Cost"

Structure CONSULTANT_SCHEDULE   USER DEFINED
   Description "Consultant schedule information"
   User Text "@NOCODEGEN"

Field ID   Type DECIMAL   Size 6
   Description "Unique ID for schedule entry"

Field CONSULTANT_ID   Template T_USERNAME

Field START_DATE   Template T_DATE
   Description "Appointment start date"

Field START_TIME   Template T_TIME
   Description "Appointment start time"

Field END_DATE   Template T_DATE
   Description "Appointment end date"

Field END_TIME   Template T_TIME
   Description "Appointment end time"

Field SUBJECT   Template T_DESCRIPTION

Field DESCRIPTION   Type ALPHA   Size 700
   Description "Long description"

Field LOCATION   Template T_DESCRIPTION
   Description "Location name"

Field STATUS   Type DECIMAL   Size 1
   Description "Time slot status"

Field APPOINTMENT_TYPE   Type DECIMAL   Size 2
   Description "Appointment type (business etc.)"

Structure COUNTRY   DBL ISAM
   Description "Country Master File"

Field SYNERGYGRFA   Template T_GRFA

Field COUNTRY_ID   Template T_COUNTRYCODE
   Report Heading "Country Code"

Field COUNTRY_NAME   Type ALPHA   Size 30
   Description "Country name"
   Prompt "Country"   Help "H_CountryName"
   Info Line "Enter the name of the country"
   User Text "@CODEGEN_DISPLAY_FIELD"   Report Heading "Country Name"
   Required

Field DIALING_CODE   Type DECIMAL   Size 5
   Description "International calling code"
   Prompt "Intn'l Dialing Code"   Help "H_DialingCode"
   Info Line "Enter the international dialing code"
   Report Heading "Dialling Code"   Report Just LEFT   Input Just LEFT
   Blankifzero

Field CURRENCY_CODE   Template T_CURRENCY

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key COUNTRY_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   COUNTRY_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure CUSTOMER   DBL ISAM
   Description "Customer Master File"

Field SYNERGYGRFA   Template T_GRFA

Field CUSTOMER_ID   Template T_CUSTNO

Field COMPANY   Template T_CUSTOMER_NAME
   User Text "@CODEGEN_DISPLAY_FIELD"

Field TECH_CONTACT_ID   Template T_CONTACT
   Description "Tech Contact ID"
   Prompt "Tech Contact ID"   Report Heading "Technical Contact"
   Norequired

Field LEGAL_CONTACT_ID   Template T_CONTACT
   Description "Primary legal contact ID"
   Prompt "Primary Legal Contact"   Report Heading "Legal Contact"
   Norequired

Field CURRENT_CONTRACT   Template T_CONTRACT
   Description "Current contract number"
   Info Line "Enter the customers current contract number"
   Norequired

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key CUSTOMER_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   CUSTOMER_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Relation  2   CUSTOMER CUSTOMER_KEY0   CUSTOMER_CONTACT CUSTOMER_CONTACT_KEY0

Relation  3   CUSTOMER CUSTOMER_KEY0   CUSTOMER_CONTRACT CUSTOMER_CONTRACT_KEY0

Relation  4   CUSTOMER CUSTOMER_KEY0   CUSTOMER_LOCATION CUSTOMER_LOCATION_KEY0

Structure CUSTOMER_BREIF   USER DEFINED
   Description "Partial Customer Master File"
   User Text "@NOCODEGEN"

Field SYNERGYGRFA   Template T_GRFA

Field CUSTOMER_ID   Template T_CUSTNO

Field COMPANY   Template T_CUSTOMER_NAME
   User Text "@CODEGEN_DISPLAY_FIELD"

Key CUSTOMER_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   CUSTOMER_ID

Structure CUSTOMER_CONTACT   DBL ISAM
   Description "Customer contact record"
   User Text "@ALIAS=CONTACT;"

Field SYNERGYGRFA   Template T_GRFA

Field CUSTOMER_ID   Template T_CUSTNO

Field CONTACT_ID   Template T_CONTACT
   Noreadonly
   Nodrill Method   Nochange Method

Field FIRST_NAME   Template T_FIRST_NAME

Field LAST_NAME   Template T_LAST_NAME
   User Text "@CODEGEN_DISPLAY_FIELD"

Field TITLE   Template T_JOB_TITLE

Field CURRENT_LOCATION   Template T_LOCATION_NUMBER
   Description "Contacts cuttent location"
   Prompt "Current Location"   Report Heading "Current Location"

Field OFFICE_PHONE   Template T_PHONE_OFFICE

Field MOBILE_PHONE   Template T_PHONE_MOBILE

Field EMAIL   Template T_EMAIL

Field PICTURE_FILE   Template T_FILEPATH
   Description "Path to contact image file"
   Prompt "Picture File"   Report Heading "Picture File"

Field FRIENDLY_NAME   Template T_FRIENDLY_NAME

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key CUSTOMER_CONTACT_KEY0   ACCESS   Order ASCENDING   Dups NO
   Compress INDEX RECORD KEY
   Segment FIELD   CUSTOMER_ID
   Segment FIELD   CONTACT_ID

Key CUSTOMER_CONTACT_KEY1   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 001
   Description "Contacts for a customer location"
   Segment FIELD   CUSTOMER_ID
   Segment FIELD   CURRENT_LOCATION

Key CUSTOMER_CONTACT_KEY2   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 002
   Description "All contacts by last name"
   Segment FIELD   LAST_NAME

Key CUSTOMER_CONTACT_KEY3   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   Compress INDEX RECORD KEY   Krf 003
   Description "All customer contacts by email address"
   Segment FIELD   EMAIL

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 004
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure CUSTOMER_CONTRACT   DBL ISAM
   Description "Customer contracts"
   User Text "@ALIAS=CONTRACT;"

Field SYNERGYGRFA   Template T_GRFA

Field CUSTOMER_ID   Template T_CUSTNO

Field CONTRACT_ID   Template T_CONTRACT

Field ISSUED_BY   Template T_USERNAME
   Prompt "Issued By"
   Info Line "Enter or select the user who issued the contract"
   Report Heading "Issued By"

Field ISSUED_DATE   Template T_DATE
   Description "Date issued"
   Prompt "Issued"   Info Line "Enter the date that the contract was issued"
   Report Heading "Issued Date"
   Required

Field SIGNED_BY   Template T_CONTACT
   Description "Contract signed by (customer contact)"
   Prompt "Signed By"
   Info Line "Enter or select the customer contact who signed the contract"
   Report Heading "Signed By"
   Norequired

Field SIGNED_DATE   Template T_DATE
   Description "Date contract was signed by contact"
   Prompt "Signed"
   Info Line "Enter the date the contract was signed by the customer"
   User Text "@CODEGEN_DISPLAY_FIELD"   Report Heading "Signed Date"

Field CREATED_BY   Template T_USERNAME_READONLY
   Description "Contract record created by (username)"
   Prompt "Created By"
   Info Line "The user that entered the contract into the system"
   Report Heading "Created By"

Field CREATED_DATE   Template T_DATE_READONLY
   Description "Date contract entered into system"
   Prompt "Created"
   Info Line "The date the contract was entered into the system"
   Report Heading "Created Date"

Field CONTRACT_DOCUMENT   Template T_FILEPATH
   Description "Contract file spec"
   Prompt "Contract File"
   Info Line "Enter or select the file spec of the contract document"
   Report Heading "Contract Document"
   Norequired

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key CUSTOMER_CONTRACT_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   CUSTOMER_ID
   Segment FIELD   CONTRACT_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure CUSTOMER_LOCATION_INPUT   USER DEFINED
   Description "Customer location input record"
   User Text "@NOCODEGEN"

Group CUSTOMER_LOCATION   Reference CUSTOMER_LOCATION   Type ALPHA

Field CUSTOMER_ID_DSP   Template T_CUSTOMER_NAME
   Noprompt   Noinfo   Disabled
   Norequired

Structure EXPENSE_TYPE   DBL ISAM
   Description "Expense Types"

Field SYNERGYGRFA   Template T_GRFA

Field EXPENSE_TYPE_ID   Template T_EXPENSETYPE

Field DESCRIPTION   Type ALPHA   Size 35
   Description "Expense type description"
   Prompt "Description"   Info Line "Enter a description for the expense type"
   User Text "@CODEGEN_DISPLAY_FIELD"   Report Heading "Description"
   Required

Field HAS_UNITS   Template T_BOOLEAN
   Description "Does this expense type have units?"
   Prompt "Has Units"
   Info Line "Indicate whether the expense type can have multiple units"
   Report Heading "Has Units"

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key EXPENSE_TYPE_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   EXPENSE_TYPE_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure FEE_TYPE   DBL ISAM
   Description "Fee types"

Field SYNERGYGRFA   Template T_GRFA

Field FEE_TYPE_ID   Template T_FEETYPE

Field DESCRIPTION   Type ALPHA   Size 35
   Description "Fee type description"
   Prompt "Description"   Info Line "Enter a description for the fee type"
   User Text "@CODEGEN_DISPLAY_FIELD"   Report Heading "Description"
   Required

Field HAS_UNITS   Template T_BOOLEAN
   Description "Does this fee type have units?"
   Prompt "Has Units"
   Info Line "Indicate whether the fee type can have multiple units"
   Report Heading "Has Units"

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key FEE_TYPE_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   FEE_TYPE_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure GANTT_VIEW   USER DEFINED
   Description "Gantt view layout"
   User Text "@NOCODEGEN"

Field USER_ID   Template T_USERNAME

Field PROJECT_ID   Template T_PROJECT

Field PROJECT_TYPE   Template T_PROJECT_TYPE
   Description "Type of project/request"

Field DESCRIPTION   Template T_DESCRIPTION

Field START_DATE   Template T_DATE

Field END_DATE   Template T_DATE

Field OUTBOUND_TRAVEL_DAYS   Template T_OUT_TRAVEL_DAYS

Field INBOUND_TRAVEL_DAYS   Template T_IN_TRAVEL_DAYS

Field DAY1   Template T_DAY_COLUMN

Field DAY2   Template T_DAY_COLUMN

Field DAY3   Template T_DAY_COLUMN

Field DAY4   Template T_DAY_COLUMN

Field DAY5   Template T_DAY_COLUMN

Field DAY6   Template T_DAY_COLUMN

Field DAY7   Template T_DAY_COLUMN

Field DAY8   Template T_DAY_COLUMN

Field DAY9   Template T_DAY_COLUMN

Field DAY10   Template T_DAY_COLUMN

Field DAY11   Template T_DAY_COLUMN

Field DAY12   Template T_DAY_COLUMN

Field DAY13   Template T_DAY_COLUMN

Field DAY14   Template T_DAY_COLUMN

Field DAY15   Template T_DAY_COLUMN

Field DAY16   Template T_DAY_COLUMN

Field DAY17   Template T_DAY_COLUMN

Field DAY18   Template T_DAY_COLUMN

Field DAY19   Template T_DAY_COLUMN

Field DAY20   Template T_DAY_COLUMN

Field DAY21   Template T_DAY_COLUMN

Field DAY22   Template T_DAY_COLUMN

Field DAY23   Template T_DAY_COLUMN

Field DAY24   Template T_DAY_COLUMN

Field DAY25   Template T_DAY_COLUMN

Field DAY26   Template T_DAY_COLUMN

Field DAY27   Template T_DAY_COLUMN

Field DAY28   Template T_DAY_COLUMN

Field DAY29   Template T_DAY_COLUMN

Field DAY30   Template T_DAY_COLUMN

Field DAY31   Template T_DAY_COLUMN

Structure LOGIN_AUDIT   DBL ISAM
   Description "Login audit record"
   User Text "@NOCODEGEN"

Field LOGIN_TIME   Template T_DATETIME
   Description "Login datetime"

Field USER_ID   Template T_USERNAME

Field PRODUCER   Type ALPHA   Size 6
   Description "License producer code"

Field APPLICATION   Type ALPHA   Size 6
   Description "License application code"

Field CONCURRENT_USERS   Type DECIMAL   Size 6
   Description "Number of concurrent users"

Key LOGIN_TIME   ACCESS   Order ASCENDING   Dups YES   Insert END   Density 100
   Compress INDEX RECORD KEY
   Segment FIELD   LOGIN_TIME  SegType ALPHA  SegOrder ASCENDING

Key USER_TIME   ACCESS   Order ASCENDING   Dups YES   Insert END
   Compress INDEX RECORD KEY   Krf 001
   Description "User ID and time"
   Segment FIELD   USER_ID  SegType ALPHA  SegOrder ASCENDING
   Segment FIELD   LOGIN_TIME  SegType ALPHA  SegOrder ASCENDING

Key LICENSE   ACCESS   Order ASCENDING   Dups YES   Insert END
   Compress INDEX RECORD KEY   Krf 002
   Description "License producer & application & time"
   Segment FIELD   PRODUCER  SegType ALPHA  SegOrder ASCENDING
   Segment FIELD   APPLICATION  SegType ALPHA  SegOrder ASCENDING
   Segment FIELD   LOGIN_TIME  SegType ALPHA  SegOrder ASCENDING

Structure PROJECT   DBL ISAM
   Description "Project master record"

Field SYNERGYGRFA   Template T_GRFA

Field PROJECT_ID   Template T_PROJECT
   Info Line "Current project number"   Disabled
   Nodrill Method   Nochange Method

Field PROJECT_ID_FOREIGN   Template T_PROJECT   Overlay PROJECT_ID:0
   Language Noview
   Description "Project number for Foreign Key overlay"

Field CUSTOMER_ID   Template T_CUSTNO

Field CONTRACT_ID   Template T_CONTRACT

Field CONTRACT_PROJECT_ID   Type DECIMAL   Size 3
   Description "Project number within contract"
   Prompt "Contract Project #"   Info Line "Project number within the contract"
   Report Heading "Contract Project #"   Disabled
   Required

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short project description"
   Info Line "Enter a short description of this project"
   User Text "@CODEGEN_DISPLAY_FIELD"

Field START_DATE   Template T_DATE
   Description "Start date"
   Prompt "Start Date"   Report Heading "Start Date"
   Required

Field END_DATE   Template T_DATE
   Description "End date"
   Prompt "End Date"   Report Heading "End Date"

Field CURRENT_STATUS   Template T_PROJECTSTATUS
   Prompt "Status"   Report Heading "Status"
   Required

Field STATUS_DATE   Template T_DATE_READONLY
   Description "Last status change"
   Prompt "Status Changed"   Report Heading "Status Date"

Field LEAD_CONSULTANT   Template T_USERNAME
   Description "Consultant username"
   Prompt "Consultant"   Info Line "Enter consultangt username"
   Report Heading "Lead Consultant"

Field COORDINATOR   Template T_USERNAME
   Description "Project coordinator"
   Prompt "Coordinator"   Info Line "Enter username of project coordinator"
   Report Heading "Coordinator"

Field APPROVED_BY_FIRST   Template T_CONTACT
   Description "First approved by contact"
   Prompt "First Approved By"
   Info Line "Enter or select the person who first approved the project"
   Report Heading "Approved By (First)"

Field APPROVED_BY_LAST   Template T_CONTACT
   Description "Last approved by contact"
   Prompt "Last Approved By"
   Info Line "Enter or select the person who last approved the project"
   Report Heading "Approved By (Last)"

Field APPROVED_DATE   Template T_DATE
   Description "Date approved by customer"
   Prompt "Date Approved"   Info Line "Enter the date the project was approved"
   Report Heading "Approved Date"
   Required

Field APPROVAL_LOCATION   Template T_LOCATION_NUMBER
   Description "Location for approval processing"
   Prompt "Approval Location"   Report Heading "Approval Location"

Field WORK_LOCATION_ID   Template T_LOCATION_NUMBER
   Description "Location for task execution"
   Report Heading "Work Location ID"
   Norequired

Field CREATED_BY   Template T_USERNAME_READONLY
   Description "Project created by"
   Prompt "Created By"
   Info Line "The user that originally created this project"
   Report Heading "Created By"

Field CREATED_DATE   Template T_DATE_READONLY
   Description "Date project created"
   Prompt "Created"   Report Heading "Created"

Field MODIFIED_BY   Template T_USERNAME_READONLY
   Description "Last modified by"
   Prompt "Modified By"   Info Line "The user that last modified this project"
   Report Heading "Modified By"
   Norequired

Field MODIFIED_DATE   Template T_DATE_READONLY
   Description "Last modified date"
   Prompt "Modified"   Info Line "The date this project was last modified"
   Report Heading "Modified"
   Norequired

Field TEXT   Type ALPHA   Size 700   Script Noview
   Description "Long description"
   Prompt "Overview"   Info Line "Enter an overview of the project"
   Report Heading "Project Overview"

Field TEXT_ARRAY   Type ALPHA   Size 70   Dimension 10   Overlay TEXT:0
   Language Noview   Report Noview
   Description "text field overlay"
   Prompt "Details"
   Required

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key PROJECT_KEY0   ACCESS   Order ASCENDING   Dups NO
   Compress INDEX RECORD KEY
   Segment FIELD   PROJECT_ID

Key PROJECT_KEY1   ACCESS   Order ASCENDING   Dups NO
   Compress INDEX RECORD KEY   Krf 001
   Description "Projects by customer"
   Segment FIELD   CUSTOMER_ID
   Segment FIELD   CONTRACT_ID
   Segment FIELD   CONTRACT_PROJECT_ID

Key PROJECT_KEY2   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 002
   Description "Projects by start date"
   Segment FIELD   START_DATE

Key PROJECT_KEY3   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 003
   Description "Projects by consultant and status"
   Segment FIELD   LEAD_CONSULTANT
   Segment FIELD   CURRENT_STATUS

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 004
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Key PROJECT_ID_FOREIGN   FOREIGN
   Description "Foreign key for Project-related DBs"
   Segment FIELD   PROJECT_ID_FOREIGN

Key COORDINATOR   FOREIGN
   Description "Project Coordinator foreign key"
   Segment FIELD   COORDINATOR

Relation  5   PROJECT PROJECT_KEY1   CUSTOMER CUSTOMER_KEY0

Relation  6   PROJECT COORDINATOR   USER USER_KEY0

Relation  7   PROJECT PROJECT_KEY0   PROJECT_ACTIVITY PROJECT_ACTIVITY_KEY0

Relation  9   PROJECT PROJECT_ID_FOREIGN   PROJECT_CONSULTANT PROJECT_CONSULTANT_KEY0

Relation 10   PROJECT PROJECT_ID_FOREIGN   PROJECT_EXPENSE PROJECT_EXPENSE_KEY0

Relation 11   PROJECT PROJECT_ID_FOREIGN   PROJECT_NOTE PROJECT_NOTE_KEY0

Relation 12   PROJECT PROJECT_ID_FOREIGN   PROJECT_TASK PROJECT_TASK_KEY0

Structure PROJECT_ACTIVITY   DBL ISAM
   Description "Activities associated with tasks"
   User Text "@ALIAS=ACTIVITY;"

Field SYNERGYGRFA   Template T_GRFA

Field PROJECT_ID   Template T_PROJECT

Field TASK_ID   Template T_TASK_NUMBER

Field ACTIVITY_ID   Template T_ACTIVITY_NUMBER

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short description (for lists)"
   Info Line "Enter a short description of this activity"
   User Text "@CODEGEN_DISPLAY_FIELD"

Field START_DATE   Template T_DATE
   Description "Date activity started"
   Prompt "Start Date"   Info Line "Enter the date you started this activity"
   Report Heading "Start Date"
   Required

Field START_TIME   Template T_TIME
   Description "Time activity started"
   Prompt "Start Time"   Info Line "Enter the time you started this activity"
   Report Heading "Start Time"
   Required

Field END_DATE   Template T_DATE
   Description "Date activity ended"
   Prompt "End Date"   Info Line "Enter the date you completed this activity"
   Report Heading "End Date"
   Required

Field END_TIME   Template T_TIME
   Description "Time activity ended"
   Prompt "End Time"   Info Line "Enter the time you completed this activity"
   Report Heading "End Time"
   Required

Field CREATED_BY   Template T_USERNAME_READONLY
   Description "Activity originally entered by"
   Prompt "Created By"
   Info Line "The user that originally entered this activity"
   Report Heading "Created By"

Field CREATED_DATE   Template T_DATE_READONLY
   Description "Date originally created"
   Prompt "Created"   Info Line "The date the activity was originally entered"
   Report Heading "Created"

Field MODIFIED_BY   Template T_USERNAME_READONLY
   Description "Activity last modified by"
   Prompt "Modified By"   Info Line "The user that last modified this activity"
   Report Heading "Modified By"
   Norequired

Field MODIFIED_DATE   Template T_DATE_READONLY
   Description "Date last modified"
   Prompt "Modified"   Info Line "The date the activity was last modified"
   Report Heading "Modified"
   Norequired

Field TEXT   Type ALPHA   Size 700   Script Noview
   Description "Description of activity"
   Prompt "Detail"   Info Line "Describe the activity"
   Report Heading "Detail"
   Required

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key PROJECT_ACTIVITY_KEY0   ACCESS   Order ASCENDING   Dups NO
   Compress INDEX RECORD KEY
   Segment FIELD   PROJECT_ID
   Segment FIELD   TASK_ID
   Segment FIELD   ACTIVITY_ID

Key PROJECT_ACTIVITY_KEY1   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 001
   Description "Project activity by start date/time"
   Segment FIELD   PROJECT_ID
   Segment FIELD   START_DATE
   Segment FIELD   START_TIME

Key PROJECT_ACTIVITY_KEY2   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 002
   Description "Project activity by user"
   Segment FIELD   PROJECT_ID
   Segment FIELD   CREATED_BY
   Segment FIELD   START_DATE
   Segment FIELD   START_TIME

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 003
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Relation  1   PROJECT_ACTIVITY PROJECT_ACTIVITY_KEY0   PROJECT PROJECT_KEY0

Structure PROJECT_ACTIVITY_SUMMARY   USER DEFINED
   Description "Activities associated with tasks (web)"
   User Text "@NOCODEGEN"

Field PROJECT_ID   Template T_PROJECT

Field TASK_ID   Template T_TASK_NUMBER

Field ACTIVITY_ID   Template T_ACTIVITY_NUMBER

Field CREATED_BY   Template T_FRIENDLY_NAME
   Description "Activity originally entered by"
   Prompt "Created By"
   Info Line "The user that originally entered this activity"
   Report Heading "Created By"

Field START_DATE   Template T_DATE
   Description "Date activity started"
   Prompt "Start Date"   Info Line "Enter the date you started this activity"
   Report Heading "Start Date"
   Required

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short description (for lists)"
   Info Line "Enter a short description of this activity"
   User Text "@CODEGEN_DISPLAY_FIELD"

Structure PROJECT_ATTACHMENT   DBL ISAM
   Description "Attachments for project, by note"
   User Text "@ALIAS=ATTACHMENT;"

Field SYNERGYGRFA   Template T_GRFA

Field PROJECT_ID   Template T_PROJECT

Field TASK_ID   Template T_TASK_NUMBER

Field ATTACHMENT_ID   Template T_ATTACHMENT_NUMBER

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short description of attachment"
   Info Line "Enter a short description of this attachment"
   User Text "@CODEGEN_DISPLAY_FIELD"

Field DOC_TYPE   Template T_DOCUMENTTYPE
   Required

Field FILESPEC   Template T_FILEPATH
   Description "Path and filename of attachment"
   Prompt "File"
   Required

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key PROJECT_ATTACHMENT_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   PROJECT_ID
   Segment FIELD   TASK_ID
   Segment FIELD   ATTACHMENT_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure PROJECT_COMBINED   USER DEFINED
   Description "Project combined with customer details"
   User Text "@NOCODEGEN"

Field PROJECT_ID   Template T_PROJECT
   Info Line "Current project number"   Disabled
   Nodrill Method   Nochange Method

Field CUSTOMER_NAME   Template T_CUSTOMER_NAME

Field CUSTOMER_LOCATION   Type ALPHA   Size 40

Field CUSTOMER_CONTACT   Type ALPHA   Size 30
   Prompt "Contract #"   Help "H_ContractNo"
   Info Line "Enter the contract number"   Report Heading "Contract #"
   Uppercase
   Required
   Drill Method "contract_drill"   Change Method "contract_change"

Field CONTACT_PHONE   Template T_PHONE

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short project description"
   Info Line "Enter a short description of this project"
   User Text "@CODEGEN_DISPLAY_FIELD"

Field START_DATE   Template T_DATE
   Description "Start date"
   Prompt "Start Date"   Report Heading "Start Date"
   Required

Field END_DATE   Template T_DATE
   Description "End date"
   Prompt "End Date"   Report Heading "End Date"

Field CURRENT_STATUS   Template T_PROJECTSTATUS   Type ALPHA   Size 10
   Prompt "Status"   Report Heading "Status"
   Required
   Noallow
   Noselect
   Noenumerated

Field STATUS_DATE   Template T_DATE_READONLY
   Description "Last status change"
   Prompt "Status Changed"   Report Heading "Status Date"

Field CONSULTANT_FULL_NAME   Type ALPHA   Size 60

Field COORDINATOR_FULL_NAME   Type ALPHA   Size 60

Field TEXT   Type ALPHA   Size 700   Script Noview
   Description "Long description"
   Prompt "Overview"   Info Line "Enter an overview of the project"
   Report Heading "Project Overview"

Structure PROJECT_CONSULTANT   DBL ISAM
   Description "Consultant information by project"

Field SYNERGYGRFA   Template T_GRFA

Field PROJECT_ID   Template T_PROJECT
   Required

Field CONSULTANT_ID   Template T_USERNAME
   Description "Consultant Username"
   Prompt "Consultant"   Info Line "Enter consultant username"
   User Text "@CODEGEN_DISPLAY_FIELD"   Report Heading "Consultant"

Field FEE_TYPE_ID   Template T_FEETYPE

Field FEE   Template T_PRICE
   Description "Price or amount of consultant, by type"
   Prompt "Fee"
   Info Line "Enter the fee of the consultant, based on the fee type"
   Report Heading "Customer Fee"
   Required

Field COST   Template T_PRICE
   Description "Actual cost of consultant to Synergex"
   Prompt "Synergex Cost"
   Info Line "Enter the cost of the consultant to Synergex, based on type"
   Report Heading "Synergex Cost"
   Required

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key PROJECT_CONSULTANT_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   PROJECT_ID
   Segment FIELD   CONSULTANT_ID
   Segment FIELD   FEE_TYPE_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure PROJECT_CONSULTANT_AMOUNT   USER DEFINED
   Description "Consultant / Amount totals by project"
   User Text "@NOCODEGEN"

Field CONSULTANT_ID   Template T_USERNAME

Field AMOUNT   Template T_PRICE

Structure PROJECT_EXPENSE   DBL ISAM
   Description "Project expense record"
   User Text "@ALIAS=EXPENSE;"

Field SYNERGYGRFA   Template T_GRFA

Field PROJECT_ID   Template T_PROJECT

Field EXPENSE_ID   Template T_EXPENSE_NUMBER

Field EXPENSE_DATE   Template T_DATE
   Description "Date of expense"
   Prompt "Expense Date"
   Info Line "Enter the date of the expense (format XX/XX/XXXX)"
   Report Heading "Expense Date"
   Change Method "expense_date_change"

Field EXPENSE_TYPE   Template T_EXPENSETYPE
   Info Line "Enter or select the expense type code"

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short description of expense"
   Info Line "Enter a short description of this expense item"
   User Text "@CODEGEN_DISPLAY_FIELD"
   Norequired

Field CURRENCY_CODE   Template T_CURRENCY
   Required

Field UNIT_PRICE   Template T_PRICE
   Description "Price per each"
   Report Heading "Unit Price"

Field QUANTITY   Type DECIMAL   Size 6   Precision 2
   Description "Quantity"
   Prompt "Qty"   Help "H_Quantity"   Info Line "Enter the quantity"
   Report Heading "Quantity"
   Negative

Field EXPENSED_BY   Template T_USERNAME
   Description "User submitting expense"
   Prompt "Expensed By"   Report Heading "Expensed By"

Field ENTERED_BY   Template T_USERNAME_READONLY
   Description "Expense entered by"
   Prompt "Entered By"
   Info Line "The user that originally entered this expense"
   Report Heading "Entered By"   Readonly

Field ENTERED_DATE   Template T_DATE_READONLY
   Description "Date entered"
   Prompt "Entered"   Info Line "The date this expense was originally entered"
   Report Heading "Entered"
   Date Today

Field MODIFIED_BY   Template T_USERNAME_READONLY
   Description "User who last modified entry"
   Prompt "Modified By"
   Info Line "The last user to modify this expense record"
   Report Heading "Modified By"
   Norequired

Field MODIFIED_DATE   Template T_DATE_READONLY
   Description "Last modification date"
   Prompt "Modified"   Info Line "The date that this expense was last modified"
   Report Heading "Modified"
   Date Today
   Norequired

Field IS_ESTIMATE   Template T_BOOLEAN
   Description "Expense is an estimate"
   Prompt "Estimate"   Help "H_Estimate"
   Info Line "Is this expense an estimate?"   Report Heading "Estimate"

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key PROJECT_EXPENSE_KEY0   ACCESS   Order ASCENDING   Dups NO
   Compress INDEX RECORD KEY
   Segment FIELD   PROJECT_ID
   Segment FIELD   EXPENSE_ID

Key PROJECT_EXPENSE_KEY1   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 001
   Description "Project expenses by date and user"
   Segment FIELD   PROJECT_ID
   Segment FIELD   EXPENSE_DATE
   Segment FIELD   EXPENSED_BY

Key PROJECT_EXPENSE_KEY2   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 002
   Description "Project expenses by user and date"
   Segment FIELD   PROJECT_ID
   Segment FIELD   EXPENSED_BY
   Segment FIELD   EXPENSE_DATE

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 003
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure PROJECT_EXPENSE_SUMMARY   USER DEFINED
   Description "Project expense record summary (web)"
   User Text "@NOCODEGEN"

Field PROJECT_ID   Template T_PROJECT

Field EXPENSE_ID   Template T_EXPENSE_NUMBER

Field EXPENSE_DATE   Template T_DATE
   Description "Date of expense"
   Prompt "Expense Date"
   Info Line "Enter the date of the expense (format XX/XX/XXXX)"
   Report Heading "Expense Date"
   Change Method "expense_date_change"

Field EXPENSED_BY   Template T_FRIENDLY_NAME
   Description "User submitting expense"
   Prompt "Expensed By"   Report Heading "Expensed By"

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short description of expense"
   Info Line "Enter a short description of this expense item"
   User Text "@CODEGEN_DISPLAY_FIELD"
   Norequired

Field CURRENCY_CODE   Template T_CURRENCY
   Required

Field UNIT_PRICE   Template T_PRICE
   Description "Price per each"
   Report Heading "Unit Price"

Field QUANTITY   Type DECIMAL   Size 6   Precision 2
   Description "Quantity"
   Prompt "Qty"   Help "H_Quantity"   Info Line "Enter the quantity"
   Report Heading "Quantity"
   Negative

Field TOTAL_PRICE   Type DECIMAL   Size 16   Precision 2
   Description "Total price"

Field IS_ESTIMATE   Type ALPHA   Size 3
   Description "Is this an estimated value"

Structure PROJECT_FILTER   USER DEFINED
   Description "Project filter"
   User Text "@NOCODEGEN"

Field LOWER_DATE   Template T_DATE
   Description "Lower date filter"

Field UPPER_DATE   Template T_DATE
   Description "Upper date filter"

Field CUSTOMER_ID   Template T_CUSTNO

Field PROJECT_ID   Template T_PROJECT

Field PROJECT_STATUS   Template T_PROJECTSTATUS

Field CONSULTANT_ID   Template T_USERNAME
   Description "Consultant ID"

Structure PROJECT_NOTE   DBL ISAM
   Description "Project notes"
   User Text "@ALIAS=NOTE;"

Field SYNERGYGRFA   Template T_GRFA

Field PROJECT_ID   Template T_PROJECT

Field NOTE_ID   Template T_NOTE_NUMBER

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short description of note"
   Info Line "Enter a short description of this note"
   User Text "@CODEGEN_DISPLAY_FIELD"

Field CREATED_BY   Template T_USERNAME_READONLY
   Description "Note originally created by"
   Prompt "Created By"
   Info Line "The user that originally created this project note"
   Report Heading "Created By"

Field CREATED_DATE   Template T_DATE_READONLY
   Description "Date created"
   Prompt "Created"   Info Line "Date the project note was originally created"
   Report Heading "Created"
   Date Today

Field MODIFIED_BY   Template T_USERNAME_READONLY
   Description "Last modified by"
   Prompt "Modified By"
   Info Line "The user that last modified this project note"
   Report Heading "Modified By"
   Norequired

Field MODIFIED_DATE   Template T_DATE_READONLY
   Description "Last modified date"
   Prompt "Modified"
   Info Line "The date that this project note was last modified"
   Report Heading "Modified"
   Norequired

Field TEXT   Type ALPHA   Size 700   Script Noview
   Description "Note text"
   Prompt "Note"   Info Line "Enter notes for the project"
   Report Heading "Note Text"
   Required

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key PROJECT_NOTE_KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   PROJECT_ID
   Segment FIELD   NOTE_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure PROJECT_NOTE_SUMMARY   USER DEFINED
   Description "Project note summary (web)"
   User Text "@NOCODEGEN"

Field PROJECT_ID   Template T_PROJECT

Field NOTE_ID   Template T_NOTE_NUMBER

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short description of note"
   Info Line "Enter a short description of this note"
   User Text "@CODEGEN_DISPLAY_FIELD"

Field CREATED_BY   Template T_FRIENDLY_NAME
   Description "Note originally created by"
   Prompt "Created By"
   Info Line "The user that originally created this project note"
   Report Heading "Created By"

Field CREATED_DATE   Template T_DATE_READONLY
   Description "Date created"
   Prompt "Created"   Info Line "Date the project note was originally created"
   Report Heading "Created"
   Date Today

Structure PROJECT_SUMMARY   USER DEFINED
   Description "Project summary (web)"
   User Text "@NOCODEGEN"

Field PROJECT_ID   Template T_PROJECT
   Info Line "Current project number"   Disabled
   Nodrill Method   Nochange Method

Field CUSTOMER_ID   Template T_CUSTNO

Field CUSTOMER_NAME   Template T_CUSTOMER_NAME

Field WORK_LOCATION   Template T_DESCRIPTION
   Description "Work location name"
   Prompt "Customer Location"   Report Heading "Location"

Field STATUS   Type ALPHA   Size 15
   Description "Current status text"

Field START_DATE   Template T_DATE
   Description "Start date"
   Prompt "Start Date"   Report Heading "Start Date"
   Required

Field END_DATE   Template T_DATE
   Description "End date"
   Prompt "End Date"   Report Heading "End Date"

Field LEAD_CONSULTANT   Template T_FRIENDLY_NAME
   Description "Consultant username"
   Prompt "Consultant"   Info Line "Enter consultangt username"
   Report Heading "Lead Consultant"

Field SUBJECT   Template T_DESCRIPTION
   Description "Short project description"
   Info Line "Enter a short description of this project"
   User Text "@CODEGEN_DISPLAY_FIELD"

Structure PROJECT_TASK   DBL ISAM
   Description "Tasks associated with project"
   User Text "@ALIAS=TASK;"

Field SYNERGYGRFA   Template T_GRFA

Field PROJECT_ID   Template T_PROJECT

Field TASK_ID   Template T_TASK_NUMBER
   Nodisabled
   Nodrill Method   Nochange Method

Field TASK_TYPE   Template T_TASKTYPE

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short description of task"
   Info Line "Enter a short description of this test"
   User Text "@CODEGEN_DISPLAY_FIELD"

Field ASSIGNED_TO   Template T_USERNAME
   Description "Task assigned to (username)"
   Prompt "Assigned To"
   Info Line "Enter or select the user this task is assigned to"
   Report Heading "Assigned To"

Field START_DATE   Template T_DATE
   Description "Task start date"
   Prompt "Start Date"
   Info Line "Enter the date that the task is scheduled to start"
   Report Heading "Start Date"
   Required

Field START_TIME   Template T_TIME
   Description "Start time"
   Prompt "Start Time"
   Info Line "Enter the time that the task is scheduled to start"
   Report Heading "Start Time"

Field END_DATE   Template T_DATE
   Description "Task end date"
   Prompt "End Date"
   Info Line "Enter the date that the task is scheduled to end"
   Report Heading "End Date"
   Required

Field END_TIME   Template T_TIME
   Description "End time"
   Prompt "End Time"
   Info Line "Enter the time that the task is scheduled to start"
   Report Heading "End Time"

Field LOCATION   Template T_LOCATION_NUMBER
   Description "Location task to be completed at"

Field BILLABLE_HOURS   Type DECIMAL   Size 4   Precision 1
   Description "Number of billable hours"
   Prompt "Billable Hours"   Report Heading "Billable Hours"   Input Just LEFT

Field CREATED_BY   Template T_USERNAME_READONLY
   Description "Task created by"
   Prompt "Created By"   Info Line "The user that created this task"
   Report Heading "Created By"   Readonly
   Nodrill Method

Field CREATED_DATE   Template T_DATE_READONLY
   Description "Date that the task was created"
   Prompt "Created"   Info Line "The date the task was originally created"
   Report Heading "Created"

Field MODIFIED_BY   Template T_USERNAME_READONLY
   Description "Task last modified by"
   Prompt "Modified By"   Info Line "The user that last modified this task"
   Report Heading "Modified By"

Field MODIFIED_DATE   Template T_DATE_READONLY
   Description "Date task last modified"
   Prompt "Modified"   Info Line "The date that the task was last modified"
   Report Heading "Modified"
   Norequired

Field COMPLETED   Template T_BOOLEAN
   Description "Task completed?"
   Prompt "Complete"   Help "H_Complete"
   Info Line "Has the task been completed?"   Report Heading "Complete"
   Change Method "project_note_completed_change"

Field TEXT   Type ALPHA   Size 700   Script Noview
   Description "Description of task"
   Prompt "Detail"   Report Heading "Task Detail"

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key PROJECT_TASK_KEY0   ACCESS   Order ASCENDING   Dups NO
   Compress INDEX RECORD KEY
   Segment FIELD   PROJECT_ID
   Segment FIELD   TASK_ID

Key PROJECT_TASK_KEY1   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 001
   Description "Project tasks by start date"
   Segment FIELD   PROJECT_ID
   Segment FIELD   START_DATE

Key PROJECT_TASK_KEY2   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Compress INDEX RECORD KEY   Krf 002
   Description "Project tasks by assigned to and date"
   Segment FIELD   PROJECT_ID
   Segment FIELD   ASSIGNED_TO
   Segment FIELD   START_DATE

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 003
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure PROJECT_TASK_SUMMARY   USER DEFINED
   Description "Task summary (web)"
   User Text "@NOCODEGEN"

Field PROJECT_ID   Template T_PROJECT

Field TASK_ID   Template T_TASK_NUMBER
   Nodisabled
   Nodrill Method   Nochange Method

Field TASK_TYPE   Type ALPHA   Size 22
   Description "Task type"

Field DESCRIPTION   Template T_DESCRIPTION
   Description "Short description of task"
   Info Line "Enter a short description of this test"
   User Text "@CODEGEN_DISPLAY_FIELD"

Field ASSIGNED_TO   Template T_FRIENDLY_NAME
   Description "Task assigned to (username)"
   Prompt "Assigned To"   Noinfo   Noheading

Field START_DATE   Template T_DATE
   Description "Task start date"
   Prompt "Start Date"
   Info Line "Enter the date that the task is scheduled to start"
   Report Heading "Start Date"
   Required

Field END_DATE   Template T_DATE
   Description "Task end date"
   Prompt "End Date"
   Info Line "Enter the date that the task is scheduled to end"
   Report Heading "End Date"
   Required

Field COMPLETED   Type ALPHA   Size 3
   Description "Task completed?"
   Checkbox

Structure REQUEST_INPUT   USER DEFINED
   Description "Request input structure"
   User Text "@NOCODEGEN"

Group REQUEST   Reference REQUEST   Type ALPHA   Script Noview

Field CUSTOMER_ID_DSP   Template T_CUSTOMER_NAME
   Noprompt   Noinfo   Disabled
   Norequired

Field CONTACT_ID_DSP   Type ALPHA   Size 61
   Description "Contact name"
   Disabled

Field PROJECT_ID_DSP   Template T_DESCRIPTION
   Noprompt   Noinfo   Disabled
   Norequired

Field WORK_LOCATION_ID_DSP   Template T_DESCRIPTION
   Description "Work location ID description"
   Noprompt   Noinfo   Disabled
   Norequired

Structure SQL_REPLICATION_ITEM   DBL ISAM
   Description "SQL Replication Action Record"
   User Text "@NOCODEGEN"

Field UNIQUE_KEY_VALUE   Template T_REPLICATION_KEY
   Description "Unique key of replication item"

Field SDMS_ACTION   Type DECIMAL   Size 1
   Description "the SDM action flag"

Field STRUCTURE_NAME   Type ALPHA   Size 32
   Description "the SDMS structure name"

Field STRUCTURE_KEY   Template T_REPLICATION_KEY
   Description "Unique structure key value"

Key KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   UNIQUE_KEY_VALUE  SegType ALPHA  SegOrder ASCENDING

Structure STATE   DBL ISAM
   Description "State file"

Field SYNERGYGRFA   Template T_GRFA

Field CODE   Template T_STATE

Field NAME   Template T_STATE_NAME
   User Text "@CODEGEN_DISPLAY_FIELD"

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key STATE_KEY0   ACCESS   Order ASCENDING   Dups NO
   Description "primary key"
   Segment FIELD   CODE

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure TASK_TYPE   DBL ISAM
   Description "Task Types"

Field SYNERGYGRFA   Template T_GRFA

Field TASK_TYPE_ID   Template T_TASKTYPE

Field DESCRIPTION   Type ALPHA   Size 35
   Description "Expense type description"
   Prompt "Description"   Info Line "Enter a description for the expense type"
   User Text "@CODEGEN_DISPLAY_FIELD"   Report Heading "Description"
   Required

Field REPLICATION_KEY   Template T_REPLICATION_KEY

Key TASK_TYPE_KEY_0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   TASK_TYPE_ID

Key REPLICATION_KEY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   ODBC Noview   Krf 001
   Description "SQL Timestamp Key"
   Segment FIELD   REPLICATION_KEY  SegType ALPHA  SegOrder ASCENDING

Structure USER_INPUT   USER DEFINED
   Description "User input structure"
   User Text "@NOCODEGEN"

Group USER   Reference USER   Type ALPHA   Script Noview   Report Noview
   Nonamelink
   Description "User record"

Field COUNTRY_ID_DSP   Type ALPHA   Size 30
   Description "Country name"
   Disabled

Structure USER_BREIF   USER DEFINED
   Description "Brief User records"
   User Text "@NOCODEGEN"

Field USER_ID   Template T_USERNAME

Field FULL_NAME   Type ALPHA   Size 60

Field PICTURE_FILE   Template T_FILEPATH
   Description "Path to contact image file"
   Prompt "Picture"   Report Heading "Picture File"

Field VISIBLE   Type INTEGER   Size 1
   Description "display user in project view"

Field IS_CONSULTANT   Template T_BOOLEAN

Structure USER_CRITERIA   USER DEFINED
   Description "User search criteria"
   User Text "@NOCODEGEN"

Field MODE   Type DECIMAL   Size 1
   Description "Search mode"
   Prompt "Search by"   Radio
   Selection List 0 0 0  Entries "Last Name", "Email", "Username"
   Enumerated 9 1 1
   Change Method "user_mntmode"

Field FIELD1   Template T_LAST_NAME
   Noprompt   Nohelp   Info Line "Enter a full or partial last name"
   Norequired

Field FIELD2   Template T_EMAIL
   Noprompt   Info Line "Enter a full or partial email address"
   View Length 40
   Norequired
   Nochange Method

Field FIELD3   Template T_USERNAME
   Noprompt   Info Line "Enter a full or partial username"
   Norequired
   Nodrill Method   Nochange Method

File CONSULTANT_FEE   DBL ISAM   "DAT:fee.ism"
   Description "Consultant standard fees file"
   Assign CONSULTANT_FEE   ODBC Name FEE

File COUNTRY   DBL ISAM   "DAT:country.ism"
   Description "Country file"
   Assign COUNTRY   ODBC Name COUNTRY

File CUSTOMER   DBL ISAM   "DAT:customer.ism"
   Description "Customer file"
   Assign CUSTOMER   ODBC Name CUSTOMER

File CUSTOMER_CONTACT   DBL ISAM   "DAT:contact.ism"
   Description "Customer contacts file"
   Assign CUSTOMER_CONTACT   ODBC Name CONTACT

File CUSTOMER_CONTRACT   DBL ISAM   "DAT:contract.ism"
   Description "Customer contracts file"
   Assign CUSTOMER_CONTRACT   ODBC Name CONTRACT

File CUSTOMER_LOCATION   DBL ISAM   "DAT:location.ism"
   Description "Customer locations file"
   Assign CUSTOMER_LOCATION   ODBC Name LOCATION

File EXPENSE_TYPE   DBL ISAM   "DAT:expensetype.ism"
   Description "Expense types file"
   Assign EXPENSE_TYPE   ODBC Name EXPENSETYPE

File FEE_TYPE   DBL ISAM   "DAT:feetype.ism"
   Description "Fee types file"
   Assign FEE_TYPE   ODBC Name FEETYPE

File LOGIN_AUDIT   DBL ISAM   "DAT:login_audit.ism"
   Description "Login audit file"
   Page Size 8192
   Assign LOGIN_AUDIT

File PROJECT   DBL ISAM   "DAT:project.ism"
   Description "Project master file"
   Assign PROJECT   ODBC Name PROJECT

File PROJECT_ACTIVITY   DBL ISAM   "DAT:activity.ism"
   Description "Project activity file"
   Assign PROJECT_ACTIVITY   ODBC Name ACTIVITY

File PROJECT_ATTACHMENT   DBL ISAM   "DAT:attachment.ism"
   Description "Project task attachments file"
   Assign PROJECT_ATTACHMENT   ODBC Name ATTACHMENT

File PROJECT_CONSULTANT   DBL ISAM   "DAT:consultant.ism"
   Description "Project consultant rates file"
   Assign PROJECT_CONSULTANT   ODBC Name CONSULTANT

File PROJECT_EXPENSE   DBL ISAM   "DAT:expense.ism"
   Description "Project expenses file"
   Assign PROJECT_EXPENSE   ODBC Name EXPENSE

File PROJECT_NOTE   DBL ISAM   "DAT:note.ism"
   Description "Project notes file"
   Assign PROJECT_NOTE   ODBC Name NOTE

File PROJECT_TASK   DBL ISAM   "DAT:task.ism"
   Description "Project tasks"
   Assign PROJECT_TASK   ODBC Name TASK

File REQUEST   DBL ISAM   "DAT:request.ism"
   Description "Requests file"
   Assign REQUEST   ODBC Name REQUEST

File SQL_REPLICATION_ITEM   DBL ISAM   "DAT:replication.ism"
   Description "SQL Replication Action File"
   Assign SQL_REPLICATION_ITEM

File STATE   DBL ISAM   "DAT:state.ism"
   Description "State"
   Assign STATE   ODBC Name STATE

File TASK_TYPE   DBL ISAM   "DAT:tasktype.ism"
   Description "Task types file"
   Assign TASK_TYPE   ODBC Name TASKTYP

File USER   DBL ISAM   "DAT:user.ism"
   Description "User file"
   Assign USER   ODBC Name CHRONOTRACK_USER

