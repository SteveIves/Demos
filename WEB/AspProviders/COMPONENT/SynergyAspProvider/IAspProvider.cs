// Generated on 28-Apr-2012 6:25:12 by gencs v1.0.11.0
// 
// The contents of this file are auto-generated. Only add modifications to the end of this file.
// Any modifications will be lost when the file is re-generated.
// 
using System;
using System.Collections;
using System.Reflection;
using Synergex.xfnlnet;
namespace SynPSG.ASP
{
/// <summary>
/// Interface SynergyAspProvider
/// </summary>
#if POOLING
	public interface IAspProvider : IDisposable
#else
	public interface IAspProvider
#endif
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <param name="Role">Roles</param>
		/// <returns></returns>
		int AddUsersToRoles (
			string Application
			,string[] Username
			,string[] Role
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="NewPassword"></param>
		/// <returns></returns>
		int ChangePassword (
			string Application
			,string Username
			,string NewPassword
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="PasswordQuestion"></param>
		/// <param name="PasswordAnswer"></param>
		/// <returns></returns>
		int ChangePasswordQuestion (
			string Application
			,string Username
			,string PasswordQuestion
			,string PasswordAnswer
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Role"></param>
		/// <returns></returns>
		int CreateRole (
			string Application
			,string Role
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ASPNET_USERS"></param>
		/// <returns></returns>
		int CreateUser (
			Aspnet_user ASPNET_USERS
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Role">Role name</param>
		/// <returns></returns>
		int DeleteRole (
			string Application
			,string Role
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="DeleteRelatedData"></param>
		/// <returns></returns>
		int DeleteUser (
			string Application
			,string Username
			,int DeleteRelatedData
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Role"></param>
		/// <param name="Pattern"></param>
		/// <param name="MatchingUsers"></param>
		void FindUsersInRole (
			string Application
			,string Role
			,string Pattern
			,ref ArrayList MatchingUsers
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Roles"></param>
		void GetAllRoles (
			string Application
			,ref ArrayList Roles
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="PageIndex"></param>
		/// <param name="PageSize"></param>
		/// <param name="UserData"></param>
		/// <param name="TotalUsers"></param>
		void GetAllUsers (
			string UserName
			,int PageIndex
			,int PageSize
			,ref ArrayList UserData
			,ref int TotalUsers
		);
		/// <summary>
		/// Returns the current number of active users
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="DateTime">Date and time for comparison</param>
		/// <returns>User count (-ve number = error)</returns>
		int GetOnlineUserCount (
			string Application
			,Date_time DateTime
		);
		/// <summary>
		/// Returns a users password details
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">username</param>
		/// <param name="Password">Password</param>
		/// <param name="PasswordAnswer">Password secret answer</param>
		/// <param name="IsLockedOut">Is the user locked out</param>
		/// <returns>0 = success</returns>
		int GetPassword (
			string Application
			,string Username
			,ref string Password
			,ref string PasswordAnswer
			,ref int IsLockedOut
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="PasswordCounters"></param>
		/// <returns></returns>
		int GetPasswordCounters (
			string Application
			,string Username
			,ref Aspnet_password_counters PasswordCounters
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="Roles"></param>
		void GetRolesForUser (
			string Application
			,string Username
			,ref ArrayList Roles
		);
		/// <summary>
		/// Retrieve a user by PKID
		/// </summary>
		/// <param name="Pkid">Primary key identifier (GUID)</param>
		/// <param name="UpdateActivity">Update activity date/time</param>
		/// <param name="UserRecord">User record</param>
		/// <returns>0=success</returns>
		int GetUserByPkid (
			string Pkid
			,int UpdateActivity
			,ref Aspnet_user UserRecord
		);
		/// <summary>
		/// Returns a user record
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <param name="UpdateActivity">Update last activity date</param>
		/// <param name="User">User record</param>
		/// <returns>0 = success</returns>
		int GetUserByUsername (
			string Application
			,string Username
			,int UpdateActivity
			,ref Aspnet_user User
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Email">Email address</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		int GetUsernameByEmail (
			string Application
			,string Email
			,ref string Username
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="PartialEmail"></param>
		/// <param name="PageIndex"></param>
		/// <param name="PageSize"></param>
		/// <param name="Users"></param>
		/// <param name="MatchingUserCount"></param>
		void GetUsersByEmail (
			string Application
			,string PartialEmail
			,int PageIndex
			,int PageSize
			,ref ArrayList Users
			,ref int MatchingUserCount
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="PartialUsername"></param>
		/// <param name="PageIndex"></param>
		/// <param name="PageSize"></param>
		/// <param name="Users"></param>
		/// <param name="MatchingUserCount"></param>
		void GetUsersByName (
			string Application
			,string PartialUsername
			,int PageIndex
			,int PageSize
			,ref ArrayList Users
			,ref int MatchingUserCount
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Role"></param>
		/// <param name="Users"></param>
		void GetUsersInRole (
			string Application
			,string Role
			,ref ArrayList Users
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		int IncrementAnswerFailures (
			string Application
			,string Username
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		int IncrementPasswordFailures (
			string Application
			,string Username
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="Role"></param>
		/// <returns></returns>
		int IsUserInRole (
			string Application
			,string Username
			,string Role
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		int LockUser (
			string Application
			,string Username
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		void RemoveUserFromAllRoles (
			string Application
			,string Username
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Usernames"></param>
		/// <param name="Roles"></param>
		/// <returns></returns>
		int RemoveUsersFromRoles (
			string Application
			,string[] Usernames
			,string[] Roles
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Role"></param>
		/// <returns></returns>
		int RoleExists (
			string Application
			,string Role
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		void SetLastLoginDate (
			string Application
			,string Username
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		int StartAnswerFailWindow (
			string Application
			,string Username
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		int StartPasswordFailWindow (
			string Application
			,string Username
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <returns></returns>
		int UnlockUser (
			string Application
			,string Username
		);
		/// <summary>
		/// Updates the data for an existing user
		/// </summary>
		/// <param name="Application"></param>
		/// <param name="Username"></param>
		/// <param name="EmailAddress"></param>
		/// <param name="Comment"></param>
		/// <param name="IsApproved"></param>
		/// <returns></returns>
		int UpdateUser (
			string Application
			,string Username
			,string EmailAddress
			,string Comment
			,int IsApproved
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <returns></returns>
		int UpdateUserActivityTime (
			string Application
			,string Username
		);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Application">Application name</param>
		/// <param name="Username">Username</param>
		/// <param name="Password">Password</param>
		/// <param name="IsApproved">User is approved</param>
		/// <param name="IsLockedOut">User is locked out</param>
		/// <returns></returns>
		int ValidateUser (
			string Application
			,string Username
			,ref string Password
			,ref int IsApproved
			,ref int IsLockedOut
		);
		#region xfnlnet support methods
		/// <summary>
		/// connect to xfServerPlus
		/// </summary>
		void connect();
		/// <summary>
		/// xfServerPlus four parameter connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		/// <param name="minPort">minport number</param>
		/// <param name="maxPort">maxport number</param>
		void connect(string hostIP, int hostPort, int minPort, int maxPort);
		/// <summary>
		/// xfServerPlus host and port connect
		/// </summary>
		/// <param name="hostIP">IP address</param>
		/// <param name="hostPort">port number</param>
		void connect(string hostIP, int hostPort);
		/// <summary>
		/// disconnect from xfServerPlus
		/// </summary>
		void disconnect();
		/// <summary>
		/// initialize a debug session
		/// </summary>
		/// <param name="hexip">IP address</param>
		/// <param name="port">port number</param>
		void debugInit(ref string hexip, ref int port);
		/// <summary>
		/// start a debug session of xfServerPlus
		/// </summary>
		void debugStart();
#if !POOLING
		/// <summary>
		/// get the object's xfServerPlus connection
		/// </summary>
		/// <returns>xfServerPlus connection</returns>
		object getConnect();
		/// <summary>
		/// share the provided connection
		/// </summary>
		/// <param name="connect">connection to share</param>
		void shareConnect(object connect);
#endif
		/// <summary>
		/// set the call timeout in seconds
		/// </summary>
		/// <param name="seconds">timeout in seconds</param>
		void setCallTimeout(int seconds);
		/// <summary>
		/// set the user string
		/// </summary>
		/// <param name="userString">The user string</param>
		void setUserString(string userString);
		/// <summary>
		/// get the user string 
		/// </summary>
		/// <returns>User String</returns>
		string getUserString();
		#endregion
	}
}
