// Thu Nov 03 11:34:54 PDT 2011

package SynergyApp;

import Synergex.synTypes.*;

public class User

{
  private synStruct m_synStruct = null;
 
  /** Default constructor 
  */ 
  public User() throws Exception 
  {
    m_synStruct = this.toStruct(); 
  }

  /** getUsername - Gets Username
      @return String
  */ 
  public String getUsername()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(1);
    String ret = (String)temp.value();
    return ret;
  }

  /** setUsername - Sets Username
      @param val String in 
  */ 
  public void setUsername(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(1,temp);
  }

  /** getFirst_name - Gets First name
      @return String
  */ 
  public String getFirst_name()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(2);
    String ret = (String)temp.value();
    return ret;
  }

  /** setFirst_name - Sets First name
      @param val String in 
  */ 
  public void setFirst_name(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(2,temp);
  }

  /** getLast_name - Gets Last name
      @return String
  */ 
  public String getLast_name()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(3);
    String ret = (String)temp.value();
    return ret;
  }

  /** setLast_name - Sets Last name
      @param val String in 
  */ 
  public void setLast_name(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(3,temp);
  }

  /** getPassword - Gets Password
      @return String
  */ 
  public String getPassword()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(4);
    String ret = (String)temp.value();
    return ret;
  }

  /** setPassword - Sets Password
      @param val String in 
  */ 
  public void setPassword(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(4,temp);
  }

  /** getUser_customer - Gets Account number
      @return String
  */ 
  public String getUser_customer()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(5);
    String ret = (String)temp.value();
    return ret;
  }

  /** setUser_customer - Sets Account number
      @param val String in 
  */ 
  public void setUser_customer(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(5,temp);
  }

  /** getPhone_area - Gets Area code
      @return short
  */ 
  public short getPhone_area()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(6);
    short ret = (short)temp.value();
    return ret;
  }

  /** setPhone_area - Sets Area code
      @param val short in 
  */ 
  public void setPhone_area(short val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(6,temp);
  }

  /** getPhone_number - Gets Phone number
      @return int
  */ 
  public int getPhone_number()
  {
    synDec temp = (synDec)m_synStruct.getFieldValue(7);
    int ret = (int)temp.value();
    return ret;
  }

  /** setPhone_number - Sets Phone number
      @param val int in 
  */ 
  public void setPhone_number(int val)
  {
    synDec temp = new synDec(val);
    m_synStruct.setFieldValue(7,temp);
  }

  /** getEmail - Gets Email address
      @return String
  */ 
  public String getEmail()
  {
    synAlpha temp = (synAlpha)m_synStruct.getFieldValue(8);
    String ret = (String)temp.value();
    return ret;
  }

  /** setEmail - Sets Email address
      @param val String in 
  */ 
  public void setEmail(String val)
  {
    synAlpha temp = new synAlpha(val);
    m_synStruct.setFieldValue(8,temp);
  }

  public static StructDescriptor getStructDescriptor()
  {
    try {
      return new StructDescriptor ( "User", 258,
        new FieldDescriptor[] {
        new ScalarDescriptor("Username", synType.ST_ALPHA, 40)
        ,new ScalarDescriptor("First_name", synType.ST_ALPHA, 40)
        ,new ScalarDescriptor("Last_name", synType.ST_ALPHA, 40)
        ,new ScalarDescriptor("Password", synType.ST_ALPHA, 40)
        ,new ScalarDescriptor("User_customer", synType.ST_ALPHA, 8)
        ,new ScalarDescriptor("Phone_area", synType.ST_DECIMAL, 3)
        ,new ScalarDescriptor("Phone_number", synType.ST_DECIMAL, 7)
        ,new ScalarDescriptor("Email", synType.ST_ALPHA, 80)
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
    st.setFieldValue(8, new synAlpha(""));
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
    synAlpha temp8 = (synAlpha)synstr.getFieldValue(8);
    m_synStruct.setFieldValue(8,temp8);
  }

}
