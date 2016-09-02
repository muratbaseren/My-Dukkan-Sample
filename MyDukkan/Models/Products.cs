namespace MyDukkan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Products")]
    public partial class Products
    {
        public Products()
        {
            this.Comments = new List<Comments>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [StringLength(150), Required]
        public string Summary { get; set; }

        public string Description { get; set; }
        public byte StarCount { get; set; }
        public int CategoryId { get; set; }

        [StringLength(200), Required]
        public string ImageFileName { get; set; }
    
        public virtual Categories Categories { get; set; }
        public virtual List<Comments> Comments { get; set; }
    }
}
