using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFormSite.Models
{
    public class User
    {
        [StringLength(20,ErrorMessage="Username length must < 20")]
        [Required(ErrorMessage="*You must fill this space")]
        public string username{get;set;}
        [MinLength(15,ErrorMessage="*The password length must > 5")]
        [Required(ErrorMessage = "*You must fill this space")]
        public string password { get; set; }

        public string email { get; set; }

        public int headicon { get; set; }

        [RegularExpression(@"^\d+$",ErrorMessage="Must be a number")]
        [Range(10,100,ErrorMessage="Your age is not allowed for register this cite")]
        [Required(ErrorMessage = "*You must fill this space")]
        public int age { get; set; }

        public User()
        {

        }
        public User(string username, string password, string email, int headicon, int age)
        {
            this.username = username;
            this.password = password;
            this.email = email;
            this.headicon = headicon;
            this.age = age;
        }
    }
}