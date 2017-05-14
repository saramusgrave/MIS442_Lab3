﻿using MIS442Store.DataLayer.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS442Store.Models
{
    public class RegistrationModel
    {
        public List<USState> States { get; set; }
        public string RegistrationAddress { get; set; }
        
        public string RegistrationCity { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int RegistrationID { get; set; }
        public string RegistrationPhone { get; set; }
        public int RegistrationProductID { get; set; }
        public string RegistrationSerialNumber { get; set; }
        public string RegistrationState { get; set; }
        public string RegistrationUserName { get; set; }
        public string RegistrationVerified { get; set; }
        public string RegistrationZip { get; set; }
    }
}