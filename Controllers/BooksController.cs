using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookLibraryBE.Data;
using BookLibraryBE.Models;
using BookLibraryBE.Interfaces;

namespace BookLibraryBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IBookService _bookService;

        public BooksController(AppDbContext context, IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }


        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }


        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _bookService.GetBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }


        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, [FromBody] BookUpdateDTO bookUpdateDTO)
        {
            var result = await _bookService.UpdateBookAsync(id, bookUpdateDTO);

            if (!result)
            {
                return NotFound(); 
            }

            return NoContent(); 
        }


        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] BookAddDTO bookAddDTO)
        {
            var createdBook = await _bookService.CreateBookAsync(bookAddDTO);

            return CreatedAtAction("GetBook", new { id = createdBook.Id }, createdBook);
        }


        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (!result)
            {
                return NotFound(); // Book not found
            }

            return NoContent(); // Deletion successful
        }


    }
}
