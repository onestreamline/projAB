using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Collections;
using System.IO;


namespace WebAppDojo
{
    

    public partial class F1_Search : System.Web.UI.Page
    {
        List<Person> people = new List<Person>();
        public int count = 0;
       

        protected void Page_Load(object sender, EventArgs e)
        {      



        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string resource = "https://demo.fellowshiponeapi.com/v1/People/Search?mode=demo&searchFor=" + txtSearch.Text.Trim();
            
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

                    if (oPerson.Id > 0)
                        people.Add(oPerson);


                }


            }
            #endregion

            //binding
            rptResults.DataSource = people;
            rptResults.DataBind();
            count = people.Count;




        }

        protected void BtnRefresh_Click(object sender, EventArgs e)
        {
            people.Clear();
            rptResults.DataSource = people;
            rptResults.DataBind();
            txtSearch.Text = "";



        }
    }
}