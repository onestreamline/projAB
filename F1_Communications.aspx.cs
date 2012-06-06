using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using System.Xml;
using System.Collections;
using System.IO;
namespace WebAppDojo
{
    public partial class F1_Communications : System.Web.UI.Page
    {
        List<Person> people = new List<Person>();
        List<Communication> communications = new List<Communication>();
        public int personID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                personID = Text.ReturnInt(Request.QueryString["id"]);
            }

            if (!IsPostBack)
            {
                if (personID > 0)
                {
                    Db_Bind(personID);

                }

            }

        }

        private void Db_Bind(int id)
        {
            string resource = "https://demo.fellowshiponeapi.com/v1/People/" + id.ToString() + "/Communications?mode=demo";
            #region reader
            using (XmlReader reader = XmlReader.Create(resource))
            {
                while (reader.Read())
                {
                    
                    Person oPerson = new Person();
                    Communication oComm = new Communication();

                    
                    reader.ReadToFollowing("communication");
                    reader.MoveToAttribute("id");
                    oComm.CommunicationID = Common.Text.ReturnInt(reader.Value);

                    reader.ReadToFollowing("household");
                    reader.MoveToAttribute("id");
                    oPerson.HouseholdID = Common.Text.ReturnInt(reader.Value);



                    reader.ReadToFollowing("communicationType");
                    reader.ReadToFollowing("name");
                    oComm.CommunicationTypeName = reader.ReadString();

                    reader.ReadToFollowing("communicationValue");
                    oComm.CommunicationValue = reader.ReadString();

                    if (oComm.CommunicationID > 0)
                        communications.Add(oComm);
                       


                }
            }
            #endregion

            //binding
            rptCommu.DataSource = communications;
            rptCommu.DataBind();




        }

    }
}