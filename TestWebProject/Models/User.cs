using System;
using System.Threading;


namespace Tests.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public static User TestUser()
        {
            return new User()
            {
                Login = "test000000000000000000",
                Email = "test88989898@gmail.com",
                Password = "tes7876%%67ting",
            };
        }
        
        public static User MyAkk()
        {
            return new User()
            {
                Email = "droozd15@gmail.com",
                Password = "1@2#qwertyuiop3$4_",
            };
        }
    }
}