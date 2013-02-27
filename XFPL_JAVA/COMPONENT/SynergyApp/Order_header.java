// Thu Nov 03 11:34:54 PDT 2011

package SynergyApp;

import java.util.*;
import Synergex.synTypes.*;

public class Order_header

{
  private synStruct m_synStruct = null;
 
  /** Default constructor 
  */ 
  public Order_header() throws Exception 
  {
    m_synStruct = this.toStruct(); 
  }

  /** getOrder - Gets Order number
      @return int
  */ 
  public int getOrder()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(1);
    int ret = (int)temp.value();
    return ret;
  }

  /** setOrder - Sets Order number
      @param val int in 
  */ 
  public void setOrder(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(1,temp);
  }

  /** getOrder_date - Gets the property value
      @return Calendar 
  */ 
  public Calendar getOrder_date()
  {
     synDec temp = (synDec)m_synStruct.getFieldValue(2);
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
 
  /** setOrder_date - Sets the property value
      @param dte Calendar in 
  */ 
  public void setOrder_date(Calendar tdte)
  {
     long dt = 0; 
     int mm, dd, yy; 
     yy = tdte.get(Calendar.YEAR); 
     mm = tdte.get(Calendar.MONTH) + 1; 
     dd = tdte.get(Calendar.DATE); 
     dt = (yy * 10000) + (mm * 100) + dd; 
     synDec temp = new synDec(dt); 
     m_synStruct.setFieldValue(2,temp);
  }
 
  /** getStatus - Gets Order Status
      @return String
  */ 
  public String getStatus()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(3);
    String ret = (String)temp.value();
    return ret;
  }

  /** setStatus - Sets Order Status
      @param val String in 
  */ 
  public void setStatus(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(3,temp);
  }

  /** getShip_date - Gets the property value
      @return Calendar 
  */ 
  public Calendar getShip_date()
  {
     synDec temp = (synDec)m_synStruct.getFieldValue(4);
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
 
  /** setShip_date - Sets the property value
      @param dte Calendar in 
  */ 
  public void setShip_date(Calendar tdte)
  {
     long dt = 0; 
     int mm, dd, yy; 
     yy = tdte.get(Calendar.YEAR); 
     mm = tdte.get(Calendar.MONTH) + 1; 
     dd = tdte.get(Calendar.DATE); 
     dt = (yy * 10000) + (mm * 100) + dd; 
     synDec temp = new synDec(dt); 
     m_synStruct.setFieldValue(4,temp);
  }
 
  /** getCustomer - Gets Account number
      @return String
  */ 
  public String getCustomer()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(5);
    String ret = (String)temp.value();
    return ret;
  }

  /** setCustomer - Sets Account number
      @param val String in 
  */ 
  public void setCustomer(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(5,temp);
  }

  /** getDelivery_date - Gets the property value
      @return Calendar 
  */ 
  public Calendar getDelivery_date()
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
 
  /** setDelivery_date - Sets the property value
      @param dte Calendar in 
  */ 
  public void setDelivery_date(Calendar tdte)
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
 
  /** getCustomer_order_ref - Gets Customer Order Reference
      @return String
  */ 
  public String getCustomer_order_ref()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(7);
    String ret = (String)temp.value();
    return ret;
  }

  /** setCustomer_order_ref - Sets Customer Order Reference
      @param val String in 
  */ 
  public void setCustomer_order_ref(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(7,temp);
  }

  /** getGoods_value - Gets Total goods value
      @return double
  */ 
  public double getGoods_value()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(8);
    double ret = (double)temp.value();
    return ret;
  }

  /** setGoods_value - Sets Total goods value
      @param val double in 
  */ 
  public void setGoods_value(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(8,temp);
  }

  /** getTax_value - Gets Total tax value
      @return double
  */ 
  public double getTax_value()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(9);
    double ret = (double)temp.value();
    return ret;
  }

  /** setTax_value - Sets Total tax value
      @param val double in 
  */ 
  public void setTax_value(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(9,temp);
  }

  /** getShipping_value - Gets Total Shipping value
      @return double
  */ 
  public double getShipping_value()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(10);
    double ret = (double)temp.value();
    return ret;
  }

  /** setShipping_value - Sets Total Shipping value
      @param val double in 
  */ 
  public void setShipping_value(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(10,temp);
  }

  /** getGift_wrap - Gets Gift wrap required
      @return byte
  */ 
  public byte getGift_wrap()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(11);
    byte ret = (byte)temp.value();
    return ret;
  }

  /** setGift_wrap - Sets Gift wrap required
      @param val byte in 
  */ 
  public void setGift_wrap(byte val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(11,temp);
  }

  /** getGift_message - Gets Gift Message
      @return String
  */ 
  public String getGift_message()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(12);
    String ret = (String)temp.value();
    return ret;
  }

  /** setGift_message - Sets Gift Message
      @param val String in 
  */ 
  public void setGift_message(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(12,temp);
  }

  /** getNoname_001 - Gets Spare space
      @return String
  */ 
  public String getNoname_001()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(13);
    String ret = (String)temp.value();
    return ret;
  }

  /** setNoname_001 - Sets Spare space
      @param val String in 
  */ 
  public void setNoname_001(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(13,temp);
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
      return new StructDescriptor ( "Order_header", 200,
        new FieldDescriptor[] {
        new ScalarDescriptor("Order", synType.ST_DECIMAL, 8)
        ,new ScalarDescriptor("Order_date", synType.ST_DECIMAL, 8)
        ,new ScalarDescriptor("Status", synType.ST_ALPHA, 1)
        ,new ScalarDescriptor("Ship_date", synType.ST_DECIMAL, 8)
        ,new ScalarDescriptor("Customer", synType.ST_ALPHA, 8)
        ,new ScalarDescriptor("Delivery_date", synType.ST_DECIMAL, 8)
        ,new ScalarDescriptor("Customer_order_ref", synType.ST_ALPHA, 20)
        ,new ImpDecDescriptor("Goods_value", 8,2)
        ,new ImpDecDescriptor("Tax_value", 8,2)
        ,new ImpDecDescriptor("Shipping_value", 8,2)
        ,new ScalarDescriptor("Gift_wrap", synType.ST_DECIMAL, 1)
        ,new ScalarDescriptor("Gift_message", synType.ST_ALPHA, 60)
        ,new ScalarDescriptor("Noname_001", synType.ST_ALPHA, 54)
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
    st.setFieldValue(1, new synDec(0));
    st.setFieldValue(2, new synDec(0));
    st.setFieldValue(3, new synAlpha(""));
    st.setFieldValue(4, new synDec(0));
    st.setFieldValue(5, new synAlpha(""));
    st.setFieldValue(6, new synDec(0));
    st.setFieldValue(7, new synAlpha(""));
    st.setFieldValue(8, new synImpDec(0));
    st.setFieldValue(9, new synImpDec(0));
    st.setFieldValue(10, new synImpDec(0));
    st.setFieldValue(11, new synDec(0));
    st.setFieldValue(12, new synAlpha(""));
    st.setFieldValue(13, new synAlpha(""));
    st.setCompatibility("1.5");
    return st; 
  }

  public synStruct getSynStruct()
  {
    return m_synStruct;
  }

  public void setSynStruct(synStruct synstr) throws Exception 
  {
    synDec temp1 = (synDec)synstr.getFieldValue(1);
    m_synStruct.setFieldValue(1,temp1);
    synDec temp2 = (synDec)synstr.getFieldValue(2);
    m_synStruct.setFieldValue(2,temp2);
    synAlpha temp3 = (synAlpha)synstr.getFieldValue(3);
    m_synStruct.setFieldValue(3,temp3);
    synDec temp4 = (synDec)synstr.getFieldValue(4);
    m_synStruct.setFieldValue(4,temp4);
    synAlpha temp5 = (synAlpha)synstr.getFieldValue(5);
    m_synStruct.setFieldValue(5,temp5);
    synDec temp6 = (synDec)synstr.getFieldValue(6);
    m_synStruct.setFieldValue(6,temp6);
    synAlpha temp7 = (synAlpha)synstr.getFieldValue(7);
    m_synStruct.setFieldValue(7,temp7);
    synImpDec temp8 = (synImpDec)synstr.getFieldValue(8);
    m_synStruct.setFieldValue(8,temp8);
    synImpDec temp9 = (synImpDec)synstr.getFieldValue(9);
    m_synStruct.setFieldValue(9,temp9);
    synImpDec temp10 = (synImpDec)synstr.getFieldValue(10);
    m_synStruct.setFieldValue(10,temp10);
    synDec temp11 = (synDec)synstr.getFieldValue(11);
    m_synStruct.setFieldValue(11,temp11);
    synAlpha temp12 = (synAlpha)synstr.getFieldValue(12);
    m_synStruct.setFieldValue(12,temp12);
    synAlpha temp13 = (synAlpha)synstr.getFieldValue(13);
    m_synStruct.setFieldValue(13,temp13);
  }

}
