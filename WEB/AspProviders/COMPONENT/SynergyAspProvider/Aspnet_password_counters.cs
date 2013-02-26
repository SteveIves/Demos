// Generated on 28-Apr-2012 6:25:12 by gencs v1.0.11.0
// 
// The contents of this file are auto-generated. Only add modifications to the end of this file.
// Any modifications will be lost when the file is re-generated.
// 
using System;
using System.Text;
using Synergex.xfnlnet;
namespace SynPSG.ASP
{
/// <summary>
/// Structural Interface Class SynergyAspProvider
/// </summary>
	[XFAttr(size=36)]
	[Serializable]
	public class Aspnet_password_counters : IStructWire
	{
		/// <summary>
		/// Attributes for fields
		/// </summary>
		public readonly static XFAttr[] fieldAttributes = new XFAttr[6];
		static Aspnet_password_counters()
		{
			fieldAttributes[0]= new XFAttr(XFAttr.xftype.DECIMAL,4);
			fieldAttributes[1]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[2]= new XFAttr(XFAttr.xftype.TIME,XFAttr.xftype.DATETIME,XFAttr.xfformat.HHMMSS,6);
			fieldAttributes[3]= new XFAttr(XFAttr.xftype.DECIMAL,4);
			fieldAttributes[4]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[5]= new XFAttr(XFAttr.xftype.TIME,XFAttr.xftype.DATETIME,XFAttr.xfformat.HHMMSS,6);
		}
		private int f_Password_fail_count=0;
		 
		/// <summary>
		/// *** Field To Do ***
		/// </summary>
		public int Password_fail_count
		{
			get{ return f_Password_fail_count;}
			set { 
			    if(f_Password_fail_count != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Password_fail_count = value;
			} 
		}
		 
		private DateTime f_Password_window_date=new DateTime();
		 
		/// <summary>
		/// Window date
		/// </summary>
		public DateTime Password_window_date
		{
			get{ return f_Password_window_date;}
			set { 
			    if(f_Password_window_date != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Password_window_date = value;
			} 
		}
		 
		private DateTime f_Password_window_time=new DateTime();
		 
		/// <summary>
		/// Password window time
		/// </summary>
		public DateTime Password_window_time
		{
			get{ return f_Password_window_time;}
			set { 
			    if(f_Password_window_time != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Password_window_time = value;
			} 
		}
		 
		private int f_Answer_fail_count=0;
		 
		/// <summary>
		/// Answer fail count
		/// </summary>
		public int Answer_fail_count
		{
			get{ return f_Answer_fail_count;}
			set { 
			    if(f_Answer_fail_count != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Answer_fail_count = value;
			} 
		}
		 
		private DateTime f_Answer_window_date=new DateTime();
		 
		/// <summary>
		/// *** Field To Do ***
		/// </summary>
		public DateTime Answer_window_date
		{
			get{ return f_Answer_window_date;}
			set { 
			    if(f_Answer_window_date != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Answer_window_date = value;
			} 
		}
		 
		private DateTime f_Answer_window_time=new DateTime();
		 
		/// <summary>
		/// *** Field To Do ***
		/// </summary>
		public DateTime Answer_window_time
		{
			get{ return f_Answer_window_time;}
			set { 
			    if(f_Answer_window_time != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Answer_window_time = value;
			} 
		}
		 
		/// <summary>
		/// structure clone
		/// </summary>
		public Aspnet_password_counters Clone()
		{
			Aspnet_password_counters tmp = new Aspnet_password_counters();
			tmp.f_Password_fail_count = this.f_Password_fail_count;
			tmp.f_Password_window_date = this.f_Password_window_date;
			tmp.f_Password_window_time = this.f_Password_window_time;
			tmp.f_Answer_fail_count = this.f_Answer_fail_count;
			tmp.f_Answer_window_date = this.f_Answer_window_date;
			tmp.f_Answer_window_time = this.f_Answer_window_time;
			return tmp;
		}
		/// <summary>
		/// structure equals
		/// </summary>
		public bool Equals(Aspnet_password_counters str)
		{
			bool eq = true;
			if (this.Password_fail_count != str.Password_fail_count)
			{
				eq = false;
				return eq;
			}
			if (this.Password_window_date != str.Password_window_date)
			{
				eq = false;
				return eq;
			}
			if (this.Password_window_time != str.Password_window_time)
			{
				eq = false;
				return eq;
			}
			if (this.Answer_fail_count != str.Answer_fail_count)
			{
				eq = false;
				return eq;
			}
			if (this.Answer_window_date != str.Answer_window_date)
			{
				eq = false;
				return eq;
			}
			if (this.Answer_window_time != str.Answer_window_time)
			{
				eq = false;
				return eq;
			}
			return eq;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public Aspnet_password_counters() {
		}
		/// <summary>
		/// serialize structure
		/// </summary>
		public string structToWire()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("ST[6]36%");
			StringBuilder body = new StringBuilder();
			body.Append(XFProtocol.fieldToWire(f_Password_fail_count,fieldAttributes[0]));
			body.Append(XFProtocol.fieldToWire(f_Password_window_date,fieldAttributes[1]));
			body.Append(XFProtocol.fieldToWire(f_Password_window_time,fieldAttributes[2]));
			body.Append(XFProtocol.fieldToWire(f_Answer_fail_count,fieldAttributes[3]));
			body.Append(XFProtocol.fieldToWire(f_Answer_window_date,fieldAttributes[4]));
			body.Append(XFProtocol.fieldToWire(f_Answer_window_time,fieldAttributes[5]));
			body.Append("^");
			sb.Append(body.Length+"#"+body.ToString()+";");
			return sb.ToString();
		}
 
		/// <summary>
		/// deserialize structure
		/// </summary>
		public void wireToStruct(SynMessage reply)
		{
			f_Password_fail_count = XFProtocol.wireToint(reply);
			f_Password_window_date = XFProtocol.wireToDateTime(reply,fieldAttributes[1]);
			f_Password_window_time = XFProtocol.wireToDateTime(reply,fieldAttributes[2]);
			f_Answer_fail_count = XFProtocol.wireToint(reply);
			f_Answer_window_date = XFProtocol.wireToDateTime(reply,fieldAttributes[4]);
			f_Answer_window_time = XFProtocol.wireToDateTime(reply,fieldAttributes[5]);
		}
 
		private bool m_changed = false;
 
		/// <summary>
		/// Structure Changed 
		/// </summary>
		/// <returns>true if structure has been changed</returns>
		public bool Changed
		{
		    get{ return m_changed;}
		}
 
	}
}
