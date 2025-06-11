using System.Collections.Generic;
using BookServices.Application.DTOs;

namespace BookServices.Application.Services
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetBooks();
        BookDto GetBookById(int id);
        void AddBook(BookDto bookDto);
        void UpdateBook(BookDto bookDto);
        void DeleteBook(int id);
    }
}
