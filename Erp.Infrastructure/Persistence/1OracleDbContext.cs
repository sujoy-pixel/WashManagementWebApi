using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Erp.Application.Common.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace Erp.Infrastructure.Persistence
{
    public abstract class OracleDbContext<TEntity> where TEntity : class
    {
        private readonly OracleConnection _con;
        private OracleTransaction _trans;

        protected OracleDbContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            _con = new OracleConnection(connectionString);
        }

        private async Task ConnectionOpenAsync()
        {
            if (_con.State == ConnectionState.Closed)
                await _con.OpenAsync();
            else {
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


        //Dispose Error Free Set Method

        public async Task<Result> SetDisposeErrorFreeSingleAsync(string sqlQuery, DynamicParameters parameter)
        {
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

        

    }
}
