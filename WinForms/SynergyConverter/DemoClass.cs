using System;
using System.Collections.Generic;
using System.Text;

namespace SynergyConverter
{
    class DemoClass
    {
        private int mProp1;
        private string mProp2;

        public DemoClass()
        {
            mProp1 = 5;
            mProp2 = "Hello World";
        }

        public int Property1
        {
            get
            {
                return mProp1;
            }
            set
            {
                mProp1 = value;
            }
        }

        public string Property2
        {
            get
            {
                return mProp2;
            }
            set
            {
                mProp2 = value;
            }
        }

        public bool ClearTheString()
        {
            mProp2 = "";
            return true;
        }
    }
}
