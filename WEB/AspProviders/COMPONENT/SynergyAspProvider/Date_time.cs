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
	[XFAttr(size=14)]
	[Serializable]
	public class Date_time : IStructWire
	{
		/// <summary>
		/// Attributes for fields
		/// </summary>
		public readonly static XFAttr[] fieldAttributes = new XFAttr[2];
		static Date_time()
		{
			fieldAttributes[0]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[1]= new XFAttr(XFAttr.xftype.TIME,XFAttr.xftype.DATETIME,XFAttr.xfformat.HHMMSS,6);
		}
		private DateTime f_Date_field=new DateTime();
		 
		/// <summary>
		/// Date
		/// </summary>
		public DateTime Date_field
		{
			get{ return f_Date_field;}
			set { 
			    if(f_Date_field != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Date_field = value;
			} 
		}
		 
		private DateTime f_Time_field=new DateTime();
		 
		/// <summary>
		/// Time
		/// </summary>
		public DateTime Time_field
		{
			get{ return f_Time_field;}
			set { 
			    if(f_Time_field != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Time_field = value;
			} 
		}
		 
		/// <summary>
		/// structure clone
		/// </summary>
		public Date_time Clone()
		{
			Date_time tmp = new Date_time();
			tmp.f_Date_field = this.f_Date_field;
			tmp.f_Time_field = this.f_Time_field;
			return tmp;
		}
		/// <summary>
		/// structure equals
		/// </summary>
		public bool Equals(Date_time str)
		{
			bool eq = true;
			if (this.Date_field != str.Date_field)
			{
				eq = false;
				return eq;
			}
			if (this.Time_field != str.Time_field)
			{
				eq = false;
				return eq;
			}
			return eq;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public Date_time() {
		}
		/// <summary>
		/// serialize structure
		/// </summary>
		public string structToWire()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("ST[2]14%");
			StringBuilder body = new StringBuilder();
			body.Append(XFProtocol.fieldToWire(f_Date_field,fieldAttributes[0]));
			body.Append(XFProtocol.fieldToWire(f_Time_field,fieldAttributes[1]));
			body.Append("^");
			sb.Append(body.Length+"#"+body.ToString()+";");
			return sb.ToString();
		}
 
		/// <summary>
		/// deserialize structure
		/// </summary>
		public void wireToStruct(SynMessage reply)
		{
			f_Date_field = XFProtocol.wireToDateTime(reply,fieldAttributes[0]);
			f_Time_field = XFProtocol.wireToDateTime(reply,fieldAttributes[1]);
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
