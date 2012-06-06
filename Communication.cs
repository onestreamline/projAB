using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppDojo
{
    public class Communication
    {
        public Communication() { }


        #region Model

        private int _communicationID;        
        private string _communicationTypeName;
        private string _communicationValue;


        public int CommunicationID
        {
            set { _communicationID = value; }
            get { return _communicationID; }
        }



        public string CommunicationTypeName
        {
            set { _communicationTypeName = value; }
            get { return _communicationTypeName; }
        }

        public string CommunicationValue
        {
            set { _communicationValue = value; }
            get { return _communicationValue; }
        }

     


        #endregion Model
    }
}