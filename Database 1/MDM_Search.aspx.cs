using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI;
using System;
using System.Data.SqlClient;

namespace Database_1
{
    public partial class MDM_Search : Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            ERR.Visible = false;
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> getco_name(string prefixText, int count)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con2"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select [CMPNY_NM]from CMPNY.company where [CMPNY_NM] like @Name +'%'", con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> CountryNames = new List<string>();
            var loopTo = dt.Rows.Count - 1;
            for (int i = 0; i <= loopTo; i++)
            {
                CountryNames.Add(dt.Rows[i][0].ToString());
                if (i >= 10)
                    break;
            }

            return CountryNames;
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> getco_name_other(string prefixText, int count)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con2"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select [CMPNY_ALT_NM] from [CMPNY].[COMPANY] where [CMPNY_ALT_NM] like @Name +'%'", con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> CountryNames = new List<string>();
            var loopTo = dt.Rows.Count - 1;
            for (int i = 0; i <= loopTo; i++)
            {
                CountryNames.Add(dt.Rows[i][0].ToString());
                if (i >= 10)
                    break;
            }

            return CountryNames;
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> getco_add(string prefixText, int count)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con2"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select [CMPNY_ADDR_1] from [CMPNY].[COMPANY] where [CMPNY_ADDR_1] like @Name +'%'", con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> CountryNames = new List<string>();
            var loopTo = dt.Rows.Count - 1;
            for (int i = 0; i <= loopTo; i++)
            {
                CountryNames.Add(dt.Rows[i][0].ToString());
                if (i >= 10)
                    break;
            }

            return CountryNames;
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> getco_city(string prefixText, int count)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con2"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct [CMPNY_CITY] from [CMPNY].[COMPANY] where [CMPNY_CITY] like @Name +'%'", con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> CountryNames = new List<string>();
            var loopTo = dt.Rows.Count - 1;
            for (int i = 0; i <= loopTo; i++)
            {
                CountryNames.Add(dt.Rows[i][0].ToString());
                if (i >= 10)
                    break;
            }

            return CountryNames;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> getco_st(string prefixText, int count)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con2"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct [CMPNY_ST] from [CMPNY].[COMPANY] where [CMPNY_ST] like @Name +'%'", con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> CountryNames = new List<string>();
            var loopTo = dt.Rows.Count - 1;
            for (int i = 0; i <= loopTo; i++)
            {
                CountryNames.Add(dt.Rows[i][0].ToString());
                if (i >= 10)
                    break;
            }

            return CountryNames;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> getco_zip(string prefixText, int count)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Con2"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("select distinct [CMPNY_ZIP] from [CMPNY].[COMPANY] where [CMPNY_ZIP] like @Name +'%'", con);
            cmd.Parameters.AddWithValue("@Name", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<string> CountryNames = new List<string>();
            var loopTo = dt.Rows.Count - 1;
            for (int i = 0; i <= loopTo; i++)
            {
                CountryNames.Add(dt.Rows[i][0].ToString());
                if (i >= 10)
                    break;
            }

            return CountryNames;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            gd1.Visible = false;

            if (string.IsNullOrEmpty(txt_name.Text) & string.IsNullOrEmpty(txt_add.Text.ToString()))
            {
                ERR.Visible = true;
                ERR.Text = "At least name or alternate name or street address is needed to run a search";
            }
            else
            {
                gd1.Visible = true;
                gd1_show();
            }
        }
        public void gd1_show()
        {
            gd1.DataSourceID = null;
            gd1.EditIndex = -1;
            gd1.DataBind();
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                string x = string.Empty;

                // SQL Command - the name have to exactly the same as in SQL server database in Exec command
                SqlCommand cmd1 = new SqlCommand("[CMPNY].[spSRCH_CMPNY]", conn1);
                cmd1.CommandType = CommandType.StoredProcedure;
                // define parameter -- the parameter name have to exactly how it is in the store dprocedure

                SqlParameter Param3 = cmd1.Parameters.AddWithValue("@CO_NM", txt_name.Text);
                SqlParameter Param4 = cmd1.Parameters.AddWithValue("@CO_ZIP ", Zip_txt.Text);
                SqlParameter Param5 = cmd1.Parameters.AddWithValue("@CO_ADDR ", txt_add.Text);
                SqlParameter Param6 = cmd1.Parameters.AddWithValue("@CO_CITY ", txt_city.Text);
                SqlParameter Param7 = cmd1.Parameters.AddWithValue("@CO_ST ", txt_st.Text);
                Param3.Direction = ParameterDirection.Input;
                Param4.Direction = ParameterDirection.Input;
                Param5.Direction = ParameterDirection.Input;
                Param6.Direction = ParameterDirection.Input;
                Param7.Direction = ParameterDirection.Input;

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
                }
                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }

        protected void txt_name_TextChanged(object sender, EventArgs e)
        {
        }

        private void gd1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gd1.PageIndex = e.NewPageIndex;
            gd1_show();
        }

        private void gd1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int pageSize = gd1.PageSize;
            int pageIndex = gd1.PageIndex;

            int newRowIndex = 0;

            if (pageIndex > 0)
            {
                newRowIndex = pageIndex * pageSize;
                rowIndex = rowIndex - newRowIndex;
            }
            if (e.CommandName == "select")
            {

                // row.Cells(CellIndex).Text
                string CompanyID = ((Label)gd1.Rows[rowIndex].FindControl("COMPANY_ID")).Text;
                Response.Redirect("MDM_Network.aspx?id=" + CompanyID.ToString());
            }
            else if (e.CommandName == "search")
            {
                string CompanyID = ((Label)gd1.Rows[rowIndex].FindControl("COMPANY_ID")).Text;
                GetCompanySalesDetails(int.Parse(CompanyID));
            }
        }
        private void GetCompanySalesDetails(int cmpnyId)
        {
            string CS = ConfigurationManager.ConnectionStrings["Con1"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("CNT.spGET_COMPANY_SALES_DETAILS", conn1);
                cmd.CommandType = CommandType.StoredProcedure;
                // define parameter -- the parameter name have to exactly how it is in the store dprocedure
                SqlParameter CompanyID = cmd.Parameters.AddWithValue("@cmpnyId", cmpnyId);
                CompanyID.Direction = ParameterDirection.Input;

                try
                {
                    conn1.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        lblSani.Text = dt.Rows[0]["SANI_SURFACE"].ToString();
                        lblPrevantics.Text = dt.Rows[0]["Prevantics"].ToString();
                        lblBabyWipes.Text = dt.Rows[0]["BABY_WIPES"].ToString();
                        lblOthers.Text = dt.Rows[0]["OTHER"].ToString();
                        lblTotal.Text = dt.Rows[0]["SALES_AMT"].ToString();
                        lblAdultWipes.Text = dt.Rows[0]["ADULT_WIPES"].ToString();
                        lblCompAcc.Text = dt.Rows[0]["Comp_Acc"].ToString();
                        lblHygea.Text = dt.Rows[0]["Hygea"].ToString();
                        lblIodine.Text = dt.Rows[0]["Iodine"].ToString();
                        lblSaniHands.Text = dt.Rows[0]["SANI_HANDS"].ToString();
                        lblSpecial.Text = dt.Rows[0]["Specialty"].ToString();
                    }
                }
                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }
    }
}
