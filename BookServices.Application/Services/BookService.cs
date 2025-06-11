using System.Collections.Generic;
using System.Linq;
using BookServices.Domain;
using BookServices.Domain.Interfaces;
using BookServices.Application.DTOs;
using BookServices.Application.Commands;
using BookServices.Application.Interfaces;

using static System.Reflection.Metadata.BlobBuilder;

namespace BookServices.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BooksDto> GetAllBooks()
        {
            var books = _repository.GetAll();
            return books.Select(b => new BooksDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                Price = b.Price
            });
        }

        public BooksDto? GetBookById(int id)
        {
            var book = _repository.GetById(id);
            if (book == null) return null;

            return new BooksDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };
        }

        public BooksDto AddBook(CreateBookCommand command)
        {
            var book = new Books
            {
                Title = command.Title,
                Author = command.Author,
                Price = command.Price
            };
            _repository.Add(book);

            return new BooksDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };


        }

        //public void UpdateBook(UpdateBookCommand command)
        //{
        //    var book = new Books
        //    {
        //        Id = command.Id,
        //        Title = command.Title,
        //        Author = command.Author,
        //        Price = command.Price
        //    };
        //    _repository.Update(book);
        //}
        public void UpdateBook(UpdateBookCommand command)
        {
            var existingBook = _repository.GetById(command.Id);
            if (existingBook == null) return;

            existingBook.Title = command.Title;
            existingBook.Author = command.Author;
            existingBook.Price = command.Price;

            _repository.Update(existingBook);
        }

        public void DeleteBook(int id)
        {
            _repository.Delete(id);
        }
    }
}
