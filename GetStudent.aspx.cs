using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsWithOracle
{
    public partial class GetStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT column1, column2 FROM your_table";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;
            using (var connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (OracleCommand command = new OracleCommand(sqlQuery, connection))
                    {
                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            // Process the query results here
                            while (reader.Read())
                            {
                                // Access the data using reader["column_name"] or reader.GetInt32(0), reader.GetString(1), etc.
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error creating connection with database");
                }
            }
        }
    }
}