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
	[XFAttr(size=593)]
	[Serializable]
	public class Aspnet_user : IStructWire
	{
		/// <summary>
		/// Attributes for fields
		/// </summary>
		public readonly static XFAttr[] fieldAttributes = new XFAttr[27];
		static Aspnet_user()
		{
			fieldAttributes[0]= new XFAttr(XFAttr.xftype.ALPHA,36);
			fieldAttributes[1]= new XFAttr(XFAttr.xftype.ALPHA,32);
			fieldAttributes[2]= new XFAttr(XFAttr.xftype.ALPHA,32);
			fieldAttributes[3]= new XFAttr(XFAttr.xftype.ALPHA,64);
			fieldAttributes[4]= new XFAttr(XFAttr.xftype.ALPHA,128);
			fieldAttributes[5]= new XFAttr(XFAttr.xftype.ALPHA,64);
			fieldAttributes[6]= new XFAttr(XFAttr.xftype.ALPHA,64);
			fieldAttributes[7]= new XFAttr(XFAttr.xftype.ALPHA,64);
			fieldAttributes[8]= new XFAttr(XFAttr.xftype.DECIMAL,1);
			fieldAttributes[9]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[10]= new XFAttr(XFAttr.xftype.TIME,XFAttr.xftype.DATETIME,XFAttr.xfformat.HHMMSS,6);
			fieldAttributes[11]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[12]= new XFAttr(XFAttr.xftype.TIME,XFAttr.xftype.DATETIME,XFAttr.xfformat.HHMMSS,6);
			fieldAttributes[13]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[14]= new XFAttr(XFAttr.xftype.TIME,XFAttr.xftype.DATETIME,XFAttr.xfformat.HHMMSS,6);
			fieldAttributes[15]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[16]= new XFAttr(XFAttr.xftype.TIME,XFAttr.xftype.DATETIME,XFAttr.xfformat.HHMMSS,6);
			fieldAttributes[17]= new XFAttr(XFAttr.xftype.DECIMAL,1);
			fieldAttributes[18]= new XFAttr(XFAttr.xftype.DECIMAL,1);
			fieldAttributes[19]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[20]= new XFAttr(XFAttr.xftype.TIME,XFAttr.xftype.DATETIME,XFAttr.xfformat.HHMMSS,6);
			fieldAttributes[21]= new XFAttr(XFAttr.xftype.DECIMAL,4);
			fieldAttributes[22]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[23]= new XFAttr(XFAttr.xftype.TIME,XFAttr.xftype.DATETIME,XFAttr.xfformat.HHMMSS,6);
			fieldAttributes[24]= new XFAttr(XFAttr.xftype.DECIMAL,4);
			fieldAttributes[25]= new XFAttr(XFAttr.xftype.DATE,XFAttr.xftype.DATETIME,XFAttr.xfformat.YYYYMMDD,8);
			fieldAttributes[26]= new XFAttr(XFAttr.xftype.TIME,XFAttr.xftype.DATETIME,XFAttr.xfformat.HHMMSS,6);
		}
		private string f_Pkid="";
		 
		/// <summary>
		/// Primary key identifier
		/// </summary>
		public string Pkid
		{
			get{ return f_Pkid;}
			set { 
			      if(f_Pkid == null) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Pkid.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Pkid = value;
			} 
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
		 
		private string f_Username="";
		 
		/// <summary>
		/// Username
		/// </summary>
		public string Username
		{
			get{ return f_Username;}
			set { 
			      if(f_Username == null) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Username.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Username = value;
			} 
		}
		 
		private string f_Email="";
		 
		/// <summary>
		/// Email address
		/// </summary>
		public string Email
		{
			get{ return f_Email;}
			set { 
			      if(f_Email == null) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Email.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Email = value;
			} 
		}
		 
		private string f_Comment="";
		 
		/// <summary>
		/// Comment
		/// </summary>
		public string Comment
		{
			get{ return f_Comment;}
			set { 
			      if(f_Comment == null) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Comment.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Comment = value;
			} 
		}
		 
		private string f_Password="";
		 
		/// <summary>
		/// Password
		/// </summary>
		public string Password
		{
			get{ return f_Password;}
			set { 
			      if(f_Password == null) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Password.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Password = value;
			} 
		}
		 
		private string f_Password_question="";
		 
		/// <summary>
		/// Password question
		/// </summary>
		public string Password_question
		{
			get{ return f_Password_question;}
			set { 
			      if(f_Password_question == null) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Password_question.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Password_question = value;
			} 
		}
		 
		private string f_Password_answer="";
		 
		/// <summary>
		/// Password answer
		/// </summary>
		public string Password_answer
		{
			get{ return f_Password_answer;}
			set { 
			      if(f_Password_answer == null) 
			      { 
			         m_changed = true; 
			      } 
			      else
			      { 
			        if(!f_Password_answer.Equals(value)) 
			        { 
			           m_changed = true; 
			        } 
			      } 
			      f_Password_answer = value;
			} 
		}
		 
		private int f_Is_approved=0;
		 
		/// <summary>
		/// Is the user account approved
		/// </summary>
		public int Is_approved
		{
			get{ return f_Is_approved;}
			set { 
			    if(f_Is_approved != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Is_approved = value;
			} 
		}
		 
		private DateTime f_Created_date=new DateTime();
		 
		/// <summary>
		/// Date account created
		/// </summary>
		public DateTime Created_date
		{
			get{ return f_Created_date;}
			set { 
			    if(f_Created_date != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Created_date = value;
			} 
		}
		 
		private DateTime f_Created_time=new DateTime();
		 
		/// <summary>
		/// time account created
		/// </summary>
		public DateTime Created_time
		{
			get{ return f_Created_time;}
			set { 
			    if(f_Created_time != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Created_time = value;
			} 
		}
		 
		private DateTime f_Last_activity_date=new DateTime();
		 
		/// <summary>
		/// *** Field To Do ***
		/// </summary>
		public DateTime Last_activity_date
		{
			get{ return f_Last_activity_date;}
			set { 
			    if(f_Last_activity_date != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Last_activity_date = value;
			} 
		}
		 
		private DateTime f_Last_activity_time=new DateTime();
		 
		/// <summary>
		/// Last activity time
		/// </summary>
		public DateTime Last_activity_time
		{
			get{ return f_Last_activity_time;}
			set { 
			    if(f_Last_activity_time != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Last_activity_time = value;
			} 
		}
		 
		private DateTime f_Last_login_date=new DateTime();
		 
		/// <summary>
		/// Last login date
		/// </summary>
		public DateTime Last_login_date
		{
			get{ return f_Last_login_date;}
			set { 
			    if(f_Last_login_date != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Last_login_date = value;
			} 
		}
		 
		private DateTime f_Last_login_time=new DateTime();
		 
		/// <summary>
		/// Last login time
		/// </summary>
		public DateTime Last_login_time
		{
			get{ return f_Last_login_time;}
			set { 
			    if(f_Last_login_time != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Last_login_time = value;
			} 
		}
		 
		private DateTime f_Last_password_change_date=new DateTime();
		 
		/// <summary>
		/// Last password change date
		/// </summary>
		public DateTime Last_password_change_date
		{
			get{ return f_Last_password_change_date;}
			set { 
			    if(f_Last_password_change_date != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Last_password_change_date = value;
			} 
		}
		 
		private DateTime f_Last_password_change_time=new DateTime();
		 
		/// <summary>
		/// Last password change time
		/// </summary>
		public DateTime Last_password_change_time
		{
			get{ return f_Last_password_change_time;}
			set { 
			    if(f_Last_password_change_time != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Last_password_change_time = value;
			} 
		}
		 
		private int f_Is_online=0;
		 
		/// <summary>
		/// UIs the user on line
		/// </summary>
		public int Is_online
		{
			get{ return f_Is_online;}
			set { 
			    if(f_Is_online != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Is_online = value;
			} 
		}
		 
		private int f_Is_locked_out=0;
		 
		/// <summary>
		/// Is the user locked out
		/// </summary>
		public int Is_locked_out
		{
			get{ return f_Is_locked_out;}
			set { 
			    if(f_Is_locked_out != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Is_locked_out = value;
			} 
		}
		 
		private DateTime f_Last_locked_out_date=new DateTime();
		 
		/// <summary>
		/// Last locked out date
		/// </summary>
		public DateTime Last_locked_out_date
		{
			get{ return f_Last_locked_out_date;}
			set { 
			    if(f_Last_locked_out_date != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Last_locked_out_date = value;
			} 
		}
		 
		private DateTime f_Last_locked_out_time=new DateTime();
		 
		/// <summary>
		/// Last locked out time
		/// </summary>
		public DateTime Last_locked_out_time
		{
			get{ return f_Last_locked_out_time;}
			set { 
			    if(f_Last_locked_out_time != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Last_locked_out_time = value;
			} 
		}
		 
		private int f_Failed_password_count=0;
		 
		/// <summary>
		/// Failed password attempt count
		/// </summary>
		public int Failed_password_count
		{
			get{ return f_Failed_password_count;}
			set { 
			    if(f_Failed_password_count != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Failed_password_count = value;
			} 
		}
		 
		private DateTime f_Failed_password_window_date=new DateTime();
		 
		/// <summary>
		/// *** Field To Do ***
		/// </summary>
		public DateTime Failed_password_window_date
		{
			get{ return f_Failed_password_window_date;}
			set { 
			    if(f_Failed_password_window_date != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Failed_password_window_date = value;
			} 
		}
		 
		private DateTime f_Failed_password_window_time=new DateTime();
		 
		/// <summary>
		/// *** Field To Do ***
		/// </summary>
		public DateTime Failed_password_window_time
		{
			get{ return f_Failed_password_window_time;}
			set { 
			    if(f_Failed_password_window_time != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Failed_password_window_time = value;
			} 
		}
		 
		private int f_Failed_answer_count=0;
		 
		/// <summary>
		/// *** Field To Do ***
		/// </summary>
		public int Failed_answer_count
		{
			get{ return f_Failed_answer_count;}
			set { 
			    if(f_Failed_answer_count != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Failed_answer_count = value;
			} 
		}
		 
		private DateTime f_Failed_answer_window_date=new DateTime();
		 
		/// <summary>
		/// *** Field To Do ***
		/// </summary>
		public DateTime Failed_answer_window_date
		{
			get{ return f_Failed_answer_window_date;}
			set { 
			    if(f_Failed_answer_window_date != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Failed_answer_window_date = value;
			} 
		}
		 
		private DateTime f_Failed_answer_window_time=new DateTime();
		 
		/// <summary>
		/// *** Field To Do ***
		/// </summary>
		public DateTime Failed_answer_window_time
		{
			get{ return f_Failed_answer_window_time;}
			set { 
			    if(f_Failed_answer_window_time != value) 
			    { 
			       m_changed = true; 
			    } 
			    f_Failed_answer_window_time = value;
			} 
		}
		 
		/// <summary>
		/// structure clone
		/// </summary>
		public Aspnet_user Clone()
		{
			Aspnet_user tmp = new Aspnet_user();
			tmp.f_Pkid = this.f_Pkid;
			tmp.f_Application = this.f_Application;
			tmp.f_Username = this.f_Username;
			tmp.f_Email = this.f_Email;
			tmp.f_Comment = this.f_Comment;
			tmp.f_Password = this.f_Password;
			tmp.f_Password_question = this.f_Password_question;
			tmp.f_Password_answer = this.f_Password_answer;
			tmp.f_Is_approved = this.f_Is_approved;
			tmp.f_Created_date = this.f_Created_date;
			tmp.f_Created_time = this.f_Created_time;
			tmp.f_Last_activity_date = this.f_Last_activity_date;
			tmp.f_Last_activity_time = this.f_Last_activity_time;
			tmp.f_Last_login_date = this.f_Last_login_date;
			tmp.f_Last_login_time = this.f_Last_login_time;
			tmp.f_Last_password_change_date = this.f_Last_password_change_date;
			tmp.f_Last_password_change_time = this.f_Last_password_change_time;
			tmp.f_Is_online = this.f_Is_online;
			tmp.f_Is_locked_out = this.f_Is_locked_out;
			tmp.f_Last_locked_out_date = this.f_Last_locked_out_date;
			tmp.f_Last_locked_out_time = this.f_Last_locked_out_time;
			tmp.f_Failed_password_count = this.f_Failed_password_count;
			tmp.f_Failed_password_window_date = this.f_Failed_password_window_date;
			tmp.f_Failed_password_window_time = this.f_Failed_password_window_time;
			tmp.f_Failed_answer_count = this.f_Failed_answer_count;
			tmp.f_Failed_answer_window_date = this.f_Failed_answer_window_date;
			tmp.f_Failed_answer_window_time = this.f_Failed_answer_window_time;
			return tmp;
		}
		/// <summary>
		/// structure equals
		/// </summary>
		public bool Equals(Aspnet_user str)
		{
			bool eq = true;
			if (!this.Pkid.Equals(str.Pkid))
			{
				eq = false;
				return eq;
			}
			if (!this.Application.Equals(str.Application))
			{
				eq = false;
				return eq;
			}
			if (!this.Username.Equals(str.Username))
			{
				eq = false;
				return eq;
			}
			if (!this.Email.Equals(str.Email))
			{
				eq = false;
				return eq;
			}
			if (!this.Comment.Equals(str.Comment))
			{
				eq = false;
				return eq;
			}
			if (!this.Password.Equals(str.Password))
			{
				eq = false;
				return eq;
			}
			if (!this.Password_question.Equals(str.Password_question))
			{
				eq = false;
				return eq;
			}
			if (!this.Password_answer.Equals(str.Password_answer))
			{
				eq = false;
				return eq;
			}
			if (this.Is_approved != str.Is_approved)
			{
				eq = false;
				return eq;
			}
			if (this.Created_date != str.Created_date)
			{
				eq = false;
				return eq;
			}
			if (this.Created_time != str.Created_time)
			{
				eq = false;
				return eq;
			}
			if (this.Last_activity_date != str.Last_activity_date)
			{
				eq = false;
				return eq;
			}
			if (this.Last_activity_time != str.Last_activity_time)
			{
				eq = false;
				return eq;
			}
			if (this.Last_login_date != str.Last_login_date)
			{
				eq = false;
				return eq;
			}
			if (this.Last_login_time != str.Last_login_time)
			{
				eq = false;
				return eq;
			}
			if (this.Last_password_change_date != str.Last_password_change_date)
			{
				eq = false;
				return eq;
			}
			if (this.Last_password_change_time != str.Last_password_change_time)
			{
				eq = false;
				return eq;
			}
			if (this.Is_online != str.Is_online)
			{
				eq = false;
				return eq;
			}
			if (this.Is_locked_out != str.Is_locked_out)
			{
				eq = false;
				return eq;
			}
			if (this.Last_locked_out_date != str.Last_locked_out_date)
			{
				eq = false;
				return eq;
			}
			if (this.Last_locked_out_time != str.Last_locked_out_time)
			{
				eq = false;
				return eq;
			}
			if (this.Failed_password_count != str.Failed_password_count)
			{
				eq = false;
				return eq;
			}
			if (this.Failed_password_window_date != str.Failed_password_window_date)
			{
				eq = false;
				return eq;
			}
			if (this.Failed_password_window_time != str.Failed_password_window_time)
			{
				eq = false;
				return eq;
			}
			if (this.Failed_answer_count != str.Failed_answer_count)
			{
				eq = false;
				return eq;
			}
			if (this.Failed_answer_window_date != str.Failed_answer_window_date)
			{
				eq = false;
				return eq;
			}
			if (this.Failed_answer_window_time != str.Failed_answer_window_time)
			{
				eq = false;
				return eq;
			}
			return eq;
		}
		/// <summary>
		/// Constructor
		/// </summary>
		public Aspnet_user() {
		}
		/// <summary>
		/// serialize structure
		/// </summary>
		public string structToWire()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("ST[27]593%");
			StringBuilder body = new StringBuilder();
			body.Append(XFProtocol.fieldToWire(f_Pkid,fieldAttributes[0]));
			body.Append(XFProtocol.fieldToWire(f_Application,fieldAttributes[1]));
			body.Append(XFProtocol.fieldToWire(f_Username,fieldAttributes[2]));
			body.Append(XFProtocol.fieldToWire(f_Email,fieldAttributes[3]));
			body.Append(XFProtocol.fieldToWire(f_Comment,fieldAttributes[4]));
			body.Append(XFProtocol.fieldToWire(f_Password,fieldAttributes[5]));
			body.Append(XFProtocol.fieldToWire(f_Password_question,fieldAttributes[6]));
			body.Append(XFProtocol.fieldToWire(f_Password_answer,fieldAttributes[7]));
			body.Append(XFProtocol.fieldToWire(f_Is_approved,fieldAttributes[8]));
			body.Append(XFProtocol.fieldToWire(f_Created_date,fieldAttributes[9]));
			body.Append(XFProtocol.fieldToWire(f_Created_time,fieldAttributes[10]));
			body.Append(XFProtocol.fieldToWire(f_Last_activity_date,fieldAttributes[11]));
			body.Append(XFProtocol.fieldToWire(f_Last_activity_time,fieldAttributes[12]));
			body.Append(XFProtocol.fieldToWire(f_Last_login_date,fieldAttributes[13]));
			body.Append(XFProtocol.fieldToWire(f_Last_login_time,fieldAttributes[14]));
			body.Append(XFProtocol.fieldToWire(f_Last_password_change_date,fieldAttributes[15]));
			body.Append(XFProtocol.fieldToWire(f_Last_password_change_time,fieldAttributes[16]));
			body.Append(XFProtocol.fieldToWire(f_Is_online,fieldAttributes[17]));
			body.Append(XFProtocol.fieldToWire(f_Is_locked_out,fieldAttributes[18]));
			body.Append(XFProtocol.fieldToWire(f_Last_locked_out_date,fieldAttributes[19]));
			body.Append(XFProtocol.fieldToWire(f_Last_locked_out_time,fieldAttributes[20]));
			body.Append(XFProtocol.fieldToWire(f_Failed_password_count,fieldAttributes[21]));
			body.Append(XFProtocol.fieldToWire(f_Failed_password_window_date,fieldAttributes[22]));
			body.Append(XFProtocol.fieldToWire(f_Failed_password_window_time,fieldAttributes[23]));
			body.Append(XFProtocol.fieldToWire(f_Failed_answer_count,fieldAttributes[24]));
			body.Append(XFProtocol.fieldToWire(f_Failed_answer_window_date,fieldAttributes[25]));
			body.Append(XFProtocol.fieldToWire(f_Failed_answer_window_time,fieldAttributes[26]));
			body.Append("^");
			sb.Append(body.Length+"#"+body.ToString()+";");
			return sb.ToString();
		}
 
		/// <summary>
		/// deserialize structure
		/// </summary>
		public void wireToStruct(SynMessage reply)
		{
			f_Pkid = XFProtocol.wireTostring(reply);
			f_Application = XFProtocol.wireTostring(reply);
			f_Username = XFProtocol.wireTostring(reply);
			f_Email = XFProtocol.wireTostring(reply);
			f_Comment = XFProtocol.wireTostring(reply);
			f_Password = XFProtocol.wireTostring(reply);
			f_Password_question = XFProtocol.wireTostring(reply);
			f_Password_answer = XFProtocol.wireTostring(reply);
			f_Is_approved = XFProtocol.wireToint(reply);
			f_Created_date = XFProtocol.wireToDateTime(reply,fieldAttributes[9]);
			f_Created_time = XFProtocol.wireToDateTime(reply,fieldAttributes[10]);
			f_Last_activity_date = XFProtocol.wireToDateTime(reply,fieldAttributes[11]);
			f_Last_activity_time = XFProtocol.wireToDateTime(reply,fieldAttributes[12]);
			f_Last_login_date = XFProtocol.wireToDateTime(reply,fieldAttributes[13]);
			f_Last_login_time = XFProtocol.wireToDateTime(reply,fieldAttributes[14]);
			f_Last_password_change_date = XFProtocol.wireToDateTime(reply,fieldAttributes[15]);
			f_Last_password_change_time = XFProtocol.wireToDateTime(reply,fieldAttributes[16]);
			f_Is_online = XFProtocol.wireToint(reply);
			f_Is_locked_out = XFProtocol.wireToint(reply);
			f_Last_locked_out_date = XFProtocol.wireToDateTime(reply,fieldAttributes[19]);
			f_Last_locked_out_time = XFProtocol.wireToDateTime(reply,fieldAttributes[20]);
			f_Failed_password_count = XFProtocol.wireToint(reply);
			f_Failed_password_window_date = XFProtocol.wireToDateTime(reply,fieldAttributes[22]);
			f_Failed_password_window_time = XFProtocol.wireToDateTime(reply,fieldAttributes[23]);
			f_Failed_answer_count = XFProtocol.wireToint(reply);
			f_Failed_answer_window_date = XFProtocol.wireToDateTime(reply,fieldAttributes[25]);
			f_Failed_answer_window_time = XFProtocol.wireToDateTime(reply,fieldAttributes[26]);
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
