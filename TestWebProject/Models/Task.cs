using Tests.Helpers;

namespace Tests.Models
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        
        public static Task GetRandomTask()
        {
            return new Task()
            {
                Title = WordCreator.GetRandomWord(10),
                Description = WordCreator.GetRandomWord(10),
                FilePath = "C:/Users/Anna Zanovskaya/RiderProjects/TestWebProject/Image/papug.jpg",
            };
        }
    }
}