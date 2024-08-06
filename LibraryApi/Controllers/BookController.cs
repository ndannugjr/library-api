using LibraryApi.Models;
using LibraryApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        { 
        var books = _bookRepository.GetAllBooks();
            return Ok(books);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest("Book is null");

            var createdBook = _bookRepository.AddBook(book);
            return Ok(createdBook);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, [FromBody] Book book)
        {
            if (book == null)
                return BadRequest("Book is null");

            if (book.Id != id)
                return BadRequest("Cannot find book");

            var updatedBook = _bookRepository.UpdateBook(book);
            if (updatedBook == null)
                return NotFound();

            return Ok(updatedBook);
        }
    }
}
