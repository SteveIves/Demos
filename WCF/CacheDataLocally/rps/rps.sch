 
;  SYNERGY DATA LANGUAGE OUTPUT
;
;  REPOSITORY     : D:\Dev\Demos\WCF\CacheDataLocally\rps\rpsmain.ism
;                 : D:\Dev\Demos\WCF\CacheDataLocally\rps\rpstext.ism
;                 : Version 9.5.1
;
;  GENERATED      : 26-FEB-2013, 15:32:34
;                 : Version 10.1.1
;  EXPORT OPTIONS : [ALL] 
 
 
Structure PERSON   DBL ISAM
   Description "Person file"
 
Field PERSON_ID   Type DECIMAL   Size 8
   Description "Person ID"
 
Field FIRST_NAME   Type ALPHA   Size 25
   Description "First name"
 
Field LAST_NAME   Type ALPHA   Size 25
   Description "Last name"
 
Field EMAIL   Type ALPHA   Size 60
   Description "Email address"
 
Key PERSON_ID   ACCESS   Order ASCENDING   Dups NO
   Description "Person ID"
   Segment FIELD   PERSON_ID  SegType ALPHA  SegOrder ASCENDING
 
Key LAST_NAME   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 001
   Description "Last name"
   Segment FIELD   LAST_NAME  SegType NOCASE  SegOrder ASCENDING
 
Key EMAIL   ACCESS   Order ASCENDING   Dups NO   Modifiable YES   Krf 002
   Description "Email address"
   Segment FIELD   EMAIL  SegType NOCASE  SegOrder ASCENDING
 
File PERSON   DBL ISAM   "DAT:person.ism"
   Description "Person file"
   Static RFA
   Assign PERSON
 
