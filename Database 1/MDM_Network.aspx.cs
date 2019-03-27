using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System;
using System.Data.SqlClient;

namespace Database_1
{
    public partial class MDM_Network : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id;
            try
            {
                id = Request.QueryString["id"].ToString();
                Session["compId"] = id;
            }
            catch (Exception ex)
            {
                Response.Redirect("MDM_Search.aspx");
            }

            if (!IsPostBack)
            {
                gd_company_load(id);
                gd_IDN_company_load(id);
                gd_parent_company_load(id);
                gd_network_company_load(id);
                gd_child_company_load(id);
                gd_aff_company_load(id);
            }
        }

        public void gd_company_load(string id)
        {
            string CS = ConfigurationManager.ConnectionStrings["Con1"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand(@"SELECT C.CMPNY_ID, 'SELF' as relation , C.CMPNY_NM,  C.CMPNY_ADDR_1, C.CMPNY_CITY, C.CMPNY_ST,
C.CMPNY_ZIP,C.BUYER_INDICATOR as  PDI_CUSTOMER 
,CONVERT(varchar, CAST( ROUND(cs.[TOTAL SALES PRIOR YEAR],0) AS money), 1) AS SALES_AMT
 from cmpny.company C  
 LEFT JOIN CMPNY.CMPNY_SALES cs ON cs.CMPNY_ID = c.CMPNY_ID 
                                                        WHERE C.CMPNY_ID =" + id.ToString(), conn1);

                try
                {
                    // open connection
                    conn1.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);


                    gd_company.DataSource = ds;
                    gd_company.DataBind();
                }

                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }
        public void gd_IDN_company_load(string id)
        {
            string CS = ConfigurationManager.ConnectionStrings["Con1"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand(@"SELECT CI.CMPNY_ID, 'IDN', CI.CMPNY_NM,
                        CI.CMPNY_ADDR_1, CI.CMPNY_CITY, CI.CMPNY_ST, CI.CMPNY_ZIP,CI.BUYER_INDICATOR as  PDI_CUSTOMER
                        ,CONVERT(varchar, CAST( ROUND(cs.[TOTAL SALES PRIOR YEAR],0) AS money), 1) AS SALES_AMT
                        from cmpny.company C 
                        JOIN cmpny.company CI ON CI.CMPNY_ID = C.IDN_CMPNY_ID
                        LEFT JOIN CMPNY.CMPNY_SALES cs ON cs.CMPNY_ID = cI.CMPNY_ID 
                                                     WHERE C.CMPNY_ID =" + id.ToString(), conn1);

                try
                {
                    // open connection
                    conn1.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);


                    gd_IDN.DataSource = ds;
                    gd_IDN.DataBind();
                }

                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }

        public void gd_parent_company_load(string id)
        {
            string CS = ConfigurationManager.ConnectionStrings["Con1"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand(@"SELECT CP.CMPNY_ID, 'Org. Parent', CP.CMPNY_NM, 
                            CP.CMPNY_ADDR_1, CP.CMPNY_CITY, CP.CMPNY_ST, CP.CMPNY_ZIP,CP.BUYER_INDICATOR as  PDI_CUSTOMER
                            ,CONVERT(varchar, CAST( ROUND(cs.[TOTAL SALES PRIOR YEAR],0) AS money), 1) AS SALES_AMT
                            From cmpny.company C Join cmpny.company CP ON CP.CMPNY_ID = C.CMPNY_PRNT_ID
                            LEFT JOIN CMPNY.CMPNY_SALES cs ON cs.CMPNY_ID = cP.CMPNY_ID 
                            Where C.CMPNY_ID =" + id.ToString(), conn1);

                try
                {
                    // open connection
                    conn1.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);


                    gd_parent.DataSource = ds;
                    gd_parent.DataBind();
                }

                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }
        public void gd_network_company_load(string id)
        {
            string CS = ConfigurationManager.ConnectionStrings["Con1"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand(@"Select CI.CMPNY_ID, 'IN NETWORK' as relation, CI.CMPNY_NM, 
                                            CI.CMPNY_ADDR_1, CI.CMPNY_CITY, CI.CMPNY_ST, CI.CMPNY_ZIP,CI.BUYER_INDICATOR as  PDI_CUSTOMER
                                            ,CONVERT(varchar, CAST( ROUND(cs.[TOTAL SALES PRIOR YEAR],0) AS money), 1) AS SALES_AMT 
                                            from cmpny.company C 
                                            JOIN cmpny.company CI ON CI.IDN_CMPNY_ID = C.IDN_CMPNY_ID
                                            LEFT JOIN CMPNY.CMPNY_SALES cs ON cs.CMPNY_ID = CI.CMPNY_ID  
                                                        WHERE C.CMPNY_ID = '" + id.ToString() + "' AND CI.CMPNY_ID <>" + id.ToString(), conn1);

                try
                {
                    // open connection
                    conn1.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);


                    gd_network.DataSource = ds;
                    gd_network.DataBind();
                }

                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }
        public void gd_child_company_load(string id)
        {
            string CS = ConfigurationManager.ConnectionStrings["Con1"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand(@" SELECT CC.CMPNY_ID, 'SUBSIDIARIES' as relation, CC.CMPNY_NM, CC.CMPNY_ADDR_1, CC.CMPNY_CITY, 
                        CC.CMPNY_ST, CC.CMPNY_ZIP,CC.BUYER_INDICATOR as  PDI_CUSTOMER
                             ,CONVERT(varchar, CAST( ROUND(cs.[TOTAL SALES PRIOR YEAR],0) AS money), 1) AS SALES_AMT
                             from cmpny.company CC 
                            LEFT JOIN CMPNY.CMPNY_SALES cs ON cs.CMPNY_ID = cc.CMPNY_ID  
                            WHERE CC.CMPNY_PRNT_ID =" + id.ToString(), conn1);

                try
                {
                    // open connection
                    conn1.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);


                    gd_child.DataSource = ds;
                    gd_child.DataBind();
                }

                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }
        public void gd_aff_company_load(string id)
        {
            string CS = ConfigurationManager.ConnectionStrings["Con1"].ConnectionString;

            // SQL Conection
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand(@"SELECT C.CMPNY_ID, 'SELF' as relation , C.CMPNY_NM, C.CMPNY_ADDR_1, C.CMPNY_CITY, C.CMPNY_ST, C.CMPNY_ZIP,'YES' as  PDI_CUSTOMER
                                            ,cs.[TOTAL SALES PRIOR YEAR] AS SALES_AMT 
                                                     from cmpny.company C 
                                            LEFT JOIN CMPNY.CMPNY_SALES cs ON cs.CMPNY_ID = c.CMPNY_ID 
                                            WHERE C.CMPNY_ID =" + id.ToString(), conn1);

                try
                {
                    // open connection
                    conn1.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);


                    gd_aff.DataSource = ds;
                    gd_aff.DataBind();
                }

                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }

        private void gd_network_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gd_network_company_load(Session["compId"]);
            gd_network.PageIndex = e.NewPageIndex;
            gd_network.DataBind();
        }

        private void gd_child_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gd_child_company_load(Session["compId"]);
            gd_child.PageIndex = e.NewPageIndex;
            gd_child.DataBind();
        }

        private void gd_aff_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gd_aff_company_load(Session["compId"]);
            gd_aff.PageIndex = e.NewPageIndex;
            gd_aff.DataBind();
        }
        private void gd1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int newRowIndex = 0;
            try
            {
                if (e.CommandName == "search")
                {
                    string CompanyId = ((HiddenField)sender.Rows(rowIndex).FindControl("CMPNY_ID")).Value;
                    GetCompanySalesDetails(CompanyId);
                }
            }
            catch (Exception ex)
            {
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

        protected void gd_company_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
