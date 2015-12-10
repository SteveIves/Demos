REQUIRED:
-You must supply your Amazon dev key in Barcode.Site\FindProducts.aspx.cs 
-The Silverlight Toolkit Nov. 2009 must be installed and referenced in the "barcodePrototype" project.
-Expression Blend 3.0 SDK is required

For best results with the barcode scanning:
-Need good light / brightly lit area where the barcode is
-Need to try different zoom levels, ideally filling the screen with the barcode in focus
-Need to hold the camera steady

Known issues:
-Some items you scan may not be in Amazons Database and therefore will return no results
-"Searching" animation stops after a certain time. If a web request takes too long, it appears to be hung, but it is not.  Just click Scan again.
-Sometimes the promt to allow camera access appears behind the browser, inaccessible. Kill the browser process and relaunch.

This project uses code from a community project by Berend Engelbrecht 
See http://www.codeproject.com/KB/graphics/BarcodeImaging3.aspx
