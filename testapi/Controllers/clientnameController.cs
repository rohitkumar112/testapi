using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testapi.Models;
namespace testapi.Controllers
{
    public class clientnameController : ApiController
    {
        [HttpGet]
        public namelistmodel get()
        {
            List<getnamemodel> g = new List<getnamemodel>();
            string s = "";
            string connetionString;
            SqlConnection cnn;

            //    connetionString = @"Data Source=DESKTOP-F9MHQ34\ROHIT;Initial Catalog=careconnect;Integrated Security=True";
            connetionString = @"Data Source=DL-5590-I7-018;Initial Catalog=nomeshdatabase;Integrated Security=true";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            ///addclient api
            ///
            string query = "select name from addclient";
            //   string query = "Insert into addclient(name,phonenumber,detail) values('" + value.name + "','" + value.phonenumber + "','" + value.detials + "')";
            SqlCommand sqlcommand = new SqlCommand(query, cnn);
            SqlDataReader sqlDatareader = sqlcommand.ExecuteReader();
            while (sqlDatareader.Read())
            {
                getnamemodel m = new getnamemodel();
                m.name = sqlDatareader["name"].ToString();
                g.Add(m);
                //v.message = "successfull";
            }
            namelistmodel namelist = new namelistmodel();
            namelist.data = g;
            
            return namelist;
        }
    }
}
