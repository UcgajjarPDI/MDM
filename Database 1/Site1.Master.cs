namespace Database_1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (Session["user"] != null)
            {
                Label1.Visible = true;
                Label1.Text = "Welcome " + Session["Greet"].ToString();
            }
            else
            {
            }
        }
    }
}
