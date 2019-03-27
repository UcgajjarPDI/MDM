using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web.UI;
using System;
using System.Data.SqlClient;

namespace Database_1
{
    public partial class Master_Data : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Btn_Gd1_Save.Visible = false;
            if (!IsPostBack)
            {
                // GetMasterData()
                Label Page_name = Master.FindControl("Page_name");
                Label Main_Menu = Master.FindControl("Main_Menu");
                Page_name.Text = "Master Data";
                Main_Menu.Text = "Sales Tracing";
                Getdropdown_terr();
            }
        }
        private void GetMasterData()
        {
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {

                // SQL Command - the name have to exactly the same as in SQL server database in Exec command
                SqlCommand cmd1 = new SqlCommand("[MDM].[spTRC_GET_CO_USR_FEEDBK]", conn1);
                cmd1.CommandType = CommandType.StoredProcedure;
                // define parameter -- the parameter name have to exactly how it is in the store dprocedure

                SqlParameter Param3 = cmd1.Parameters.AddWithValue("@TERR_ID", drop_ter.SelectedValue.ToString());
                SqlParameter Param4 = cmd1.Parameters.AddWithValue("@RSTATUS", drp_Filter.SelectedValue.ToString());

                Param3.Direction = ParameterDirection.Input;
                Param4.Direction = ParameterDirection.Input;
                try
                {
                    // open connection
                    conn1.Open();

                    // read the data
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    gd1.DataSource = ds;
                    gd1.DataBind();
                    Btn_Gd1_Save.Visible = true;
                }
                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }

        private void Getdropdown_terr()
        {
            drop_ter.Items.Add(new ListItem("--Select--", ""));
            drop_ter.AppendDataBoundItems = true;
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;



            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {

                // SQL Command - the name have to exactly the same as in SQL server database in Exec command
                SqlCommand cmd1 = new SqlCommand("[MDM].[spDISPLAY_TERR]", conn1);
                cmd1.CommandType = CommandType.StoredProcedure;
                // define parameter -- the parameter name have to exactly how it is in the store dprocedure
                cmd1.Connection = conn1;

                try
                {
                    // open connection
                    conn1.Open();

                    drop_ter.DataSource = cmd1.ExecuteReader();
                    drop_ter.DataTextField = "TERRITORY_NAME";
                    drop_ter.DataValueField = "TERRITORY_ID";
                    drop_ter.DataBind();
                }


                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }
        private void save_gd1()
        {
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {



                // 'SQL Command - the name have to exactly the same as in SQL server database in Exec command
                // cmd As SqlCommand = New SqlCommand("MDM.spTRC_SAVE_CO_USR_FEEDBK", conn1)
                // cmd.CommandType = CommandType.StoredProcedure
                SqlParameter para1 = new SqlParameter();
                SqlParameter para2 = new SqlParameter();
                // define parameter -- the parameter name have to exactly how it is in the store dprocedure
                foreach (GridViewRow row in gd1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                        bool rd1 = row.Cells[5].Controls.OfType<RadioButton>().FirstOrDefault().Checked;
                        bool rd2 = row.Cells[6].Controls.OfType<RadioButton>().FirstOrDefault().Checked;



                        if (isChecked)
                        {
                            if (rd1)
                            {
                                using (SqlCommand cmd = new SqlCommand("MDM.spTRC_SAVE_CO_USR_FEEDBK", conn1))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    para1 = cmd.Parameters.AddWithValue("@FEEDBK_ID", row.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text);
                                    para2 = cmd.Parameters.AddWithValue("@FEEDBK", "A");
                                    para1.Direction = ParameterDirection.Input;
                                    para2.Direction = ParameterDirection.Input;
                                    conn1.Open();


                                    cmd.ExecuteNonQuery();
                                    conn1.Close();
                                }
                            }
                            else if (rd2)
                            {
                                using (SqlCommand cmd = new SqlCommand("MDM.spTRC_SAVE_CO_USR_FEEDBK", conn1))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    para1 = cmd.Parameters.AddWithValue("@FEEDBK_ID", row.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text);
                                    para2 = cmd.Parameters.AddWithValue("@FEEDBK", "R");
                                    para1.Direction = ParameterDirection.Input;
                                    para2.Direction = ParameterDirection.Input;
                                    conn1.Open();


                                    cmd.ExecuteNonQuery();
                                    conn1.Close();
                                }
                            }
                            else
                            {
                                Lbl_Error.EnableViewState = true;
                                Lbl_Error.Text = "Please Accept or Reject";
                            }
                        }
                    }
                }


                try
                {
                }
                // open connection


                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }
        protected void gd1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void gd1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gd1.PageIndex = e.NewPageIndex;
            GetMasterData();
        }

        protected void btn_drop_Click(object sender, EventArgs e)
        {
            if (drop_ter.SelectedValue == "")
            {
                Lbl_Error.EnableViewState = true;
                Lbl_Error.Text = "Please Select Territory and Filter";
                gd1.Visible = false;
                Btn_Gd1_Save.Visible = false;
            }
            else if (drp_Filter.SelectedValue == "")
            {
                Lbl_Error.EnableViewState = true;
                Lbl_Error.Text = "Please Select Territory and Filter";
                gd1.Visible = false;
                Btn_Gd1_Save.Visible = false;
            }
            else
            {
                Lbl_Error.EnableViewState = false;
                GetMasterData();
                gd1.Visible = true;
                Btn_Gd1_Save.Visible = true;
            }
        }

        protected void Btn_Gd1_Save_Click(object sender, EventArgs e)
        {
            save_gd1();
            GetMasterData();
        }

        protected void drp_Filter_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void drop_ter_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
