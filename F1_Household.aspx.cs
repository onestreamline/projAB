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
    public partial class F1_Household : System.Web.UI.Page
    {
        List<Person> people = new List<Person>();
        public int householdID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null) {
                householdID = Text.ReturnInt(Request.QueryString["id"]);
            }

            if (!IsPostBack) {
                if (householdID > 0) {
                    Db_Bind(householdID);
                
                }
            
            }




        }

        private void Db_Bind(int id) {

            string resource = "https://demo.fellowshiponeapi.com/v1/Households/" + id.ToString() + "/People?mode=demo";
            #region reader
            using (XmlReader reader = XmlReader.Create(resource))
            {
                while (reader.Read())
                {
                    Person oPerson = new Person();
                    reader.ReadToFollowing("person");
                    reader.MoveToAttribute("id");
                    oPerson.Id = Common.Text.ReturnInt(reader.Value);

                    reader.MoveToAttribute("householdID");
                    oPerson.HouseholdID = Common.Text.ReturnInt(reader.Value);

                    reader.ReadToFollowing("firstName");
                    oPerson.FirstName = reader.ReadString();
                    reader.ReadToFollowing("lastName");
                    oPerson.LastName = reader.ReadString();

                    reader.ReadToFollowing("householdMemberType");
                    reader.ReadToFollowing("name");
                    oPerson.HouseholdMemberTypeName = reader.ReadString();

                    if (oPerson.Id > 0)
                        people.Add(oPerson);


                }
            }
            #endregion

            //binding
            rptResults.DataSource = people;
            rptResults.DataBind();
            

        
        
        }
    }
}