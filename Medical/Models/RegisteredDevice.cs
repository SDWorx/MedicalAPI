using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medical.Models
{
    public class RegisteredDevice
    {
        [Key]
        public int id { get; set; }

        public string ipAddress { get; set; }
    }
}