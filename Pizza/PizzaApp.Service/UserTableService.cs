using RegistrationSystem;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace PizzaApp.Service
{
    public class UserTableService
    {
        private readonly string _connectionString;
        private readonly string _providerName;
        private readonly DbProviderFactory _providerFactory;

        public UserTableService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["appConnectionString"].ConnectionString;
            _providerName = ConfigurationManager.ConnectionStrings["appConnectionString"].ProviderName;
            _providerFactory = DbProviderFactories.GetFactory(_providerName);
        }

        public List<User> SelectUsers()
        {
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
                        string phonenumber = sqlDataReader["PhoneNumber"].ToString();

                        data.Add(new User
                        {
                            Id = id,
                            Login = login,
                            Password = password,
                            PhoneNumber = phonenumber
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
                    command.CommandText = $"insert into Users (Login, Password, PhoneNumber) values ('{user.Login}','{user.Password}','{user.PhoneNumber}')";
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

      
    }
}
