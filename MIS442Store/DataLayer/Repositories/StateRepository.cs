using MIS442Store.Controllers;
using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MIS442Store.DataLayer.Repositories
{
    public class StateRepository : IStateRepository
    {
       public List<USState> GetState()
        {
           List<USState>  state = new List<USState>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"MIS442_SMusgrave"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM State";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           USState s = new USState();
                            s.code = reader["code"].ToString();
                            s.name = reader["name"].ToString();
                            state.Add(s);
                        }
                    }
                }
            }
            return (state);
        } 
    }
}
