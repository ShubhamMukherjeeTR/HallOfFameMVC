using System.Data;
using System.Data.SqlClient;
using Dapper;
using FastMember;
using Microsoft.Extensions.Configuration;

namespace HallOfFameMVC.Data
{
    public class ExecuteProcedure
    {
        private readonly IConfiguration _configuration;

        public ExecuteProcedure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<DataTable> GetAllLoginTableData()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("GetAllLoginTableData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable result = new DataTable();
                        adapter.Fill(result);
                        await connection.CloseAsync(); // Explicitly close the connection
                        return result;
                    }
                }
            }
        }

        public async Task<DataTable> VerifyLoginCredentials(string username, string password)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("Proc_VerifyLoginCredentials", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        DataTable result = new DataTable();
                        adapter.Fill(result);
                        return result;
                    }
                }
            }
        }
    }

    
}
