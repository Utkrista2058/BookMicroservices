using System.Collections.Generic;
using System.Linq;
using BookServices.Application.DTOs;
using BookServices.Domain;
using BookServices.Domain.Interfaces;

namespace BookServices.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookDto> GetBooks()
        {
            return _bookRepository.GetAll().Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Price = b.Price
            });
        }

        public BookDto GetBookById(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };
        }

        public void AddBook(BookDto bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Price = bookDto.Price
            };
            _bookRepository.Add(book);
        }

        public void UpdateBook(BookDto bookDto)
        {
            var book = _bookRepository.GetById(bookDto.Id);
            if (book == null) return;

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.Price = bookDto.Price;

            _bookRepository.Update(book);
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}
