
using BookApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    private static List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Title = "CleanCode", Author = "Robert C. Martin", Year = 2008 },
            new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Year = 1999 }
        };

    // GET: api/books
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetBooks()
    {
      return Ok(books);
    }

    // GET: api/books/1
    [HttpGet("{id}")]
    public ActionResult<Book> GetBook(int id)
    {
      var book = books.FirstOrDefault(b => b.Id == id);

      if (book == null)
      {
        return NotFound();
      }

      return Ok(book);
    }

    // POST: api/books
    [HttpPost]
    public ActionResult<Book> CreateBook(Book book)
    {
      book.Id = books.Max(b => b.Id) + 1;
      books.Add(book);

      return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    // PUT: api/books/1
    [HttpPut("{id}")]
    public ActionResult UpdateBook(int id, Book updatedBook)
    {
      var book = books.FirstOrDefault(b => b.Id == id);

      if (book == null)
      {
        return NotFound();
      }

      book.Title = updatedBook.Title;
      book.Author = updatedBook.Author;
      book.Year = updatedBook.Year;

      return NoContent();
    }

    // DELETE: api/books/1
    [HttpDelete("{id}")]
    public ActionResult DeleteBook(int id)
    {
      var book = books.FirstOrDefault(b => b.Id == id);

      if (book == null)
      {
        return NotFound();
      }

      books.Remove(book);

      return NoContent();
    }
  }
}
