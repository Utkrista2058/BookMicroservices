using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookServices.Application.Commands;
using BookServices.Application.DTOs;

namespace BookServices.Application.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BooksDto> GetAllBooks();
        BooksDto? GetBookById(int id);
        BooksDto AddBook(CreateBookCommand command);
        void UpdateBook(UpdateBookCommand command);
        void DeleteBook(int id);
    }
}
