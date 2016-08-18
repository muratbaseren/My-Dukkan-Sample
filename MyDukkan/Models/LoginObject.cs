using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDukkan.Models
{
    public partial class LoginObject
    {
        public string LoginText { get; set; }
        public string LoginIcon { get; set; }
        public string LoginColor { get; set; }
        public string LostText { get; set; }
        public string LostIcon { get; set; }
        public string LostColor { get; set; }
        public string RegisterText { get; set; }
        public string RegisterIcon { get; set; }
        public string RegisterColor { get; set; }

        public LoginObject()
        {
            LoginText = "Kullanıcı adı ve şifrenizi giriniz.";
            LoginIcon = "glyphicon-chevron-right";
            LoginColor = string.Empty;
            LostText = "E-Posta adresinizi giriniz.";
            LostIcon = "glyphicon-chevron-right";
            LostColor = string.Empty;
            RegisterText = "Bir Hesap Oluşturma";
            RegisterIcon = "glyphicon-chevron-right";
            RegisterColor = string.Empty;
        }
    }
}