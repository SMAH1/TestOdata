using System.Diagnostics;
using System.Net;

namespace TestOdata.Models
{
    public static class DataSource
    {
        private static IList<Book> _books { get; set; } = new List<Book>();
        private static IList<Author> _authors { get; set; } = new List<Author>();

        public static IList<Book> GetBooks()
        {
            if (_books.Count != 0)
            {
                return _books;
            }

            InitDb();

            return _books;
        }

        public static IList<Author> GetAuthors()
        {
            if (_authors.Count != 0)
            {
                return _authors;
            }

            InitDb();

            return _authors;
        }

        private static void InitDb()
        {
            _books.Add(new Book() { Id = 1, Title = "A", AuthorId = 1, });
            _books.Add(new Book() { Id = 2, Title = "B", AuthorId = 1, });
            _books.Add(new Book() { Id = 3, Title = "C", AuthorId = 2, });
            _books.Add(new Book() { Id = 4, Title = "D", AuthorId = 3, });
            _books.Add(new Book() { Id = 5, Title = "E", AuthorId = 2, });
            _books.Add(new Book() { Id = 6, Title = "F", AuthorId = 1, });


            _authors.Add(new Author() { Id = 1, Name = "Z-1", });
            _authors.Add(new Author() { Id = 2, Name = "Z-2", });
            _authors.Add(new Author() { Id = 3, Name = "Z-3", });
            _authors.Add(new Author() { Id = 4, Name = "Z-4", });
        }
    }
}
