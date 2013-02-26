using System;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.Security;

namespace KitaroDB_AspProviders
{
    public sealed class KitaroMembershipProvider : MembershipProvider
    {

        // Global generated password length, generic exception message, event log info.
        private int newPasswordLength = 8;
        private string eventSource = "SynergyMembershipProvider";
        private string eventLog = "Application";

        private string exceptionMessage = "SynergyMembershipProvider: An exception occurred. Please check the Event Log.";
        // Used when determining encryption key values.

        private MachineKeySection machineKey;
        // If False, exceptions are thrown to the caller. If True exceptions are written to the event log.

        private bool pWriteExceptionsToEventLog;
        public bool WriteExceptionsToEventLog
        {
            get { return pWriteExceptionsToEventLog; }
            set { pWriteExceptionsToEventLog = value; }
        }

        // System.Configuration.Provider.ProviderBase.Initialize Method

        public override void Initialize(string Name, NameValueCollection config)
        {
            // Initialize values from web.config.
            if ((config == null))
                throw new ArgumentNullException("config");

            if (((Name == null) | Name.Length == 0))
                Name = "SynergyMembershipProvider";

            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "Synergy ASP.NET Membership provider");
            }

            // Initialize the abstract base class.
            base.Initialize(Name, config);

            pApplicationName = GetConfigValue(config["applicationName"], System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            pMaxInvalidPasswordAttempts = Convert.ToInt32(GetConfigValue(config["MaxInvalidPasswordAttempts"], "5"));
            pPasswordAttemptWindow = Convert.ToInt32(GetConfigValue(config["PasswordAttemptWindow"], "10"));
            pMinRequiredNonAlphanumericCharacters = Convert.ToInt32(GetConfigValue(config["minRequiredAlphaNumericCharacters"], "1"));
            pMinRequiredPasswordLength = Convert.ToInt32(GetConfigValue(config["minRequiredPasswordLength"], "7"));
            pPasswordStrengthRegularExpression = Convert.ToString(GetConfigValue(config["passwordStrengthRegularExpression"], ""));
            pEnablePasswordReset = Convert.ToBoolean(GetConfigValue(config["EnablePasswordReset"], "True"));
            pEnablePasswordRetrieval = Convert.ToBoolean(GetConfigValue(config["EnablePasswordRetrieval"], "True"));
            pRequiresQuestionAndAnswer = Convert.ToBoolean(GetConfigValue(config["RequiresQuestionAndAnswer"], "False"));
            pRequiresUniqueEmail = Convert.ToBoolean(GetConfigValue(config["RequiresUniqueEmail"], "True"));
            pWriteExceptionsToEventLog = Convert.ToBoolean(GetConfigValue(config["WriteExceptionsToEventLog"], "True"));

            string temp_format = config["PasswordFormat"];
            if ((temp_format == null))
                temp_format = "Hashed";

            switch (temp_format)
            {
                case "Hashed":
                    pPasswordFormat = MembershipPasswordFormat.Hashed;
                    break;
                case "Encrypted":
                    pPasswordFormat = MembershipPasswordFormat.Encrypted;
                    break;
                case "Clear":
                    pPasswordFormat = MembershipPasswordFormat.Clear;
                    break;
                default:
                    throw new ProviderException("SynergyMembershipProvider: Password format not supported.");
            }

            // Get encryption and decryption key information from the configuration.
            System.Configuration.Configuration Cfg = WebConfigurationManager.OpenWebConfiguration(System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath);
            machineKey = (MachineKeySection)Cfg.GetSection("system.web/machineKey");

            if (machineKey.ValidationKey.Contains("AutoGenerate"))
                if (PasswordFormat != MembershipPasswordFormat.Clear)
                    throw new ProviderException("SynergyMembershipProvider: Hashed or Encrypted passwords are not supported with auto-generated keys.");

        }

        // A helper function to retrieve config values from the configuration file.
        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (string.IsNullOrEmpty(configValue))
                return defaultValue;
            return configValue;
        }

        // System.Web.Security.MembershipProvider properties.

        private string pApplicationName;
        private bool pEnablePasswordReset;
        private bool pEnablePasswordRetrieval;
        private bool pRequiresQuestionAndAnswer;
        private bool pRequiresUniqueEmail;
        private int pMaxInvalidPasswordAttempts;
        private int pPasswordAttemptWindow;
        private int pMinRequiredNonAlphanumericCharacters;
        private int pMinRequiredPasswordLength;
        private string pPasswordStrengthRegularExpression;

        private MembershipPasswordFormat pPasswordFormat;
        public override string ApplicationName
        {
            get { return pApplicationName; }
            set { pApplicationName = value; }
        }

        public override bool EnablePasswordReset
        {
            get { return pEnablePasswordReset; }
        }

        public override bool EnablePasswordRetrieval
        {
            get { return pEnablePasswordRetrieval; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return pRequiresQuestionAndAnswer; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return pRequiresUniqueEmail; }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return pMaxInvalidPasswordAttempts; }
        }

        public override int PasswordAttemptWindow
        {
            get { return pPasswordAttemptWindow; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return pPasswordFormat; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return pMinRequiredNonAlphanumericCharacters; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return pMinRequiredPasswordLength; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return pPasswordStrengthRegularExpression; }
        }

        //System.Web.Security.MembershipProvider methods.

        //MembershipProvider.ChangePassword

        public override bool ChangePassword(string Username, string OldPassword, string NewPassword)
        {

            //Validate that we have been given the correct old password
            if (!ValidateUser(Username, OldPassword))
                return false;

            //Raise a ValidatingPassword event (if an event handler has been declared) 
            ValidatePasswordEventArgs Args = new ValidatePasswordEventArgs(Username, NewPassword, true);
            OnValidatingPassword(Args);

            if (Args.Cancel)
            {
                if ((Args.FailureInformation != null))
                {
                    throw Args.FailureInformation;
                }
                else
                {
                    throw new ProviderException("SynergyMembershipProvider: Change password canceled due to New password validation failure.");
                }
            }

            //Change the password in the Synergy database
            //SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();
            //try
            //{
            //    if (Server.ChangePassword(pApplicationName, Username, EncodePassword(NewPassword)) == 0)
            //    {
                    return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ThrowException("ChangePassword", ex);
            //}
            //finally
            //{
            //    Server.Dispose();
            //}

        }

        //MembershipProvider.ChangePasswordQuestionAndAnswer

        public override bool ChangePasswordQuestionAndAnswer(string Username, string Password, string NewPasswordQuestion, string NewPasswordAnswer)
        {

            //Validate that we have been given the correct old password
            if (!ValidateUser(Username, Password))
                return false;

            //Change the password question and answer in the Synergy database
            //SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();

            //try
            //{
            //    if (Server.ChangePasswordQuestion(pApplicationName, Username, NewPasswordQuestion, EncodePassword(NewPasswordAnswer)) > 0)
            //    {
            return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ThrowException("ChangePasswordQuestionAndAnswer", ex);
            //}
            //finally
            //{
            //    Server.Dispose();
            //}

        }

        //MembershipProvider.CreateUser

        public override MembershipUser CreateUser(string Username, string Password, string Email, string PasswordQuestion, string PasswordAnswer, bool IsApproved, object ProviderUserKey, ref MembershipCreateStatus status)
        {

            ValidatePasswordEventArgs Args = new ValidatePasswordEventArgs(Username, Password, true);
            OnValidatingPassword(Args);
            if (Args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && !string.IsNullOrEmpty(GetUserNameByEmail(Email)))
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }


            if ((GetUser(Username, false) == null))
            {
                DateTime CreateDate = DateTime.Now;

                if (ProviderUserKey == null)
                {
                    ProviderUserKey = Guid.NewGuid();
                }
                else
                {
                    if (ProviderUserKey.GetType() != typeof(Guid))
                    {
                        status = MembershipCreateStatus.InvalidProviderUserKey;
                        return null;
                    }
                }

                //SynPSG.ASP.Aspnet_user NewUser = new SynPSG.ASP.Aspnet_user();
                //{
                //    NewUser.Pkid = ProviderUserKey.ToString;
                //    NewUser.Application = pApplicationName;
                //    NewUser.Username = Username;
                //    NewUser.Password = EncodePassword(Password);
                //    NewUser.Email = Email;
                //    NewUser.Password_question = PasswordQuestion;
                //    NewUser.Password_answer = EncodePassword(PasswordAnswer);
                //    NewUser.Is_approved = IsApproved;
                //    NewUser.Comment = "";
                //    NewUser.Created_date = CreateDate;
                //    NewUser.Created_time = CreateDate;
                //    NewUser.Last_password_change_date = CreateDate;
                //    NewUser.Last_password_change_time = CreateDate;
                //    NewUser.Last_activity_date = CreateDate;
                //    NewUser.Last_activity_time = CreateDate;
                //    NewUser.Is_locked_out = false;
                //    NewUser.Last_locked_out_date = CreateDate;
                //    NewUser.Last_locked_out_time = CreateDate;
                //    NewUser.Failed_password_count = 0;
                //    NewUser.Failed_password_window_date = CreateDate;
                //    NewUser.Failed_password_window_time = CreateDate;
                //    NewUser.Failed_answer_count = 0;
                //    NewUser.Failed_answer_window_date = CreateDate;
                //    NewUser.Failed_answer_window_time = CreateDate;
                //}

                //SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();

                //try
                //{
                //    if (Server.CreateUser(NewUser) == 0)
                //    {
                //        status = MembershipCreateStatus.Success;
                //    }
                //    else
                //    {
                //        status = MembershipCreateStatus.UserRejected;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    ThrowException("CreateUser", ex);
                //    status = MembershipCreateStatus.ProviderError;
                //}
                //finally
                //{
                //    Server.Dispose();
                //}

                return GetUser(Username, false);

            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
            }

            return null;

        }

        // MembershipProvider.DeleteUser

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {

            //SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();

            //try
            //{
            //    if (Server.DeleteUser(pApplicationName, username, deleteAllRelatedData) == 0)
            //    {
            return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ThrowException("DeleteUser", ex);
            //}
            //finally
            //{
            //    Server.Dispose();
            //}

        }

        // MembershipProvider.GetAllUsers

        public override MembershipUserCollection GetAllUsers(int PageIndex, int PageSize, ref int TotalRecords)
        {

            MembershipUserCollection Users = new MembershipUserCollection();

            //SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();
            //ArrayList UserRecords = new ArrayList();

            //try
            //{
            //    Server.GetAllUsers(pApplicationName, PageIndex, PageSize, UserRecords, TotalRecords);
            //}
            //catch (Exception Ex)
            //{
            //    ThrowException("GetAllUsers", Ex);
            //}
            //finally
            //{
            //    Server.Dispose();
            //}

            //SynPSG.ASP.Aspnet_user UserRecord = default(SynPSG.ASP.Aspnet_user);

            //foreach ( UserRecord in UserRecords)
            //{
            //    Users.Add(UserFromUserRecord(UserRecord));
            //}

            return Users;

        }

        // MembershipProvider.GetNumberOfUsersOnline

        public override int GetNumberOfUsersOnline()
        {

            int NumOnline = 0;
            TimeSpan OnlineSpan = new TimeSpan(0, Membership.UserIsOnlineTimeWindow, 0);
            DateTime CompareTime = DateTime.Now.Subtract(OnlineSpan);

            //SynPSG.ASP.Date_time DateTimeRec = new SynPSG.ASP.Date_time();
            //{
            //    DateTimeRec.Date_field = CompareTime;
            //    DateTimeRec.Time_field = CompareTime;
            //}

            //SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();

            //try
            //{
            //    NumOnline = Server.GetOnlineUserCount(pApplicationName, DateTimeRec);
            //}
            //catch (Exception ex)
            //{
            //    ThrowException("GetOnlineUserCount", ex);
            //}
            //finally
            //{
            //    Server.Dispose();
            //}

            if (NumOnline < 0)
            {
                ThrowException("GotOnlineUserCount", new Exception("Failed to retrieve online user count"));
            }

            return NumOnline;

        }

        // MembershipProvider.GetPassword

        public override string GetPassword(string username, string answer)
        {
            if (!EnablePasswordRetrieval)
                throw new ProviderException("SynergyMembershipProvider: Password retrieval is not enabled.");

            if (PasswordFormat == MembershipPasswordFormat.Hashed)
                throw new ProviderException("SynergyMembershipProvider: Cannot retrieve hashed passwords.");

            string password = "";
            string passwordAnswer = "";
            bool isLockedOut = false;
            int callStatus = 0;

            //SynPSG.ASP.AspProvider server = new SynPSG.ASP.AspProvider();

            //try
            //{
            //    callStatus = server.GetPassword(pApplicationName, username, password, passwordAnswer, isLockedOut);
            //}
            //catch (Exception ex)
            //{
            //    ThrowException("GetPassword", ex);
            //}
            //finally
            //{
            //    server.Dispose();
            //}

            if (callStatus != 0)
                throw new MembershipPasswordException("The supplied user name is not found.");

            if (isLockedOut)
                throw new MembershipPasswordException("The supplied user is locked out.");

            if (RequiresQuestionAndAnswer && !CheckPassword(answer, passwordAnswer))
            {
                UpdateFailureCount(username, "passwordAnswer");
                throw new MembershipPasswordException("Incorrect password answer.");
            }

            if (PasswordFormat == MembershipPasswordFormat.Encrypted)
                password = UnEncodePassword(password);

            return password;

        }

        // MembershipProvider.GetUser(String, Boolean)

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {

            int callStatus = 0;
            //SynPSG.ASP.Aspnet_user userRecord = new SynPSG.ASP.Aspnet_user();

            MembershipUser u = null;

            //SynPSG.ASP.AspProvider server = new SynPSG.ASP.AspProvider();

            //try
            //{
            //    callStatus = server.GetUserByUsername(pApplicationName, username, userIsOnline, userRecord);
            //    if (callStatus == 0)
            //    {
            //        u = UserFromUserRecord(userRecord);
            //    }
            //    else if (callStatus > 0)
            //    {
            //        ThrowException("GetUserByUsername", new Exception("Provider method returned error " + callStatus));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ThrowException("GetUserByUsername", ex);
            //}
            //finally
            //{
            //    server.Dispose();
            //}

            return u;

        }

        // MembershipProvider.GetUser(Object, Boolean)

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {

            int callStatus = 0;
            SynPSG.ASP.Aspnet_user UserRecord = new SynPSG.ASP.Aspnet_user();
            Guid Pkid = providerUserKey;

            SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();
            try
            {
                callStatus = Server.GetUserByPkid(Pkid.ToString, userIsOnline, UserRecord);
            }
            catch (Exception ex)
            {
                ThrowException("GetUserByPkid", ex);
            }
            finally
            {
                Server.Dispose();
            }

            if (callStatus != 0)
            {
                ThrowException("GetUserByPkid", new Exception("Failed to get user record by primary key"));
            }

            return UserFromUserRecord(UserRecord);

        }

        private MembershipUser UserFromUserRecord(SynPSG.ASP.Aspnet_user UserRecord)
        {

            MembershipUser User = default(MembershipUser);

            DateTime CreateDate = default(DateTime);
            DateTime LastLoginDate = default(DateTime);
            DateTime LastActivityDate = default(DateTime);
            DateTime LastPasswordChangeDate = default(DateTime);
            DateTime LastLockoutDate = default(DateTime);

            {
                CreateDate = OneDateFromTwo(UserRecord.Created_date, UserRecord.Created_time);
                LastLoginDate = OneDateFromTwo(UserRecord.Last_login_date, UserRecord.Last_login_time);
                LastActivityDate = OneDateFromTwo(UserRecord.Last_activity_date, UserRecord.Last_activity_time);
                LastPasswordChangeDate = OneDateFromTwo(UserRecord.Last_password_change_date, UserRecord.Last_password_change_time);
                LastLockoutDate = OneDateFromTwo(UserRecord.Last_locked_out_date, UserRecord.Last_locked_out_time);
                User = new MembershipUser(this.Name, UserRecord.Username, UserRecord.Pkid, UserRecord.Email, UserRecord.Password_question, UserRecord.Comment, UserRecord.Is_approved, UserRecord.Is_locked_out, CreateDate, LastLoginDate,
                LastActivityDate, LastPasswordChangeDate, LastLockoutDate);
            }

            return User;

        }

        //
        // MembershipProvider.UnlockUser
        //

        public override bool UnlockUser(string username)
        {

            int callStatus = 0;
            SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();
            try
            {
                callStatus = Server.UnlockUser(pApplicationName, username);
            }
            catch (Exception ex)
            {
                ThrowException("UnlockUser", ex);
            }
            finally
            {
                Server.Dispose();
            }

            if (callStatus != 0)
            {
                ThrowException("UnlockUser", new Exception("Failed to unlock user record"));
            }

            return true;

        }


        //
        // MembershipProvider.GetUserNameByEmail
        //
        public override string GetUserNameByEmail(string Email)
        {

            string Username = "";
            int CallStatus = 0;
            SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();

            try
            {
                CallStatus = Server.GetUsernameByEmail(pApplicationName, Email, Username);
            }
            catch (Exception ex)
            {
                ThrowException("GetUsernameByEmail", ex);
            }
            finally
            {
                Server.Dispose();
            }

            if (CallStatus != 0)
            {
                ThrowException("GetUsernameByEmail", new Exception("Provider method returned error " + CallStatus));
            }

            return Username;

        }

        //
        // MembershipProvider.ResetPassword
        //
        public override string ResetPassword(string Username, string Answer)
        {

            if (!EnablePasswordReset)
            {
                throw new NotSupportedException("Password Reset is not enabled.");
            }

            if (Answer == null && RequiresQuestionAndAnswer)
            {
                UpdateFailureCount(Username, "passwordAnswer");
                throw new ProviderException("SynergyMembershipProvider: Password answer required for password reset.");
            }

            string newPassword = System.Web.Security.Membership.GeneratePassword(newPasswordLength, MinRequiredNonAlphanumericCharacters);

            ValidatePasswordEventArgs Args = new ValidatePasswordEventArgs(Username, newPassword, true);
            OnValidatingPassword(Args);
            if (Args.Cancel)
            {
                if ((Args.FailureInformation != null))
                {
                    throw Args.FailureInformation;
                }
                else
                {
                    throw new MembershipPasswordException("Reset password canceled due to password validation failure.");
                }
            }

            int callStatus = 0;
            string Password = "";
            string PasswordAnswer = "";
            bool IsLockedOut = false;

            SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();
            try
            {
                callStatus = Server.GetPassword(pApplicationName, Username, Password, PasswordAnswer, IsLockedOut);
            }
            catch (Exception ex)
            {
                ThrowException("ResetPassword", ex);
            }
            finally
            {
                Server.Dispose();
            }

            if (callStatus != 0)
            {
                ThrowException("ResetPassword", new Exception("Failed to reset password"));
            }

            //Is the user locked out?
            if (IsLockedOut)
                throw new MembershipPasswordException("The supplied user is locked out.");

            if (RequiresQuestionAndAnswer && !CheckPassword(Answer, PasswordAnswer))
            {
                UpdateFailureCount(Username, "passwordAnswer");
                throw new MembershipPasswordException("Incorrect password answer.");
            }

            //Change the password in the Synergy database
            try
            {
                callStatus = Server.ChangePassword(pApplicationName, Username, EncodePassword(newPassword));
            }
            catch (Exception ex)
            {
                ThrowException("ResetPassword", ex);
            }
            finally
            {
                Server = null;
            }

            //Did it work?
            if (callStatus == 0)
            {
                return newPassword;
            }
            else
            {
                throw new MembershipPasswordException("User not found, or user is locked out. Password not Reset.");
                return "";
            }

            return "";

        }

        //
        // MembershipProvider.UpdateUser
        //

        public override void UpdateUser(MembershipUser user)
        {
            int callStatus = 0;
            SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();
            try
            {
                callStatus = Server.UpdateUser(pApplicationName, user.UserName, user.Email, user.Comment, user.IsApproved);
            }
            catch (Exception ex)
            {
                ThrowException("UpdateUser", ex);
            }
            finally
            {
                Server.Dispose();
            }

            if (callStatus != 0)
            {
                ThrowException("UpdateUser", new Exception("Failed to update user record"));
            }


        }

        //
        // MembershipProvider.ValidateUser
        //
        public override bool ValidateUser(string username, string password)
        {

            bool isValid = false;
            int CallStatus = 0;
            bool isApproved = false;
            bool isLockedOut = false;
            string RealPassword = "";
            SynPSG.ASP.AspProvider Server = default(SynPSG.ASP.AspProvider);

            Server = new SynPSG.ASP.AspProvider();
            try
            {
                CallStatus = Server.ValidateUser(pApplicationName, username, RealPassword, isApproved, isLockedOut);
            }
            catch (Exception ex)
            {
                ThrowException("ValidateUser", ex);
            }
            finally
            {
                Server.Dispose();
                Server = null;
            }

            if (CallStatus != 0 | isLockedOut)
            {
                return false;
            }

            if (CheckPassword(password, RealPassword))
            {
                if (isApproved)
                {
                    //We're good to go
                    isValid = true;
                    //Update date of last login
                    Server = new SynPSG.ASP.AspProvider();
                    try
                    {
                        Server.SetLastLoginDate(pApplicationName, username);
                    }
                    catch (Exception ex)
                    {
                        ThrowException("SetLastLoginDate", ex);
                    }
                    finally
                    {
                        Server.Dispose();
                    }
                }
            }
            else
            {
                UpdateFailureCount(username, "password");
            }

            Server = null;

            return isValid;

        }

        //
        // UpdateFailureCount
        //   A helper method that performs the checks and updates associated with
        // password failure tracking.
        //

        private void UpdateFailureCount(string Username, string FailureType)
        {
            SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();

            try
            {
                SynPSG.ASP.Aspnet_password_counters PasswordCounters = new SynPSG.ASP.Aspnet_password_counters();
                int CallStatus = 0;

                CallStatus = Server.GetPasswordCounters(pApplicationName, Username, PasswordCounters);
                if (CallStatus != 0)
                    throw new ProviderException("SynergyMembershipProvider: Unable to retrieve password counters.");

                DateTime WindowStart = new DateTime();
                int FailureCount = 0;

                {
                    switch (FailureType)
                    {
                        case "password":
                            FailureCount = PasswordCounters.Password_fail_count;
                            WindowStart = OneDateFromTwo(PasswordCounters.Password_window_date, PasswordCounters.Password_window_time);
                            break;
                        case "passwordAnswer":
                            FailureCount = PasswordCounters.Answer_fail_count;
                            WindowStart = OneDateFromTwo(PasswordCounters.Answer_window_date, PasswordCounters.Answer_window_time);
                            break;
                    }
                }

                DateTime WindowEnd = WindowStart.AddMinutes(PasswordAttemptWindow);


                if (FailureCount == 0 || DateTime.Now > WindowEnd)
                {
                    // First password failure or outside of PasswordAttemptWindow. 
                    // Start a New password failure count from 1 and a New window starting now.

                    switch (FailureType)
                    {
                        case "password":
                            CallStatus = Server.StartPasswordFailWindow(pApplicationName, Username);
                            break;
                        case "passwordAnswer":
                            CallStatus = Server.StartAnswerFailWindow(pApplicationName, Username);
                            break;
                    }

                    if (CallStatus != 0)
                        throw new ProviderException("SynergyMembershipProvider: Unable to update failure count and window start.");


                }
                else
                {
                    FailureCount += 1;


                    if (FailureCount >= MaxInvalidPasswordAttempts)
                    {
                        // Password attempts have exceeded the failure threshold. Lock out the user.
                        if (Server.LockUser(pApplicationName, Username) != 0)
                            throw new ProviderException("SynergyMembershipProvider: Unable to lock out user.");

                    }
                    else
                    {
                        // Password attempts have not exceeded the failure threshold. Update
                        // the failure counts. Leave the window the same.

                        switch (FailureType)
                        {
                            case "password":
                                CallStatus = Server.IncrementPasswordFailures(pApplicationName, Username);
                                break;
                            case "passwordAnswer":
                                CallStatus = Server.IncrementAnswerFailures(pApplicationName, Username);
                                break;
                        }

                        if (CallStatus != 0)
                            throw new ProviderException("SynergyMembershipProvider: Unable to update failure count.");

                    }
                }

            }
            catch (Exception ex)
            {
                ThrowException("UpdateFailureCount", ex);
            }
            finally
            {
                Server.Dispose();
            }

        }

        //
        // CheckPassword
        //   Compares password values based on the MembershipPasswordFormat.
        //
        private bool CheckPassword(string password, string dbpassword)
        {
            string pass1 = password;
            string pass2 = dbpassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Encrypted:
                    pass2 = UnEncodePassword(dbpassword);
                    break;
                case MembershipPasswordFormat.Hashed:
                    pass1 = EncodePassword(password);
                    break;
                default:
                    break;
            }

            if (pass1 == pass2)
            {
                return true;
            }

            return false;
        }

        //
        // EncodePassword
        //   Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
        //
        private string EncodePassword(string password)
        {
            string encodedPassword = password;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:

                    break;
                case MembershipPasswordFormat.Encrypted:
                    encodedPassword = Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    HMACSHA1 hash = new HMACSHA1();
                    hash.Key = HexToByte(machineKey.ValidationKey);
                    encodedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    break;
                default:
                    throw new ProviderException("SynergyMembershipProvider: Unsupported password format.");
            }

            return encodedPassword;
        }

        //
        // UnEncodePassword
        //   Decrypts or leaves the password clear based on the PasswordFormat.
        //
        private string UnEncodePassword(string encodedPassword)
        {
            string password = encodedPassword;

            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:

                    break;
                case MembershipPasswordFormat.Encrypted:
                    password = Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
                    break;
                case MembershipPasswordFormat.Hashed:
                    throw new ProviderException("SynergyMembershipProvider: Cannot unencode a hashed password.");
                default:
                    throw new ProviderException("SynergyMembershipProvider: Unsupported password format.");
            }

            return password;
        }

        //
        // HexToByte
        //   Converts a hexadecimal string to a byte array. Used to convert encryption
        // key values from the configuration.
        //
        private byte[] HexToByte(string hexString)
        {
            byte[] ReturnBytes = new byte[(hexString.Length / 2)];
            for (int i = 0; i <= ReturnBytes.Length - 1; i++)
            {
                ReturnBytes(i) = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return ReturnBytes;
        }

        //
        // MembershipProvider.FindUsersByName
        //
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, ref int totalRecords)
    {

        MembershipUserCollection Users = new MembershipUserCollection();

        ArrayList UserRecords = new ArrayList();
        SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();
        try
        {
            Server.GetUsersByName(pApplicationName, usernameToMatch, pageIndex, pageSize, UserRecords, totalRecords);
        }
        catch (Exception ex) {
            ThrowException("GetUsersByName", ex);
        }
        finally
        {
            Server.Dispose();
        }

        //Did the method return success but no data?
        if (totalRecords == 0)
            return Users;

        //Build the return collection
        SynPSG.ASP.Aspnet_user UserRecord = default(SynPSG.ASP.Aspnet_user);
        foreach ( UserRecord in UserRecords) {
            {
                Users.Add(new MembershipUser(this.Name, UserRecord.Username, new Guid(UserRecord.Pkid), UserRecord.Email, UserRecord.Password_question, UserRecord.Comment, UserRecord.Is_approved, UserRecord.Is_locked_out, ConsolidateDateTime(UserRecord.Created_date, UserRecord.Created_time), ConsolidateDateTime(UserRecord.Last_login_date, UserRecord.Last_login_time),
                ConsolidateDateTime(UserRecord.Last_activity_date, UserRecord.Last_activity_time), ConsolidateDateTime(UserRecord.Last_password_change_date, UserRecord.Last_password_change_time), ConsolidateDateTime(UserRecord.Last_locked_out_date, UserRecord.Last_locked_out_date)));
            }
        }

        return Users;

    }

        //
        // MembershipProvider.FindUsersByEmail
        //
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, ref int totalRecords)
    {

        MembershipUserCollection Users = new MembershipUserCollection();

        ArrayList UserRecords = new ArrayList();
        SynPSG.ASP.AspProvider Server = new SynPSG.ASP.AspProvider();
        try {
            Server.GetUsersByEmail(pApplicationName, emailToMatch, pageIndex, pageSize, UserRecords, totalRecords);
        } catch (Exception ex) {
            ThrowException("GetUsersByEmail", ex);
        } finally {
            Server.Dispose();
        }

        //Did the method return success but no data?
        if (totalRecords == 0)
            return Users;

        //Build the return collection
        SynPSG.ASP.Aspnet_user UserRecord = default(SynPSG.ASP.Aspnet_user);
        foreach ( UserRecord in UserRecords) {
            {
                Users.Add(new MembershipUser(this.Name, UserRecord.Username, new Guid(UserRecord.Pkid), UserRecord.Email, UserRecord.Password_question, UserRecord.Comment, UserRecord.Is_approved, UserRecord.Is_locked_out, ConsolidateDateTime(UserRecord.Created_date, UserRecord.Created_time), ConsolidateDateTime(UserRecord.Last_login_date, UserRecord.Last_login_time),
                ConsolidateDateTime(UserRecord.Last_activity_date, UserRecord.Last_activity_time), ConsolidateDateTime(UserRecord.Last_password_change_date, UserRecord.Last_password_change_time), ConsolidateDateTime(UserRecord.Last_locked_out_date, UserRecord.Last_locked_out_date)));
            }
        }

        return Users;

    }

        private void ThrowException(string MethodName, Exception ex)
        {
            if (pWriteExceptionsToEventLog)
            {
                WriteToEventLog(MethodName, ex);
                throw new ProviderException(exceptionMessage);
            }
            else
            {
                throw ex;
            }
        }


        //
        // WriteToEventLog
        //   A helper function that writes exception detail to the event log. Exceptions
        // are written to the event log as a security measure to aSub Private database
        // details from being Returned to the browser. If a method does not Return a status
        // or boolean indicating the action succeeded or failed, a generic exception is also 
        // Thrown by the caller.
        //

        private void WriteToEventLog(string MethodName, Exception e)
        {
            EventLog log = new EventLog();
            log.Source = eventSource;
            log.Log = eventLog;
            string message = "Failed to call Synergy method " + MethodName + Environment.NewLine;
            message += "Exception: " + e.ToString();
            log.WriteEntry(message);
        }

        private System.DateTime ConsolidateDateTime(ref System.DateTime DateVar, ref System.DateTime TimeVar)
        {
            return new System.DateTime(DateVar.Year, DateVar.Month, DateVar.Day, TimeVar.Hour, TimeVar.Minute, TimeVar.Second);
        }

        private DateTime OneDateFromTwo(DateTime SourceDate, DateTime SourceTime)
        {
            DateTime NewDateTime = default(DateTime);
            NewDateTime = new DateTime(SourceDate.Year, SourceDate.Month, SourceDate.Day, SourceTime.Hour, SourceTime.Minute, SourceTime.Second);
            return NewDateTime;
        }
    }
}