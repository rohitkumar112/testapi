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
    public class getvaluefromdbController : ApiController
    {
        [HttpGet]
        public uppermodel get()
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
            string query = "select * from clientdetials";
            //   string query = "Insert into addclient(name,phonenumber,detail) values('" + value.name + "','" + value.phonenumber + "','" + value.detials + "')";
            SqlCommand sqlcommand = new SqlCommand(query, cnn);
            List<debitcreditmodel> debitcreditmodels = new List<debitcreditmodel>();
            SqlDataReader sqlDatareader = sqlcommand.ExecuteReader();
            while (sqlDatareader.Read())
            {
                debitcreditmodel db = new debitcreditmodel();
                db.name = sqlDatareader["name"].ToString();
                db.debit = int.Parse(sqlDatareader["debit"].ToString());
                db.credit = int.Parse(sqlDatareader["credit"].ToString());
                debitcreditmodels.Add(db);
            }
            uppermodel u = new uppermodel();
            u.getdata = debitcreditmodels;
            //execute scalar 1 value;
            //execute reader more than 1
            //execute non query for insert update
            //     responsemessage rs = new responsemessage();
            /*    int row = sqlcommand.ExecuteNonQuery();
                if (row > 0)
                {
                    rs.message = "successfull";
                }
                else
                {
                    rs.message = "not successfull";
                }
                */

            return u;
        }
    }
}
