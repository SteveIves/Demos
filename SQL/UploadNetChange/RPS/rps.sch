 
;  SYNERGY DATA LANGUAGE OUTPUT
;
;  REPOSITORY     : D:\Dev\Demos\SQL\UploadNetChange\RPS\rpsmain.ism
;                 : D:\Dev\Demos\SQL\UploadNetChange\RPS\rpstext.ism
;                 : Version 10.2.1
;
;  GENERATED      : 02-JUL-2014, 12:33:14
;                 : Version 10.2.3
;  EXPORT OPTIONS : [ALL-K-R-A] 
 
 
Format PHONE   Type NUMERIC   "(XXX) XXX-XXXX"   Justify LEFT
 
Template DEPARTMENT_ID   Type ALPHA   Size 15
   Description "Department ID"
   Prompt "Department"
   Uppercase
   Required
   Drill Method "DepartmentDrill"   Change Method "DepartmentChange"
 
Template DEPARTMENT_NAME   Type ALPHA   Size 50
   Description "Department name"
   Required
 
Template EMPLOYEE_ID   Type DECIMAL   Size 6
   Description "Employee ID"
   Prompt "Employee"
   Required
 
Template PERSON_FIRST_NAME   Type ALPHA   Size 30
   Description "First name"
   Prompt "First name"
   Required
 
Template PERSON_LAST_NAME   Type ALPHA   Size 30
   Description "Last name"
   Prompt "Last name"
   Uppercase
   Required
 
Template PHONE_NUMBER   Type DECIMAL   Size 10
   Description "Phone Number"
   Prompt "Phone"   Info Line "Enter a telephone number"   Format PHONE
   Blankifzero
 
Structure EMPLOYEE   DBL ISAM
   Description "Employee Master File"
 
Field EMP_ID   Template EMPLOYEE_ID
   Info Line "Enter an employee ID"   ODBC Name EMPLOYEE_ID
 
Field EMP_FIRST_NAME   Template PERSON_FIRST_NAME
   Prompt "First name"   Info Line "Enter the employees first name"
   ODBC Name FIRST_NAME
   Required
 
Field EMP_LAST_NAME   Template PERSON_LAST_NAME
   Info Line "Enter the employees last name"
   User Text "@CODEGEN_DISPLAY_FIELD"   ODBC Name LAST_NAME
 
Field EMP_DEPT   Template DEPARTMENT_ID
   Description "Employee's department ID"
   Info Line "Enter a department ID"   ODBC Name DEPARTMENT_ID   Nodisabled
 
Field EMP_HIRE_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date hired"
   Prompt "Hire Date"   Info Line "Enter the employees date of hire"
   ODBC Name HIRE_DATE
   Date Today
 
Field EMP_PHONE   Template PHONE_NUMBER   Dimension 3
   Noinfo   ODBC Name PHONE
 
Field EMP_PAID   Type DECIMAL   Size 1
   Description "Employee pay method"
   Prompt "Paid"   Info Line "Is the employee paid hourly or salaried"
   Default "1"   Automatic
   Selection List 0 0 0  Entries "Hourly", "Salaried"
   Enumerated 8 1 1
 
Field EMP_HOME_OK   Type DECIMAL   Size 1
   Description "OK to call at home"
   Prompt "OK to Call Home"
   Info Line "Is it OK to call this employee at home"   Checkbox
   Default "1"   Automatic
 
Field NONAME_001   Type ALPHA   Size 79   Language Noview   Script Noview
   Report Noview   Nonamelink
   Description "Spare space"
 
Key EMP_ID   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   EMP_ID  SegType ALPHA
 
Key EMP_DEPT   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 001
   Description "Department ID"
   Segment FIELD   EMP_DEPT
 
Key EMP_LAST_NAME   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 002
   Description "Last name"
   Segment FIELD   EMP_LAST_NAME
 
Structure DEPARTMENT   DBL ISAM
   Description "Department Master File"
 
Field DEPT_ID   Template DEPARTMENT_ID
   Prompt "Department"
 
Field DEPT_NAME   Template DEPARTMENT_NAME   Dimension 1
   Prompt "Description"   User Text "@CODEGEN_DISPLAY_FIELD"
 
Field DEPT_MANAGER   Template EMPLOYEE_ID
   Description "Department manager"
   Prompt "Manager"
 
Key DEPT_ID   ACCESS   Order ASCENDING   Dups NO
   Description "Department ID"
   Segment FIELD   DEPT_ID
 
Key DEPT_MANAGER   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 001
   Description "Department manager"
   Segment FIELD   DEPT_MANAGER  SegType ALPHA
 
Structure EMPLOYEE_INPUT   DBL ISAM
   Description "Employee Master File (For Input)"
   User Text "@NOCODEGEN"
 
Group EMPLOYEE   Reference EMPLOYEE   Type ALPHA
   Description "Employee structure"
 
Field EMP_DEPT_DSP   Template DEPARTMENT_NAME
   Readonly
 
Structure EMPLOYEE_CRITERIA   DBL ISAM
   Description "Employee Master File (Search Criteria)"
   User Text "@NOCODEGEN"
 
Field MODE   Type DECIMAL   Size 1
   Description "Search mode"
   Radio
   Selection List 0 0 0  Entries "Last Name", "Department"
   Enumerated 10 1 1
   Change Method "employee_mntmode"
 
Field FIELD1   Template PERSON_LAST_NAME
   Noprompt
   Norequired
 
Field FIELD2   Template DEPARTMENT_ID
   Noprompt
   Norequired
 
File DEPARTMENT   DBL ISAM   "DAT:department.ism"
   Description "Department master file"
   Compress
   Assign DEPARTMENT
 
File EMPLOYEE   DBL ISAM   "DAT:employee.ism"
   Description "Employee master file"
   Compress
   Assign EMPLOYEE
 
