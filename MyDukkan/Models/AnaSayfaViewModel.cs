using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDukkan.Models
{
    public class AnaSayfaViewModel
    {
        public List<Products> ProductList { get; set; }
        public List<Categories> CategoryList { get; set; }

        public AnaSayfaViewModel()
        {
            ProductList = new List<Products>();
            CategoryList = new List<Categories>();
        }
    }
}