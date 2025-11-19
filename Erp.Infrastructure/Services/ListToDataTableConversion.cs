using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Services
{
    public class ListToDataTableConversion
    {
        public static DataTable ConvertListToDataTable<T>(List<T> list)
        {
            DataTable table = new DataTable();

            foreach (var prop in typeof(T).GetProperties())
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in list)
            {
                DataRow row = table.NewRow();

                foreach (var prop in typeof(T).GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
