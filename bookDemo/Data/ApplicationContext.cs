using bookDemo.Models;

namespace bookDemo.Data
{
    public static class ApplicationContext
    {
        // In Memory DB
        public static List<Book> Books { get; set; }

        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                 new Book() { Id = 1, Title = ".Net Framework", Price = 120 },
                 new Book() { Id = 2, Title = "Javascript", Price = 90 },
                 new Book() { Id = 3, Title = "MVC Pattern", Price = 65 }
            };
        }
    }
}
