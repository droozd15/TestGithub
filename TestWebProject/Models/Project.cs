using Tests.Helpers;

namespace Tests.Models
{
    public class Project
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
        public static Project GetRandomProject()
        {
            return new Project()
            {
                Title = WordCreator.GetRandomWord(10),
                Description = WordCreator.GetRandomWord(10),
            };
        }
        public static Project GetEmptyProject()
        {
            return new Project()
            {
                Title = "",
                Description = "",
            };
        }
    }
}