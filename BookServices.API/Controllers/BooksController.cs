using BookServices.Domain;
using BookServices.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BookServices.Application.Commands;
using BookServices.Application.DTOs;
using BookServices.Application.Interfaces;
using System.Collections.Generic;

//namespace BookServices.API.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class BooksController : ControllerBase
//    {
//        private readonly IBookRepository _bookRepository;

//        public BooksController(IBookRepository bookRepository)
//        {
//            _bookRepository = bookRepository;
//        }

//        // GET: api/books
//        [HttpGet]
//        public IActionResult GetAllBooks()
//        {
//            var books = _bookRepository.GetAll();
//            return Ok(books);
//        }

//        // GET: api/books/{id}
//        [HttpGet("{id}")]
//        public IActionResult GetBookById(int id)
//        {
//            var book = _bookRepository.GetById(id);
//            if (book == null) return NotFound();
//            return Ok(book);
//        }

//        // POST: api/books
//        [HttpPost]
//        public IActionResult CreateBook([FromBody] Books book)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);

//            _bookRepository.Add(book);
//            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
//        }

//        // PUT: api/books/{id}
//        [HttpPut("{id}")]
//        public IActionResult UpdateBook(int id, [FromBody] Books book)
//        {
//            if (id != book.Id) return BadRequest("ID mismatch");

//            var existing = _bookRepository.GetById(id);
//            if (existing == null) return NotFound();

//            _bookRepository.Update(book);
//            return NoContent();
//        }

//        // DELETE: api/books/{id}
//        [HttpDelete("{id}")]
//        public IActionResult DeleteBook(int id)
//        {
//            var book = _bookRepository.GetById(id);
//            if (book == null) return NotFound();

//            _bookRepository.Delete(id);
//            return NoContent();
//        }
//    }
//}




namespace BookServices.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService BookService)
        {
            _bookService = BookService;
        }

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<BooksDto>> GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<BooksDto> GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdBook = _bookService.AddBook(command);

            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch");

            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null) return NotFound();

            _bookService.UpdateBook(command);
            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null) return NotFound();

            _bookService.DeleteBook(id);
            return NoContent();
        }
    }
}
