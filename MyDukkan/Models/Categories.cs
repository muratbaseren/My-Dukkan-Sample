
namespace MyDukkan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Categories")]
    public partial class Categories
    {
        public Categories()
        {
            this.Products = new List<Products>();
        }
    
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }
    
        public virtual List<Products> Products { get; set; }
    }
}
