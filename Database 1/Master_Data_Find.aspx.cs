using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace Database_1
{
    public partial class MDM_Search1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {

            // Lbl_name.Text = Session("fi_na").ToString
            // lbl_add1.Text = Session("fi_a1").ToString
            // lbl_add2.Text = Session("fi_a2").ToString
            // lbl_city.Text = Session("fi_ci").ToString
            // lbl_st.Text = Session("fi_st").ToString
            // lbl_zip.Text = Session("fi_zip").ToString

            ERR.Visible = false;
            err2.Visible = false;
            err3.Visible = false;

            // Button2.Visible = False

            if (!IsPostBack)
                // Button2.Visible = False
                gd_un_show();
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
                gd2_show();
                Button2.Visible = true;
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


                // Dim output As SqlParameter = cmd1.Parameters.Add("@Msg", SqlDbType.VarChar, 200)
                // output.Direction = ParameterDirection.Output


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
                // Button2.Visible = True




                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }
        public void gd2_show()
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
                SqlCommand cmd1 = new SqlCommand("[CMPNY].[spSRCH_CMS_CMPNY]", conn1);
                cmd1.CommandType = CommandType.StoredProcedure;

                // define parameter -- the parameter name have to exactly how it is in the store dprocedure




                SqlParameter Param3 = cmd1.Parameters.AddWithValue("@CO_NM", txt_name.Text);
                SqlParameter Param4 = cmd1.Parameters.AddWithValue("@CO_ZIP ", Zip_txt.Text);
                SqlParameter Param5 = cmd1.Parameters.AddWithValue("@CO_ADDR ", txt_add.Text);
                SqlParameter Param6 = cmd1.Parameters.AddWithValue("@CO_CITY ", txt_city.Text);
                SqlParameter Param7 = cmd1.Parameters.AddWithValue("@CO_ST ", txt_st.Text);


                // Dim output As SqlParameter = cmd1.Parameters.Add("@Msg", SqlDbType.VarChar, 200)
                // output.Direction = ParameterDirection.Output


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







                    gd2.DataSource = ds;
                    gd2.DataBind();
                }
                // Button2.Visible = True




                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }
        // Protected Sub btnShowPopUp54_Click(sender As Object, e As ImageClickEventArgs) Handles btnShowPopUp54.Click
        // Response.Redirect("Master_Data_Find.aspx")
        // End Sub

        // Protected Sub btnShowPopUp23_Click(sender As Object, e As EventArgs) Handles btnShowPopUp23.Click
        // Response.Redirect("Master_Data_Find.aspx")
        // End Sub



        private void gd1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gd1.PageIndex = e.NewPageIndex;
            gd1_show();
            gd1.DataBind();
        }





        public void gd_un_show()
        {
            gd_un.DataSourceID = null;
            gd_un.EditIndex = -1;
            gd_un.DataBind();
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                string x = string.Empty;

                // SQL Command - the name have to exactly the same as in SQL server database in Exec command
                SqlCommand cmd1 = new SqlCommand(@"select top 1000 TRC_ENDUSER_1_ID as COMPANY_ID , T.DISTCOID AS SRC_ID,
                                                        DISTID SOURCE_NM, DISTACCTID , DISTACCTSHIPNAME as CMPNY_NM, 
                                                        DISTACCTSHIPADDR1 as ADDR_1, DISTACCTSHIPCITY AS CITY, DISTACCTSHIPSTATE AS ST,
                                                        DISTACCTSHIPZIP AS ZIP ,
                                                        convert(varchar,cast(SALES_SUM as money),1) AS SALES_AMT,'YES' as  PDI_CUSTOMER
                                                        FROM STAGE.TRC_ENDUSER_3K T
                                                        LEFT JOIN MDM_STAGE.CMPNY_MATCH_XREF C ON T.TRC_ENDUSER_1_ID = C.SRC_DATA_ID 
                                                        WHERE
                                                        T.COMPANY_ID is NULL
                                                        AND C.SRC_DATA_ID IS NULL
                                                        ORDER BY SALES_SUM DESC", conn1);
                // cmd1.CommandType = CommandType.StoredProcedure
                // define parameter -- the parameter name have to exactly how it is in the store dprocedure






                // Dim output As SqlParameter = cmd1.Parameters.Add("@Msg", SqlDbType.VarChar, 200)
                // output.Direction = ParameterDirection.Output



                try
                {
                    // open connection
                    conn1.Open();
                    // read the data
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);

                    DataSet ds = new DataSet();
                    adapter.Fill(ds);







                    gd_un.DataSource = ds;
                    gd_un.DataBind();
                }

                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            err3.Visible = false;
            string srcids;
            string distaccids;
            Int64 company_ids;
            string sources;
            Int64 cmnpny_ids;


            foreach (GridViewRow row in gd_un.Rows)
            {
                bool isSelected = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                if (isSelected)
                {
                    srcids = row.Cells[1].Controls.OfType<HiddenField>().FirstOrDefault().Value;
                    distaccids = row.Cells[2].Controls.OfType<HiddenField>().FirstOrDefault().Value;
                    company_ids = Convert.ToInt64(row.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text);
                }
            }
            if (srcids == null)
            {
                err3.Visible = true;
                err3.Text = "Please Select Unmatched Record";
            }
            foreach (GridViewRow row in gd1.Rows)
            {
                bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                if (isChecked)
                {
                    sources = row.Cells[7].Controls.OfType<Label>().FirstOrDefault().Text;
                    cmnpny_ids = Convert.ToInt64(row.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text);
                }
            }
            foreach (GridViewRow row in gd2.Rows)
            {
                bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                if (isChecked)
                {
                    sources = row.Cells[7].Controls.OfType<Label>().FirstOrDefault().Text;
                    cmnpny_ids = Convert.ToInt64(row.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text);
                }
            }
            if (sources == null)
            {
                err3.Visible = true;
                err3.Text = "Please Select Searched Record";
            }
            if (err3.Visible == false)
            {
                string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;

                // SQL Conection
                using (SqlConnection conn1 = new SqlConnection(CS))
                {
                    SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [MDM_STAGE].[CMPNY_MATCH_XREF]
                                                           (
                                                           [SRC_ID]
                                                           ,[SRC_ACCT_ID]
                                                           ,[SRC_DATA_ID]
                                                           ,[MTCH_To_TYPE]
                                                           ,[MTCH_To_ID]
                                                           )
                                                        values(@src,@dist,@com,@sour,@cmp)", conn1);

                    SqlParameter Param3 = cmd1.Parameters.AddWithValue("@src", srcids);
                    SqlParameter Param4 = cmd1.Parameters.AddWithValue("@dist ", distaccids);
                    SqlParameter Param5 = cmd1.Parameters.AddWithValue("@com ", company_ids);
                    SqlParameter Param6 = cmd1.Parameters.AddWithValue("@sour ", sources);
                    SqlParameter Param7 = cmd1.Parameters.AddWithValue("@cmp ", cmnpny_ids);
                    Param3.Direction = ParameterDirection.Input;
                    Param4.Direction = ParameterDirection.Input;
                    Param5.Direction = ParameterDirection.Input;
                    Param6.Direction = ParameterDirection.Input;
                    Param7.Direction = ParameterDirection.Input;

                    try
                    {
                        conn1.Open();
                        cmd1.ExecuteNonQuery();
                    }

                    finally
                    {
                        // close the connection
                        if ((!(conn1 == null)))
                            conn1.Close();
                    }
                }
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void Man_match_Click(object sender, EventArgs e)
        {
            string srcids;
            string distaccids;
            Int64 company_ids;
            foreach (GridViewRow row in gd_un.Rows)
            {
                bool isSelected = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                if (isSelected)
                {
                    srcids = row.Cells[1].Controls.OfType<HiddenField>().FirstOrDefault().Value;
                    distaccids = row.Cells[2].Controls.OfType<HiddenField>().FirstOrDefault().Value;
                    company_ids = Convert.ToInt64(row.Cells[1].Controls.OfType<Label>().FirstOrDefault().Text);
                }
            }

            if (srcids == null)
            {
                err2.Visible = true;
                err2.Text = "Please Checked Unmatched Record";
            }
            if (err2.Visible == false)
            {
                string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;

                // SQL Conection
                using (SqlConnection conn1 = new SqlConnection(CS))
                {
                    SqlCommand cmd1 = new SqlCommand(@"INSERT INTO [MDM_STAGE].[CMPNY_MATCH_XREF]
                                                           (
                                                           [SRC_ID]
                                                           ,[SRC_ACCT_ID]
                                                           ,[SRC_DATA_ID]
                                                           ,[MTCH_To_CMPNY_NM]
                                                           ,[MTCH_To_CMPNY_ADDR_1]
                                                           ,[MTCH_To_CMPNY_CITY]
                                                           ,[MTCH_To_CMPNY_STATE]
                                                           ,[MTCH_To_CMPNY_ZIP]
                                                           )
                                                        values(@src,@dist,@com,@nm,@add1,@city,@st,@zip)", conn1);
                    SqlParameter Param3 = cmd1.Parameters.AddWithValue("@src", srcids);
                    SqlParameter Param4 = cmd1.Parameters.AddWithValue("@dist ", distaccids);
                    SqlParameter Param5 = cmd1.Parameters.AddWithValue("@com ", company_ids);
                    SqlParameter Param6 = cmd1.Parameters.AddWithValue("@nm ", TextBox1.Text);
                    SqlParameter Param7 = cmd1.Parameters.AddWithValue("@add1 ", TextBox2.Text);
                    SqlParameter Param8 = cmd1.Parameters.AddWithValue("@city ", TextBox3.Text);
                    SqlParameter Param9 = cmd1.Parameters.AddWithValue("@st ", TextBox4.Text);
                    SqlParameter Param10 = cmd1.Parameters.AddWithValue("@zip ", TextBox5.Text);
                    Param3.Direction = ParameterDirection.Input;
                    Param4.Direction = ParameterDirection.Input;
                    Param5.Direction = ParameterDirection.Input;
                    Param6.Direction = ParameterDirection.Input;
                    Param7.Direction = ParameterDirection.Input;
                    Param8.Direction = ParameterDirection.Input;
                    Param9.Direction = ParameterDirection.Input;
                    Param10.Direction = ParameterDirection.Input;
                    try
                    {
                        conn1.Open();
                        cmd1.ExecuteNonQuery();
                    }

                    finally
                    {
                        // close the connection
                        if ((!(conn1 == null)))
                            conn1.Close();
                    }
                }

                Response.Redirect(Request.RawUrl);
            }
        }

        protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            // Dim chk As CheckBox = CType(gd1.Rows.FindControl("chkAll"), CheckBox)
            foreach (GridViewRow row in gd1.Rows)
            {
                bool isSelected = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                if (isSelected)
                {
                    // row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = False
                    foreach (GridViewRow row1 in gd2.Rows)
                        row1.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked = false;
                }
            }
        }

        protected void CheckBoxAll1_CheckedChanged(object sender, EventArgs e)
        {
            // Dim chk As CheckBox = CType(gd1.Rows.FindControl("chkAll"), CheckBox)
            foreach (GridViewRow row in gd2.Rows)
            {
                bool isSelected = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                if (isSelected)
                {
                    // row.Cells(0).Controls.OfType(Of CheckBox)().FirstOrDefault().Checked = False
                    foreach (GridViewRow row1 in gd1.Rows)
                        row1.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked = false;
                }
            }
        }

        private void gd_un_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gd_un.PageIndex = e.NewPageIndex;

            gd_un_show();
            gd_un.DataBind();
        }

        private void gd2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gd2.PageIndex = e.NewPageIndex;
            gd2_show();
            gd2.DataBind();

            gd1_show();
        }
    }
}
