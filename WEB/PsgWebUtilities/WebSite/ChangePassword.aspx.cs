using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.DirectoryServices;
using ActiveDs;



public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        if (txtNewPassword1.Text!=txtNewPassword2.Text)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Passwords don't match";
        }
        else
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://psg.loc",txtUsername.Text,txtOldPassword.Text,AuthenticationTypes.Secure);
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + txtUsername.Text + ")";
            search.SearchScope = SearchScope.Subtree;
            search.CacheResults = false;

            SearchResultCollection results = search.FindAll();
            if (results.Count > 0)
            {
                foreach (SearchResult result in results)
                {
                    try
                    {
                        entry = result.GetDirectoryEntry();
                    }
                    catch (Exception error)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = error.Message.ToString();
                    }
                }

                try
                {
                    entry.Invoke("ChangePassword", new object[] { txtOldPassword.Text, txtNewPassword1.Text });
                    entry.CommitChanges();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Your password was changed. When you click the Back to Site button you will need to log in using your new credientials.";
                }
                catch (Exception)
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Password couldn't be changed due to restrictions";
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "User not found or bad password";
            }
        }

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://psg.synergex.com", true);
    }
}
