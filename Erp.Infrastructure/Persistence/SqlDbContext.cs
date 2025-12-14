using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Erp.Application.Common.Models;
using Microsoft.Extensions.Configuration; 
//using System.Data.Common;
using System.Data.SqlClient;
using System.Data.Common;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Transactions;
using System.Linq;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Erp.Infrastructure.Persistence
{
    public abstract class DbContext<TEntity> where TEntity : class
    {
        private readonly DbConnection _con;
        private DbTransaction _trans;
        private object transaction;
        private Castle.Core.Configuration.IConfiguration configuration;

  

        protected DbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            _con = new SqlConnection(connectionString);

        }

        protected DbContext(Castle.Core.Configuration.IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        private async Task ConnectionOpenAsync()
        {
            if (_con.State == ConnectionState.Closed)
                await _con.OpenAsync();
            else
            {
                await _con.OpenAsync();
            }
        }

        private void ConnectionClose()
        {
            if (_con.State == ConnectionState.Open)
                _con.Close();

        }

        public async Task<IEnumerable<TEntity>> GetListAsync(string sqlQuery, DynamicParameters parameter)
        {
            await using var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryAsync<TEntity>(sqlQuery, parameter);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(string sqlQuery, DynamicParameters parameter)
        {
            await using var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryAsync<T>(sqlQuery, parameter);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<IEnumerable<T>> GetListAsyncSP<T>(string sqlQuery, DynamicParameters parameter)
        {
            await using var connection = _con;
            
            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryAsync<T>(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<IEnumerable<T>> GetListAsyncSPDetail<T>(string sqlQuery, DynamicParameters parameter)
        {
            await using var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryAsync<T>(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                //ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<IEnumerable<T>> SaveListAsyncSP<T>(string sqlQuery, DynamicParameters parameter)
        {
            await using var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryAsync<T>(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



      
          
        public async Task<TEntity> GetSingleAsync(string sqlQuery, DynamicParameters parameter)
        {
            await using var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryFirstOrDefaultAsync<TEntity>(sqlQuery, parameter);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<T> GetSingleAsync<T>(string sqlQuery, DynamicParameters parameter)
        {
            await using var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryFirstOrDefaultAsync<T>(sqlQuery, parameter);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<string> GetSingleStringAsync(string sqlQuery, DynamicParameters parameter)
        {
            await using var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                var resultList = await connection.QueryFirstOrDefaultAsync<string>(sqlQuery, parameter);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Int32> GetSingleIntAsync(string sqlQuery, DynamicParameters parameter)
        {
            await using var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                var resultList = await connection.QueryFirstOrDefaultAsync<Int32>(sqlQuery, parameter);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Result> SetSingleAsync(string sqlQuery, DynamicParameters parameter)
        {
            await using var connection = _con;

            try
            {
                await ConnectionOpenAsync();

                await using (_trans = connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRows = await connection.ExecuteAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                        await _trans.CommitAsync();
                        ConnectionClose();
                        var result = parameter.Get<string>("P_MESSAGE");
                        return Result.Success(result);
                    }
                    catch (Exception ex)
                    {
                        await _trans.RollbackAsync();
                        return Result.Failure(new List<string> { ex.Message });
                    }
                }
            }
            catch (Exception ex)
            {
                ConnectionClose();
                return Result.Failure(new List<string> { ex.Message });
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Result> SetMultipleAsync(string sqlQuery, List<DynamicParameters> parameter)
        {
            /*await using*/
            var connection = _con;

            try
            {
                await ConnectionOpenAsync();

                await using (_trans = connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRows = await connection.ExecuteAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                        await _trans.CommitAsync();
                        ConnectionClose();
                        return Result.Success();
                    }
                    catch (Exception ex)
                    {
                        await _trans.RollbackAsync();
                        return Result.Failure(new List<string> { ex.Message });
                    }
                }
            }
            catch (Exception ex)
            {
                ConnectionClose();
                return Result.Failure(new List<string> { ex.Message });
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Result> DeleteSingleAsync(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                await ConnectionOpenAsync();

                await using (_trans = connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRows = await connection.ExecuteAsync(sqlQuery, parameter);
                        await _trans.CommitAsync();
                        ConnectionClose();
                        //var result = parameter.Get<string>("P_MESSAGE");
                        if (affectedRows >= 0)
                        {
                            return Result.Success("Successful");
                        }
                        return Result.Failure(new List<string> { "Delete operation not happend" });
                    }
                    catch (Exception ex)
                    {
                        await _trans.RollbackAsync();
                        return Result.Failure(new List<string> { ex.Message });
                    }
                }
            }
            catch (Exception ex)
            {
                ConnectionClose();
                return Result.Failure(new List<string> { ex.Message });
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Result> DeleteByProcedureAsync(string sqlQuery, DynamicParameters parameter)
        {
            using var connection = _con;

            try
            {
                await ConnectionOpenAsync();

                await using (_trans = connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRows = await connection.ExecuteAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                        await _trans.CommitAsync();
                        ConnectionClose();
                        var result = parameter.Get<string>("P_MESSAGE");
                        return Result.Success(result);
                    }
                    catch (Exception ex)
                    {
                        await _trans.RollbackAsync();
                        return Result.Failure(new List<string> { ex.Message });
                    }
                }
            }
            catch (Exception ex)
            {
                ConnectionClose();
                return Result.Failure(new List<string> { ex.Message });
            }
            finally
            {
                ConnectionClose();
            }
        }


        //Get Numbers by Procedure
        public async Task<int> GetIntNumberAsync(string sqlQuery, DynamicParameters parameter)
        {
            // This one specifically for costing revise
            await using var connection = _con;

            try
            {
                await ConnectionOpenAsync();

                await using (_trans = connection.BeginTransaction())
                {
                    try
                    {
                        var affectedRows = await connection.ExecuteAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                        await _trans.CommitAsync();
                        ConnectionClose();
                        var result = parameter.Get<int>("P_NEW_ID");
                        return result;
                    }
                    catch (Exception ex)
                    {
                        await _trans.RollbackAsync();
                        throw new Exception(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.ToString());
            }
            finally
            {
                ConnectionClose();
            }
        }
        public async Task<Result> SetDisposeErrorFreeSingleAsyncOld(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                await ConnectionOpenAsync();

                await using (_trans = connection.BeginTransaction())
                {
                    try
                    {
                        _con.Close();
                        var affectedRows = await connection.ExecuteAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                        await _trans.CommitAsync();
                        ConnectionClose();
                        var result = parameter.Get<string>("P_MESSAGE");
                        return Result.Success(result);
                    }
                    catch (Exception ex)
                    {
                        await _trans.RollbackAsync();
                        return Result.Failure(new List<string> { ex.Message });
                    }
                }
            }
            catch (Exception ex)
            {
                ConnectionClose();
                return Result.Failure(new List<string> { ex.Message });
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<Result> SetDisposeErrorFreeSingleAsync(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;
           try
           {
                await ConnectionOpenAsync();
                await using (_trans = connection.BeginTransaction())
                {
                    _con.Close();
                    _con.Open();
                   
                    var affectedRows = await connection.ExecuteAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                    
                    await _trans.CommitAsync();
                    ConnectionClose();
                    var result = parameter.Get<string>("P_MESSAGE");

                    return Result.Success("result");                


                
                }
            }
            catch (Exception ex)
            {
                //await _trans.RollbackAsync();
                 ConnectionClose();
                return Result.Failure(new List<string> { ex.Message });
            }
            finally
            {
                ConnectionClose();
            }
        }
        public async Task<Result> SetDisposeErrorFreeSingleAsyncNew(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;
            await ConnectionOpenAsync();     
            {
                _con.Close();
                _con.Open();

                var affectedRows = await connection.ExecuteAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure);

               
                ConnectionClose();
           
                var result = parameter.Get<string>("P_MESSAGE");

                return Result.Success(result);

          
            }


        }
        public async Task<string> GetStringNumberAsync(string sqlQuery, DynamicParameters parameter)
            {
                await using var connection = _con;

                try
                {
                    await ConnectionOpenAsync();

                    await using (_trans = connection.BeginTransaction())
                    {
                        try
                        {
                            var affectedRows = await connection.QueryFirstOrDefaultAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                            await _trans.CommitAsync();
                            ConnectionClose();
                            var result = parameter.Get<string>("P_MESSAGE");
                            return result;
                        }
                        catch (Exception ex)
                        {
                            await _trans.RollbackAsync();
                            throw new Exception(ex.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    ConnectionClose();
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    ConnectionClose();
                }
            }
        
        //Dispose Error Free Get method
        public async Task<TEntity> GetDisposeErrorFreeSingleListAsync(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryFirstOrDefaultAsync<TEntity>(sqlQuery, parameter);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<T> GetDisposeErrorFreeSingleListAsync<T>(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryFirstOrDefaultAsync<T>(sqlQuery, parameter);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<IEnumerable<TEntity>> GetDisposeErrorFreeListAsync(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryAsync<TEntity>(sqlQuery, parameter);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<IEnumerable<T>> GetDisposeErrorFreeListAsync<T>(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryAsync<T>(sqlQuery, parameter);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

      


        public async Task<IEnumerable<T>> GetDisposeErrorFreeListAsyncNew<T>(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryAsync<T>(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                ConnectionClose();
                return resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        public async Task<DataSet> GetDataByDataSet(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;

                using (var command = new SqlCommand(sqlQuery, (SqlConnection)_con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters to the command
                    foreach (var param in parameter.ParameterNames)
                    {
                        command.Parameters.Add(new SqlParameter(param, parameter.Get<object>(param) ?? DBNull.Value));
                    }

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }
        public async Task<IEnumerable<DataSet>> GetDataByDataSet22<T>(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;
            DataTable dt = new DataTable();


            try
            {
                var results = await connection.QueryAsync<DataSet>(sqlQuery, parameter, commandType: CommandType.StoredProcedure
            );

                return results;

            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<IEnumerable<DataTable>> GetDataByDataTable<T>(string sqlQuery, DynamicParameters parameter,DataTable dataTable)
        {
            var connection = _con;
            DataTable dt = new DataTable();


            try
            {
                var results = await connection.QueryAsync<DataTable>(sqlQuery, parameter,commandType: CommandType.StoredProcedure
            );

                return results;

            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<DataTable> GetDataByDataTableAsync(string sqlQuery, DynamicParameters parameter, DataTable dataTable)
        {
            var dt = dataTable;

            try
            {
                using (var connection = _con)
                {
                    await connection.OpenAsync();

                    using (var reader = await connection.ExecuteReaderAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure))
                    {
                        dt.Load(reader); // fill DataTable from reader
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error executing stored procedure", ex);
            }
            finally
            {
                ConnectionClose(); // or connection.Close() if not using _con globally
            }
        }


        public async Task<(List<SaveCashLc> GetList, List<SaveCashLc> GetList1)> GetDataByDataTableMulti<SaveCashLc>(
     string sqlQuery,
     DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                using (var reader = await connection.QueryMultipleAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure))
                {
                    // Read the first result set into GetList
                    var GetList = (await reader.ReadAsync<SaveCashLc>()).ToList();

                    // Read the second result set into GetList1
                    var GetList1 = (await reader.ReadAsync<SaveCashLc>()).ToList();

                    return (GetList, GetList1);
                }
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }


        public async Task<(List<SaveCashLc> GetList, List<SaveCashLc> GetList1, List<SaveCashLc> GetList2)>GetDataByDataTableMultiData<SaveCashLc>(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                using (var reader = await connection.QueryMultipleAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure))
                {
                    // Read the first result set
                    var GetList = (await reader.ReadAsync<SaveCashLc>()).ToList();

                    // Read the second result set
                    var GetList1 = (await reader.ReadAsync<SaveCashLc>()).ToList();

                    // Read the third result set
                    var GetList2 = (await reader.ReadAsync<SaveCashLc>()).ToList();

                    return (GetList, GetList1, GetList2);
                }
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }

        private DataTable ConvertToDataTable(IEnumerable<dynamic> items)
        {
            var dataTable = new DataTable();

            // Extract column names and types from the first item
            if (items.Any())
            {
                var first = items.First();
                foreach (var prop in (IDictionary<string, object>)first)
                {
                    dataTable.Columns.Add(prop.Key, prop.Value?.GetType() ?? typeof(object));
                }

                // Populate DataTable rows
                foreach (var item in items)
                {
                    var row = dataTable.NewRow();
                    foreach (var prop in (IDictionary<string, object>)item)
                    {
                        row[prop.Key] = prop.Value ?? DBNull.Value;
                    }
                    dataTable.Rows.Add(row);
                }
            }

            return dataTable;
        }

        public async Task<DataTable> GetDataByDataTable(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;
            var dataTable = new DataTable();

            try
            {
                await ConnectionOpenAsync();
                using (var reader = await connection.ExecuteReaderAsync(sqlQuery, parameter, commandType: CommandType.StoredProcedure))
                {
                    dataTable.Load(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }

            return dataTable;
        }

        public async Task<dynamic>GetDisposeErrorFreeListAsyncOject<dynamic>(string sqlQuery, DynamicParameters parameter)
        {
            var connection = _con;

            try
            {
                await ConnectionOpenAsync();
                DefaultTypeMap.MatchNamesWithUnderscores = true;
                var resultList = await connection.QueryAsync<dynamic>(sqlQuery, parameter, commandType: CommandType.StoredProcedure);
                ConnectionClose();
                return (dynamic)resultList;
            }
            catch (Exception ex)
            {
                ConnectionClose();
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionClose();
            }
        }



        //Dispose Error Free Set Method


        //private Task newmethod(string sqlQuery, DynamicParameters parameter, DbConnection connection)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
