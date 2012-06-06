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
    public partial class F1_Address_Edit : System.Web.UI.Page
    {
        public int householdID, personID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["personid"] != null)
            {
                personID = Text.ReturnInt(Request.QueryString["personid"]);
            }
            if (Request.QueryString["householdid"] != null)
            {
                householdID = Text.ReturnInt(Request.QueryString["householdid"]);
            }



        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            #region LoadXml
            string postData2 = "<?xml version='1.0' encoding='utf-8'?>" +
            "<address id=\"\" uri=\"\">" +
              "<household id=\"" + householdID + "\" uri=\"https://demo.fellowshiponeapi.com/v1/Households/" + householdID + "\" />" +
              "<person id=\"" + personID + "\" uri=\"https://demo.fellowshiponeapi.com/v1/People/" + personID + "\" />" +
              "<addressType id=\"7\" uri=\"https://demo.fellowshiponeapi.com/v1/Addresses/AddressTypes/7\">" +
               " <name>Previous</name>" +
              "</addressType>" +
              "<address1>" + txtSearch.Text.Trim() + "</address1>" +
              "<address2></address2>" +
              "<address3></address3>" +
              "<city>Keller</city>" +
              "<postalCode>76248</postalCode>" +
              "<county></county>" +
              "<country>US</country>" +
              "<stProvince>TX</stProvince>" +
              "<carrierRoute>C042</carrierRoute>" +
              "<deliveryPoint>12</deliveryPoint>" +
              "<addressDate>2001-04-11T00:00:00</addressDate>" +
              "<addressComment></addressComment>" +
              "<uspsVerified>false</uspsVerified>" +
              "<addressVerifiedDate></addressVerifiedDate>" +
              "<lastVerificationAttemptDate></lastVerificationAttemptDate>" +
              "<createdDate></createdDate>" +
              "<lastUpdatedDate></lastUpdatedDate></address>";
            #endregion


            byte[] bytes = Encoding.ASCII.GetBytes(postData2);
            string oUri = "https://demo.fellowshiponeapi.com/v1/People/" + personID + "/Addresses?mode=demo";
        
            


            HttpWebRequest request = CreateWebRequest(oUri, bytes.Length);

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            

            var httpResponse = (HttpWebResponse)request.GetResponse();
            Response.Write("status code: " + httpResponse.StatusCode);
            Response.Write("<br/>header: " + httpResponse.Headers);
          



            
        }

        private HttpWebRequest CreateWebRequest(string endPoint, Int32 contentLength)
        {
            var request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = "POST";
            //request.Method = "DELETE";          
            request.ContentLength = contentLength;
            request.Headers.Clear();
            request.ContentType = "application/xml";
           

            return request;
        }  




    }
}