﻿
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace HealthHub_Records.Models
{
    public class Contact
    {
        [Key]
        public int Id{ get; set; }  
        public string Name { get; set; }
        public string Email{ get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

}