using FCMServer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FCMServer.Views
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            txtResult.Text = null;
            try
            {
                
                string applicationID = "AIz----------------LwIE"; //Server key project on firebase. (using Legacy server key)

                string senderId = "21---------42"; //sender ID project on firebase

                //<-- select all token from database -->
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = WIN-8893B70UHDT; database = SHAFCM;user id=admin;password=123456";
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from FCM", con);
                SqlDataReader reader = cmd.ExecuteReader();
                FCM fcm = null;
                //Read every token in succession
                while (reader.Read())
                {
                    fcm = new FCM();
                    fcm.Id = reader.GetInt32(0);
                    fcm.Token = reader.GetString(1);

                    string deviceId = fcm.Token;

                    //create request to firebase cloud messaging with method post
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    tRequest.ContentType = "application/json";
                    var data = new
                    {
                        //token device and message
                        to = deviceId,
                        notification = new
                        {
                            body = txtContent.Text,
                            title = txtTitle.Text,
                            sound = "Enabled"

                        }
                    };

                    //<-- convert data to json; -->
                    var serializer = new JavaScriptSerializer();
                    var json = serializer.Serialize(data);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                    //<-- add to request header server key and sender ID. 
                    tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                    tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                    tRequest.ContentLength = byteArray.Length;
                    //<-- send request to firebase cloud messaging
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    String sResponseFromServer = tReader.ReadToEnd();
                                    string str = sResponseFromServer;
                                    
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            txtResult.Text = "Notification is sent";
        }
                
        }
  
 
}