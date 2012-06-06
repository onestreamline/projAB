using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDojo
{
    public class Person
    {
        public Person() { }


        #region Model

        private int _id;
        private int _householdID;
        private string _firstName;
        private string _lastName;
        private string _householdMemberTypeName;
        
        private List<Communication> _commu;

        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        public int HouseholdID
        {
            set { _householdID = value; }
            get { return _householdID; }
        }


        public string FirstName
        {
            set { _firstName = value; }
            get { return _firstName; }
        }

        public string LastName
        {
            set { _lastName = value; }
            get { return _lastName; }
        }

        public string HouseholdMemberTypeName
        {
            set { _householdMemberTypeName = value; }
            get { return _householdMemberTypeName; }
        }

        

        public List<Communication> Commu
        {
            get
            {
                if (_commu == null)
                {
                    _commu = new List<Communication>();
                }
                return _commu;
            }
            set { _commu = value; }
        }


        #endregion Model
    }
}