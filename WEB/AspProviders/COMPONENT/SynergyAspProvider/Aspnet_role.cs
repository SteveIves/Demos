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
	[XFAttr(size=64)]
	[Serializable]
	public class Aspnet_role : IStructWire
	{
		/// <summary>
		/// Attributes for fields
		/// </summary>
		public readonly static XFAttr[] fieldAttributes = new XFAttr[2];
		static Aspnet_role()
		{
			fieldAttributes[0]= new XFAttr(XFAttr.xftype.ALPHA,32);
			fieldAttributes[1]= new XFAttr(XFAttr.xftype.ALPHA,32);
		}
		private string f_Application="";
		 
		/// <summary>
		/// Application name
		/// </summary>
		public string Application
		{
			get{ return f_Application;}
			set { 
			      if(f_Application == null) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Application.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Application = value;
			} 
		}
		 
		private string f_Role="";
		 
		/// <summary>
		/// Role name
		/// </summary>
		public string Role
		{
			get{ return f_Role;}
			set { 
			      if(f_Role == null) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Role.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Role = value;
			} 
		}
		 
		/// <summary>
		/// structure clone
		/// </summary>
		public Aspnet_role Clone()
		{
			Aspnet_role tmp = new Aspnet_role();
			tmp.f_Application = this.f_Application;
			tmp.f_Role = this.f_Role;
			return tmp;
		}
		/// <summary>
		/// structure equals
		/// </summary>
		public bool Equals(Aspnet_role str)
		{
			bool eq = true;
			if (!this.Application.Equals(str.Application))
			{
				eq = false;
				return eq;
			}
			if (!this.Role.Equals(str.Role))
			{
				eq = false;
				return eq;
			}
			return eq;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public Aspnet_role() {
		}
		/// <summary>
		/// serialize structure
		/// </summary>
		public string structToWire()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("ST[2]64%");
			StringBuilder body = new StringBuilder();
			body.Append(XFProtocol.fieldToWire(f_Application,fieldAttributes[0]));
			body.Append(XFProtocol.fieldToWire(f_Role,fieldAttributes[1]));
			body.Append("^");
			sb.Append(body.Length+"#"+body.ToString()+";");
			return sb.ToString();
		}
 
		/// <summary>
		/// deserialize structure
		/// </summary>
		public void wireToStruct(SynMessage reply)
		{
			f_Application = XFProtocol.wireTostring(reply);
			f_Role = XFProtocol.wireTostring(reply);
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
