using System.Configuration;
using System;
using System.Data.SqlClient;

namespace Database_1
{
    public partial class Site_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            ERR.Visible = false;
            get_sales_period();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            ERR.Visible = false;

            JobRunning();
        }



        private void JobRunning()
        {
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                SqlCommand dbCmd = new SqlCommand("exec msdb.dbo.sp_help_job @job_name = N'ETL_NON_EDI_FILES' ;", conn1);
                try
                {
                    conn1.Open();
                    SqlDataReader dr = dbCmd.ExecuteReader();
                    dr.Read();
                    int status = Convert.ToInt32(dr["current_execution_status"]);
                    dr.Close();

                    if (status == 1)
                        ERR.Visible = true;
                    else
                    {
                        ERR.Visible = false;
                        StartJob();
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


        private void StartJob()
        {
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                SqlCommand dbCmd = new SqlCommand("EXEC msdb.dbo.sp_start_job N'ETL_NON_EDI_FILES' ;", conn1);



                try
                {
                    conn1.Open();
                    dbCmd.ExecuteNonQuery();
                }
                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Reset_sales_period();
        }

        private void Reset_sales_period()
        {
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                SqlCommand Cmd1 = new SqlCommand("exec [TRC].[spRESET_SALES_PERIOD] @vSales_Period = N'" + TextBox1.Text.ToString() + "';", conn1);
                // dbCmd.CommandType = CommandType.StoredProcedure
                // Dim para1 As SqlParameter = Cmd1.Parameters.AddWithValue("@vSales_Period", TextBox1.Text.ToString)
                // para1.Direction = ParameterDirection.Input

                try
                {
                    conn1.Open();
                    Cmd1.ExecuteNonQuery();
                    get_sales_period();
                }
                finally
                {
                    // close the connection
                    if ((!(conn1 == null)))
                        conn1.Close();
                }
            }
        }

        public void get_sales_period()
        {
            string CS = ConfigurationManager.ConnectionStrings["Con2"].ConnectionString;
            using (SqlConnection conn1 = new SqlConnection(CS))
            {
                // Dim Cmd1 As SqlCommand = New SqlCommand("SELECT DISTINCT SALES_PERIOD FROM [STAGE].[SALES_PERIOD] 
                // WHERE LOAD_IN = 'Y'", conn1)
                // Dim s As String = ""
                // Dim sql As String = "SELECT DISTINCT SALES_PERIOD FROM [STAGE].[SALES_PERIOD] WHERE LOAD_IN = 'Y'"


                try
                {
                    conn1.Open();

                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("SELECT DISTINCT SALES_PERIOD FROM [STAGE].[SALES_PERIOD] WHERE LOAD_IN = 'Y'", conn1);
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        Label1.Text = myReader[0].ToString();
                        Label2.Text = myReader[0].ToString();
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
