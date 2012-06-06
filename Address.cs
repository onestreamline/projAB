using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDojo
{
    public class Address
    {
        public Address() { }


        #region Model
        private int _addressID;
        private string _addressTypeName;
        private string _address1;



        public int AddressID
        {
            set { _addressID = value; }
            get { return _addressID; }
        }

        public string AddressTypeName
        {
            set { _addressTypeName = value; }
            get { return _addressTypeName; }
        }


        public string Address1
        {
            set { _address1 = value; }
            get { return _address1; }
        }

        #endregion Model
    }
}