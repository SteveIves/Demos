;  SYNERGY DATA LANGUAGE OUTPUT
;
;  REPOSITORY FILES   : officeDAT:rpsmain.ism
;                     : officeDAT:rpstext.ism
;
;  CREATION DATE      : 21-MAR-97, 16:17:52
;  REPOSITORY VERSION : 6.1a
 
 
Format PHONE   Type NUMERIC   "(ZZZ) ZZZ-ZZZZ"   Justify RIGHT
 
Format ZIP   Type NUMERIC   "XXXXX-XXXX"   Justify LEFT
 
Structure ROLODEX   DBL ISAM
   Description "Rolodex Master File"
 
Format PHONE   Type NUMERIC   "(XXX) XXX-XXXX"   Justify RIGHT
 
Format AZIP   Type ALPHA   "@@@@@"   Justify LEFT
 
Format ZIP   Type NUMERIC   "XXXXX-XXXX"   Justify LEFT
 
Field HEADER   Type ALPHA   Size 50
   Description "HEADER"
   Prompt "Header "   Help "h_header"
   Info Line "Enter head line information.  This is the primary key."
   User Text "L<Name>"   Report Heading "Name or Company"
 
Field CATEGORY   Type ALPHA   Size 3
   Description "CATEGORY"
   Prompt "Category "
   Info Line "Enter the category from the selection list. (Keyfield)"
   User Text "L<Category>"
 
Field ADDRESS1   Type ALPHA   Size 30
   Description "ADDRESS1"
   Prompt "Optional address " Help "h_address"
   Info Line "Enter PO Box number, suite number or other misc info."
 
Field ADDRESS2   Type ALPHA   Size 30
   Description "ADDRESS2"
   Prompt "Street address "   Help "h_address"
   Info Line "Enter the street address. (required)"
 
Field CITY   Type ALPHA   Size 20
   Description "CITY"
   Prompt "City "   Help "h_city"   Info Line "Enter the city or town."
   User Text "L<Town>"
 
Field STATE   Type ALPHA   Size 2
   Description "STATE"
   Prompt "State "   Help "h_state"
   Info Line "Enter the two letter state code. (Required, keyfield)"
   User Text "L<*>"
   Uppercase   Noterm
 
Field ZIP   Type ALPHA   Size 5
   Description "ZIP"
   Prompt "Zip code "   Help "h_zip"
   Info Line "Enter zip code or postal code"   Format AZIP
   Report Heading "Zip Code"
   Noterm
 
Field ZIP_PLUS   Type ALPHA   Size 4
   Description "Extended Zip Code"
   Noterm
 
Field PHONE   Type DECIMAL   Size 10
   Description "PHONE"
   Prompt "Phone number "   Help "h_phone"
   Info Line "Enter the phone number with the area code first."
   User Text "L<Telephone>"   Format PHONE   Report Heading "Phone Number"
   Blankifzero
   Noterm
 
Field FAX   Type DECIMAL   Size 10
   Description "FAX"
   Prompt "Fax number "   Help "h_phone"
   Info Line "Enter the FAX number, area code first."   User Text "L<FAX num>"
   Format PHONE   Report Heading "FAX Number"   Blankifzero
   Noterm
 
Field COMMENT   Type ALPHA   Size 50   Dimension 10
   Description "COMMENTS"
   Prompt "Additional information "
   Info Line "Enter birthdays, anniversaries, phone extensions, ect."
 
Key KEY0   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   HEADER
 
Key KEY1   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   CATEGORY
   Segment FIELD   HEADER
 
Key KEY2   ACCESS   Order ASCENDING   Dups NO
   Segment FIELD   STATE
   Segment FIELD   HEADER
 
File ROLODEX   DBL ISAM   "OFFICEDAT:rolodex"
   Description "Master Rolodex file"
   Assign ROLODEX
 
