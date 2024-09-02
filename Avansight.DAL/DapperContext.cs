using AvanSight.Models.DomainModels;
using Dapper;
using FastMember;
using System.Data;
using System.Data.SqlClient;


namespace AvanSight.DAL
{
    public class DapperContext : IDapperContext
    {
        private readonly string _connectionString;

        public DapperContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void SavePatients(DataTable patients)
        {
            throw new NotImplementedException();
        }

       
    }
}
