 
;  SYNERGY DATA LANGUAGE OUTPUT
;
;  REPOSITORY     : D:\Dev\Demos\WEB\SynNetAspProviders\RPS\rpsmain.ism
;                 : D:\Dev\Demos\WEB\SynNetAspProviders\RPS\rpstext.ism
;                 : Version 8.3.1b
;
;  GENERATED      : 26-FEB-2013, 15:55:38
;                 : Version 10.1.1
;  EXPORT OPTIONS : [ALL] 
 
 
Template APPLICATION_NAME   Type ALPHA   Size 32
   Description "Application name"
 
Template EMAIL   Type ALPHA   Size 64
   Description "Email address"
 
Template ROLE   Type ALPHA   Size 32
   Description "Role name"
 
Template USERNAME   Type ALPHA   Size 32
   Description "Username"
 
Structure ASPNET_PASSWORD_COUNTERS   USER DEFINED
   Description "Password counters"
 
Field PASSWORD_FAIL_COUNT   Type DECIMAL   Size 4
 
Field PASSWORD_WINDOW_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Window date"
 
Field PASSWORD_WINDOW_TIME   Type TIME   Size 6   Stored HHMMSS
   Description "Password window time"
 
Field ANSWER_FAIL_COUNT   Type DECIMAL   Size 4
   Description "Answer fail count"
 
Field ANSWER_WINDOW_DATE   Type DATE   Size 8   Stored YYYYMMDD
 
Field ANSWER_WINDOW_TIME   Type TIME   Size 6   Stored HHMMSS
 
Structure ASPNET_PROFILE   DBL ISAM
   Description "ASP.NET profile provider profiles"
 
Field UNIQUEID   Type ALPHA   Size 36
 
Field APPLICATION   Template APPLICATION_NAME
 
Field USERNAME   Template USERNAME
 
Field ANONYMOUS   Type DECIMAL   Size 1
   Description "Anonymous profile"
 
Field LAST_ACTIVITY_DATE   Type DATE   Size 8   Stored YYYYMMDD
 
Field LAST_ACTIVITY_TIME   Type TIME   Size 6   Stored HHMMSS
 
Field LAST_UPDATED_DATE   Type DATE   Size 8   Stored YYYYMMDD
 
Field LAST_UPDATED_TIME   Type TIME   Size 6   Stored HHMMSS
 
Structure ASPNET_ROLE   DBL ISAM
   Description "ASP.NET roles provider role record"
 
Field APPLICATION   Template APPLICATION_NAME
 
Field ROLE   Template ROLE
 
Key APP_ROLE   ACCESS   Order ASCENDING   Dups NO
   Description "Application and role"
   Segment FIELD   APPLICATION  SegType ALPHA  SegOrder ASCENDING
   Segment FIELD   ROLE  SegType ALPHA  SegOrder ASCENDING
 
Structure ASPNET_USER   DBL ISAM
   Description "ASP.NET membership provider user record"
 
Field PKID   Type ALPHA   Size 36
   Description "Primary key identifier"
 
Field APPLICATION   Template APPLICATION_NAME
 
Field USERNAME   Template USERNAME
 
Field EMAIL   Template EMAIL
 
Field COMMENT   Type ALPHA   Size 128
   Description "Comment"
 
Field PASSWORD   Type ALPHA   Size 64
   Description "Password"
 
Field PASSWORD_QUESTION   Type ALPHA   Size 64
   Description "Password question"
 
Field PASSWORD_ANSWER   Type ALPHA   Size 64
   Description "Password answer"
 
Field IS_APPROVED   Type DECIMAL   Size 1
   Description "Is the user account approved"
 
Field CREATED_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date account created"
 
Field CREATED_TIME   Type TIME   Size 6   Stored HHMMSS
   Description "time account created"
 
Field LAST_ACTIVITY_DATE   Type DATE   Size 8   Stored YYYYMMDD
 
Field LAST_ACTIVITY_TIME   Type TIME   Size 6   Stored HHMMSS
   Description "Last activity time"
 
Field LAST_ACTIVITY   Type ALPHA   Size 14   Overlay LAST_ACTIVITY_DATE:0
   Script Noview   Report Noview   Nonamelink
   Description "Last activity date/time"
 
Field LAST_LOGIN_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Last login date"
 
Field LAST_LOGIN_TIME   Type TIME   Size 6   Stored HHMMSS
   Description "Last login time"
 
Field LAST_LOGIN   Type ALPHA   Size 14   Overlay LAST_LOGIN_DATE:0
   Description "Date & time of last login"
 
Field LAST_PASSWORD_CHANGE_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Last password change date"
 
Field LAST_PASSWORD_CHANGE_TIME   Type TIME   Size 6   Stored HHMMSS
   Description "Last password change time"
 
Field LAST_PASSWORD_CHANGE   Type ALPHA   Size 14
   Overlay LAST_PASSWORD_CHANGE_DATE:0
   Description "Last password change"
 
Field IS_ONLINE   Type DECIMAL   Size 1
   Description "UIs the user on line"
 
Field IS_LOCKED_OUT   Type DECIMAL   Size 1
   Description "Is the user locked out"
 
Field LAST_LOCKED_OUT_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Last locked out date"
 
Field LAST_LOCKED_OUT_TIME   Type TIME   Size 6   Stored HHMMSS
   Description "Last locked out time"
 
Field LAST_LOCKED_OUT   Type ALPHA   Size 14   Overlay LAST_LOCKED_OUT_DATE:0
 
Field FAILED_PASSWORD_COUNT   Type DECIMAL   Size 4
   Description "Failed password attempt count"
 
Field FAILED_PASSWORD_WINDOW_DATE   Type DATE   Size 8   Stored YYYYMMDD
 
Field FAILED_PASSWORD_WINDOW_TIME   Type TIME   Size 6   Stored HHMMSS
 
Field FAILED_PASSWORD_WINDOW   Type ALPHA   Size 14
   Overlay FAILED_PASSWORD_WINDOW_DATE:0
 
Field FAILED_ANSWER_COUNT   Type DECIMAL   Size 4
 
Field FAILED_ANSWER_WINDOW_DATE   Type DATE   Size 8   Stored YYYYMMDD
 
Field FAILED_ANSWER_WINDOW_TIME   Type TIME   Size 6   Stored HHMMSS
 
Field FAILED_ANSWER_WINDOW   Type ALPHA   Size 14
   Overlay FAILED_ANSWER_WINDOW_DATE:0
 
Key PKID   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   PKID
 
Key APP_USER   ACCESS   Order ASCENDING   Dups NO   Krf 001
   Segment FIELD   APPLICATION
   Segment FIELD   USERNAME
 
Key APP_EMAIL   ACCESS   Order ASCENDING   Dups NO   Modifiable YES   Krf 002
   Description "Email address"
   Segment FIELD   APPLICATION
   Segment FIELD   EMAIL
 
Key APP_LAST_ACTIVITY   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   Krf 003
   Segment FIELD   APPLICATION
   Segment FIELD   LAST_ACTIVITY_DATE
   Segment FIELD   LAST_ACTIVITY_TIME
   Segment FIELD   PKID
 
Key APP_ONLINE   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 004
   Description "IS the user online"
   Segment FIELD   APPLICATION
   Segment FIELD   IS_ONLINE
 
Structure ASPNET_USER_ROLE   DBL ISAM
   Description "ASP.NET roles provider users in roles"
 
Field APPLICATION   Template APPLICATION_NAME
 
Field USERNAME   Template USERNAME
 
Field ROLE   Template ROLE
 
Key APP_USER_ROLE   ACCESS   Order ASCENDING   Dups NO
   Compress INDEX RECORD KEY
   Description "Application/User/Role"
   Segment FIELD   APPLICATION  SegType ALPHA  SegOrder ASCENDING
   Segment FIELD   USERNAME  SegType ALPHA  SegOrder ASCENDING
   Segment FIELD   ROLE  SegType ALPHA  SegOrder ASCENDING
 
Key APP_ROLE_USER   ACCESS   Order ASCENDING   Dups NO
   Compress INDEX RECORD KEY   Krf 001
   Description "Application/Role/Username"
   Segment FIELD   APPLICATION  SegType ALPHA  SegOrder ASCENDING
   Segment FIELD   ROLE  SegType ALPHA  SegOrder ASCENDING
   Segment FIELD   USERNAME  SegType ALPHA  SegOrder ASCENDING
 
Structure DATE_TIME   DBL ISAM
   Description "Date and time"
 
Field DATE_FIELD   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date"
 
Field TIME_FIELD   Type TIME   Size 6   Stored HHMMSS
   Description "Time"
 
File ASPNET_ROLE   DBL ISAM   "DAT:aspnet_role.ism"
   Description "ASP.NET"
   Assign ASPNET_ROLE
 
File ASPNET_USER   DBL ISAM   "DAT:aspnet_user.ism"
   Description "ASP.NET membership provider user file"
   Assign ASPNET_USER
 
File ASPNET_USER_ROLE   DBL ISAM   "DAT:aspnet_user_role"
   Description "ASP.NET users in role"
   Assign ASPNET_USER_ROLE
 
