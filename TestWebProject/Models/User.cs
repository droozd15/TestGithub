using System;
using System.Threading;
using Tests.Helpers;


namespace Tests.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public static User GetRandomUserForRegistration()
        {
            return new User()
            {
                Login = WordCreator.GetRandomWord(10),
                Email = WordCreator.GetRandomEmail(10) ,
                Password = WordCreator.GetRandomWord(15),
            };
        }
        
        public static User ValidUser()
        {
            return new User()
            {
                Email = "droozd15@gmail.com",
                Password = "1@2#qwertyuiop3$4_",
            };
        }
    }
}