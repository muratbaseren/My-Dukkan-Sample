using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyDukkan.Models
{
    [Table("Logs")]
    public class Log
    {
        [Key]
        public Guid Id { get; set; }
        public string IP { get; set; }
        public string Username { get; set; }
        public DateTime AccessDate { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string Description { get; set; }
    }
}