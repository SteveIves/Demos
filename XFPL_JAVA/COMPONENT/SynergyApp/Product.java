// Thu Nov 03 11:34:54 PDT 2011

package SynergyApp;

import java.util.*;
import Synergex.synTypes.*;

public class Product

{
  private synStruct m_synStruct = null;
 
  /** Default constructor 
  */ 
  public Product() throws Exception 
  {
    m_synStruct = this.toStruct(); 
  }

  /** getSku - Gets SKU
      @return String
  */ 
  public String getSku()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(1);
    String ret = (String)temp.value();
    return ret;
  }

  /** setSku - Sets SKU
      @param val String in 
  */ 
  public void setSku(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(1,temp);
  }

  /** getGroup - Gets Product group
      @return String
  */ 
  public String getGroup()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(2);
    String ret = (String)temp.value();
    return ret;
  }

  /** setGroup - Sets Product group
      @param val String in 
  */ 
  public void setGroup(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(2,temp);
  }

  /** getDescription - Gets Product name
      @return String
  */ 
  public String getDescription()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(3);
    String ret = (String)temp.value();
    return ret;
  }

  /** setDescription - Sets Product name
      @param val String in 
  */ 
  public void setDescription(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(3,temp);
  }

  /** getPrice_group - Gets Pricing group
      @return String
  */ 
  public String getPrice_group()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(4);
    String ret = (String)temp.value();
    return ret;
  }

  /** setPrice_group - Sets Pricing group
      @param val String in 
  */ 
  public void setPrice_group(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(4,temp);
  }

  /** getSelling_price - Gets Selling Price
      @return double
  */ 
  public double getSelling_price()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(5);
    double ret = (double)temp.value();
    return ret;
  }

  /** setSelling_price - Sets Selling Price
      @param val double in 
  */ 
  public void setSelling_price(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(5,temp);
  }

  /** getLast_sale - Gets the property value
      @return Calendar 
  */ 
  public Calendar getLast_sale()
  {
     synDec temp = (synDec)m_synStruct.getFieldValue(6);
     long hldlng = (long)temp.value(); 
     hldlng = ckifzero(hldlng,8); 
     String hldstr = new String(); 
     hldstr = String.valueOf(hldlng); 
     hldstr = zerofill(hldstr, 8); 
     Calendar tdte = Calendar.getInstance(); 
     tdte.clear(); 
     Integer fld = new Integer(0); 
     fld = Integer.valueOf(hldstr.substring(0,4)); 
     tdte.set(Calendar.YEAR, fld.intValue()); 
     fld = Integer.valueOf(hldstr.substring(4,6)); 
     tdte.set(Calendar.MONTH, (fld.intValue() - 1)); 
     fld = Integer.valueOf(hldstr.substring(6)); 
     tdte.set(Calendar.DATE, fld.intValue()); 
     return tdte; 
  }
 
  /** setLast_sale - Sets the property value
      @param dte Calendar in 
  */ 
  public void setLast_sale(Calendar tdte)
  {
     long dt = 0; 
     int mm, dd, yy; 
     yy = tdte.get(Calendar.YEAR); 
     mm = tdte.get(Calendar.MONTH) + 1; 
     dd = tdte.get(Calendar.DATE); 
     dt = (yy * 10000) + (mm * 100) + dd; 
     synDec temp = new synDec(dt); 
     m_synStruct.setFieldValue(6,temp);
  }
 
  /** getLast_cost_price - Gets Last Cost price
      @return double
  */ 
  public double getLast_cost_price()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(7);
    double ret = (double)temp.value();
    return ret;
  }

  /** setLast_cost_price - Sets Last Cost price
      @param val double in 
  */ 
  public void setLast_cost_price(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(7,temp);
  }

  /** getMoving_ave_cost_price - Gets Moving Average Cost price
      @return double
  */ 
  public double getMoving_ave_cost_price()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(8);
    double ret = (double)temp.value();
    return ret;
  }

  /** setMoving_ave_cost_price - Sets Moving Average Cost price
      @param val double in 
  */ 
  public void setMoving_ave_cost_price(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(8,temp);
  }

  /** getQty_in_stock - Gets Quantity
      @return int
  */ 
  public int getQty_in_stock()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(9);
    int ret = (int)temp.value();
    return ret;
  }

  /** setQty_in_stock - Sets Quantity
      @param val int in 
  */ 
  public void setQty_in_stock(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(9,temp);
  }

  /** getQty_allocated - Gets Quantity allocated to orders
      @return int
  */ 
  public int getQty_allocated()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(10);
    int ret = (int)temp.value();
    return ret;
  }

  /** setQty_allocated - Sets Quantity allocated to orders
      @param val int in 
  */ 
  public void setQty_allocated(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(10,temp);
  }

  /** getQty_in_transit - Gets Quantity in transit between warehouses
      @return int
  */ 
  public int getQty_in_transit()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(11);
    int ret = (int)temp.value();
    return ret;
  }

  /** setQty_in_transit - Sets Quantity in transit between warehouses
      @param val int in 
  */ 
  public void setQty_in_transit(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(11,temp);
  }

  /** getQty_on_order - Gets Quantity on Order
      @return int
  */ 
  public int getQty_on_order()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(12);
    int ret = (int)temp.value();
    return ret;
  }

  /** setQty_on_order - Sets Quantity on Order
      @param val int in 
  */ 
  public void setQty_on_order(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(12,temp);
  }

  /** getReference - Gets Reference
      @return String
  */ 
  public String getReference()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(13);
    String ret = (String)temp.value();
    return ret;
  }

  /** setReference - Sets Reference
      @param val String in 
  */ 
  public void setReference(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(13,temp);
  }

  /** getPublisher - Gets Publisher
      @return String
  */ 
  public String getPublisher()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(14);
    String ret = (String)temp.value();
    return ret;
  }

  /** setPublisher - Sets Publisher
      @param val String in 
  */ 
  public void setPublisher(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(14,temp);
  }

  /** getAuthor - Gets Author
      @return String
  */ 
  public String getAuthor()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(15);
    String ret = (String)temp.value();
    return ret;
  }

  /** setAuthor - Sets Author
      @param val String in 
  */ 
  public void setAuthor(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(15,temp);
  }

  /** getType - Gets Product type
      @return String
  */ 
  public String getType()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(16);
    String ret = (String)temp.value();
    return ret;
  }

  /** setType - Sets Product type
      @param val String in 
  */ 
  public void setType(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(16,temp);
  }

  /** getRelease_date - Gets the property value
      @return Calendar 
  */ 
  public Calendar getRelease_date()
  {
     synDec temp = (synDec)m_synStruct.getFieldValue(17);
     long hldlng = (long)temp.value(); 
     hldlng = ckifzero(hldlng,8); 
     String hldstr = new String(); 
     hldstr = String.valueOf(hldlng); 
     hldstr = zerofill(hldstr, 8); 
     Calendar tdte = Calendar.getInstance(); 
     tdte.clear(); 
     Integer fld = new Integer(0); 
     fld = Integer.valueOf(hldstr.substring(0,4)); 
     tdte.set(Calendar.YEAR, fld.intValue()); 
     fld = Integer.valueOf(hldstr.substring(4,6)); 
     tdte.set(Calendar.MONTH, (fld.intValue() - 1)); 
     fld = Integer.valueOf(hldstr.substring(6)); 
     tdte.set(Calendar.DATE, fld.intValue()); 
     return tdte; 
  }
 
  /** setRelease_date - Sets the property value
      @param dte Calendar in 
  */ 
  public void setRelease_date(Calendar tdte)
  {
     long dt = 0; 
     int mm, dd, yy; 
     yy = tdte.get(Calendar.YEAR); 
     mm = tdte.get(Calendar.MONTH) + 1; 
     dd = tdte.get(Calendar.DATE); 
     dt = (yy * 10000) + (mm * 100) + dd; 
     synDec temp = new synDec(dt); 
     m_synStruct.setFieldValue(17,temp);
  }
 
  /** getRating - Gets Motion Picture Rating
      @return String
  */ 
  public String getRating()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(18);
    String ret = (String)temp.value();
    return ret;
  }

  /** setRating - Sets Motion Picture Rating
      @param val String in 
  */ 
  public void setRating(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(18,temp);
  }

  /** getNoname_001 - Gets Spare space
      @return String
  */ 
  public String getNoname_001()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(19);
    String ret = (String)temp.value();
    return ret;
  }

  /** setNoname_001 - Sets Spare space
      @param val String in 
  */ 
  public void setNoname_001(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(19,temp);
  }

 
  private String zerofill(String tstr, int size) 
  { 
     int len = size - tstr.length(); 
     String rstr = new String(""); 
     if (len > 0) 
     { 
        for (int i=0; i<len; i++) 
           rstr = "0" + rstr; 
     } 
     rstr = rstr + tstr; 
     return rstr; 
  } 
 
  private long ckifzero(long cklng, int siz) 
  {
     if (cklng == 0) { 
       switch (siz) { 
       case 4: cklng = 101; 
               break; 
       case 5: cklng = 1001; 
               break; 
       case 6: cklng = 10101; 
               break; 
       case 7: cklng = 1001; 
               break; 
       case 8: cklng = 10101; 
               break; 
       default: cklng = 10101; 
               break; 
       } 
     } 
     return cklng; 
  }
 
  public static StructDescriptor getStructDescriptor()
  {
    try {
      return new StructDescriptor ( "Product", 440,
        new FieldDescriptor[] {
        new ScalarDescriptor("Sku", synType.ST_ALPHA, 10)
        ,new ScalarDescriptor("Group", synType.ST_ALPHA, 10)
        ,new ScalarDescriptor("Description", synType.ST_ALPHA, 80)
        ,new ScalarDescriptor("Price_group", synType.ST_ALPHA, 10)
        ,new ImpDecDescriptor("Selling_price", 6,2)
        ,new ScalarDescriptor("Last_sale", synType.ST_DECIMAL, 8)
        ,new ImpDecDescriptor("Last_cost_price", 10,4)
        ,new ImpDecDescriptor("Moving_ave_cost_price", 10,4)
        ,new ScalarDescriptor("Qty_in_stock", synType.ST_DECIMAL, 6)
        ,new ScalarDescriptor("Qty_allocated", synType.ST_DECIMAL, 6)
        ,new ScalarDescriptor("Qty_in_transit", synType.ST_DECIMAL, 6)
        ,new ScalarDescriptor("Qty_on_order", synType.ST_DECIMAL, 6)
        ,new ScalarDescriptor("Reference", synType.ST_ALPHA, 20)
        ,new ScalarDescriptor("Publisher", synType.ST_ALPHA, 50)
        ,new ScalarDescriptor("Author", synType.ST_ALPHA, 50)
        ,new ScalarDescriptor("Type", synType.ST_ALPHA, 20)
        ,new ScalarDescriptor("Release_date", synType.ST_DECIMAL, 8)
        ,new ScalarDescriptor("Rating", synType.ST_ALPHA, 6)
        ,new ScalarDescriptor("Noname_001", synType.ST_ALPHA, 118)
        }
      );
    }
    catch (InvalidStructException ise){
        ise.printStackTrace();
        return null;
    }
  }

  public synStruct toStruct() throws Exception 
  {
    synStruct st = new synStruct(getStructDescriptor());
    st.setFieldValue(1, new synAlpha(""));
    st.setFieldValue(2, new synAlpha(""));
    st.setFieldValue(3, new synAlpha(""));
    st.setFieldValue(4, new synAlpha(""));
    st.setFieldValue(5, new synImpDec(0));
    st.setFieldValue(6, new synDec(0));
    st.setFieldValue(7, new synImpDec(0));
    st.setFieldValue(8, new synImpDec(0));
    st.setFieldValue(9, new synDec(0));
    st.setFieldValue(10, new synDec(0));
    st.setFieldValue(11, new synDec(0));
    st.setFieldValue(12, new synDec(0));
    st.setFieldValue(13, new synAlpha(""));
    st.setFieldValue(14, new synAlpha(""));
    st.setFieldValue(15, new synAlpha(""));
    st.setFieldValue(16, new synAlpha(""));
    st.setFieldValue(17, new synDec(0));
    st.setFieldValue(18, new synAlpha(""));
    st.setFieldValue(19, new synAlpha(""));
    st.setCompatibility("1.5");
    return st; 
  }

  public synStruct getSynStruct()
  {
    return m_synStruct;
  }

  public void setSynStruct(synStruct synstr) throws Exception 
  {
    synAlpha temp1 = (synAlpha)synstr.getFieldValue(1);
    m_synStruct.setFieldValue(1,temp1);
    synAlpha temp2 = (synAlpha)synstr.getFieldValue(2);
    m_synStruct.setFieldValue(2,temp2);
    synAlpha temp3 = (synAlpha)synstr.getFieldValue(3);
    m_synStruct.setFieldValue(3,temp3);
    synAlpha temp4 = (synAlpha)synstr.getFieldValue(4);
    m_synStruct.setFieldValue(4,temp4);
    synImpDec temp5 = (synImpDec)synstr.getFieldValue(5);
    m_synStruct.setFieldValue(5,temp5);
    synDec temp6 = (synDec)synstr.getFieldValue(6);
    m_synStruct.setFieldValue(6,temp6);
    synImpDec temp7 = (synImpDec)synstr.getFieldValue(7);
    m_synStruct.setFieldValue(7,temp7);
    synImpDec temp8 = (synImpDec)synstr.getFieldValue(8);
    m_synStruct.setFieldValue(8,temp8);
    synDec temp9 = (synDec)synstr.getFieldValue(9);
    m_synStruct.setFieldValue(9,temp9);
    synDec temp10 = (synDec)synstr.getFieldValue(10);
    m_synStruct.setFieldValue(10,temp10);
    synDec temp11 = (synDec)synstr.getFieldValue(11);
    m_synStruct.setFieldValue(11,temp11);
    synDec temp12 = (synDec)synstr.getFieldValue(12);
    m_synStruct.setFieldValue(12,temp12);
    synAlpha temp13 = (synAlpha)synstr.getFieldValue(13);
    m_synStruct.setFieldValue(13,temp13);
    synAlpha temp14 = (synAlpha)synstr.getFieldValue(14);
    m_synStruct.setFieldValue(14,temp14);
    synAlpha temp15 = (synAlpha)synstr.getFieldValue(15);
    m_synStruct.setFieldValue(15,temp15);
    synAlpha temp16 = (synAlpha)synstr.getFieldValue(16);
    m_synStruct.setFieldValue(16,temp16);
    synDec temp17 = (synDec)synstr.getFieldValue(17);
    m_synStruct.setFieldValue(17,temp17);
    synAlpha temp18 = (synAlpha)synstr.getFieldValue(18);
    m_synStruct.setFieldValue(18,temp18);
    synAlpha temp19 = (synAlpha)synstr.getFieldValue(19);
    m_synStruct.setFieldValue(19,temp19);
  }

}
