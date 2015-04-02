 
;  SYNERGY DATA LANGUAGE OUTPUT
;
;  REPOSITORY     : D:\Conference\2013\08_LicensingToolkit\Demos\LicenseManager\
;                 : D:\Conference\2013\08_LicensingToolkit\Demos\LicenseManager\
;                 : Version 10.1.1
;
;  GENERATED      : 01-MAR-2013, 12:21:40
;                 : Version 10.1.1
;  EXPORT OPTIONS : [ALL-K-R-A] 
 
 
Format LICENSE_ID   Type NUMERIC   "XXXXXXXXXX"
 
Format LM_REG_STRING   Type ALPHA   "@@@@-@@-@@@@-@@"
 
Format PLATFORM_ID   Type NUMERIC   "XXX"
 
Format SYSTEM_ID   Type NUMERIC   "XXXXXXXXXX"
 
Template DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date"
   Prompt "Date"   Format "#01  MM/DD/YYYY"   Blankifzero
 
Template CUSTOMER_ID   Type ALPHA   Size 15
   Description "Customer ID"
   Prompt "Customer"
   Uppercase
   Required
   Drill Method "CustomerLookup"
 
Template DATE_NO_UI   Parent DATE   Script Noview
 
Template LICENSE_ID   Type DECIMAL   Size 10
   Description "License ID"
   Prompt "License"   Format LICENSE_ID   Blankifzero
   Required
 
Template LM_CUSTOM_DATA   Type ALPHA   Size 100
   Description "Custom data"
   Prompt "Custom"   View Length 40
 
Template LM_KEY   Type ALPHA   Size 19
   Description "Configuration key"
   Prompt "Key"
 
Template LM_LICENSEE   Type ALPHA   Size 50
   Description "Licensee"
   Prompt "Licensee"
   Required
 
Template LM_REG_STRING   Type ALPHA   Size 12
   Description "Registration string"
   Prompt "Reg String"   Format LM_REG_STRING
   Uppercase
 
Template LM_SEATS   Type DECIMAL   Size 4
   Description "Number of seats"
   Prompt "Seats"   Blankifzero
   Required
 
Template PLATFORM_ID   Type DECIMAL   Size 3
   Description "Platform ID"
   Prompt "Platform"   Format PLATFORM_ID   Blankifzero
   Required
   Drill Method "PlatformLookup"
 
Template PRODUCER_ID   Type DECIMAL   Size 3
   Description "Producer ID"
   Prompt "Producer"   Blankifzero
   Required
   Drill Method "ProducerLookup"
 
Template PRODUCT_ID   Type ALPHA   Size 6
   Description "Product ID"
   Prompt "Product"
   Required
   Drill Method "ProductLookup"
 
Template SYSTEM_ID   Type DECIMAL   Size 10
   Description "System ID"
   Prompt "System"   Format SYSTEM_ID   Blankifzero
   Required
 
Structure CUSTOMER   DBL ISAM
   Description "Customer record"
 
Field ID   Template CUSTOMER_ID
 
Field NAME   Type ALPHA   Size 30
   Description "Customer name"
   Prompt "Name"
   Required
 
Field EMAIL   Type ALPHA   Size 40
   Description "Email address"
   Prompt "Email"
 
Field NONAME_001   Type ALPHA   Size 115   Language Noview   Script Noview
   Report Noview
   Description "Spare space"
 
Key ID   ACCESS   Order ASCENDING   Dups NO
   Description "Customer ID"
   Segment FIELD   ID
 
Structure KEY_DATA   USER DEFINED
   Description "License key data"
 
Field COMPANY   Type ALPHA   Size 50
   Description "COMPANY"
   Prompt "Company"
   Required
 
Field CONTACT   Type ALPHA   Size 50
   Description "CONTACT"
   Prompt "Contact"
   Required
 
Field EMAIL   Type ALPHA   Size 50
   Description "EMAIL"
   Prompt "Email"
   Required
 
Field LICENSEE   Type ALPHA   Size 50
   Description "LICENSEE"
   Prompt "Licensee"
   Required
 
Field REGSTRING   Type ALPHA   Size 15
   Description "REGSTRING"
   Prompt "Reg String"
   Required
 
Field PRODUCT   Type ALPHA   Size 6
   Description "PRODUCT"
   Prompt "Product"
   Uppercase
 
Field UNITS   Type DECIMAL   Size 4
   Description "UNITS"
   Prompt "Units"   Report Just LEFT   Input Just LEFT   Blankifzero
 
Field EXPIRY   Type DATE   Size 8   Stored YYYYMMDD
   Description "EXPIRY"
   Prompt "Expiry"   Blankifzero
 
Field CUSTOM_DATA   Type ALPHA   Size 100
   Description "CUSTOM_DATA"
   Prompt "Custom Data"   View Length 50
   Uppercase
 
Structure LICENSE   DBL ISAM
   Description "License record"
 
Field CUSTOMER   Template CUSTOMER_ID
 
Field SYSTEM   Template SYSTEM_ID
 
Field PRODUCER   Template PRODUCER_ID
 
Field PRODUCT   Template PRODUCT_ID
 
Field SEATS   Template LM_SEATS
 
Field CUSTOM   Template LM_CUSTOM_DATA
 
Field KEY   Template LM_KEY
 
Field GENERATED   Template DATE
   Description "Date generated"
   Prompt "Generated"
 
Field EXPIRES   Template DATE
   Description "Expirt date"
   Prompt "Expires"
 
Field NONAME_001   Type ALPHA   Size 77   Language Noview   Script Noview
   Report Noview
   Description "Spare space"
 
Key PRIMARY   ACCESS   Order ASCENDING   Dups NO
   Description "Primary key"
   Segment FIELD   CUSTOMER
   Segment FIELD   SYSTEM
   Segment FIELD   PRODUCER
   Segment FIELD   PRODUCT
 
Key SYSTEM   ACCESS   Order ASCENDING   Dups NO   Krf 001
   Description "Licenses for a specific system"
   Segment FIELD   SYSTEM
   Segment FIELD   PRODUCER
   Segment FIELD   PRODUCT
 
Key PRODUCT   ACCESS   Order ASCENDING   Dups YES   Insert END   Krf 002
   Description "Licenses for a product"
   Segment FIELD   PRODUCER
   Segment FIELD   PRODUCT
 
Structure LM_LICENSE   USER DEFINED
   Description "License data"
 
Field LM_APPLIC   Type ALPHA   Size 6
   Description "LM_APPLIC"
 
Field LM_USRMAX   Type DECIMAL   Size 4
   Description "LM_USRMAX"
   Report Just LEFT   Input Just LEFT
 
Field LM_EXPDAT   Type DECIMAL   Size 8
   Description "LM_EXPDAT"
   Report Just LEFT   Input Just LEFT
 
Field LM_INSDAT   Type DECIMAL   Size 8
   Description "LM_INSDAT"
   Report Just LEFT   Input Just LEFT
 
Field LM_CUSTOM   Type ALPHA   Size 100
   Description "LM_CUSTOM"
 
Structure LM_SITE   USER DEFINED
   Description "Site data"
 
Field NONAME_001   Type ALPHA   Size 6   Language Noview   Script Noview
   Report Noview
   Description "NONAME_001"
 
Field LM_LICENSEE   Type ALPHA   Size 50
   Description "LM_LICENSEE"
 
Field LM_REGSTR   Type ALPHA   Size 12
   Description "LM_REGSTR"
 
Field LM_REGDAT   Type DECIMAL   Size 8
   Description "LM_REGDAT"
   Report Just LEFT   Input Just LEFT
 
Field LM_TIMOUT   Type DECIMAL   Size 8
   Description "LM_TIMOUT"
   Report Just LEFT   Input Just LEFT
 
Structure PLATFORM   DBL ISAM
   Description "Platform codes"
 
Format PLATFORM_ID   Type NUMERIC   "XXX"
 
Field ID   Template PLATFORM_ID
 
Field NAME   Type ALPHA   Size 30
   Description "Platform name"
   Prompt "Name"
   Required
 
Field NONAME_001   Type ALPHA   Size 67   Language Noview   Script Noview
   Report Noview
   Description "Spare space"
 
Key ID   ACCESS   Order ASCENDING   Dups NO
   Description "Platform code"
   Segment FIELD   ID
 
Structure PRODUCER   DBL ISAM
   Description "Producer codes"
 
Field ID   Template PRODUCER_ID
 
Field NAME   Type ALPHA   Size 40
   Description "Producer name"
   Prompt "Name"
   Required
 
Key ID   ACCESS   Order ASCENDING   Dups NO
   Description "Producer code"
   Segment FIELD   ID
 
Structure PRODUCT   DBL ISAM
   Description "Product codes"
 
Format PLATFORM_ID   Type NUMERIC   "XXX"
 
Field PRODUCER   Template PRODUCER_ID   Script Noview
 
Field ID   Template PRODUCT_ID
 
Field NAME   Type ALPHA   Size 40
   Description "Product name"
   Prompt "Name"
   Required
 
Field ENABLED   Type DECIMAL   Size 1
   Description "Enabled"
   Prompt "Enabled"   Checkbox
 
Field NONAME_001   Type ALPHA   Size 50   Language Noview   Script Noview
   Report Noview
   Description "Spare space"
 
Key ID   ACCESS   Order ASCENDING   Dups NO
   Description "Product code"
   Segment FIELD   PRODUCER
   Segment FIELD   ID
 
Structure SYSTEM   DBL ISAM
   Description "Installed system record"
 
Field ID   Template SYSTEM_ID
 
Field CUSTOMER   Template CUSTOMER_ID
 
Field LICENSEE   Template LM_LICENSEE
 
Field REG_STRING   Template LM_REG_STRING
 
Field PLATFORM   Template PLATFORM_ID
 
Field CREATED   Template DATE_NO_UI
   Description "Date created"
   Prompt "Created"
 
Field UPDATED   Template DATE_NO_UI
   Description "Date last updated"
   Prompt "Updated"
 
Field NONAME_001   Type ALPHA   Size 94   Language Noview   Script Noview
   Report Noview
   Description "Spare space"
 
Key ID   ACCESS   Order ASCENDING   Dups NO
   Description "System ID"
   Segment FIELD   ID
 
Key CUSTOMER_PLATFORM   ACCESS   Order ASCENDING   Dups NO   Modifiable YES
   Krf 001
   Description "Customer ID and platform"
   Segment FIELD   CUSTOMER
   Segment FIELD   PLATFORM
   Segment FIELD   ID
 
File CUSTOMER   DBL ISAM   "LM_ROOT:customer.ism"
   Description "Customer file"
   Density 75   Addressing 40BIT   Compress   Static RFA   Terabyte
   Stored GRFA
   Assign CUSTOMER
 
File LICENSE   DBL ISAM   "LM_ROOT:license.ism"
   Description "Licenses file"
   Density 75   Addressing 40BIT   Compress   Static RFA   Terabyte
   Stored GRFA
   Assign LICENSE
 
File PLATFORM   DBL ISAM   "LM_ROOT:platform.ism"
   Description "Platform codes file"
   Density 75   Addressing 40BIT   Compress   Static RFA   Terabyte
   Stored GRFA
   Assign PLATFORM
 
File PRODUCER   DBL ISAM   "LM_ROOT:producer.ism"
   Description "Producer codes file"
   Density 75   Addressing 40BIT   Compress   Static RFA   Terabyte
   Stored GRFA
   Assign PRODUCER
 
File PRODUCT   DBL ISAM   "LM_ROOT:product.ism"
   Description "Product codes file"
   Density 75   Addressing 40BIT   Compress   Static RFA   Terabyte
   Stored GRFA
   Assign PRODUCT
 
File SYSTEM   DBL ISAM   "LM_ROOT:system.ism"
   Description "Installed systems file"
   Density 75   Addressing 40BIT   Compress   Static RFA   Terabyte
   Stored GRFA
   Assign SYSTEM
 
