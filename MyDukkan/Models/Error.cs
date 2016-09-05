using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyDukkan.Models
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime OccuredDate { get; set; }

        [StringLength(500), Required]
        public string Message { get; set; }

        public string StackTrace { get; set; }
    }
}