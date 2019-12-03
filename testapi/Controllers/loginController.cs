using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using testapi.Models;
using System.Web.Http;

namespace testapi.Controllers
{
    public class loginController : ApiController
    {
        [HttpGet]
        public verifymodel get(string name,string pass)
        {
            string s = "";
            string connetionString;
            SqlConnection cnn;

            //    connetionString = @"Data Source=DESKTOP-F9MHQ34\ROHIT;Initial Catalog=careconnect;Integrated Security=True";
            connetionString = @"Data Source=DL-5590-I7-018;Initial Catalog=nomeshdatabase;Integrated Security=true";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            ///addclient api
            ///
            string query = "select * from login where name='"+name+"' and pass='"+pass+"'";
            //   string query = "Insert into addclient(name,phonenumber,detail) values('" + value.name + "','" + value.phonenumber + "','" + value.detials + "')";
            SqlCommand sqlcommand = new SqlCommand(query, cnn);
            SqlDataReader sqlDatareader = sqlcommand.ExecuteReader();
            verifymodel v = new verifymodel();
            if (sqlDatareader.HasRows)
            {
               v.message = "successfull";
            }
            else
            {
                v.message = "unsuccessfull";
            }
            return v;
        }
    }
}
