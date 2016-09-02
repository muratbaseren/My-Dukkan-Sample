
namespace MyDukkan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SiteUsers")]
    public partial class SiteUsers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(20)]
        public string Surname { get; set; }

        [StringLength(80), Required]
        public string Email { get; set; }

        [StringLength(20), Required]
        public string Password { get; set; }
        public DateTime LastAccess { get; set; }

        [StringLength(20), Required]
        public string Permission { get; set; }
    }
}
