using System.Configuration;
using System.Data.Common;


namespace PizzaApp.Service
{
    public class LoginSystem
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["appConnectionString"].ConnectionString;
        private readonly string _providerName = ConfigurationManager.ConnectionStrings["appConnectionString"].ProviderName;
        private readonly DbProviderFactory _providerFactory;
        MainMenu main = new MainMenu();

        public LoginSystem()
        {
            _providerFactory = DbProviderFactories.GetFactory(_providerName);
        }

        public void LogIn(string login, string password)
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
                                if (reader["Password"].ToString() == password)
                                    main.OpenPizzaMenu();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}

#region Comment
/*using ConnectedLevelApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
namespace ConnectedLevelApp.DataAccess
{
    public class UsersTableService
    {
        private readonly string _connectionString;
        private readonly string _providerName;
        private readonly DbProviderFactory _providerFactory;
        private DbTransaction transaction;

        public UsersTableService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appConnectionString"].ConnectionString;
            _providerName = ConfigurationManager.ConnectionStrings["appConnectionString"].ProviderName;
            _providerFactory = DbProviderFactories.GetFactory(_providerName);
        }

        public List<User> SelectUsers()
        {
            var isAdminAsString = ConfigurationManager.AppSettings["isAdmin"];
            var data = new List<User>();

            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = _connectionString;
                    connection.Open();
                    command.CommandText = "select * from Users";

                    var sqlDataReader = command.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        int id = (int)sqlDataReader["Id"];
                        string login = sqlDataReader["Login"].ToString();
                        string password = sqlDataReader["Password"].ToString();

                        data.Add(new User
                        {
                            Id = id,
                            Login = login,
                            Password = password
                        });
                    }
                    sqlDataReader.Close();

                }
                catch (DbException exception)
                {
                    //обработать
                    throw;
                }
                catch (Exception exception)
                {
                    //обработать
                    throw;
                }
            }
            return data;
        }

        public void InsertUser(User user)
        {
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {

                    connection.ConnectionString = _connectionString;

                    connection.Open();

                    transaction = connection.BeginTransaction();

                    command.CommandText = $"insert into Users(Login, Password) values(@login, @password) " +
                        $"insert into Users(Login, Password) values(@login, @password)";

                    var loginParameter = command.CreateParameter();
                    loginParameter.ParameterName = "@login";
                    loginParameter.DbType = System.Data.DbType.String;
                    loginParameter.Value = user.Login;

                    var passwordParameter =  command.CreateParameter();
                    passwordParameter.ParameterName = "@password";
                    loginParameter.DbType = System.Data.DbType.String;
                    loginParameter.Value = user.Password;


                    command.Parameters.Add(passwordParameter);
                    command.Parameters.Add(loginParameter);

                    command.Transaction = transaction;

                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows < 1)
                    {
                        throw new Exception("Вставка не удалась");
                    }
                    transaction.Commit();
                }
                catch (DbException exception)
                {
                    //обработать
                    transaction?.Rollback();
                    throw;
                }
                catch (Exception exception)
                {
                    //обработать
                    transaction?.Rollback();
                    throw;
                }
            }
        }

        public void DeleteUserById(int id)
        {
            using (var connection = _providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    command.CommandText = $"delete from Users where Id = {id}";
                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows < 1)
                    {
                        throw new Exception("Вставка не удалась");
                    }
                }
                catch (DbException exception)
                {
                    //обработать
                    throw;
                }
                catch (Exception exception)
                {
                    //обработать
                    throw;
                }
            }
        }
        //public void StartTransaction(SqlCommand command)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    using (command = connection.CreateCommand())
        //    {
        //        transaction = connection.BeginTransaction();

        //        command.Transaction = transaction;
        //        command.


        //        transaction.Commit();   
        //    }
        //}
    }
}
*/
#endregion