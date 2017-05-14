﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.DataModels
{
    public class Product
    {        [Required]
        [StringLength(10)]
        public string ProductCode { get; set; }
 [Required]
        public int ProductID { get;  set; }
            [Required]
        [StringLength(50)]
        public string ProductName { get;  set; }
    [Required]
        public DateTime ProductReleaseDate { get; set; }
       [Required]
        
        public decimal ProductVersion { get;  set; }
    }
}