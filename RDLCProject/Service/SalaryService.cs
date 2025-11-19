using System.Data;
using System.Data.SqlClient;

namespace RDLCProject.Service
{
    public class SalaryService
    {
        string connectionString = "Data Source=192.168.50.77;Initial Catalog=GarmentsProductionDB;User ID=sa;Password=1ndex@2023%24#new;";

        public DataTable GetSalaryInfo()
        {
            var dt=new DataTable(); 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_Salary_Report_RDLC", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataAdapter da=new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }
       
        
    }
}
