using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using MIS442Store.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MIS442Store.Controllers
{
    public class NewsController : Controller
    {

        private INewsRepository _sara;
        // GET: News
        public NewsController ()
        {
            _sara = new NewsRepository();
        }

        public ActionResult Index()
        {

            //Given Headers from problem
            ViewBag.Title = "MIS442 News";
            ViewBag.Header = "MIS442 News";

            //My headers
            //List 1
            List<News> NewsList = new List<News>();
            News listitem = new DataLayer.DataModels.News();
            listitem.ID = 1;
            listitem.Title = "Musgrave";
            listitem.Body = "Its April and STILL raing?!";
            listitem.Author = "Sara Musgrave";
            listitem.DatePosted = "Posted on 04/27/2016";

            //List 2
            News listitme2 = new News();
            listitme2.ID = 2;
            listitme2.Title = "Musgrave2";
            listitme2.Body = "I love my new laptop";
            listitme2.Author = "Sara Musgrave";
            listitme2.DatePosted = "Posted on 03/12/1996";

            NewsList.Add(listitem);
            NewsList.Add(listitme2);
            return View(GetNews());
        }
        private List<News> GetNews()
        {
            List<News> NewsList = new List<News>();
            News listitem2 = new News();
            listitem2.ID = 3;
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

        public static implicit operator NewsController(NewsRepository v)
        {
            throw new NotImplementedException();
        }
    }
}