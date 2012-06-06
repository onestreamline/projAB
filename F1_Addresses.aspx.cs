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
    public partial class F1_Addresses : System.Web.UI.Page
    {
        List<Person> people = new List<Person>();
        List<Address> addresses = new List<Address>();

        public int personID, householdID = 0;
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
        
            string resource = "https://demo.fellowshiponeapi.com/v1/People/" + id.ToString() + "/Addresses?mode=demo";
            #region reader
            using (XmlReader reader = XmlReader.Create(resource))
            {
                while (reader.Read())
                {
                    
                    Person oPerson = new Person();
                    Address oAdd = new Address();


                    reader.ReadToFollowing("address");
                    reader.MoveToAttribute("id");
                    oAdd.AddressID = Common.Text.ReturnInt(reader.Value);

                    reader.ReadToFollowing("household");
                    reader.MoveToAttribute("id");
                    oPerson.HouseholdID = Common.Text.ReturnInt(reader.Value);



                    reader.ReadToFollowing("addressType");
                    reader.ReadToFollowing("name");
                    oAdd.AddressTypeName = reader.ReadString();

                    reader.ReadToFollowing("address1");
                    oAdd.Address1 = reader.ReadString();

                    if (oAdd.AddressID > 0)
                        addresses.Add(oAdd);
                    if (oPerson.HouseholdID > 0)
                        people.Add(oPerson);
                       


                }
            }
            #endregion

            //binding
            rptCommu.DataSource = addresses;
            rptCommu.DataBind();
            householdID = people[0].HouseholdID;




        }

    }
}