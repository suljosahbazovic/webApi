using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webApi.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}