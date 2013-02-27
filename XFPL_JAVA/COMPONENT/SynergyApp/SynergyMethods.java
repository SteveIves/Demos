// Thu Nov 03 11:34:54 PDT 2011

package SynergyApp;

import java.lang.Exception;
import java.io.*;
import java.math.*;
import java.net.UnknownHostException;
import java.net.InetAddress;
import java.util.*;
import org.omg.CORBA.*;
import Synergex.synProxy.*;
import Synergex.synTypes.*;
import Synergex.util.*;

@SuppressWarnings({ "unused" })
public class SynergyMethods
{
  private SWPConnect m_swpCnt = null;
  private SynergyWebProxy m_swp = null;
  private InetAddress m_localIP = null;
  private File m_iniFile = null;
  private String m_userString = null;
  private String m_xfhost = "";
  private int m_xfport = 0;
  private int m_xfminport = 0;
  private int m_xfmaxport = 0;
  private boolean m_xflogging = false;
  private String m_xflogfile = "";
  private String m_sslCertFile = "";
  private String m_sslPassword = "";
  private boolean m_override = false;
  private SynergyTrace m_tracer = null;
  private boolean m_usepool = false;
  private String m_poolname = null;
  private SWPManager m_pool = null;

  /**   Default constructor 
  */ 
  public SynergyMethods() 
  {
    try {
      m_localIP = InetAddress.getLocalHost();
      m_iniFile = new java.io.File("xfNetLnk.ini");
      m_userString = new String();
      loadProperties();
      int pos = 0;
      if (m_xflogfile != null)
        pos = m_xflogfile.lastIndexOf('.');
      String lgfle = new String("");
      if (pos > 0)
      {
         lgfle = m_xflogfile.substring(0,pos);
         lgfle = lgfle + "JCW";
         lgfle = lgfle + m_xflogfile.substring(pos);
      }
      if (m_xflogging)
        m_tracer = new SynergyTrace(lgfle, m_xflogging);
    } catch (UnknownHostException uhe){
      System.out.println("SynergyMethods : " + uhe.getMessage());
    }
  }

  /**   Ini file constructor 
          @param inifile String in 
  */ 
  public SynergyMethods(String inifile) 
  {
    try {
      m_localIP = InetAddress.getLocalHost();
      m_iniFile = new java.io.File(inifile);
      m_userString = new String();
      loadProperties();
      int pos = 0;
      if (m_xflogfile != null)
        pos = m_xflogfile.lastIndexOf('.');
      String lgfle = new String("");
      if (pos > 0)
      {
         lgfle = m_xflogfile.substring(0,pos);
         lgfle = lgfle + "JCW";
         lgfle = lgfle + m_xflogfile.substring(pos);
      }
      if (m_xflogging)
        m_tracer = new SynergyTrace(lgfle, m_xflogging);
    } catch (UnknownHostException uhe){
      System.out.println("SynergyMethods : " + uhe.getMessage());
    }
  }

  private void loadProperties() {  
    try { 
        String tmpstr = new String(""); 
        Properties synProperties = System.getProperties(); 
        FileInputStream synPropIni = new FileInputStream(m_iniFile); 
        synProperties.load(synPropIni); 
        synPropIni.close(); 
        m_xfhost = synProperties.getProperty("xf_RemoteHostName"); 
        m_xflogfile = synProperties.getProperty("xf_LogFile"); 
        m_sslCertFile = synProperties.getProperty("xf_SSLCertFile"); 
        m_sslPassword = synProperties.getProperty("xf_SSLPassword"); 
        try { 
          tmpstr = synProperties.getProperty("xf_RemotePort"); 
          m_xfport = Utils.atoi(tmpstr); 
        } catch (Exception e) { 
        } 
        try { 
          tmpstr = synProperties.getProperty("xf_LocalMinPort"); 
          m_xfminport = Utils.atoi(tmpstr); 
        } catch (Exception e) { 
        } 
        try { 
          tmpstr = synProperties.getProperty("xf_LocalMaxPort"); 
          m_xfmaxport = Utils.atoi(tmpstr); 
        } catch (Exception e) { 
        } 
        try { 
          tmpstr = synProperties.getProperty("xf_DebugOutput"); 
          m_xflogging = false; 
          if (tmpstr.equals("true")) 
            m_xflogging = true; 
        } catch (Exception e) { 
        } 
    } catch (Exception e) { 
    } 
  }

/** 
    Terminates the server-side environment (logout).
*/  

  public void Cleanup() throws xfJCWException
  {
    try {
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: Cleanup");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
           }
         } catch (Exception e) { }
      }
      wp.xcall("Cleanup");
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.Cleanup:" + e.getMessage());
    }
  }

/** 
    Creates a new order.
      @return Returns 0 on error, or order number.
      @param order Passed order data.
      @param lineItems Passed line items.
*/  

  public int CreateOrder(Order_header order,Order_line[] lineItems) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synStruct order_tmp = order.getSynStruct();
      synArray lineItems_tmp = new synArray(lineItems.length);
      for (int i=0; i < lineItems.length;i++){
        lineItems_tmp.assignElement(i,lineItems[i].getSynStruct());
      }
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: CreateOrder");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str order = **********");
             m_tracer.trace("     str lineItems = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str order = " + order_tmp.toString());
             for (int k = 0; k < lineItems.length; k++)
             {
                   m_tracer.trace("     str lineItems index " + k + " = " + lineItems[k].getSynStruct().toString());
           }
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("CreateOrder",order_tmp,lineItems_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      order.setSynStruct(order_tmp); 
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str order = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str order = " + order_tmp.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.CreateOrder:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Bulk-adds several new products.
      @return Returns 0 on success or 1 on error.
      @param product Passed product to add.
*/  

  public int CreateProduct(Product product) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synStruct product_tmp = product.getSynStruct();
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: CreateProduct");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str product = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str product = " + product_tmp.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("CreateProduct",product_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.CreateProduct:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Creates a new product group.
      @return Returns 0 on success.
      @param productGroup Product group to create.
*/  

  public int CreateProductGroup(Product_group productGroup) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synStruct productGroup_tmp = productGroup.getSynStruct();
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: CreateProductGroup");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str productGroup = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str productGroup = " + productGroup_tmp.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("CreateProductGroup",productGroup_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.CreateProductGroup:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Bulk-adds several new products.
      @return Returns 0 on success or the number of failures.
      @param products Passed array of products to add.
*/  

  public int CreateProducts(Product[] products) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synArray products_tmp = new synArray(products.length);
      for (int i=0; i < products.length;i++){
        products_tmp.assignElement(i,products[i].getSynStruct());
      }
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: CreateProducts");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str products = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             for (int k = 0; k < products.length; k++)
             {
                   m_tracer.trace("     str products index " + k + " = " + products[k].getSynStruct().toString());
           }
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("CreateProducts",products_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.CreateProducts:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    *** To Do *** Add method description 
      @return int 
      @param d21_in double in 
      @param d21_out DoubleHolder out 
      @param d21_inout DoubleHolder inout 
      @param d2818_in double in 
      @param d2818_out DoubleHolder out 
      @param d2818_inout DoubleHolder inout 
*/  

  public int DataTestMethod(double d21_in,DoubleHolder d21_out,DoubleHolder d21_inout,double d2818_in,DoubleHolder d2818_out,DoubleHolder d2818_inout) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synImpDec d21_in_tmp =  new synImpDec(d21_in);
      synImpDec d21_out_tmp =  new synImpDec();
      synImpDec d21_inout_tmp =  new synImpDec(d21_inout.value);
      synImpDec d2818_in_tmp =  new synImpDec(d2818_in);
      synImpDec d2818_out_tmp =  new synImpDec();
      synImpDec d2818_inout_tmp =  new synImpDec(d2818_inout.value);
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: DataTestMethod");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     double d21_in = **********");
             m_tracer.trace("     DoubleHolder d21_out = **********");
             m_tracer.trace("     DoubleHolder d21_inout = **********");
             m_tracer.trace("     double d2818_in = **********");
             m_tracer.trace("     DoubleHolder d2818_out = **********");
             m_tracer.trace("     DoubleHolder d2818_inout = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     double d21_in = " + d21_in);
             m_tracer.trace("     DoubleHolder d21_out = " + d21_out.value);
             m_tracer.trace("     DoubleHolder d21_inout = " + d21_inout.value);
             m_tracer.trace("     double d2818_in = " + d2818_in);
             m_tracer.trace("     DoubleHolder d2818_out = " + d2818_out.value);
             m_tracer.trace("     DoubleHolder d2818_inout = " + d2818_inout.value);
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("DataTestMethod",d21_in_tmp,d21_out_tmp,d21_inout_tmp,d2818_in_tmp,d2818_out_tmp,d2818_inout_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      d21_out.value = ((synImpDec)d21_out_tmp).value();
      d21_inout.value = ((synImpDec)d21_inout_tmp).value();
      d2818_out.value = ((synImpDec)d2818_out_tmp).value();
      d2818_inout.value = ((synImpDec)d2818_inout_tmp).value();
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     DoubleHolder d21_out = **********");
             m_tracer.trace("     DoubleHolder d21_inout = **********");
             m_tracer.trace("     DoubleHolder d2818_out = **********");
             m_tracer.trace("     DoubleHolder d2818_inout = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     DoubleHolder d21_out = " + d21_out.value);
             m_tracer.trace("     DoubleHolder d21_inout = " + d21_inout.value);
             m_tracer.trace("     DoubleHolder d2818_out = " + d2818_out.value);
             m_tracer.trace("     DoubleHolder d2818_inout = " + d2818_inout.value);
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.DataTestMethod:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Deletes a single product.
      @return Returns 0 on success.
      @param product Passed product data.
      @param errorText Returned error text (on failure).
*/  

  public int DeleteProduct(Product product,StringBuffer errorText) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synStruct product_tmp = product.getSynStruct();
      synAlpha errorText_tmp =  new synAlpha();
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: DeleteProduct");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str product = **********");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str product = " + product_tmp.toString());
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("DeleteProduct",product_tmp,errorText_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      product.setSynStruct(product_tmp); 
      errorText.replace(0,errorText.length(),((synAlpha)errorText_tmp).value());
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str product = **********");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str product = " + product_tmp.toString());
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.DeleteProduct:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Deletes a single product group.
      @return Returns 0 on success.
      @param productGroupCode Passed product group code.
      @param errorText StringBuffer out 
*/  

  public int DeleteProductGroup(String productGroupCode,StringBuffer errorText) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synAlpha productGroupCode_tmp =  new synAlpha(productGroupCode);
      synAlpha errorText_tmp =  new synAlpha();
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: DeleteProductGroup");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String productGroupCode = **********");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String productGroupCode = " + productGroupCode);
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("DeleteProductGroup",productGroupCode_tmp,errorText_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      errorText.replace(0,errorText.length(),((synAlpha)errorText_tmp).value());
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.DeleteProductGroup:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Downloads a file from the server.
      @return Returns 0 on success.
      @param fileName The name of the file to download.
      @param fileData The returned file data.
*/  

  public int DownloadFile(String fileName,ArrayList<byte[]> fileData) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synAlpha fileName_tmp =  new synAlpha(fileName);
      synByteArray fileData_tmp =  new synByteArray();
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: DownloadFile");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String fileName = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String fileName = " + fileName);
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("DownloadFile",fileName_tmp,fileData_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      fileData.clear();
fileData.add((byte[])fileData_tmp.value());
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.DownloadFile:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Retrieves a collection of all products.
      @return Returns the number of products retrieved.
      @param products Returned collection of products.
*/  

  public int GetAllProducts(ArrayList<Product> products) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      Product xfnjStr0 = new Product();
      String xfstrnme0 = new String(xfnjStr0.getClass().getName());
      synStruct xfsynstr0 = xfnjStr0.getSynStruct();
      StructDescriptor xfstrdes0 = Product.getStructDescriptor();
      ArrayList<java.lang.Object> objAL0 = new ArrayList<java.lang.Object>();
      synArrayList products_tmp = new synArrayList(objAL0, xfstrnme0, xfsynstr0, xfstrdes0);
       SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: GetAllProducts");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str products = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str products = " + products_tmp.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("GetAllProducts",products_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      objAL0 = products_tmp.value(); 
      for (int i = 0; i < objAL0.size(); i++)
           products.add((Product)objAL0.get(i));
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str products = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str products = " + products_tmp.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.GetAllProducts:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Retrieves a single customer record.
      @return Returns 0 on success.
      @param customer Customer data (containing customer code).
      @param errorText Returned error text (on failure).
*/  

  public int GetCustomer(Customer customer,StringBuffer errorText) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synStruct customer_tmp = customer.getSynStruct();
      synAlpha errorText_tmp =  new synAlpha();
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: GetCustomer");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str customer = **********");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str customer = " + customer_tmp.toString());
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("GetCustomer",customer_tmp,errorText_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      customer.setSynStruct(customer_tmp); 
      errorText.replace(0,errorText.length(),((synAlpha)errorText_tmp).value());
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str customer = **********");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str customer = " + customer_tmp.toString());
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.GetCustomer:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Retrieves all orders for a customer.
      @return Returns the number of orders retrieved.
      @param customerCode Passed customer code.
      @param orders Returned collection of orders.
*/  

  public int GetCustomerOrders(String customerCode,ArrayList<Order_header> orders) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synAlpha customerCode_tmp =  new synAlpha(customerCode);
      Order_header xfnjStr1 = new Order_header();
      String xfstrnme1 = new String(xfnjStr1.getClass().getName());
      synStruct xfsynstr1 = xfnjStr1.getSynStruct();
      StructDescriptor xfstrdes1 = Order_header.getStructDescriptor();
      ArrayList<java.lang.Object> objAL1 = new ArrayList<java.lang.Object>();
      synArrayList orders_tmp = new synArrayList(objAL1, xfstrnme1, xfsynstr1, xfstrdes1);
       SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: GetCustomerOrders");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String customerCode = **********");
             m_tracer.trace("     str orders = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String customerCode = " + customerCode);
             m_tracer.trace("     str orders = " + orders_tmp.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("GetCustomerOrders",customerCode_tmp,orders_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      objAL1 = orders_tmp.value(); 
      for (int i = 0; i < objAL1.size(); i++)
           orders.add((Order_header)objAL1.get(i));
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str orders = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str orders = " + orders_tmp.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.GetCustomerOrders:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Retrieves the application logo.
      @return Returns 0 on success.
      @param logoData Returned logo file data (JPG).
*/  

  public int GetLogo(ArrayList<byte[]> logoData) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synByteArray logoData_tmp =  new synByteArray();
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: GetLogo");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("GetLogo",logoData_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      logoData.clear();
logoData.add((byte[])logoData_tmp.value());
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.GetLogo:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Retrieves a single order.
      @return Returns 1 on success.
      @param orderNumber Passed order number.
      @param order Returned order data.
      @param items Returned collection of line items.
*/  

  public int GetOrder(int orderNumber,Order_header order,ArrayList<Order_line> items) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synDec orderNumber_tmp =  new synDec(orderNumber);
      synStruct order_tmp = order.getSynStruct();
      Order_line xfnjStr2 = new Order_line();
      String xfstrnme2 = new String(xfnjStr2.getClass().getName());
      synStruct xfsynstr2 = xfnjStr2.getSynStruct();
      StructDescriptor xfstrdes2 = Order_line.getStructDescriptor();
      ArrayList<java.lang.Object> objAL2 = new ArrayList<java.lang.Object>();
      synArrayList items_tmp = new synArrayList(objAL2, xfstrnme2, xfsynstr2, xfstrdes2);
       SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: GetOrder");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     int orderNumber = **********");
             m_tracer.trace("     str order = **********");
             m_tracer.trace("     str items = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     int orderNumber = " + orderNumber);
             m_tracer.trace("     str order = " + order_tmp.toString());
             m_tracer.trace("     str items = " + items_tmp.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("GetOrder",orderNumber_tmp,order_tmp,items_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      order.setSynStruct(order_tmp); 
      objAL2 = items_tmp.value(); 
      for (int i = 0; i < objAL2.size(); i++)
           items.add((Order_line)objAL2.get(i));
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str order = **********");
             m_tracer.trace("     str items = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str order = " + order_tmp.toString());
             m_tracer.trace("     str items = " + items_tmp.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.GetOrder:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Retrieves line items for an order.
      @return Returns the number of line items retrieved.
      @param orderNumber Passed order number.
      @param items Returned collection of line items.
*/  

  public int GetOrderItems(int orderNumber,ArrayList<Order_line> items) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synDec orderNumber_tmp =  new synDec(orderNumber);
      Order_line xfnjStr1 = new Order_line();
      String xfstrnme1 = new String(xfnjStr1.getClass().getName());
      synStruct xfsynstr1 = xfnjStr1.getSynStruct();
      StructDescriptor xfstrdes1 = Order_line.getStructDescriptor();
      ArrayList<java.lang.Object> objAL1 = new ArrayList<java.lang.Object>();
      synArrayList items_tmp = new synArrayList(objAL1, xfstrnme1, xfsynstr1, xfstrdes1);
       SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: GetOrderItems");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     int orderNumber = **********");
             m_tracer.trace("     str items = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     int orderNumber = " + orderNumber);
             m_tracer.trace("     str items = " + items_tmp.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("GetOrderItems",orderNumber_tmp,items_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      objAL1 = items_tmp.value(); 
      for (int i = 0; i < objAL1.size(); i++)
           items.add((Order_line)objAL1.get(i));
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str items = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str items = " + items_tmp.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.GetOrderItems:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Retrieves a single product.
      @return Returns 0 on success.
      @param product Returned product data.
      @param errorText StringBuffer inout 
*/  

  public int GetProduct(Product product,StringBuffer errorText) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synStruct product_tmp = product.getSynStruct();
      synAlpha errorText_tmp =  new synAlpha(errorText.toString());
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: GetProduct");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str product = **********");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str product = " + product_tmp.toString());
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("GetProduct",product_tmp,errorText_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      product.setSynStruct(product_tmp); 
      errorText.replace(0,errorText.length(),((synAlpha)errorText_tmp).value());
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str product = **********");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str product = " + product_tmp.toString());
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.GetProduct:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Retrieves all product groups.
      @param productGroups Returned collection of product groups.
*/  

  public void GetProductGroups(ArrayList<Product_group> productGroups) throws xfJCWException
  {
    try {
      Product_group xfnjStr0 = new Product_group();
      String xfstrnme0 = new String(xfnjStr0.getClass().getName());
      synStruct xfsynstr0 = xfnjStr0.getSynStruct();
      StructDescriptor xfstrdes0 = Product_group.getStructDescriptor();
      ArrayList<java.lang.Object> objAL0 = new ArrayList<java.lang.Object>();
      synArrayList productGroups_tmp = new synArrayList(objAL0, xfstrnme0, xfsynstr0, xfstrdes0);
       SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: GetProductGroups");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str productGroups = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str productGroups = " + productGroups_tmp.toString());
           }
         } catch (Exception e) { }
      }
      wp.xcall("GetProductGroups",productGroups_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      objAL0 = productGroups_tmp.value(); 
      for (int i = 0; i < objAL0.size(); i++)
           productGroups.add((Product_group)objAL0.get(i));
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str productGroups = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str productGroups = " + productGroups_tmp.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.GetProductGroups:" + e.getMessage());
    }
  }

/** 
    Retrieves all product groups.
      @param productGroups Returned collection of product groups.
*/  

  public void GetProductGroups2(ArrayList<Product_group> productGroups) throws xfJCWException
  {
    try {
      Product_group xfnjStr0 = new Product_group();
      String xfstrnme0 = new String(xfnjStr0.getClass().getName());
      synStruct xfsynstr0 = xfnjStr0.getSynStruct();
      StructDescriptor xfstrdes0 = Product_group.getStructDescriptor();
      ArrayList<java.lang.Object> objAL0 = new ArrayList<java.lang.Object>();
      synArrayList productGroups_tmp = new synArrayList(objAL0, xfstrnme0, xfsynstr0, xfstrdes0);
       productGroups_tmp.setSystemAL(true);
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: GetProductGroups2");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str productGroups = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str productGroups = " + productGroups_tmp.toString());
           }
         } catch (Exception e) { }
      }
      wp.xcall("GetProductGroups2",productGroups_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      objAL0 = productGroups_tmp.value(); 
      for (int i = 0; i < objAL0.size(); i++)
           productGroups.add((Product_group)objAL0.get(i));
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str productGroups = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str productGroups = " + productGroups_tmp.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.GetProductGroups2:" + e.getMessage());
    }
  }

/** 
    Retrieves products in a product group.
      @return Returns the number of products retrieved.
      @param productGroupCode Product group code.
      @param products Returned collection of products.
*/  

  public int GetProductsInGroup(String productGroupCode,ArrayList<Product> products) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synAlpha productGroupCode_tmp =  new synAlpha(productGroupCode);
      Product xfnjStr1 = new Product();
      String xfstrnme1 = new String(xfnjStr1.getClass().getName());
      synStruct xfsynstr1 = xfnjStr1.getSynStruct();
      StructDescriptor xfstrdes1 = Product.getStructDescriptor();
      ArrayList<java.lang.Object> objAL1 = new ArrayList<java.lang.Object>();
      synArrayList products_tmp = new synArrayList(objAL1, xfstrnme1, xfsynstr1, xfstrdes1);
       SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: GetProductsInGroup");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String productGroupCode = **********");
             m_tracer.trace("     str products = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String productGroupCode = " + productGroupCode);
             m_tracer.trace("     str products = " + products_tmp.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("GetProductsInGroup",productGroupCode_tmp,products_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      objAL1 = products_tmp.value(); 
      for (int i = 0; i < objAL1.size(); i++)
           products.add((Product)objAL1.get(i));
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str products = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str products = " + products_tmp.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.GetProductsInGroup:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Initializes the server environment.
      @return Returns 0 on success.
*/  

  public int Initialize() throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: Initialize");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("Initialize");
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.Initialize:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Authenticates a user session.
      @return Returns 0 on success, 1 on error.
      @param username Passed user login name.
      @param password Passed account password.
      @param userData Returned user information (on success).
      @param errorText Returned error message (on error).
*/  

  public int Login(String username,String password,User userData,StringBuffer errorText) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synAlpha username_tmp =  new synAlpha(username);
      synAlpha password_tmp =  new synAlpha(password);
      synStruct userData_tmp = userData.getSynStruct();
      synAlpha errorText_tmp =  new synAlpha();
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: Login");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String username = **********");
             m_tracer.trace("     String password = **********");
             m_tracer.trace("     str userData = **********");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String username = " + username);
             m_tracer.trace("     String password = " + password);
             m_tracer.trace("     str userData = " + userData_tmp.toString());
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("Login",username_tmp,password_tmp,userData_tmp,errorText_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      userData.setSynStruct(userData_tmp); 
      errorText.replace(0,errorText.length(),((synAlpha)errorText_tmp).value());
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str userData = **********");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     str userData = " + userData_tmp.toString());
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.Login:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Updates a product record.
      @return Returns 0 on success, 1 on error.
      @param product Passed product to be updated.
      @param errorText Returned error message (on error).
*/  

  public int UpdateProduct(Product product,StringBuffer errorText) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synStruct product_tmp = product.getSynStruct();
      synAlpha errorText_tmp =  new synAlpha();
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: UpdateProduct");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str product = **********");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     str product = " + product_tmp.toString());
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("UpdateProduct",product_tmp,errorText_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      errorText.replace(0,errorText.length(),((synAlpha)errorText_tmp).value());
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     StringBuffer errorText = **********");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
             m_tracer.trace("     StringBuffer errorText = " + errorText.toString());
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.UpdateProduct:" + e.getMessage());
    }
    return (int)ret.value();
  }

/** 
    Uploads a file to the server.
      @return Returns zero on success, 1 on error.
      @param fileData Passed file data.
      @param fileName Passed name to save the file as.
*/  

  public int UploadFile(ArrayList<byte[]> fileData,String fileName) throws xfJCWException
  {
    synDec ret = new synDec();
    try {
      synByteArray fileData_tmp =  new synByteArray(fileData);
      synAlpha fileName_tmp =  new synAlpha(fileName);
      SynergyWebProxy wp = null;
      if (null != m_swp)
        wp = m_swp; //use existing connection
      else
        wp = doConnect();
      boolean isEncrypted = wp.EncryptedCall();
      if (m_xflogging)
      {
         try { 
           m_tracer.trace(" ** In method: UploadFile");
           if (isEncrypted)
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String fileName = **********");
           }
           else
           {
             m_tracer.trace("  * Input parameters");
             m_tracer.trace("     String fileName = " + fileName);
           }
         } catch (Exception e) { }
      }
      ret = (synDec)wp.xcall("UploadFile",fileData_tmp,fileName_tmp);
      if (null == m_swp)
        this.disconnect();
      wp = null;
      if (m_xflogging)
      {
         try { 
           if (isEncrypted)
           {
             m_tracer.trace("  * Output parameters");
           }
           else
           {
             m_tracer.trace("  * Output parameters");
           }
         } catch (Exception e) { }
      }
    }
    catch (Exception e) {
	   if (m_pool != null)
	      this.Discard();
	   throw new xfJCWException("SynergyMethods.UploadFile:" + e.getMessage());
    }
    return (int)ret.value();
  }
  /** 
    Gets the host name or IP address of the machine where xfServerPlus is running.
      @return String 
  */ 
  public String getxfHost()
  {
    return m_xfhost; 
  }

  /** 
    Sets the host name or IP address of the machine where xfServerPlus is running.
      @param host String in 
  */ 
  public void setxfHost(String host)
  {
    m_xfhost = host; 
    m_override = true; 
  }

  /** 
    Returns the port number of the machine where xfServerPlus is running.
      @return int 
  */ 
  public int getxfPort()
  {
    return m_xfport; 
  }

  /** 
    Sets the port number of the machine where xfServerPlus is running.
      @param port int in 
  */ 
  public void setxfPort(int port)
  {
    m_xfport = port; 
    m_override = true; 
  }

  /** 
    Returns the beginning value for the port range that the client is listening on.
      @return int 
      @deprecated This method should only be used when debugging.  
  */ 
  @Deprecated public int getxfMinport()
  {
    return m_xfminport; 
  }

  /** 
    Sets the beginning value for the port range that the client is listening on.
      @param port int in 
      @deprecated This method should only be used when debugging.  
  */ 
  @Deprecated public void setxfMinport(int port) throws xfJCWException
  {
    if (port <= 1024) 
      throw new xfJCWException("Minimum port must be > 1024");
    m_xfminport = port; 
    m_override = true; 
  }

  /** 
    Returns the ending value for the port range that the client is listening on.
      @return int 
      @deprecated This method should only be used when debugging.  
  */ 
  @Deprecated public int getxfMaxport()
  {
    return m_xfmaxport; 
  }

  /** 
    Sets the ending value for the port range that the client is listening on.
      @param port int in 
      @deprecated This method should only be used when debugging.  
  */ 
  @Deprecated public void setxfMaxport(int port) throws xfJCWException
  {
    if (port <= 1024) 
      throw new xfJCWException("Maximum port must be > 1024");
    m_xfmaxport = port; 
    m_override = true; 
  }

  /** 
    Sets client-side logging to true or false.
      @return int 
      @param logging boolean in 
  */ 
  public int setxfLogging(boolean logging)
  {
    int rtn = 0;
    if(m_swp == null) {
      m_xflogging = logging; 
      m_override = true; 
    } else {
      rtn = 1;
    }
    return(rtn);
  }

  /** 
    Returns the name of the client-side logfile.
      @return String 
  */ 
  public String getxfLogfile()
  {
    return m_xflogfile; 
  }

  /** 
    Sets the name of the client-side logfile. If you do not specify a logfile name, output is written to the screen.
      @return int 
      @param logfile String in 
  */ 
  public int setxfLogfile(String logfile)
  {
    int rtn = 0;
    if(m_swp == null) {
      m_xflogfile = logfile; 
      int pos = 0;
      if (m_xflogfile != null && m_xflogfile != "")
        pos = m_xflogfile.lastIndexOf('.');
      String lgfle = new String("");
      if (pos > 0) {
         lgfle = m_xflogfile.substring(0,pos);
         lgfle = lgfle + "JCW";
         lgfle = lgfle + m_xflogfile.substring(pos);
      }
      if (m_tracer != null) {
        m_tracer.close();
        m_tracer = null;
      }
      if (m_xflogging)
        m_tracer = new SynergyTrace(lgfle, m_xflogging);
    } else 
      rtn = 1;
    return(rtn);
  }

  /** 
    Gets the SSL certificate file to use for SSL.
      @return String 
  */ 
  public String getSSLCertFile()
  {
    return m_sslCertFile; 
  }

  /** 
    Sets the SSL certificate file to be used with SSL.
      @param certfile String in 
  */ 
  public void setSSLCertFile(String certfile)
  {
    m_sslCertFile = certfile; 
    m_override = true; 
  }

  /** 
    Gets the SSL certificate file password.
      @return String 
  */ 
  public String getSSLPassword()
  {
    return m_sslPassword; 
  }

  /** 
    Sets the SSL certificate file password.
      @param password String in 
  */ 
  public void setSSLPassword(String password)
  {
    m_sslPassword = password; 
    m_override = true; 
  }

  /** 
    Returns the name of the pool if pooling is being used.
      @return String 
  */ 
  public String getPoolName()
  {
    return m_poolname; 
  }

  /** 
    Returns the internal instance of the SynergyWebProxy.
      @return SynergyWebProxy 
  */ 
  public SynergyWebProxy getSynergyWebP0roxy()
  {
    return m_swp; 
  }

  /** 
    Makes a connection to xfServerPlus.
  */ 
  public void connect() throws xfJCWException
  {
    try {
      m_swp = doConnect();
    } catch (Exception e) {
	throw new xfJCWException("SynergyMethods.connect: " + e.getMessage());
    }
  }

  /** 
    Closes the connection to xfServerPlus.
  */ 
  public void disconnect() throws xfJCWException
  {
     try {
       if (null != m_swpCnt)
         m_swpCnt.disconnect();
       m_swpCnt = null;
       m_swp = null;
     } catch (Exception ex) {
       throw new xfJCWException(ex.getMessage());
     }
  }

  /** 
    Gets the already-established SWPConnect connection of the specified object.
      @return java.lang.Object 
  */ 
  public java.lang.Object getConnect() throws xfJCWException
  {
     checkConnect("getConnect");
     return (java.lang.Object)m_swpCnt;
  }

  /** 
    Shares the specified SWPConnect connection.
      @param anObject java.lang.Object in 
  */ 
  public void shareConnect(java.lang.Object anObject) throws xfJCWException
  {
    if (anObject instanceof SWPConnect) {
	     SWPConnect an_swpCnt = (SWPConnect)anObject;
	     m_swpCnt = an_swpCnt;
	     m_swp = an_swpCnt.getM_swp();
	     m_swpCnt.incConnectCount();
    }
    else
	throw new xfJCWException("SynergyMethods.shareConnect: Invalid connection passed into shareConnect");
  }

  /** 
    Initializes a connection to xfServerPlus so you can manually start a session in debug mode.
      @param clientIP String in 
      @param listeningIP StringBuffer out 
      @param port StringBuffer out 
  */ 
  public void debugInit (String clientIP, StringBuffer listeningIP, StringBuffer port)
         throws xfJCWException
  {
     try {
       InetAddress client = InetAddress.getByName(clientIP);
       m_swp = new SynergyWebProxy(client, true, "COM_Debug");

       // get listening IP
       StringBuffer ip = new StringBuffer(m_swp.getlisten_ip());
       if (ip.length() < 8)
	      ip.insert(0,0);
       listeningIP.replace(0,listeningIP.length(),ip.toString());

       // get listening port
       port.replace(0,port.length(),m_swp.getlisten_port());
     } catch (Exception ex) {
       throw new xfJCWException(ex.getMessage());
     }
  }

  /** 
    Completes the connection to xfServerPlus in debug mode.
      @param clientIP String in 
  */ 
  public void debugStart(String clientIP) throws xfJCWException
  {
     try {
       InetAddress client = InetAddress.getByName(clientIP);
       checkConnect("debugStart");
       m_swp.DebugStart(client);
     } catch (Exception ex) {
       throw new xfJCWException(ex.getMessage());
     }
  }

  /** 
    Sets the call time-out value in seconds. The call time-out measures the length of time the xfNetLink Java client waits for a return call from xfServerPlus.
      @param seconds int in 
  */ 
  public void setxfCallTimeout (int seconds) throws xfJCWException
  {
    checkConnect("setxfCallTimeout");
    m_swp.resetRemoteCallTimeout(seconds);
  }

  /** 
    Passes a user-defined string to the xfServerPlus log.
      @param str String in 
  */ 
  public void setUserString (String str) throws xfJCWException
  {
    checkConnect("setUserString");
    m_swp.passUserString(str);
    m_userString = str;
  }

  /** 
    Returns the user string currently stored by setUserString().
      @return String
  */ 
  public String getUserString () 
  {
    return m_userString;
  }

  /** 
    Indicates that Java connection pooling will be used. 
      @param poolID String in 
      @param swpMgr SWPManager in 
  */ 
  public void usePool (String poolID, SWPManager swpMgr)
  {
     m_poolname = poolID;
     m_pool = swpMgr;
     m_usepool = false;
     if (m_poolname != null)
       m_usepool = true;
  }

  private void checkConnect(String where) throws xfJCWException
  {
    if (null == m_swp)
       throw new xfJCWException("SynergyMethods." + where + ": No connection established");
  }

  private SynergyWebProxy doConnect() throws Exception
  {
    if (m_usepool) {
      m_swpCnt = m_pool.getConnection(m_poolname);
    } else {
      if (m_override)
        m_swpCnt = new SWPConnect(m_xfhost,m_xfport,m_xfminport,m_xfmaxport,m_xflogging,m_xflogfile, m_sslCertFile, m_sslPassword);
      else 
        m_swpCnt = new SWPConnect(m_iniFile);
    }
    return (m_swpCnt.getM_swp());
  }

  private void Discard()
  {
    try {
      if (m_pool != null)
          if (m_swpCnt != null)
          {
               m_swpCnt.setError(true);
               m_swpCnt.disconnect();
          }
    } catch (Exception ex)
    {
    }
    finally
    {
        m_swp = null;
        m_swpCnt = null;
    }
  }

}
