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
        public string FilePath { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
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
        
        public static User GetRandomUserForChangeSettings()
        {
            return new User()
            {
                Bio = WordCreator.GetRandomWord(10),
                Name = WordCreator.GetRandomWord(10) ,
                FilePath = @"C:/Users/Anna Zanovskaya/RiderProjects/TestWebProject/Image/papug.jpg"
            };
        }
    }
}