// Thu Nov 03 11:34:54 PDT 2011

package SynergyApp;

import java.util.*;
import Synergex.synTypes.*;

public class Customer

{
  private synStruct m_synStruct = null;
 
  /** Default constructor 
  */ 
  public Customer() throws Exception 
  {
    m_synStruct = this.toStruct(); 
  }

  /** getAccount - Gets Account number
      @return String
  */ 
  public String getAccount()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(1);
    String ret = (String)temp.value();
    return ret;
  }

  /** setAccount - Sets Account number
      @param val String in 
  */ 
  public void setAccount(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(1,temp);
  }

  /** getCompany - Gets Company name
      @return String
  */ 
  public String getCompany()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(2);
    String ret = (String)temp.value();
    return ret;
  }

  /** setCompany - Sets Company name
      @param val String in 
  */ 
  public void setCompany(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(2,temp);
  }

  /** getStreet - Gets Street address
      @return String
  */ 
  public String getStreet()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(3);
    String ret = (String)temp.value();
    return ret;
  }

  /** setStreet - Sets Street address
      @param val String in 
  */ 
  public void setStreet(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(3,temp);
  }

  /** getCity - Gets City
      @return String
  */ 
  public String getCity()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(4);
    String ret = (String)temp.value();
    return ret;
  }

  /** setCity - Sets City
      @param val String in 
  */ 
  public void setCity(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(4,temp);
  }

  /** getState - Gets State
      @return String
  */ 
  public String getState()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(5);
    String ret = (String)temp.value();
    return ret;
  }

  /** setState - Sets State
      @param val String in 
  */ 
  public void setState(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(5,temp);
  }

  /** getZip - Gets Zip code
      @return int
  */ 
  public int getZip()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(6);
    int ret = (int)temp.value();
    return ret;
  }

  /** setZip - Sets Zip code
      @param val int in 
  */ 
  public void setZip(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(6,temp);
  }

  /** getPhone_area - Gets Phone area code
      @return short
  */ 
  public short getPhone_area()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(7);
    short ret = (short)temp.value();
    return ret;
  }

  /** setPhone_area - Sets Phone area code
      @param val short in 
  */ 
  public void setPhone_area(short val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(7,temp);
  }

  /** getPhone_number - Gets Phone number
      @return int
  */ 
  public int getPhone_number()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(8);
    int ret = (int)temp.value();
    return ret;
  }

  /** setPhone_number - Sets Phone number
      @param val int in 
  */ 
  public void setPhone_number(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(8,temp);
  }

  /** getFax_area - Gets Fax area code
      @return short
  */ 
  public short getFax_area()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(9);
    short ret = (short)temp.value();
    return ret;
  }

  /** setFax_area - Sets Fax area code
      @param val short in 
  */ 
  public void setFax_area(short val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(9,temp);
  }

  /** getFax_number - Gets Fax number
      @return int
  */ 
  public int getFax_number()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(10);
    int ret = (int)temp.value();
    return ret;
  }

  /** setFax_number - Sets Fax number
      @param val int in 
  */ 
  public void setFax_number(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(10,temp);
  }

  /** getMobile_area - Gets Mobile phone area code
      @return short
  */ 
  public short getMobile_area()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(11);
    short ret = (short)temp.value();
    return ret;
  }

  /** setMobile_area - Sets Mobile phone area code
      @param val short in 
  */ 
  public void setMobile_area(short val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(11,temp);
  }

  /** getMobile_number - Gets Mobile number
      @return int
  */ 
  public int getMobile_number()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(12);
    int ret = (int)temp.value();
    return ret;
  }

  /** setMobile_number - Sets Mobile number
      @param val int in 
  */ 
  public void setMobile_number(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(12,temp);
  }

  /** getPager_area - Gets Pager area code
      @return short
  */ 
  public short getPager_area()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(13);
    short ret = (short)temp.value();
    return ret;
  }

  /** setPager_area - Sets Pager area code
      @param val short in 
  */ 
  public void setPager_area(short val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(13,temp);
  }

  /** getPager_number - Gets Pager number
      @return int
  */ 
  public int getPager_number()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(14);
    int ret = (int)temp.value();
    return ret;
  }

  /** setPager_number - Sets Pager number
      @param val int in 
  */ 
  public void setPager_number(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(14,temp);
  }

  /** getEmail1 - Gets Primary email address
      @return String
  */ 
  public String getEmail1()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(15);
    String ret = (String)temp.value();
    return ret;
  }

  /** setEmail1 - Sets Primary email address
      @param val String in 
  */ 
  public void setEmail1(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(15,temp);
  }

  /** getEmail2 - Gets Alternate email address
      @return String
  */ 
  public String getEmail2()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(16);
    String ret = (String)temp.value();
    return ret;
  }

  /** setEmail2 - Sets Alternate email address
      @param val String in 
  */ 
  public void setEmail2(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(16,temp);
  }

  /** getDate_opened - Gets the property value
      @return Calendar 
  */ 
  public Calendar getDate_opened()
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
 
  /** setDate_opened - Sets the property value
      @param dte Calendar in 
  */ 
  public void setDate_opened(Calendar tdte)
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
 
  /** getDate_hold - Gets the property value
      @return Calendar 
  */ 
  public Calendar getDate_hold()
  {
     synDec temp = (synDec)m_synStruct.getFieldValue(18);
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
 
  /** setDate_hold - Sets the property value
      @param dte Calendar in 
  */ 
  public void setDate_hold(Calendar tdte)
  {
     long dt = 0; 
     int mm, dd, yy; 
     yy = tdte.get(Calendar.YEAR); 
     mm = tdte.get(Calendar.MONTH) + 1; 
     dd = tdte.get(Calendar.DATE); 
     dt = (yy * 10000) + (mm * 100) + dd; 
     synDec temp = new synDec(dt); 
     m_synStruct.setFieldValue(18,temp);
  }
 
  /** getDate_closed - Gets the property value
      @return Calendar 
  */ 
  public Calendar getDate_closed()
  {
     synDec temp = (synDec)m_synStruct.getFieldValue(19);
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
 
  /** setDate_closed - Sets the property value
      @param dte Calendar in 
  */ 
  public void setDate_closed(Calendar tdte)
  {
     long dt = 0; 
     int mm, dd, yy; 
     yy = tdte.get(Calendar.YEAR); 
     mm = tdte.get(Calendar.MONTH) + 1; 
     dd = tdte.get(Calendar.DATE); 
     dt = (yy * 10000) + (mm * 100) + dd; 
     synDec temp = new synDec(dt); 
     m_synStruct.setFieldValue(19,temp);
  }
 
  /** getStatus - Gets Account status
      @return byte
  */ 
  public byte getStatus()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(20);
    byte ret = (byte)temp.value();
    return ret;
  }

  /** setStatus - Sets Account status
      @param val byte in 
  */ 
  public void setStatus(byte val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(20,temp);
  }

  /** getLimit - Gets Credit limit
      @return double
  */ 
  public double getLimit()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(21);
    double ret = (double)temp.value();
    return ret;
  }

  /** setLimit - Sets Credit limit
      @param val double in 
  */ 
  public void setLimit(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(21,temp);
  }

  /** getBalance - Gets Account balance
      @return double
  */ 
  public double getBalance()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(22);
    double ret = (double)temp.value();
    return ret;
  }

  /** setBalance - Sets Account balance
      @param val double in 
  */ 
  public void setBalance(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(22,temp);
  }

  /** getSpare - Gets Spare space
      @return String
  */ 
  public String getSpare()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(23);
    String ret = (String)temp.value();
    return ret;
  }

  /** setSpare - Sets Spare space
      @param val String in 
  */ 
  public void setSpare(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(23,temp);
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
      return new StructDescriptor ( "Customer", 430,
        new FieldDescriptor[] {
        new ScalarDescriptor("Account", synType.ST_ALPHA, 8)
        ,new ScalarDescriptor("Company", synType.ST_ALPHA, 40)
        ,new ScalarDescriptor("Street", synType.ST_ALPHA, 40)
        ,new ScalarDescriptor("City", synType.ST_ALPHA, 25)
        ,new ScalarDescriptor("State", synType.ST_ALPHA, 2)
        ,new ScalarDescriptor("Zip", synType.ST_DECIMAL, 5)
        ,new ScalarDescriptor("Phone_area", synType.ST_DECIMAL, 3)
        ,new ScalarDescriptor("Phone_number", synType.ST_DECIMAL, 7)
        ,new ScalarDescriptor("Fax_area", synType.ST_DECIMAL, 3)
        ,new ScalarDescriptor("Fax_number", synType.ST_DECIMAL, 7)
        ,new ScalarDescriptor("Mobile_area", synType.ST_DECIMAL, 3)
        ,new ScalarDescriptor("Mobile_number", synType.ST_DECIMAL, 7)
        ,new ScalarDescriptor("Pager_area", synType.ST_DECIMAL, 3)
        ,new ScalarDescriptor("Pager_number", synType.ST_DECIMAL, 7)
        ,new ScalarDescriptor("Email1", synType.ST_ALPHA, 80)
        ,new ScalarDescriptor("Email2", synType.ST_ALPHA, 80)
        ,new ScalarDescriptor("Date_opened", synType.ST_DECIMAL, 8)
        ,new ScalarDescriptor("Date_hold", synType.ST_DECIMAL, 8)
        ,new ScalarDescriptor("Date_closed", synType.ST_DECIMAL, 8)
        ,new ScalarDescriptor("Status", synType.ST_DECIMAL, 1)
        ,new ImpDecDescriptor("Limit", 10,2)
        ,new ImpDecDescriptor("Balance", 10,2)
        ,new ScalarDescriptor("Spare", synType.ST_ALPHA, 65)
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
    st.setFieldValue(5, new synAlpha(""));
    st.setFieldValue(6, new synDec(0));
    st.setFieldValue(7, new synDec(0));
    st.setFieldValue(8, new synDec(0));
    st.setFieldValue(9, new synDec(0));
    st.setFieldValue(10, new synDec(0));
    st.setFieldValue(11, new synDec(0));
    st.setFieldValue(12, new synDec(0));
    st.setFieldValue(13, new synDec(0));
    st.setFieldValue(14, new synDec(0));
    st.setFieldValue(15, new synAlpha(""));
    st.setFieldValue(16, new synAlpha(""));
    st.setFieldValue(17, new synDec(0));
    st.setFieldValue(18, new synDec(0));
    st.setFieldValue(19, new synDec(0));
    st.setFieldValue(20, new synDec(0));
    st.setFieldValue(21, new synImpDec(0));
    st.setFieldValue(22, new synImpDec(0));
    st.setFieldValue(23, new synAlpha(""));
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
    synAlpha temp5 = (synAlpha)synstr.getFieldValue(5);
    m_synStruct.setFieldValue(5,temp5);
    synDec temp6 = (synDec)synstr.getFieldValue(6);
    m_synStruct.setFieldValue(6,temp6);
    synDec temp7 = (synDec)synstr.getFieldValue(7);
    m_synStruct.setFieldValue(7,temp7);
    synDec temp8 = (synDec)synstr.getFieldValue(8);
    m_synStruct.setFieldValue(8,temp8);
    synDec temp9 = (synDec)synstr.getFieldValue(9);
    m_synStruct.setFieldValue(9,temp9);
    synDec temp10 = (synDec)synstr.getFieldValue(10);
    m_synStruct.setFieldValue(10,temp10);
    synDec temp11 = (synDec)synstr.getFieldValue(11);
    m_synStruct.setFieldValue(11,temp11);
    synDec temp12 = (synDec)synstr.getFieldValue(12);
    m_synStruct.setFieldValue(12,temp12);
    synDec temp13 = (synDec)synstr.getFieldValue(13);
    m_synStruct.setFieldValue(13,temp13);
    synDec temp14 = (synDec)synstr.getFieldValue(14);
    m_synStruct.setFieldValue(14,temp14);
    synAlpha temp15 = (synAlpha)synstr.getFieldValue(15);
    m_synStruct.setFieldValue(15,temp15);
    synAlpha temp16 = (synAlpha)synstr.getFieldValue(16);
    m_synStruct.setFieldValue(16,temp16);
    synDec temp17 = (synDec)synstr.getFieldValue(17);
    m_synStruct.setFieldValue(17,temp17);
    synDec temp18 = (synDec)synstr.getFieldValue(18);
    m_synStruct.setFieldValue(18,temp18);
    synDec temp19 = (synDec)synstr.getFieldValue(19);
    m_synStruct.setFieldValue(19,temp19);
    synDec temp20 = (synDec)synstr.getFieldValue(20);
    m_synStruct.setFieldValue(20,temp20);
    synImpDec temp21 = (synImpDec)synstr.getFieldValue(21);
    m_synStruct.setFieldValue(21,temp21);
    synImpDec temp22 = (synImpDec)synstr.getFieldValue(22);
    m_synStruct.setFieldValue(22,temp22);
    synAlpha temp23 = (synAlpha)synstr.getFieldValue(23);
    m_synStruct.setFieldValue(23,temp23);
  }

}
