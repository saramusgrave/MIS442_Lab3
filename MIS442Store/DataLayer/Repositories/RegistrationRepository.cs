using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
      public   List<Registration> GetUserRegistrations(string username)
        {
            List<Registration> registrationList = new List<Registration>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM Registration WHERE RegistrationUserName = @RegistrationUserName";
                    command.Parameters.AddWithValue("@RegistrationUserName", username);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Registration r = new Registration();
                            r.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            r.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            r.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            r.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            r.RegistrationVerified = reader["RegistrationVerified"].ToString();
                            r.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            r.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            r.RegistrationState = reader["RegistrationState"].ToString();
                            r.RegistrationCity = reader["RegistrationCity"].ToString();
                            r.RegistrationZip = reader["RegistraitonZip"].ToString();
                            r.RegistrationPhone = reader["RegistrationPhone"].ToString();
                            registrationList.Add(r);
                        }
                    }
                }
            }
            return (registrationList);
        }
       public  List<Registration> GetRegistrations()
        {
            List<Registration>registrationList = new List<Registration>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FORM Registration";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           Registration r = new Registration();
                            r.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            r.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            r.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            r.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            r.RegistrationVerified = reader["RegistrationVerified"].ToString();
                            r.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            r.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            r.RegistrationState = reader["RegistrationState"].ToString();
                            r.RegistrationCity = reader["RegistrationCity"].ToString();
                            r.RegistrationZip = reader["RegistraitonZip"].ToString();
                            r.RegistrationPhone = reader["RegistrationPhone"].ToString();
                            registrationList.Add(r);
                        }
                    }
                }
            }
            return (registrationList);
        }
      public  Registration GetRegistration(int id)
        {
            Registration r = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FORM Registration WHERE RegistrationID= @RegistrationID";
                    command.Parameters.AddWithValue("@RegistrationID", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            r= new Registration();
                            r.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            r.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            r.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            r.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            r.RegistrationVerified = reader["RegistrationVerified"].ToString();
                            r.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            r.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            r.RegistrationState = reader["RegistrationState"].ToString();
                            r.RegistrationCity = reader["RegistrationCity"].ToString();
                            r.RegistrationZip = reader["RegistraitonZip"].ToString();
                            r.RegistrationPhone = reader["RegistrationPhone"].ToString();
                        }
                    }
                }
            }
            return (r);
        }
     public void SaveRegistration(Registration registration)
        {
            Registration r = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                   
                    if (registration.RegistrationID != 0)
                    {
                        command.Parameters.AddWithValue("@RegistrationID", registration.RegistrationID);
                        command.CommandText = "UPDATE Registration SET RRegistrationDate = @RegistrationDate, RegistrationProductID = @RegistrationProductID,RegistrationSerialNumber = @RegistrationSerialNumber,RegistrationVerified = @RegistrationVerified,RegistrationUserName = @RegistrationUserName,RegistrationAddress = @RegistrationAddress,RegistrationState = @RegistrationState,RegistrationCity = @RegistrationCity,RegistrationZip = @RegistrationZip,RegistrationPhone = @RegistrationPhone, WHERE RegistrationID= @RegistrationID";
                    }
                    else
                    {
                        command.CommandText = "INSERT INTO REGISTRATION (RegistrationDate, RegistrationProductID, RegistrationSerialNumber, RegistrationVerified, RegistrationUserName, RegistrationAddress, RegistrationState, RegistrationCity, RegistrationZip, RegistrationPhone) VALUES (@RegistrationDate, @RegistrationProductID, @RegistrationSerialNumber, @RegistrationVerified, @RegistrationUserName, @RegistrationAddress, @RegistrationState, @RegistrationCity, @RegistrationZip, @RegistrationPhone) WHERE RegistrationID = @RegistraitonID";
                    }
                    command.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);
                    command.Parameters.AddWithValue("@RegistrationProductID", registration.RegistrationProductID);
                    command.Parameters.AddWithValue("@RegistrationSerialNumber", registration.RegistrationSerialNumber);
                    command.Parameters.AddWithValue("@RegistrationVerified",registration.RegistrationVerified);
                    command.Parameters.AddWithValue("@RegistrationUserName", registration.RegistrationUserName);
                    command.Parameters.AddWithValue("@RegistationAddress", registration.RegistrationAddress);
                    command.Parameters.AddWithValue("@RegistrationState", registration.RegistrationState);
                    command.Parameters.AddWithValue("@RegistationCity", registration.RegistrationCity);
                    command.Parameters.AddWithValue("@RegistrationZip", registration.RegistrationZip);
                    command.Parameters.AddWithValue("@RegistrationPhone", registration.RegistrationPhone);
                    connection.Open();
                    //command.ExecuteNonQuery();
                }
            }
        }
    }
}