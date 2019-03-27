using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System;
using System.Data.SqlClient;

namespace Database_1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public WebForm2()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            btnLogIn.Attributes.Add("class", "static");
            btnLogIn.Attributes.Add("onMouseOver", "this.className='hoverbutton'");
            btnLogIn.Attributes.Add("onMouseOut", "this.className='static'");
            // Dim navigation As Control = Master.FindControl("navigation")
            // navigation.Visible = False
            // Dim Page_name As Control = Me.Master.FindControl("Page_name")
            // 'Page_name. = "Login Page"
            Label Main_Menu = Master.FindControl("Main_Menu");
            Main_Menu.Text = "Login Page";
        }

        private void Validate_User()
        {
            // Connection String
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;
            // ' Dim userid As String = Session("user").ToString
            using (SqlConnection conn = new SqlConnection(CS))
            {
                // Dim cmd As SqlCommand = New SqlCommand("[PCM].[spValidate_User]", conn)
                using (SqlCommand cmd = new SqlCommand("[PCM].spValidate_User", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UNM", txtUNM.Text.Trim());
                    cmd.Parameters.AddWithValue("@PWD", txtPWD.Text.Trim());

                    cmd.Parameters.Add("@Msg", SqlDbType.VarChar, 96);
                    cmd.Parameters["@Msg"].Direction = ParameterDirection.Output;

                    cmd.Parameters.Add("@UID", SqlDbType.SmallInt);
                    cmd.Parameters["@UID"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Greet_NM", SqlDbType.VarChar, 40);
                    cmd.Parameters["@Greet_NM"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@Role", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Role"].Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    if (cmd.Parameters["@Msg"].Value.ToString() == "Valid")
                    {
                        Session["user"] = cmd.Parameters["@UNM"].Value.ToString();
                        Session["Greet"] = cmd.Parameters["@Greet_NM"].Value.ToString();

                        Response.Redirect("Master_Data.aspx");
                    }
                    else
                        lblMsg.Text = cmd.Parameters["@Msg"].Value.ToString();
                }
            }
        }



        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Validate_User();
        }

        protected void txtUNM_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
