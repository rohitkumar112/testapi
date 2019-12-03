using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using testapi.Models;
using System.Net.Http;
using System.Web.Http;

namespace testapi.Controllers
{
    public class creditdebitcommentsController : ApiController
    {
        [HttpPost]
        public verifymodel post(clienthistorymodel c)
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
            string query = "insert into clienthistory(name,debit,credit,comments) values('"+c.name+"','"+c.debit+"','"+c.credit+"','"+c.message+"')";
            //   string query = "Insert into addclient(name,phonenumber,detail) values('" + value.name + "','" + value.phonenumber + "','" + value.detials + "')";
            SqlCommand sqlcommand = new SqlCommand(query, cnn);
            int rows = sqlcommand.ExecuteNonQuery();
            verifymodel v = new verifymodel();
            if (rows>0)
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
