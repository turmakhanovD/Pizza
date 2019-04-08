using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace PizzaApp.Checker
{
    public class LoginChecker
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["appConnectionString"].ConnectionString;
        private readonly DbProviderFactory _providerFactory;
        private readonly string _providerName = ConfigurationManager.ConnectionStrings["appConnectionString"].ProviderName;

        public LoginChecker()
        {
            _providerFactory = DbProviderFactories.GetFactory(_providerName);
        }

        public bool IsWrong(string login)
        {
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();

                command.CommandText = "select * from Users";
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        foreach (char log in reader["Login"].ToString())
                        {
                            if (reader["Login"].ToString() == login)
                            {
                                Console.WriteLine("We have got with this username");
                                return true;
                            }
                            
                        }
                       
                    }
                }
            }
            return false;
        }
    }
}
        