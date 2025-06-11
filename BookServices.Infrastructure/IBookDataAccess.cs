using BookServices.Domain;
using BookServices.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookServices.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public Books GetById(int id) => _context.Books.Find(id);

        public IEnumerable<Books> GetAll() => _context.Books.ToList();

        public void Add(Books book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Books book)
        {

            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
