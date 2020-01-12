namespace Tests.Models
{
    public class Address
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string Index { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public static Address GetAddress()
        {
            return new Address()
            {
               Name = "Анна",
               Surname = "Анна",
               Street = "улица Есенина, дом Каруселина",
               Country = "Россия",
               City = "Белгород",
               Email = "test@mail.ru",
               Phone = "88005553535"
               
            };
        }
    }
}