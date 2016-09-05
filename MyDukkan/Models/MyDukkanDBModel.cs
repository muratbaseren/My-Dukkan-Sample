using MyDukkan.Models;
using System;
using System.Linq;
using System.Data.Entity;

namespace MyDukkan
{
    public class MyDukkanDBEntities : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<SiteUsers> SiteUsers { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Log> Logs { get; set; }

        public MyDukkanDBEntities()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }


    public class MyInitializer : CreateDatabaseIfNotExists<MyDukkanDBEntities>
    {
        protected override void Seed(MyDukkanDBEntities context)
        {
            // Insert SiteUsers..
            SiteUsers admin = new SiteUsers()
            {
                Email = "kadirmuratbaseren@gmail.com",
                LastAccess = DateTime.Now,
                Name = "Murat",
                Surname = "Başeren",
                Password = "123",
                Permission = "admin"
            };

            context.SiteUsers.Add(admin);
            context.SaveChanges();


            // Insert Categories..
            string[] categoryNames = new string[10] { "Gıda", "Kozmetik", "Giyim", "Sağlık", "Teknoloji", "Kültür", "Eğlence", "Bahçe", "Su Altı", "Çocuk" };

            foreach (string catName in categoryNames)
            {
                context.Categories.Add(new Categories()
                {
                    Name = catName
                });
            }

            context.SaveChanges();


            // Insert Products..
            foreach (var cat in context.Categories.ToList())
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(5, 15); i++)
                {
                    context.Products.Add(new Products() {
                        Name = FakeData.NameData.GetCompanyName(),
                        Description = FakeData.TextData.GetSentences(3),
                        Price = FakeData.NumberData.GetNumber(20, 1000),
                        StarCount = (byte)FakeData.NumberData.GetNumber(0, 5),
                        Summary = FakeData.TextData.GetAlphabetical(10) + " " + FakeData.TextData.GetAlphabetical(20),
                        ImageFileName = "product.jpg",
                        Categories = cat
                    });
                }
            }

            context.SaveChanges();

            // Insert Comments..
            foreach (Products pro in context.Products.ToList())
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,4); i++)
                {
                    context.Comments.Add(new Comments()
                    {
                        CreatedOn = DateTime.Now.AddHours(i),
                        IsValid = true,
                        Nickname = FakeData.NameData.GetFullName(),
                        Text = FakeData.TextData.GetSentence(),
                        Products = pro
                    });
                }
            }

            context.SaveChanges();
        }
    }
}