// Generated on 28-Apr-2012 6:25:12 by gencs v1.0.11.0
// 
// The contents of this file are auto-generated. Only add modifications to the end of this file.
// Any modifications will be lost when the file is re-generated.
// 
using System;
using System.Collections;
using System.Reflection;
#if POOLING
using System.EnterpriseServices;
#endif
using Synergex.xfnlnet;
namespace SynPSG.ASP
{
/// <summary>
/// Procedural Interface Class SynergyAspProvider
/// </summary>
#if POOLING
	[ObjectPooling()]
	public class AspProvider : ServicedComponent, IAspProvider
#else
	public class AspProvider : IAspProvider
#endif
	{
		/// <summary>
		/// constructor
		/// </summary>
		public AspProvider()
		{
			m_xfnet = new XFNet(this);
			m_xfnet.initialize();
		}
#if POOLING
		/// <summary>
		/// release method for pooling
		/// </summary>
		~AspProvider()
		{
			Dispose(false);
		}
		private new void Dispose(Boolean disposing)
		{
			m_xfnet.disconnect(disposing);
		}
#endif
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <param name="Role">Roles</param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int AddUsersToRoles (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string[] Username
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string[] Role
		)
		{
			object[] pa = new object[3];
			pa[0]=Application;
			pa[1]=Username;
			pa[2]=Role;
			int ret=(int)m_xfnet.callUserMethod("AddUsersToRoles",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="NewPassword"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int ChangePassword (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=64)]string NewPassword
		)
		{
			object[] pa = new object[3];
			pa[0]=Application;
			pa[1]=Username;
			pa[2]=NewPassword;
			int ret=(int)m_xfnet.callUserMethod("ChangePassword",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="PasswordQuestion"></param>
		/// <param name="PasswordAnswer"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int ChangePasswordQuestion (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=64)]string PasswordQuestion
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=64)]string PasswordAnswer
		)
		{
			object[] pa = new object[4];
			pa[0]=Application;
			pa[1]=Username;
			pa[2]=PasswordQuestion;
			pa[3]=PasswordAnswer;
			int ret=(int)m_xfnet.callUserMethod("ChangePasswordQuestion",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Role"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int CreateRole (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Role
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Role;
			int ret=(int)m_xfnet.callUserMethod("CreateRole",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="ASPNET_USERS"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int CreateUser (
			Aspnet_user ASPNET_USERS
		)
		{
			object[] pa = new object[1];
			pa[0]=ASPNET_USERS;
			int ret=(int)m_xfnet.callUserMethod("CreateUser",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Role">Role name</param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int DeleteRole (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Role
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Role;
			int ret=(int)m_xfnet.callUserMethod("DeleteRole",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="DeleteRelatedData"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int DeleteUser (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
			,[XFAttr(type=XFAttr.xftype.DECIMAL,coerce=XFAttr.xftype.INT,size=1)]int DeleteRelatedData
		)
		{
			object[] pa = new object[3];
			pa[0]=Application;
			pa[1]=Username;
			pa[2]=DeleteRelatedData;
			int ret=(int)m_xfnet.callUserMethod("DeleteUser",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Role"></param>
		/// <param name="Pattern"></param>
		/// <param name="MatchingUsers"></param>
		public void FindUsersInRole (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Role
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Pattern
			,[XFAttr(type=XFAttr.xftype.ARRAYLIST,size=96,dir=XFAttr.xfdir.OUT)]ref ArrayList MatchingUsers
		)
		{
			object[] pa = new object[4];
			pa[0]=Application;
			pa[1]=Role;
			pa[2]=Pattern;
			ArrayList tmpAl3 = new ArrayList();
			MatchingUsers.Clear();
			Aspnet_user_role xfStr3 = new Aspnet_user_role();
			MatchingUsers.Add(xfStr3);
			pa[3]=MatchingUsers;
			m_xfnet.callUserMethod("FindUsersInRole",ref pa);
			MatchingUsers=(ArrayList)pa[3];
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Roles"></param>
		public void GetAllRoles (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ARRAYLIST,size=64,dir=XFAttr.xfdir.OUT)]ref ArrayList Roles
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			ArrayList tmpAl1 = new ArrayList();
			Roles.Clear();
			Aspnet_role xfStr1 = new Aspnet_role();
			Roles.Add(xfStr1);
			pa[1]=Roles;
			m_xfnet.callUserMethod("GetAllRoles",ref pa);
			Roles=(ArrayList)pa[1];
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="PageIndex"></param>
		/// <param name="PageSize"></param>
		/// <param name="UserData"></param>
		/// <param name="TotalUsers"></param>
		public void GetAllUsers (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string UserName
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int PageIndex
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int PageSize
			,[XFAttr(type=XFAttr.xftype.ARRAYLIST,size=593,dir=XFAttr.xfdir.OUT)]ref ArrayList UserData
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4,dir=XFAttr.xfdir.OUT)]ref int TotalUsers
		)
		{
			object[] pa = new object[5];
			pa[0]=UserName;
			pa[1]=PageIndex;
			pa[2]=PageSize;
			ArrayList tmpAl3 = new ArrayList();
			UserData.Clear();
			Aspnet_user xfStr3 = new Aspnet_user();
			UserData.Add(xfStr3);
			pa[3]=UserData;
			pa[4]=TotalUsers;
			m_xfnet.callUserMethod("GetAllUsers",ref pa);
			UserData=(ArrayList)pa[3];
			TotalUsers=(int)pa[4];
		}
		/// <summary>
		/// Returns the current number of active users
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="DateTime">Date and time for comparison</param>
		/// <returns>User count (-ve number = error)</returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int GetOnlineUserCount (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,Date_time DateTime
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=DateTime;
			int ret=(int)m_xfnet.callUserMethod("GetOnlineUserCount",ref pa);
			return ret;
		}
		/// <summary>
		/// Returns a users password details
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">username</param>
		/// <param name="Password">Password</param>
		/// <param name="PasswordAnswer">Password secret answer</param>
		/// <param name="IsLockedOut">Is the user locked out</param>
		/// <returns>0 = success</returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int GetPassword (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=64,dir=XFAttr.xfdir.OUT)]ref string Password
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=64,dir=XFAttr.xfdir.OUT)]ref string PasswordAnswer
			,[XFAttr(type=XFAttr.xftype.DECIMAL,coerce=XFAttr.xftype.INT,size=1,dir=XFAttr.xfdir.OUT)]ref int IsLockedOut
		)
		{
			object[] pa = new object[5];
			pa[0]=Application;
			pa[1]=Username;
			pa[2]=Password;
			pa[3]=PasswordAnswer;
			pa[4]=IsLockedOut;
			int ret=(int)m_xfnet.callUserMethod("GetPassword",ref pa);
			Password=(string)pa[2];
			PasswordAnswer=(string)pa[3];
			IsLockedOut=(int)pa[4];
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="PasswordCounters"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int GetPasswordCounters (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
			,[XFAttr(dir=XFAttr.xfdir.OUT)]ref Aspnet_password_counters PasswordCounters
		)
		{
			object[] pa = new object[3];
			pa[0]=Application;
			pa[1]=Username;
			pa[2]=PasswordCounters;
			int ret=(int)m_xfnet.callUserMethod("GetPasswordCounters",ref pa);
			PasswordCounters=(Aspnet_password_counters)pa[2];
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="Roles"></param>
		public void GetRolesForUser (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
			,[XFAttr(type=XFAttr.xftype.ARRAYLIST,size=64,dir=XFAttr.xfdir.OUT)]ref ArrayList Roles
		)
		{
			object[] pa = new object[3];
			pa[0]=Application;
			pa[1]=Username;
			ArrayList tmpAl2 = new ArrayList();
			Roles.Clear();
			Aspnet_role xfStr2 = new Aspnet_role();
			Roles.Add(xfStr2);
			pa[2]=Roles;
			m_xfnet.callUserMethod("GetRolesForUser",ref pa);
			Roles=(ArrayList)pa[2];
		}
		/// <summary>
		/// Retrieve a user by PKID
		/// </summary>
		/// <param name="Pkid">Primary key identifier (GUID)</param>
		/// <param name="UpdateActivity">Update activity date/time</param>
		/// <param name="UserRecord">User record</param>
		/// <returns>0=success</returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int GetUserByPkid (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=36)]string Pkid
			,[XFAttr(type=XFAttr.xftype.DECIMAL,coerce=XFAttr.xftype.INT,size=1)]int UpdateActivity
			,[XFAttr(dir=XFAttr.xfdir.OUT)]ref Aspnet_user UserRecord
		)
		{
			object[] pa = new object[3];
			pa[0]=Pkid;
			pa[1]=UpdateActivity;
			pa[2]=UserRecord;
			int ret=(int)m_xfnet.callUserMethod("GetUserByPkid",ref pa);
			UserRecord=(Aspnet_user)pa[2];
			return ret;
		}
		/// <summary>
		/// Returns a user record
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <param name="UpdateActivity">Update last activity date</param>
		/// <param name="User">User record</param>
		/// <returns>0 = success</returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int GetUserByUsername (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
			,[XFAttr(type=XFAttr.xftype.DECIMAL,coerce=XFAttr.xftype.INT,size=1)]int UpdateActivity
			,[XFAttr(dir=XFAttr.xfdir.OUT)]ref Aspnet_user User
		)
		{
			object[] pa = new object[4];
			pa[0]=Application;
			pa[1]=Username;
			pa[2]=UpdateActivity;
			pa[3]=User;
			int ret=(int)m_xfnet.callUserMethod("GetUserByUsername",ref pa);
			User=(Aspnet_user)pa[3];
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Email">Email address</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int GetUsernameByEmail (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=64)]string Email
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32,dir=XFAttr.xfdir.OUT)]ref string Username
		)
		{
			object[] pa = new object[3];
			pa[0]=Application;
			pa[1]=Email;
			pa[2]=Username;
			int ret=(int)m_xfnet.callUserMethod("GetUsernameByEmail",ref pa);
			Username=(string)pa[2];
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="PartialEmail"></param>
		/// <param name="PageIndex"></param>
		/// <param name="PageSize"></param>
		/// <param name="Users"></param>
		/// <param name="MatchingUserCount"></param>
		public void GetUsersByEmail (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=64)]string PartialEmail
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int PageIndex
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int PageSize
			,[XFAttr(type=XFAttr.xftype.ARRAYLIST,size=593,dir=XFAttr.xfdir.OUT)]ref ArrayList Users
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4,dir=XFAttr.xfdir.OUT)]ref int MatchingUserCount
		)
		{
			object[] pa = new object[6];
			pa[0]=Application;
			pa[1]=PartialEmail;
			pa[2]=PageIndex;
			pa[3]=PageSize;
			ArrayList tmpAl4 = new ArrayList();
			Users.Clear();
			Aspnet_user xfStr4 = new Aspnet_user();
			Users.Add(xfStr4);
			pa[4]=Users;
			pa[5]=MatchingUserCount;
			m_xfnet.callUserMethod("GetUsersByEmail",ref pa);
			Users=(ArrayList)pa[4];
			MatchingUserCount=(int)pa[5];
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="PartialUsername"></param>
		/// <param name="PageIndex"></param>
		/// <param name="PageSize"></param>
		/// <param name="Users"></param>
		/// <param name="MatchingUserCount"></param>
		public void GetUsersByName (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string PartialUsername
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int PageIndex
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4)]int PageSize
			,[XFAttr(type=XFAttr.xftype.ARRAYLIST,size=593,dir=XFAttr.xfdir.OUT)]ref ArrayList Users
			,[XFAttr(type=XFAttr.xftype.INTEGER,coerce=XFAttr.xftype.INT,size=4,dir=XFAttr.xfdir.OUT)]ref int MatchingUserCount
		)
		{
			object[] pa = new object[6];
			pa[0]=Application;
			pa[1]=PartialUsername;
			pa[2]=PageIndex;
			pa[3]=PageSize;
			ArrayList tmpAl4 = new ArrayList();
			Users.Clear();
			Aspnet_user xfStr4 = new Aspnet_user();
			Users.Add(xfStr4);
			pa[4]=Users;
			pa[5]=MatchingUserCount;
			m_xfnet.callUserMethod("GetUsersByName",ref pa);
			Users=(ArrayList)pa[4];
			MatchingUserCount=(int)pa[5];
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Role"></param>
		/// <param name="Users"></param>
		public void GetUsersInRole (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Role
			,[XFAttr(type=XFAttr.xftype.ARRAYLIST,size=96,dir=XFAttr.xfdir.OUT)]ref ArrayList Users
		)
		{
			object[] pa = new object[3];
			pa[0]=Application;
			pa[1]=Role;
			ArrayList tmpAl2 = new ArrayList();
			Users.Clear();
			Aspnet_user_role xfStr2 = new Aspnet_user_role();
			Users.Add(xfStr2);
			pa[2]=Users;
			m_xfnet.callUserMethod("GetUsersInRole",ref pa);
			Users=(ArrayList)pa[2];
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int IncrementAnswerFailures (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Username;
			int ret=(int)m_xfnet.callUserMethod("IncrementAnswerFailures",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int IncrementPasswordFailures (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Username;
			int ret=(int)m_xfnet.callUserMethod("IncrementPasswordFailures",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="Role"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int IsUserInRole (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Role
		)
		{
			object[] pa = new object[3];
			pa[0]=Application;
			pa[1]=Username;
			pa[2]=Role;
			int ret=(int)m_xfnet.callUserMethod("IsUserInRole",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int LockUser (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Username;
			int ret=(int)m_xfnet.callUserMethod("LockUser",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		public void RemoveUserFromAllRoles (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Username;
			m_xfnet.callUserMethod("RemoveUserFromAllRoles",ref pa);
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Usernames"></param>
		/// <param name="Roles"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int RemoveUsersFromRoles (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string[] Usernames
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string[] Roles
		)
		{
			object[] pa = new object[3];
			pa[0]=Application;
			pa[1]=Usernames;
			pa[2]=Roles;
			int ret=(int)m_xfnet.callUserMethod("RemoveUsersFromRoles",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Role"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int RoleExists (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Role
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Role;
			int ret=(int)m_xfnet.callUserMethod("RoleExists",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		public void SetLastLoginDate (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Username;
			m_xfnet.callUserMethod("SetLastLoginDate",ref pa);
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int StartAnswerFailWindow (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Username;
			int ret=(int)m_xfnet.callUserMethod("StartAnswerFailWindow",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int StartPasswordFailWindow (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Username;
			int ret=(int)m_xfnet.callUserMethod("StartPasswordFailWindow",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int UnlockUser (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Username;
			int ret=(int)m_xfnet.callUserMethod("UnlockUser",ref pa);
			return ret;
		}
		/// <summary>
		/// Updates the data for an existing user
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="EmailAddress"></param>
		/// <param name="Comment"></param>
		/// <param name="IsApproved"></param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int UpdateUser (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=64)]string EmailAddress
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=128)]string Comment
			,[XFAttr(type=XFAttr.xftype.DECIMAL,coerce=XFAttr.xftype.INT,size=1)]int IsApproved
		)
		{
			object[] pa = new object[5];
			pa[0]=Application;
			pa[1]=Username;
			pa[2]=EmailAddress;
			pa[3]=Comment;
			pa[4]=IsApproved;
			int ret=(int)m_xfnet.callUserMethod("UpdateUser",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int UpdateUserActivityTime (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
		)
		{
			object[] pa = new object[2];
			pa[0]=Application;
			pa[1]=Username;
			int ret=(int)m_xfnet.callUserMethod("UpdateUserActivityTime",ref pa);
			return ret;
		}
		/// <summary>
		/// *** To Do ***
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <param name="Password">Password</param>
		/// <param name="IsApproved">User is approved</param>
		/// <param name="IsLockedOut">User is locked out</param>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
		public int ValidateUser (
			[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Application
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=32)]string Username
			,[XFAttr(type=XFAttr.xftype.ALPHA,size=64,dir=XFAttr.xfdir.OUT)]ref string Password
			,[XFAttr(type=XFAttr.xftype.DECIMAL,coerce=XFAttr.xftype.INT,size=1,dir=XFAttr.xfdir.OUT)]ref int IsApproved
			,[XFAttr(type=XFAttr.xftype.DECIMAL,coerce=XFAttr.xftype.INT,size=1,dir=XFAttr.xfdir.OUT)]ref int IsLockedOut
		)
		{
			object[] pa = new object[5];
			pa[0]=Application;
			pa[1]=Username;
			pa[2]=Password;
			pa[3]=IsApproved;
			pa[4]=IsLockedOut;
			int ret=(int)m_xfnet.callUserMethod("ValidateUser",ref pa);
			Password=(string)pa[2];
			IsApproved=(int)pa[3];
			IsLockedOut=(int)pa[4];
			return ret;
		}
		#region xfnlnet support methods
		/// <summary>
		/// connect to xfServerPlus
		/// </summary>
		public void connect()
		{
			m_xfnet.connect();
		}
		/// <summary>
		/// xfServerPlus four parameter connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		/// <param name="minPort">minport number</param>
		/// <param name="maxPort">maxport number</param>
		public void connect(string hostIP, int hostPort, int minPort, int maxPort)
		{
			m_xfnet.connect(hostIP, hostPort, minPort, maxPort);
		}
		/// <summary>
		/// xfServerPlus host and port connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		public void connect(string hostIP, int hostPort)
		{
			m_xfnet.connect(hostIP, hostPort);
		}
		/// <summary>
		/// disconnect from xfServerPlus
		/// </summary>
		public void disconnect()
		{
			m_xfnet.disconnect();
		}
		/// <summary>
		/// initialize a debug session
		/// </summary>
		/// <param name="hexip">IP address</param>
		/// <param name="port">port number</param>
		public void debugInit(ref string hexip, ref int port)
		{
			m_xfnet.debugInit(ref hexip, ref port);
		}
		/// <summary>
		/// start a debug session of xfServerPlus
		/// </summary>
		public void debugStart()
		{
			m_xfnet.debugStart();
		}
#if !POOLING
		/// <summary>
		/// get the object's xfServerPlus connection
		/// </summary>
		/// <returns>xfServerPlus connection</returns>
		public object getConnect()
		{
			return m_xfnet.getConnect();
		}
		/// <summary>
		/// share the provided connection
		/// </summary>
		/// <param name="connect">connection to share</param>
		public void shareConnect(object connect)
		{
			m_xfnet.shareConnect(connect);
		}
#endif
		/// <summary>
		/// set the call timeout in seconds
		/// </summary>
		/// <param name="seconds">timeout in seconds</param>
		public void setCallTimeout(int seconds)
		{
			m_xfnet.setCallTimeout(seconds);
		}
		/// <summary>
		/// set the user string
		/// </summary>
		/// <param name="userString">The user string</param>
		public void setUserString(string userString)
		{
			m_xfnet.setUserString(userString);
		}
		/// <summary>
		/// get the user string 
		/// </summary>
		/// <returns>User String</returns>
		public string getUserString()
		{
			return m_xfnet.getUserString();
		}
		/// <summary>
		/// pooling initialization
		/// </summary>
		/// <returns></returns>
		[XFAttr(type=XFAttr.xftype.VALUE,size=4)]
#if POOLING
		private int Initialize ()
#else
		public int Initialize ()
#endif
		{
			int ret=(int)m_xfnet.callUserMethod("Initialize");
			return ret;
		}
		/// <summary>
		/// pooling cleanup
		/// </summary>
#if POOLING
		private void Cleanup ()
#else
		public void Cleanup ()
#endif
		{
			m_xfnet.callUserMethod("Cleanup");
		}
		/// <summary>
		/// indicate if an object can be put back into the pool
		/// </summary>
		/// <returns>true if object can be returned to pool</returns>
		[XFAttr(type=XFAttr.xftype.INTEGER, size=1)]
#if POOLING
		protected override bool CanBePooled()
#else
		public bool CanBePooled()
#endif
		{
			bool ret = m_xfnet.CanBePooled();
			return ret;
		}
		#endregion
		private XFNet m_xfnet = null;
	}
}
