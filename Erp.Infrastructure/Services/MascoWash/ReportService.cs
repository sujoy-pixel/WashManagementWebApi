using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Erp.Infrastructure.Services.MascoWash
{
    public class ReportService
    {
        public async Task<DataTable> GetDataByDataTable(string storedProcedure, DynamicParameters parameters)
        {
            DataTable dt = new DataTable();

            // Replace with your actual connection string
            string connectionString = "Data Source=192.168.50.77;Initial Catalog=MascoWashDB;User ID=sa;Password=1ndex@2023%24#new;";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Execute the stored procedure and load the results into a DataReader
                    using (var reader = await connection.ExecuteReaderAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure))
                    {
                        // Load the data into the DataTable
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error executing stored procedure '{storedProcedure}': {ex.Message}");
                throw; // Optionally rethrow or handle the exception
            }

            return dt;
        }
        public async Task<DataTable> GetDataByDataTableReadOnly(string storedProcedure, DynamicParameters parameters)
        {
            DataTable dt = new DataTable();

            // Replace with your actual connection string
            string connectionString = "Data Source=192.168.50.78;Initial Catalog=MascoWashDB;User ID=sa;Password=1ndex@2023%24#new;";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // Execute the stored procedure and load the results into a DataReader
                    using (var reader = await connection.ExecuteReaderAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure))
                    {
                        // Load the data into the DataTable
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error executing stored procedure '{storedProcedure}': {ex.Message}");
                throw; // Optionally rethrow or handle the exception
            }

            return dt;
        }
        public string GetStoredProcedure(string ReportName)
        {
            string _storeProcedure = "";
            if(ReportName== "Date Wise Batch Plan Report")
            {
                _storeProcedure = "rpt_sp_CompanyAndMasterLcWiseB2BInfo";          
                
            }
            
            return _storeProcedure;
        }
       
    }
}
