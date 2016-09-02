namespace MyDukkan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Comments")]
    public partial class Comments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(20), Required]
        public string Nickname { get; set; }

        [StringLength(300), Required]
        public string Text { get; set; }

        public int ProductId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsValid { get; set; }
    

        public virtual Products Products { get; set; }
    }
}
