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
            string connectionString = "Data Source=192.168.50.77;Initial Catalog=MascoCommercialDB;User ID=sa;Password=1ndex@2023%24#new;";

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
            if(ReportName== "Company And Master Lc Wise B2B Info")
            {
                _storeProcedure = "rpt_sp_CompanyAndMasterLcWiseB2BInfo";
                
            }
            else if(ReportName== "Master LC Report")
            {
                _storeProcedure = "sp_Get_DATA_Master_Report";
            }else if(ReportName== "Goods Delivery Report")
            {
                _storeProcedure = "sp_Get_DATA_Goods_Service_Data";
            }
            else if (ReportName == "Proforma Invoice Report Local")
            {
                _storeProcedure = "sp_rpt_Proforma_Invoice_Local";
            }
            else if (ReportName == "Proforma Invoice Report Foreign")
            {
                _storeProcedure = "sp_rpt_Proforma_Invoice_Foreign";
            }
            else if (ReportName == "Company And Supplier Wise BTB LC Report")
            {
                _storeProcedure = "sp_get_company_supplier_wise_b2blc_report";
            }
            else if (ReportName == "Unit Wise Monthly Shipment Report")
            {
                _storeProcedure = "sp_rpt_month_wise_shipment_export";
            }
            else if (ReportName == "Day Wise Shipment Report")
            {
                _storeProcedure = "sp_rpt_day_wise_shipment_export";
            }
            else if (ReportName == "Monthly Shipment Report")
            {
                _storeProcedure = "sp_rpt_Monthly_Shipment_Report";
            }

            return _storeProcedure;
        }
       
    }
}
