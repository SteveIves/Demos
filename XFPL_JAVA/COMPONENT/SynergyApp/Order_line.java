// Thu Nov 03 11:34:54 PDT 2011

package SynergyApp;

import Synergex.synTypes.*;

public class Order_line

{
  private synStruct m_synStruct = null;
 
  /** Default constructor 
  */ 
  public Order_line() throws Exception 
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

  /** getLine_number - Gets Line number
      @return short
  */ 
  public short getLine_number()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(2);
    short ret = (short)temp.value();
    return ret;
  }

  /** setLine_number - Sets Line number
      @param val short in 
  */ 
  public void setLine_number(short val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(2,temp);
  }

  /** getSku - Gets SKU
      @return String
  */ 
  public String getSku()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(3);
    String ret = (String)temp.value();
    return ret;
  }

  /** setSku - Sets SKU
      @param val String in 
  */ 
  public void setSku(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(3,temp);
  }

  /** getDescription - Gets Product name
      @return String
  */ 
  public String getDescription()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(4);
    String ret = (String)temp.value();
    return ret;
  }

  /** setDescription - Sets Product name
      @param val String in 
  */ 
  public void setDescription(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(4,temp);
  }

  /** getQty_ordered - Gets Quantity Ordered
      @return int
  */ 
  public int getQty_ordered()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(5);
    int ret = (int)temp.value();
    return ret;
  }

  /** setQty_ordered - Sets Quantity Ordered
      @param val int in 
  */ 
  public void setQty_ordered(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(5,temp);
  }

  /** getQty_allocated - Gets Quantity
      @return int
  */ 
  public int getQty_allocated()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(6);
    int ret = (int)temp.value();
    return ret;
  }

  /** setQty_allocated - Sets Quantity
      @param val int in 
  */ 
  public void setQty_allocated(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(6,temp);
  }

  /** getPrice - Gets Price per item
      @return double
  */ 
  public double getPrice()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(7);
    double ret = (double)temp.value();
    return ret;
  }

  /** setPrice - Sets Price per item
      @param val double in 
  */ 
  public void setPrice(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(7,temp);
  }

  /** getLine_value - Gets Line Value
      @return double
  */ 
  public double getLine_value()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(8);
    double ret = (double)temp.value();
    return ret;
  }

  /** setLine_value - Sets Line Value
      @param val double in 
  */ 
  public void setLine_value(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(8,temp);
  }

  /** getTax - Gets Tax
      @return double
  */ 
  public double getTax()
  {
    synImpDec temp = (synImpDec)m_synStruct.getFieldValue(9);
    double ret = (double)temp.value();
    return ret;
  }

  /** setTax - Sets Tax
      @param val double in 
  */ 
  public void setTax(double val)
  {
    synImpDec temp = new synImpDec(val);
    m_synStruct.setFieldValue(9,temp);
  }

  /** getNoname_001 - Gets Spare space
      @return String
  */ 
  public String getNoname_001()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(10);
    String ret = (String)temp.value();
    return ret;
  }

  /** setNoname_001 - Sets Spare space
      @param val String in 
  */ 
  public void setNoname_001(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(10,temp);
  }

  public static StructDescriptor getStructDescriptor()
  {
    try {
      return new StructDescriptor ( "Order_line", 140,
        new FieldDescriptor[] {
        new ScalarDescriptor("Order", synType.ST_DECIMAL, 8)
        ,new ScalarDescriptor("Line_number", synType.ST_DECIMAL, 3)
        ,new ScalarDescriptor("Sku", synType.ST_ALPHA, 10)
        ,new ScalarDescriptor("Description", synType.ST_ALPHA, 80)
        ,new ScalarDescriptor("Qty_ordered", synType.ST_DECIMAL, 6)
        ,new ScalarDescriptor("Qty_allocated", synType.ST_DECIMAL, 6)
        ,new ImpDecDescriptor("Price", 6,2)
        ,new ImpDecDescriptor("Line_value", 6,2)
        ,new ImpDecDescriptor("Tax", 6,2)
        ,new ScalarDescriptor("Noname_001", synType.ST_ALPHA, 9)
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
    st.setFieldValue(4, new synAlpha(""));
    st.setFieldValue(5, new synDec(0));
    st.setFieldValue(6, new synDec(0));
    st.setFieldValue(7, new synImpDec(0));
    st.setFieldValue(8, new synImpDec(0));
    st.setFieldValue(9, new synImpDec(0));
    st.setFieldValue(10, new synAlpha(""));
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
    synAlpha temp4 = (synAlpha)synstr.getFieldValue(4);
    m_synStruct.setFieldValue(4,temp4);
    synDec temp5 = (synDec)synstr.getFieldValue(5);
    m_synStruct.setFieldValue(5,temp5);
    synDec temp6 = (synDec)synstr.getFieldValue(6);
    m_synStruct.setFieldValue(6,temp6);
    synImpDec temp7 = (synImpDec)synstr.getFieldValue(7);
    m_synStruct.setFieldValue(7,temp7);
    synImpDec temp8 = (synImpDec)synstr.getFieldValue(8);
    m_synStruct.setFieldValue(8,temp8);
    synImpDec temp9 = (synImpDec)synstr.getFieldValue(9);
    m_synStruct.setFieldValue(9,temp9);
    synAlpha temp10 = (synAlpha)synstr.getFieldValue(10);
    m_synStruct.setFieldValue(10,temp10);
  }

}
