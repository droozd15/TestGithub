using Tests.Helpers;

namespace Tests.Models
{
    public class Repository
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Visible Visible { get; set; }
        
        public static Repository GetRandomRepository()
        {
            return new Repository()
            {
                Name = WordCreator.GetRandomWord(10),
                Description = WordCreator.GetRandomWord(10),
                Visible = Visible.Private
            };
        }
        
        public static Repository GetExistRepository()
        {
            return new Repository()
            {
                Name = "testRepository",
                Description = WordCreator.GetRandomWord(10),
                Visible = Visible.Private
            };
        }
    }
    
    public enum Visible
    {
        Private,
        Public
    }
}