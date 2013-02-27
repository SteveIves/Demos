// Thu Nov 03 11:16:19 PDT 2011

package SynergyApp;

import org.omg.CORBA.*;

public enum My_enum
          {
            Zero (0),
            One (1),
            Three (3);

            private final int enumValue;
            My_enum(int vlu)
            {
             	enumValue = vlu;
            }

            /** 
              Gets the enumeration from its int value.
                @param vlu int in 
            */ 
            public static My_enum getEnumeration(int vlu)
            {
             	My_enum rtnEnum;
                switch(vlu)
            	{
            	  case 0 :
            	           rtnEnum = My_enum.Zero;
            	           break;
            	  case 1 :
            	           rtnEnum = My_enum.One;
            	           break;
            	  case 3 :
            	           rtnEnum = My_enum.Three;
            	           break;
            	  default :
            	           rtnEnum = null;
            	           break;
            	}
             	return rtnEnum;
            }

            /** 
              Gets the enumeration from its IntHolder value.
                @param vlu IntHolder in 
            */ 
            public static My_enum getEnumeration(IntHolder vlu)
            {
             	My_enum rtnEnum;
                int intvlu = vlu.value;
                switch(intvlu)
            	{
            	  case 0 :
            	           rtnEnum = My_enum.Zero;
            	           break;
            	  case 1 :
            	           rtnEnum = My_enum.One;
            	           break;
            	  case 3 :
            	           rtnEnum = My_enum.Three;
            	           break;
            	  default :
            	           rtnEnum = null;
            	           break;
            	}
             	return rtnEnum;
            }

            /** 
              Gets the enumerations int value. 
            */ 
            public int getIntValue()
            {
             	return this.enumValue;
            }

            /** 
              Gets the enumerations IntHolder value. 
            */ 
            public IntHolder getIntHolderValue()
            {
             	IntHolder hldr = new IntHolder(this.enumValue);
             	return hldr;
            }


          }
