using System;
using System.Collections.Generic;
using ProCivReport.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProCivReport.Data
{
    public interface IRepo
    {
        void Save(ServiceReportDto serviceReport);

        void Save(List<Street> streets);

        void Save(List<LightingBreakdownsDto> lightingBreakdon);
    }

    public class Repo : IRepo
    {
        private readonly string _connectionString;

        public Repo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Save(ServiceReportDto serviceReport)
        {
            throw new System.NotImplementedException();
        }

        public void Save(List<Street> streets)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                const string strSql = @"SELECT Cart FROM dbo.Articles";

                var k = conn.Query<string>(strSql).ToList();

            }
        }

        public void Save(List<LightingBreakdownsDto> lightingBreakdon)
        {
            throw new System.NotImplementedException();
        }
    }
}