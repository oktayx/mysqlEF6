using MysqlEF6.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MysqlEF6.Controllers
{
    public class DefaultController : ApiController
    {
        //Test for direct connection
        public string Get()
        {
            string connStr = "server=192.168.1.111;port=8889;database=nappsql;uid=root2;password=root2";

            MySqlConnection conn = new MySqlConnection(connStr);
            string ret = "";
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                // Perform database operations

                string sql = "SELECT PersonName, PersonId FROM Persons";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ret += rdr[0] + " -- " + rdr[1];
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                ret = ex.ToString();
            }
            conn.Close();
            
            return ret;
        }

        //Test for EF connection
        public string Get2()
        {
            string ret = "";
            using (var context = new MyDbContext())
            {
                var persons = context.People.ToList();
                foreach (var p in persons)
                {
                    ret = p.PersonId + " " + p.PersonName;
                }

            }
            return ret;
        }
    }
}
