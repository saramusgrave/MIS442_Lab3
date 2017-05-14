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
    public class NewsRepository : INewsRepository
    {
        public object Listitem2 { get; private set; }

        List<News> INewsRepository.GetList()
        { 
                List<News> NewsList = new List<News>();
                News listitem2 = new News();
                listitem2.ID= 3;
                listitem2.Title = "Musgrave3";
                listitem2.Body = "My old laptop sucks";
                listitem2.Author = "Sara Musgrave";
                listitem2.DatePosted = "10/08/2015";

                NewsList.Add(listitem2);
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM News";
                        command.CommandType = CommandType.Text;

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listitem2 = new News();
                                listitem2.ID = int.Parse(reader["ID"].ToString());
                                listitem2.Title = reader["Title"].ToString();
                                listitem2.Author = reader["Author"].ToString();
                                listitem2.DatePosted = reader["DatePosted"].ToString();
                                NewsList.Add(listitem2);
                            }
                        }
                    }
                }
                return NewsList;
            }
    }
}