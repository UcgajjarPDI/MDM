using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Linq;
using System;
using System.Data.SqlClient;

namespace Database_1
{
    public partial class Active_Contract : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                GetContractData30();
                GetContractData60();
                Label Page_name = Master.FindControl("Page_name");
                Label Main_Menu = Master.FindControl("Main_Menu");
                Page_name.Text = "Active Contracts";
                Main_Menu.Text = "Contract Management";
            }
        }

        private void GetContractData30()
        {
            // Connection String
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn = new SqlConnection(CS))
            {

                // SQL Command - the name have to exactly the same as in SQL server database in Exec command
                SqlCommand cmd = new SqlCommand("[PCM].[spPCM_Get_Contract_30]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // define parameter -- the parameter name have to exactly how it is in the store dprocedure
                SqlParameter Param1 = cmd.Parameters.AddWithValue("@UNM", Session["user"].ToString());
                Param1.Direction = ParameterDirection.Input;




                try
                {
                    // open connection
                    conn.Open();

                    // read the data
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    // bind the data
                    // CntRepeater.DataSource = ds
                    // CntRepeater.DataBind()
                    // GridView1.DataSource = ds
                    // GridView1.DataBind()

                    gd1.DataSource = ds;
                    gd1.DataBind();


                    // msgLabel.Text = " Total Record found -" & Param1.Value
                    if (gd1.Rows.Count == 0)
                    {
                        gd1.Visible = false;
                        visible1.Visible = true;
                        visible1.Text = "No contract is Expiering in 30 days";
                    }
                }
                finally
                {
                    // close the connection
                    if ((!(conn == null)))
                        conn.Close();
                }
            }
        }
        private void GetContractData60()
        {
            // Connection String
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn = new SqlConnection(CS))
            {

                // SQL Command - the name have to exactly the same as in SQL server database in Exec command
                SqlCommand cmd = new SqlCommand("[PCM].[spPCM_Get_Contract_60]", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // define parameter -- the parameter name have to exactly how it is in the store dprocedure
                SqlParameter Param1 = cmd.Parameters.AddWithValue("@UNM", Session["user"].ToString());
                Param1.Direction = ParameterDirection.Input;




                try
                {
                    // open connection
                    conn.Open();

                    // read the data
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    // bind the data
                    // CntRepeater.DataSource = ds
                    // CntRepeater.DataBind()
                    // GridView1.DataSource = ds
                    // GridView1.DataBind()

                    gd2.DataSource = ds;
                    gd2.DataBind();


                    // msgLabel.Text = " Total Record found -" & Param1.Value
                    if (gd2.Rows.Count == 0)
                    {
                        gd2.Visible = false;
                        visible2.Visible = true;
                        visible2.Text = "No contract is Expiering in 60 days";
                    }
                }
                finally
                {
                    // close the connection
                    if ((!(conn == null)))
                        conn.Close();
                }
            }
        }


        protected void gd1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Ct_like();
        }

        private void Ct_like()
        {
            foreach (GridViewRow row1 in gd1.Rows)
            {
                if (row1.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkcheck = (CheckBox)row1.FindControl("ckpop1");
                    string rd1 = row1.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text;
                    if (chkcheck.Checked == true)
                    {
                        Session["CNT"] = rd1.ToString();
                        Response.Redirect("Create_Alike.aspx");
                    }
                }
            }
            foreach (GridViewRow row2 in gd2.Rows)
            {
                if (row2.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkcheck1 = (CheckBox)row2.FindControl("chkCheck");
                    string rd2 = row2.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text;
                    if (chkcheck1.Checked == true)
                    {
                        Session["CNT"] = rd2.ToString();

                        Response.Redirect("Create_Alike.aspx");
                    }
                }
            }
        }
    }
}
