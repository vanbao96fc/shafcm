using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data;
using System.Data.SqlClient;
using FCMServer.Models;

namespace FCMServer.Controllers
{
    public class FCMController : ApiController
    {
        
        SqlConnection con = new SqlConnection();
        //Set up the protocol http post
        [HttpPost]
        public void Post([FromBody]FCM fcm)
        {
            //Connect to sql server
            con.ConnectionString = "data source = WIN-8893B70UHDT; database = SHAFCM;user id=admin;password=123456";
            //query insert token to database
            SqlCommand cmd = new SqlCommand("insert into FCM(token) values(@token)", con);
            //Get token from client
            cmd.Parameters.AddWithValue("@token", fcm.Token);
            try
            {
                con.Open();
                using (con)
                {
                    //Call query command
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

        }
    }
}
