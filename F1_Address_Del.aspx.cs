using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using Common;


namespace WebAppDojo
{
    public partial class F1_Address_Del : System.Web.UI.Page
    {
        public int addressID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["addressid"] != null)
            {
                addressID = Text.ReturnInt(Request.QueryString["addressid"]);
            }

        }

        //protected void BtnSubmit_Click2(object sender, EventArgs e)
        //{

            


            

           

        //    string sURL = "https://demo.fellowshiponeapi.com/v1/Addresses/26603403?mode=demo";

        //    WebRequest request = WebRequest.Create(sURL);
        //    request.Method = "DELETE";

        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();



            


        //    //var httpResponse = (HttpWebResponse)request.GetResponse();
        //    //Response.Write("status code: " + httpResponse.StatusCode);
        //    //Response.Write("<br/>header: " + httpResponse.Headers);





        //}

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            
            
               
            byte[] bytes = Encoding.ASCII.GetBytes("");
            string oUri = "https://demo.fellowshiponeapi.com/v1/Addresses/" + addressID + "?mode=demo";


            HttpWebRequest request = CreateWebRequest(oUri, bytes.Length);

            var httpResponse = (HttpWebResponse)request.GetResponse();
            Response.Write("status code: " + httpResponse.StatusCode);
            Response.Write("<br/>header: " + httpResponse.Headers);





        }

        private HttpWebRequest CreateWebRequest(string endPoint, Int32 contentLength)
        {
            var request = (HttpWebRequest)WebRequest.Create(endPoint);           
            request.Method = "DELETE";            


            return request;
        }  


    }
}