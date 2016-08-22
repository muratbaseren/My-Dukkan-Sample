using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDukkan.Models
{
    public class UrunDetayViewModel
    {
        public List<Categories> CategoryList { get; set; }
        public Products Product { get; set; }
        public string CommentOnNickname { get; set; }
        public string CommentOnText { get; set; }
    }
}