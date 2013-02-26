 
;  SYNERGY DATA LANGUAGE OUTPUT
;
;  REPOSITORY     : C:\Dev\Demos\WEBSERVICES\AMAZON\rpsmain.ism
;                 : C:\Dev\Demos\WEBSERVICES\AMAZON\rpstext.ism
;                 : Version 8.1.5b
;
;  GENERATED      : 17-FEB-2012, 21:19:37
;                 : Version 9.3.1b
;  EXPORT OPTIONS : [ALL] 
 
 
Structure CURRENCY_CONVERTER   DBL ISAM
   Description "currency converter"
 
Field FROM_CURRENCY_CODE   Type ALPHA   Size 4
   Description "from currency code"
   Prompt "From Currency"
 
Field FROM_CURRENCY_DESCIPTION   Type ALPHA   Size 30
   Description "description"
   Disabled
 
Field AMOUNT   Type DECIMAL   Size 10   Precision 2
   Description "amount"
   Prompt "Amount"
 
Field TO_CURRENCY_CODE   Type ALPHA   Size 4
   Description "to currency code"
   Prompt "To Currency"
 
Field TO_CURRENCY_DESCRIPTIOIN   Type ALPHA   Size 30
   Description "description"
   Disabled
 
Field RATE   Type DECIMAL   Size 25   Precision 9
   Description "rate"
   Prompt "Exchange Rate"
 
Field RESULT   Type DECIMAL   Size 10   Precision 2
   Description "result"
   Prompt "Result"   Disabled
 
Structure RESULTS   DBL ISAM
   Description "resuls of amazon search"
 
Field ITEM_NUMBER   Type ALPHA   Size 10
   Description "Amazon ASIN"
   Prompt "ASIN"
 
Field PRODUCT_NAME   Type ALPHA   Size 50   Dimension 2
   Description "product name"
   Prompt "Product Name (Title)"
 
Field PRODUCT_NAME_OVERLAY   Type ALPHA   Size 100   Overlay PRODUCT_NAME:0
 
Field AUTHORS   Type ALPHA   Size 50   Dimension 5
   Description "list of authors"
   Prompt "Authors"
 
Field RELEASE_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "release date"
   Prompt "Release date"
 
Field MANUFACTURER   Type ALPHA   Size 50
   Description "manufacturer"
   Prompt "Manufacturer"
 
Field AVAILABILTY   Type ALPHA   Size 50   Dimension 3
   Description "availability"
   Prompt "Availability"
 
Field AVAILABILITY_OVERLAY   Type ALPHA   Size 150   Overlay AVAILABILTY:0
 
Field LIST_PRICE   Type DECIMAL   Size 6   Precision 2
   Description "list price"
   Prompt "List Price"
 
Field OUR_PRICE   Type DECIMAL   Size 6   Precision 2
   Description "our price"
   Prompt "Our Price"
 
Field USED_PRICE   Type DECIMAL   Size 6   Precision 2
   Description "used price"
   Prompt "Used Price"
 
Structure SEARCH   DBL ISAM
   Description "Amazon Search options"
 
Field SEARCH_TYPE   Type ALPHA   Size 20
   Description "Type of search"
   Prompt "Search Type"
   Selection List 0 0 0  Entries "books", "dvd", "electronics", "kitchen",
         "music"
 
Field SEARCH_FOR   Type ALPHA   Size 50
   Description "string to search for"
   Prompt "Search string"
   Required
 
Field NO_PAGES   Type DECIMAL   Size 5
   Description "number of pages to return"
   Prompt "No. of pages"
   Required
 
Structure SPELL_IT   DBL ISAM
   Description "spell checker layout"
 
Field TEXT   Type ALPHA   Size 70   Dimension 10
   Prompt "Text"   Readonly
 
Field SUGGESTION   Type ALPHA   Size 30
   Description "suggested replacement"
   Prompt "Suggestion"
 
