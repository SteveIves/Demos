 
;  SYNERGY DATA LANGUAGE OUTPUT
;
;  REPOSITORY     : C:\FILES\DEMO\SQL\UPLOAD\rps\rpsmain.ism
;                 : C:\FILES\DEMO\SQL\UPLOAD\rps\rpstext.ism
;                 : Version 8.1.3a
;
;  GENERATED      : 18-NOV-2008, 20:12:36
;                 : Version 9.1.5a
;  EXPORT OPTIONS : [ALL-K-R-A] 
 
 
Format COST_PRICE   Type NUMERIC   "$$,$$X.XXXX"   Justify RIGHT
 
Format CREDIT_CARD_NUMBER   Type ALPHA   "XXXX-XXXX-XXXX-XXXX"
 
Format CURRENCY_10_2   Type NUMERIC   "$$$,$$$,$$X.XX"   Justify RIGHT
 
Format CURRENCY_6_2   Type NUMERIC   "$$,$$X.XX"   Justify RIGHT
 
Format CURRENCY_8_2   Type NUMERIC   "$$$$,$$X.XX"   Justify RIGHT
 
Format PHONE_NUMBER   Type NUMERIC   "XXX-XXXX"   Justify RIGHT
 
Format QUANTITY   Type NUMERIC   "ZZZZZX-"   Justify RIGHT
 
Structure CUSMAS   DBL ISAM
   Description "Customer master file"
   User Text "@NOCODEGEN"
 
Field CUSACC   Type ALPHA   Size 8
   Description "Account number"
   Prompt "Account"   Info Line "Enter the customer account number"
   Uppercase
   Required
   Drill Method "drill_customer"   Change Method "change_customer"
 
Field CUSNAM   Type ALPHA   Size 40
   Description "Company name"
   Prompt "Company"   Info Line "Enter the name of the company"
   Required
 
Field CUSAD1   Type ALPHA   Size 40
   Description "Address 1 (street address)"
   Prompt "Address"   Info Line "Enter a street address"
   Required
 
Field CUSAD2   Type ALPHA   Size 25
   Description "Customer address 2 (city)"
   Prompt "City"   Info Line "Enter the name of the city"
   Required
 
Field CUSAD3   Type ALPHA   Size 2
   Description "Customer address 3 (state)"
   Prompt "State"   Info Line "Select a US state or enter a region"
   Uppercase
   Required
   Drill Method "drill_state"   Change Method "change_state"
 
Field CUSAD4   Type DECIMAL   Size 5
   Description "Customer address 3 (zip code)"
   Prompt "Zip"   Info Line "Enter a zip or postal code code"
   Report Just LEFT   Input Just LEFT
   Required
 
Field CUSPNO   Type DECIMAL   Size 10
   Description "Phone number"
   Info Line "Enter the telephone number"   Report Just LEFT   Input Just LEFT
   Blankifzero
 
Field CUSFNO   Type DECIMAL   Size 10
   Description "Fax number"
   Info Line "Enter the customers fax number"   Report Just LEFT
   Input Just LEFT   Blankifzero
 
Field CUSMNO   Type DECIMAL   Size 10
   Description "Mobile number"
   Info Line "Enter the mobile telephone number"   Report Just LEFT
   Input Just LEFT   Blankifzero
 
Field CUSPGN   Type DECIMAL   Size 10
   Description "Pager number"
   Info Line "Enter the telephone number for the pager"   Report Just LEFT
   Input Just LEFT   Blankifzero
 
Field CUSEM1   Type ALPHA   Size 80
   Description "Primary email address"
   Prompt "Email"
   Info Line "Enter the primary email address for the customer"
 
Field CUSEM2   Type ALPHA   Size 80
   Description "Alternate email address"
   Prompt "Email2"
   Info Line "Enter an alternate e-mail address for the customer"
 
Field CUSDAO   Type DECIMAL   Size 8
   Description "Date account opened"
   Prompt "Opened"   Report Just LEFT   Input Just LEFT   Readonly
   Required
 
Field CUSDAH   Type DECIMAL   Size 8
   Description "Date account placed on hold"
   Prompt "Held"   Report Just LEFT   Input Just LEFT   Blankifzero   Readonly
 
Field CUSDAC   Type DECIMAL   Size 8
   Description "Account closed"
   Prompt "Closed"   Report Just LEFT   Input Just LEFT   Blankifzero
   Readonly
 
Field CUSAST   Type DECIMAL   Size 1
   Description "Account status"
   Prompt "Status"   Info Line "Select the account status"   Radio
   Required
   Selection List 0 0 0  Entries "Active", "Credit Hold", "Inactive"
   Enumerated 11 0 1
   Change Method "change_customer_status"
 
Field CUSCLM   Type DECIMAL   Size 10   Precision 2
   Description "Credit limit"
   Prompt "Credit limit"   Info Line "Enter this customers credit limit"
   Format CURRENCY_10_2   Blankifzero
   Required
 
Field CUSACB   Type DECIMAL   Size 10   Precision 2
   Description "Account balance"
   Prompt "Balance"   Format CURRENCY_10_2   Blankifzero   Readonly
 
Field CUSCNO   Type ALPHA   Size 16
   Description "Credit card number"
   Prompt "Card #"   Info Line "Enter a credit card number"
 
Field CUSCEX   Type DECIMAL   Size 4
   Description "Credit card expiry date"
   Prompt "Expiry"   Info Line "Enter the credit card expiry date"
   Report Just LEFT   Input Just LEFT   Blankifzero
 
Field CUSCNM   Type ALPHA   Size 25
   Description "Credit card name"
   Prompt "Card Name"   Info Line "Enter the name on the credit card"
 
Field NONAME_001   Type ALPHA   Size 27   Language Noview   Script Noview
   Report Noview
   Description "Spare space"
 
Key CUSACC   ACCESS   Order ASCENDING   Dups NO
   Description "Customer Account Code"
   Segment FIELD   CUSACC
 
Key CUSNAM   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 001
   Description "Company name"
   Segment FIELD   CUSNAM
 
Key CUSAD3   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 002
   Description "Address 3 (state)"
   Segment FIELD   CUSAD3
 
Key CUSAD4   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 003
   Description "Address 4 (zip code)"
   Segment FIELD   CUSAD4
 
Key CUSAST   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 005
   Description "Account status"
   Segment FIELD   CUSAST
 
Structure CUSTOMER   DBL ISAM
   Description "Customer master file (SQL)"
   User Text "@MAP=CUSMAS;"
 
Field ACCOUNT   Type ALPHA   Size 8
   Description "Account number"
   Prompt "Account"   Info Line "Enter the customer account number"
   User Text "@MAP=CUSACC;"
   Uppercase
   Required
   Drill Method "drill_customer"   Change Method "change_customer"
 
Field COMPANY   Type ALPHA   Size 40
   Description "Company name"
   Prompt "Company"   Info Line "Enter the name of the company"
   User Text "@MAP=CUSNAM;"
   Required
 
Field STREET   Type ALPHA   Size 40
   Description "Street address"
   Prompt "Address"   Info Line "Enter a street address"
   User Text "@MAP=CUSAD1;"
   Required
 
Field CITY   Type ALPHA   Size 25
   Description "City"
   Prompt "City"   Info Line "Enter the name of the city"
   User Text "@MAP=CUSAD2;"
   Required
 
Field STATE   Type ALPHA   Size 2
   Description "State"
   Prompt "State"   Info Line "Select a US state or enter a region"
   User Text "@MAP=CUSAD3;"
   Uppercase
   Required
   Drill Method "drill_state"   Change Method "change_state"
 
Field ZIP   Type DECIMAL   Size 5
   Description "Zip code"
   Prompt "Zip"   Info Line "Enter a zip or postal code code"
   User Text "@MAP=CUSAD4;"   Report Just LEFT   Input Just LEFT
   Required
 
Field PHONE_NUMBER   Type DECIMAL   Size 10
   Description "Phone number"
   Info Line "Enter the telephone number"   User Text "@MAP=CUSPNO;"
   Report Just LEFT   Input Just LEFT   Blankifzero
 
Field FAX_NUMBER   Type DECIMAL   Size 10
   Description "Fax number"
   Info Line "Enter the customers fax number"   User Text "@MAP=CUSFNO;"
   Report Just LEFT   Input Just LEFT   Blankifzero
 
Field MOBILE_NUMBER   Type DECIMAL   Size 10
   Description "Mobile number"
   Info Line "Enter the mobile telephone number"   User Text "@MAP=CUSMNO;"
   Report Just LEFT   Input Just LEFT   Blankifzero
 
Field PAGER_NUMBER   Type DECIMAL   Size 10
   Description "Pager number"
   Info Line "Enter the telephone number for the pager"
   User Text "@MAP=CUSPGN;"   Report Just LEFT   Input Just LEFT   Blankifzero
 
Field EMAIL1   Type ALPHA   Size 80
   Description "Primary email address"
   Prompt "Email"
   Info Line "Enter the primary email address for the customer"
   User Text "@MAP=CUSEM1;"
 
Field EMAIL2   Type ALPHA   Size 80
   Description "Alternate email address"
   Prompt "Email2"
   Info Line "Enter an alternate e-mail address for the customer"
   User Text "@MAP=CUSEM2;"
 
Field DATE_OPENED   Type DATE   Size 8   Stored YYYYMMDD
   Description "Account opened"
   Prompt "Opened"   User Text "@MAP=CUSDAO;"   Format "#01  MM/DD/YYYY"
   Readonly
   Date Today
   Required
 
Field DATE_HOLD   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date account placed on hold"
   Prompt "Held"   User Text "@MAP=CUSDAH;"   Format "#01  MM/DD/YYYY"
   Blankifzero   Readonly
 
Field DATE_CLOSED   Type DATE   Size 8   Stored YYYYMMDD
   Description "Account closed"
   Prompt "Closed"   User Text "@MAP=CUSDAC;"   Format "#01  MM/DD/YYYY"
   Blankifzero   Readonly
 
Field STATUS   Type DECIMAL   Size 1
   Description "Account status"
   Prompt "Status"   Info Line "Select the account status"
   User Text "@MAP=CUSAST;"   Radio
   Required
   Selection List 0 0 0  Entries "Active", "Credit Hold", "Inactive"
   Enumerated 11 0 1
   Change Method "change_customer_status"
 
Field LIMIT   Type DECIMAL   Size 10   Precision 2
   Description "Credit limit"
   Prompt "Credit limit"   Info Line "Enter this customers credit limit"
   User Text "@MAP=CUSCLM;"   Format CURRENCY_10_2   Blankifzero
   Required
 
Field BALANCE   Type DECIMAL   Size 10   Precision 2
   Description "Account balance"
   Prompt "Balance"   User Text "@MAP=CUSACB;"   Format CURRENCY_10_2
   Blankifzero   Readonly
 
Field CARD_NUMBER   Type ALPHA   Size 16
   Description "Credit card number"
   Prompt "Card #"   Info Line "Enter a credit card number"
   User Text "@MAP=CUSCNO;"
 
Field CARD_EXPIRY   Type DECIMAL   Size 4
   Description "Credit card expiry date"
   Prompt "Expiry"   Info Line "Enter the credit card expiry date"
   User Text "@MAP=CUSCEX;"   Report Just LEFT   Input Just LEFT   Blankifzero
 
Field CARD_NAME   Type ALPHA   Size 25
   Description "Name on credit card"
   Prompt "Card Name"   Info Line "Enter the name on the credit card"
   User Text "@MAP=CUSCNM;"
 
Key ACCOUNT   ACCESS   Order ASCENDING   Dups NO
   Description "Customer Account ID"
   Segment FIELD   ACCOUNT
 
Key COMPANY   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 001
   Description "Company name"
   Segment FIELD   COMPANY
 
Key STATE   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 002
   Description "State"
   Segment FIELD   STATE
 
Key ZIP   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 003
   Description "Zip code"
   Segment FIELD   ZIP
 
Key STATUS   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 005
   Description "Account status"
   Segment FIELD   STATUS
 
Structure INVGRP   DBL ISAM
   Description "Product groups"
   User Text "@NOCODEGEN"
 
Field IGPGID   Type ALPHA   Size 10
   Description "Product group ID"
   Prompt "Group"   Info Line "Enter or select a product group"
   Uppercase
   Required
   Drill Method "drill_product_group"   Change Method "change_product_group"
 
Field IGPDES   Type ALPHA   Size 40
   Description "Product group description"
   Prompt "Description"
   Required
 
Key IGPGID   ACCESS   Order ASCENDING   Dups NO
   Description "Product group ID"
   Segment FIELD   IGPGID
 
Structure INVMAS   DBL ISAM
   Description "Inventory master file"
   User Text "@NOCODEGEN"
 
Field INVPCD   Type ALPHA   Size 10
   Description "Product code"
   Prompt "Product"   Info Line "Enter or select a product code"
   Uppercase
   Required
   Drill Method "drill_sku"   Change Method "change_sku"
 
Field INVGRP   Type ALPHA   Size 10
   Description "Product group"
   Prompt "Group"   Info Line "Enter or select a product group"
   Uppercase
   Required
   Drill Method "drill_product_group"   Change Method "change_product_group"
 
Field INVDES   Type ALPHA   Size 80
   Description "Product description"
   Prompt "Description"   Info Line "Enter a description of this product"
   Required
 
Field INVPGP   Type ALPHA   Size 10
   Description "Pricing group"
   Prompt "Price code"   Info Line "Enter the pricing code"
   Uppercase
 
Field INVSPR   Type DECIMAL   Size 6   Precision 2
   Description "Selling Price"
   Prompt "Sell price"   Info Line "Enter the price"   Format CURRENCY_6_2
   Blankifzero
 
Field INVDLS   Type DECIMAL   Size 8
   Description "Date of last sale"
   Prompt "Last sale"   Info Line "Enter or select the date of last sale"
   Report Just LEFT   Input Just LEFT   Blankifzero   Readonly
 
Field INVLCP   Type DECIMAL   Size 10   Precision 4
   Description "Last Cost price"
   Prompt "Last cost"   Info Line "Enter the cost price"   Format COST_PRICE
   Blankifzero   Readonly
 
Field INVACP   Type DECIMAL   Size 10   Precision 4
   Description "Average Cost price"
   Prompt "Avg. cost"   Info Line "Enter the cost price"   Format COST_PRICE
   Blankifzero   Readonly
 
Field INVQIS   Type DECIMAL   Size 6
   Description "Quantity in stock"
   Prompt "In stock"   Info Line "Enter the quantity in stock"
   Format QUANTITY   Readonly
 
Field INVQAL   Type DECIMAL   Size 6
   Description "Quantity allocated to orders"
   Prompt "Allocated"   Info Line "Enter the quantity"   Format QUANTITY
   Readonly
 
Field INVQIT   Type DECIMAL   Size 6
   Description "Quantity in transit between warehouses"
   Prompt "In transit"
   Info Line "Enter the quantity in transit between warehouse's"
   Format QUANTITY   Readonly
 
Field INVQOO   Type DECIMAL   Size 6
   Description "Quantity on Order"
   Prompt "On order"   Info Line "Enter the quantity"   Format QUANTITY
   Readonly
 
Field INVREF   Type ALPHA   Size 20
   Description "Reference"
   Prompt "Reference"
 
Field INVPUB   Type ALPHA   Size 50
   Description "Publisher"
   Prompt "Publisher"
 
Field INVAUT   Type ALPHA   Size 50
   Description "Author"
   Prompt "Author"
 
Field INVTYP   Type ALPHA   Size 20
   Description "Product type"
   Prompt "Type"   Info Line "Enter the product type / category"
 
Field INVRDT   Type DECIMAL   Size 8
   Description "Release Date"
   Prompt "Released"   Info Line "Enter or select the release date"
   Report Just LEFT   Input Just LEFT   Blankifzero
   Required
 
Field INVRAT   Type ALPHA   Size 6
   Description "Motion Picture Rating"
   Prompt "Rating"   Info Line "Enter the Product rating [e.g. PG13, R]"
   Selection List 0 0 0  Entries "-------Unknown", "G     - General Audiences",
         "PG    - Parental Guidance Suggested",
         "PG13  - Parents Strongly Cautioned", "R     - Restricted",
         "NC17  - N one 17 and under admitted"
 
Field NONAME_001   Type ALPHA   Size 118   Language Noview   Script Noview
   Report Noview
   Description "Spare space"
 
Key INVPCD   ACCESS   Order ASCENDING   Dups NO
   Description "Product code"
   Segment FIELD   INVPCD
 
Key INVGRP   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 001
   Description "Product group"
   Segment FIELD   INVGRP
 
Key INVDES   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 002
   Description "Product description"
   Segment FIELD   INVDES  SegType NOCASE
 
Key INVPGP   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 003
   Description "Pricing group"
   Segment FIELD   INVPGP
 
Key INVAUT   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 004
   Description "Author"
   Segment FIELD   INVAUT  SegType NOCASE
 
Key INVPUB   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 005
   Description "Publisher"
   Segment FIELD   INVPUB  SegType NOCASE
 
Key INVREF   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 006
   Description "Reference"
   Segment FIELD   INVREF  SegType NOCASE
 
Structure ORDER_HEADER   DBL ISAM
   Description "Order header details (SQL)"
   User Text "@MAP=ORDHDR;"
 
Field ORDER_NUMBER   Type DECIMAL   Size 8
   Description "Order number"
   Prompt "Order number"   User Text "@MAP=ORDNUM;"   Readonly
   Required
   Drill Method "drill_order"   Change Method "change_order"
 
Field ORDER_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Order date"
   Prompt "Date"   Info Line "Enter or select the date the order was placed"
   User Text "@MAP=ORDDAT;"   Format "#01  MM/DD/YYYY"   Blankifzero   Disabled
   Date Today
   Required
 
Field STATUS   Type ALPHA   Size 1
   Description "Order Status"
   Prompt "Order Status"   User Text "@MAP=ORDSTS;"   Disabled
   Selection List 0 0 0  Entries "Open", "Processing", "Shipped", "Delivered",
         "Cancelled", "Back Ordered"
 
Field SHIP_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date Ship"
   Prompt "Ship Date"   Info Line "Estimated or Actual ship date"
   User Text "@MAP=ORDSDT;"   Format "#01  MM/DD/YYYY"   Blankifzero
 
Field CUSTOMER   Type ALPHA   Size 8
   Description "Account number"
   Prompt "Account"   Info Line "Enter the customer account number"
   User Text "@MAP=ORDCUS;"
   Uppercase
   Required
   Drill Method "drill_customer"   Change Method "change_customer"
 
Field DELIVERY_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Delivery Date"
   Prompt "Delivery Date"   Info Line "Estimated / Actual delivery date"
   User Text "@MAP=ORDDDT;"   Format "#01  MM/DD/YYYY"   Blankifzero
 
Field CUSTOMER_ORDER_REF   Type ALPHA   Size 20
   Description "Customer Order Reference"
   Prompt "Reference"   Info Line "Enter the Customer's Order Reference"
   User Text "@MAP=ORDCRF;"
 
Field GOODS_VALUE   Type DECIMAL   Size 8   Precision 2
   Description "Total goods value"
   Prompt "Goods"   User Text "@MAP=ORDGVL;"   Format CURRENCY_8_2
   Blankifzero   Disabled
 
Field TAX_VALUE   Type DECIMAL   Size 8   Precision 2
   Description "Total tax value"
   Prompt "Tax"   User Text "@MAP=ORDTVL;"   Format CURRENCY_8_2   Blankifzero
   Disabled
 
Field SHIPPING_VALUE   Type DECIMAL   Size 8   Precision 2
   Description "Total Shipping value"
   Prompt "Shipping"   User Text "@MAP=ORDSVL;"   Format CURRENCY_8_2
   Blankifzero   Disabled
 
Field GIFT_WRAP   Type DECIMAL   Size 1
   Description "Gift wrap required"
   Prompt "Gift Wrap"   Info Line "Is Gift Wrapping required"
   User Text "@MAP=ORDWRP;"   Checkbox
   Change Method "change_gift_wrap"
 
Field GIFT_MESSAGE   Type ALPHA   Size 60
   Description "Gift Message"
   Prompt "Message"   User Text "@MAP=ORDMSG;"
 
Key ORDER_NUMBER   ACCESS   Order ASCENDING   Dups NO
   Description "Order number"
   Segment FIELD   ORDER_NUMBER
 
Key CUSTOMER   ACCESS   Order ASCENDING   Dups YES   Insert END   Krf 001
   Description "Customer ID"
   Segment FIELD   CUSTOMER
 
Key STATUS   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 002
   Description "Status"
   Segment FIELD   STATUS
 
Key CUSREF   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 003
   Description "Customer reference"
   Segment FIELD   CUSTOMER_ORDER_REF
 
Structure ORDER_LINE   DBL ISAM
   Description "Order line details (SQL)"
   User Text "@MAP=ORDLIN;"
 
Field ORDER_NUMBER   Type DECIMAL   Size 8
   Description "Order number"
   Prompt "Order number"   User Text "@MAP=OLNONM;"   Readonly
   Required
   Drill Method "drill_order"   Change Method "change_order"
 
Field LINE_NUMBER   Type DECIMAL   Size 3
   Description "Line number"
   User Text "@MAP=OLNLIN;"
   Required
 
Field SKU   Type ALPHA   Size 10
   Description "SKU"
   Prompt "Product"   Info Line "Enter or select a product code"
   User Text "@MAP=OLNPCD;"
   Uppercase
   Required
   Drill Method "drill_sku"   Change Method "change_sku"
 
Field DESCRIPTION   Type ALPHA   Size 80
   Description "Product name"
   Prompt "Description"   Info Line "Enter a description of this product"
   User Text "@MAP=OLNDES;"   Disabled
   Required
 
Field QTY_ORDERED   Type DECIMAL   Size 6
   Description "Quantity Ordered"
   Prompt "Quantity"   Info Line "Enter the quantity ordered"
   User Text "@MAP=OLNQTY;"   Format QUANTITY
   Required
 
Field QTY_ALLOCATED   Type DECIMAL   Size 6
   Description "Quantity"
   Prompt "Quantity Allocated"   Info Line "Enter the quantity allocated"
   User Text "@MAP=OLNQTA;"   Format QUANTITY   Readonly
 
Field PRICE   Type DECIMAL   Size 6   Precision 2
   Description "Price per item"
   Prompt "Price Each"   User Text "@MAP=OLNPEA;"   Format CURRENCY_6_2
   Blankifzero   Disabled
 
Field LINE_VALUE   Type DECIMAL   Size 6   Precision 2
   Description "Line Value"
   Prompt "Goods Total"   User Text "@MAP=OLNTOT;"   Format CURRENCY_6_2
   Blankifzero   Disabled
 
Field TAX   Type DECIMAL   Size 6   Precision 2
   Description "Tax"
   Prompt "Tax"   User Text "@MAP=OLNTAX;"   Format CURRENCY_6_2   Blankifzero
   Disabled
 
Key ORDER_LINE   ACCESS   Order ASCENDING   Dups NO
   Description "Order number & line item"
   Segment FIELD   ORDER_NUMBER
   Segment FIELD   LINE_NUMBER
 
Key SKU   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Description "Sku"
   Segment FIELD   SKU
 
Structure ORDHDR   DBL ISAM
   Description "Order header details"
   User Text "@NOCODEGEN"
 
Field ORDNUM   Type DECIMAL   Size 8
   Description "Order number"
   Prompt "Order number"   Readonly
   Required
   Drill Method "drill_order"   Change Method "change_order"
 
Field ORDDAT   Type DECIMAL   Size 8
   Description "Order date"
   Prompt "Date"   Info Line "Enter or select the date the order was placed"
   Report Just LEFT   Input Just LEFT   Blankifzero   Disabled
   Required
 
Field ORDSTS   Type ALPHA   Size 1
   Description "Order Status"
   Prompt "Order Status"   Disabled
   Selection List 0 0 0  Entries "Open", "Processing", "Shipped", "Delivered",
         "Cancelled", "Back Ordered"
 
Field ORDSDT   Type DECIMAL   Size 8
   Description "Order shipped date"
   Prompt "Ship Date"   Info Line "Estimated or Actual ship date"
   Report Just LEFT   Input Just LEFT   Blankifzero
 
Field ORDCUS   Type ALPHA   Size 8
   Description "Customer account number"
   Prompt "Account"   Info Line "Enter the customer account number"
   Uppercase
   Required
   Drill Method "drill_customer"   Change Method "change_customer"
 
Field ORDDDT   Type DECIMAL   Size 8
   Description "Delivery Date"
   Prompt "Delivery Date"   Info Line "Estimated / Actual delivery date"
   Report Just LEFT   Input Just LEFT   Blankifzero
 
Field ORDCRF   Type ALPHA   Size 20
   Description "Customer Order Reference"
   Prompt "Reference"   Info Line "Enter the Customer's Order Reference"
 
Field ORDGVL   Type DECIMAL   Size 8   Precision 2
   Description "Total goods value"
   Prompt "Goods"   Format CURRENCY_8_2   Blankifzero   Disabled
 
Field ORDTVL   Type DECIMAL   Size 8   Precision 2
   Description "Total tax value"
   Prompt "Tax"   Format CURRENCY_8_2   Blankifzero   Disabled
 
Field ORDSVL   Type DECIMAL   Size 8   Precision 2
   Description "Total Shipping value"
   Prompt "Shipping"   Format CURRENCY_8_2   Blankifzero   Disabled
 
Field ORDWRP   Type DECIMAL   Size 1
   Description "Gift wrap required"
   Prompt "Gift Wrap"   Info Line "Is Gift Wrapping required"   Checkbox
   Change Method "change_gift_wrap"
 
Field ORDMSG   Type ALPHA   Size 60
   Description "Gift Message"
   Prompt "Message"
   Required
 
Field NONAME_001   Type ALPHA   Size 54   Language Noview   Script Noview
   Report Noview
   Description "Spare space"
 
Key ORDNUM   ACCESS   Order ASCENDING   Dups NO
   Description "Order number"
   Segment FIELD   ORDNUM
 
Key ORDCUS   ACCESS   Order ASCENDING   Dups YES   Insert END   Krf 001
   Description "Customer ID"
   Segment FIELD   ORDCUS
 
Key ORDSTS   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 002
   Description "Status"
   Segment FIELD   ORDSTS
 
Key ORDCRF   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 003
   Description "Customer reference"
   Segment FIELD   ORDCRF
 
Structure ORDLIN   DBL ISAM
   Description "Order line details"
   User Text "@NOCODEGEN"
 
Field OLNONM   Type DECIMAL   Size 8
   Description "Order number"
   Prompt "Order number"   Readonly
   Required
   Drill Method "drill_order"   Change Method "change_order"
 
Field OLNLIN   Type DECIMAL   Size 3
   Description "Line number"
 
Field OLNPCD   Type ALPHA   Size 10
   Description "Product code"
   Prompt "Product"   Info Line "Enter or select a product code"
   Uppercase
   Required
   Drill Method "drill_sku"   Change Method "change_sku"
 
Field OLNDES   Type ALPHA   Size 80
   Description "Product description"
   Prompt "Description"   Info Line "Enter a description of this product"
   Disabled
   Required
 
Field OLNQTY   Type DECIMAL   Size 6
   Description "Quantity Ordered"
   Prompt "Quantity"   Info Line "Enter the quantity ordered"   Format QUANTITY
   Required
 
Field OLNQTA   Type DECIMAL   Size 6
   Description "Quantity allocated"
   Prompt "Quantity Allocated"   Info Line "Enter the quantity allocated"
   Format QUANTITY   Readonly
 
Field OLNPEA   Type DECIMAL   Size 6   Precision 2
   Description "Price each"
   Prompt "Price Each"   Format CURRENCY_6_2   Blankifzero   Disabled
 
Field OLNTOT   Type DECIMAL   Size 6   Precision 2
   Description "Total price"
   Prompt "Goods Total"   Format CURRENCY_6_2   Blankifzero   Disabled
 
Field OLNTAX   Type DECIMAL   Size 6   Precision 2
   Description "Tax"
   Prompt "Tax"   Format CURRENCY_6_2   Blankifzero   Disabled
 
Field NONAME_001   Type ALPHA   Size 9   Language Noview   Script Noview
   Report Noview   Nonamelink
   Description "Spare space"
 
Key OLN_ORDER_LINE   ACCESS   Order ASCENDING   Dups NO
   Description "Order & line item number"
   Segment FIELD   OLNONM
   Segment FIELD   OLNLIN
 
Key OLNPCD   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 001
   Description "Product code"
   Segment FIELD   OLNPCD
 
Structure PRODUCT   DBL ISAM
   Description "Inventory master file (SQL)"
   User Text "@MAP=INVMAS;"
 
Field SKU   Type ALPHA   Size 10
   Description "SKU"
   Prompt "Product"   Info Line "Enter or select a product code"
   User Text "@MAP=INVPCD;"
   Uppercase
   Required
   Drill Method "drill_sku"   Change Method "change_sku"
 
Field PRODUCT_GROUP   Type ALPHA   Size 10
   Description "Product group"
   Prompt "Group"   Info Line "Enter or select a product group"
   User Text "@MAP=INVGRP;"
   Uppercase
   Required
   Drill Method "drill_product_group"   Change Method "change_product_group"
 
Field DESCRIPTION   Type ALPHA   Size 80
   Description "Product name"
   Prompt "Description"   Info Line "Enter a description of this product"
   User Text "@MAP=INVDES;"
   Required
 
Field PRICE_GROUP   Type ALPHA   Size 10
   Description "Pricing group"
   Prompt "Price code"   Info Line "Enter the pricing code"
   User Text "@MAP=INVPGP;"
   Uppercase
 
Field SELLING_PRICE   Type DECIMAL   Size 6   Precision 2
   Description "Selling Price"
   Prompt "Sell price"   Info Line "Enter the price"   User Text "@MAP=INVSPR;"
   Format CURRENCY_6_2   Blankifzero
 
Field LAST_SALE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Date of last sale"
   Prompt "Last sale"   Info Line "Enter or select the date of last sale"
   User Text "@MAP=INVDLS;"   Format "#01  MM/DD/YYYY"   Blankifzero   Readonly
 
Field LAST_COST_PRICE   Type DECIMAL   Size 10   Precision 4
   Description "Last Cost price"
   Prompt "Last cost"   Info Line "Enter the cost price"
   User Text "@MAP=INVLCP;"   Format COST_PRICE   Blankifzero   Readonly
 
Field AVERAGE_COST_PRICE   Type DECIMAL   Size 10   Precision 4
   Description "Average Cost price"
   Prompt "Avg. cost"   Info Line "Enter the cost price"
   User Text "@MAP=INVACP;"   Format COST_PRICE   Blankifzero   Readonly
 
Field QTY_IN_STOCK   Type DECIMAL   Size 6
   Description "Quantity"
   Prompt "In stock"   Info Line "Enter the quantity in stock"
   User Text "@MAP=INVQIS;"   Format QUANTITY   Readonly
 
Field QTY_ALLOCATED   Type DECIMAL   Size 6
   Description "Quantity allocated to orders"
   Prompt "Allocated"   Info Line "Enter the quantity"
   User Text "@MAP=INVQAL;"   Format QUANTITY   Readonly
 
Field QTY_IN_TRANSIT   Type DECIMAL   Size 6
   Description "Quantity in transit between warehouses"
   Prompt "In transit"
   Info Line "Enter the quantity in transit between warehouse's"
   User Text "@MAP=INVQIT;"   Format QUANTITY   Readonly
 
Field QTY_ON_ORDER   Type DECIMAL   Size 6
   Description "Quantity on Order"
   Prompt "On order"   Info Line "Enter the quantity"
   User Text "@MAP=INVQOO;"   Format QUANTITY   Readonly
 
Field REFERENCE   Type ALPHA   Size 20
   Description "Reference"
   Prompt "Reference"   User Text "@MAP=INVREF;"
 
Field PUBLISHER   Type ALPHA   Size 50
   Description "Publisher"
   Prompt "Publisher"   User Text "@MAP=INVPUB;"
 
Field AUTHOR   Type ALPHA   Size 50
   Description "Author"
   Prompt "Author"   User Text "@MAP=INVAUT;"
 
Field TYPE   Type ALPHA   Size 20
   Description "Product type"
   Prompt "Type"   Info Line "Enter the product type / category"
   User Text "@MAP=INVTYP;"
 
Field RELEASE_DATE   Type DATE   Size 8   Stored YYYYMMDD
   Description "Release Date"
   Prompt "Released"   Info Line "Enter or select the release date"
   User Text "@MAP=INVRDT;"   Format "#01  MM/DD/YYYY"   Blankifzero
   Required
 
Field RATING   Type ALPHA   Size 6
   Description "Motion Picture Rating"
   Prompt "Rating"   Info Line "Enter the Product rating [e.g. PG13, R]"
   User Text "@MAP=INVRAT;"
   Selection List 0 0 0  Entries "-------Unknown", "G     - General Audiences",
         "PG    - Parental Guidance Suggested",
         "PG13  - Parents Strongly Cautioned", "R     - Restricted",
         "NC17  - N one 17 and under admitted"
 
Key SKU   ACCESS   Order ASCENDING   Dups NO
   Description "Product code"
   Segment FIELD   SKU
 
Key PRODUCT_GROUP   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 001
   Description "Group/product"
   Segment FIELD   PRODUCT_GROUP
 
Key DESCRIPTION   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 002
   Description "Description"
   Segment FIELD   DESCRIPTION  SegType NOCASE
 
Key PRICE_GROUP   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 003
   Description "Price group"
   Segment FIELD   PRICE_GROUP
 
Key AUTHOR   ACCESS   Order ASCENDING   Dups YES   Insert END   Modifiable YES
   Krf 004
   Description "Author"
   Segment FIELD   AUTHOR  SegType NOCASE
 
Key PUBLISHER   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 005
   Description "Publisher"
   Segment FIELD   PUBLISHER  SegType NOCASE
 
Key REFERENCE   ACCESS   Order ASCENDING   Dups YES   Insert END
   Modifiable YES   Krf 006
   Description "Reference"
   Segment FIELD   REFERENCE
 
Structure PRODUCT_GROUP   DBL ISAM
   Description "Product groups (SQL)"
   User Text "@MAP=INVGRP;"
 
Field NAME   Type ALPHA   Size 10
   Description "Product group"
   Prompt "Group"   Info Line "Enter or select a product group"
   User Text "@MAP=IGPGID;"
   Uppercase
   Required
   Drill Method "drill_product_group"   Change Method "change_product_group"
 
Field DESCRIPTION   Type ALPHA   Size 40
   Description "Product group description"
   Prompt "Description"   User Text "@MAP=IGPDES;"
   Required
 
Key PRODUCT_GROUP   ACCESS   Order ASCENDING   Dups NO
   Description "Product group name"
   Segment FIELD   NAME
 
File CUSMAS   DBL ISAM   "DAT:cusmas.ism"
   Description "Customer master file"
   Assign CUSMAS
 
File INVGRP   DBL ISAM   "DAT:invgrp.ism"
   Description "Product group file"
   Assign INVGRP
 
File INVMAS   DBL ISAM   "DAT:invmas.ism"
   Description "Inventory master file"
   Assign INVMAS
 
File ORDHDR   DBL ISAM   "DAT:ordhdr.ism"
   Description "Order header file"
   Assign ORDHDR
 
File ORDLIN   DBL ISAM   "DAT:ordlin.ism"
   Description "Order line items file"
   Assign ORDLIN
 
