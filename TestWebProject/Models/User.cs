using System;
using System.Threading;
using Tests.Helpers;


namespace Tests.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Organization { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public static User GetRandomUserForRegistration()
        {
            return new User()
            {
                Name = WordCreator.GetRandomWord(10),
                Organization = WordCreator.GetRandomWord(10),
                Email = WordCreator.GetRandomEmail(10) ,
                Password = WordCreator.GetRandomWord(15),
            };
        }
        
        public static User ValidUser()
        {
            return new User()
            {
                Email = "lilibri@gmail.com",
                Password = "zxcvbnm,./",
            };
        }
        
       
    }
}