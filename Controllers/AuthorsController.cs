
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using TestOdata.Models;

namespace TestOdata.Controllers
{
    public class AuthorsController : ODataController
    {
        private BookStoreContext _db;

        public AuthorsController(BookStoreContext context)
        {
            _db = context;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                }
                foreach (var a in DataSource.GetAuthors())
                {
                    context.Authors.Add(a);
                }
                context.SaveChanges();
            }
        }

        [EnableQuery]
        public IQueryable<Author> GetAuthors()
        {
            return _db.Authors.AsQueryable<Author>();
        }

        [HttpGet("{authorId:int}"), EnableQuery]
        public IQueryable<Book> GetBooks(int authorId)
        {
            return _db.Books.Where(x => x.AuthorId == authorId).AsQueryable<Book>();
        }
    }
}
