// Thu Nov 03 11:34:54 PDT 2011

package SynergyApp;

import Synergex.synTypes.*;

public class Product_group

{
  private synStruct m_synStruct = null;
 
  /** Default constructor 
  */ 
  public Product_group() throws Exception 
  {
    m_synStruct = this.toStruct(); 
  }

  /** getName - Gets Product group
      @return String
  */ 
  public String getName()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(1);
    String ret = (String)temp.value();
    return ret;
  }

  /** setName - Sets Product group
      @param val String in 
  */ 
  public void setName(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(1,temp);
  }

  /** getDescription - Gets Product group description
      @return String
  */ 
  public String getDescription()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(2);
    String ret = (String)temp.value();
    return ret;
  }

  /** setDescription - Sets Product group description
      @param val String in 
  */ 
  public void setDescription(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(2,temp);
  }

  public static StructDescriptor getStructDescriptor()
  {
    try {
      return new StructDescriptor ( "Product_group", 50,
        new FieldDescriptor[] {
        new ScalarDescriptor("Name", synType.ST_ALPHA, 10)
        ,new ScalarDescriptor("Description", synType.ST_ALPHA, 40)
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
  }

}
