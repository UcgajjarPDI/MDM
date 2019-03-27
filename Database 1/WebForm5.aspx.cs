using System.Configuration;
using System.Data;
using System;
using System.Web.Services;
using System.Data.SqlClient;

namespace Database_1
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private static int PageSize = 10;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
                BindDummyRow();
        }
        private void BindDummyRow()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("CMPNY_NM");
            dummy.Columns.Add("CMPNY_ADDR_1");
            dummy.Columns.Add("CMPNY_CITY");
            dummy.Columns.Add("CMPNY_ST");
            dummy.Columns.Add("CMPNY_ZIP");
            dummy.Columns.Add("PDI_CMPNY_ID");
            dummy.Rows.Add();
            gvCustomers.DataSource = dummy;
            gvCustomers.DataBind();
        }
        protected void gvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        [WebMethod()]
        public static string GetCustomers(string searchTerm, int pageIndex)
        {
            string query = "[stg0].[Getcompany_Pager]";
            SqlCommand cmd = new SqlCommand(query);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SearchTerm", searchTerm);
            cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            cmd.Parameters.AddWithValue("@PageSize", PageSize);
            cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
            return GetData(cmd, pageIndex).GetXml();
        }

        private static DataSet GetData(SqlCommand cmd, int pageIndex)
        {
            string strConnString = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds, "Customers");
                        DataTable dt = new DataTable("Pager");
                        dt.Columns.Add("PageIndex");
                        dt.Columns.Add("PageSize");
                        dt.Columns.Add("RecordCount");
                        dt.Rows.Add();
                        dt.Rows[0]["PageIndex"] = pageIndex;
                        dt.Rows[0]["PageSize"] = PageSize;
                        dt.Rows[0]["RecordCount"] = cmd.Parameters["@RecordCount"].Value;
                        ds.Tables.Add(dt);
                        return ds;
                    }
                }
            }
        }
    }
}
