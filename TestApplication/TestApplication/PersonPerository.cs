using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Core;
using Dapper;

namespace TestApplication
{
    public class PersonPerository : IPersonRepository
    {
       private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Person"].ConnectionString;
        public Person Get(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "select * from Persons where id = @id";

                return connection.QueryFirstOrDefault<Person>(sql, new {id});
            }
        }
        public IList<Person> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var sql = "select * from Persons";

                return connection.Query<Person>(sql).ToList();
            }
        } 
    }
}