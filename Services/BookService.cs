using BookLibraryBE.Data;
using BookLibraryBE.Interfaces;
using BookLibraryBE.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryBE.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context) 
        {
            _context = context;
        }

        //GET
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }


        //GET (id)
        public async Task<Book> GetBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book;
        }


        //POST
        public async Task<Book> CreateBookAsync(BookAddDTO bookAddDTO)
        {
            var book = new Book
            {
                Title = bookAddDTO.Title,
                Author = bookAddDTO.Author,
                Description = bookAddDTO.Description,
                Publisher = bookAddDTO.Publisher,
                PublishYear = bookAddDTO.PublishYear
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }


        //PUT
        public async Task<bool> UpdateBookAsync(int id, BookUpdateDTO bookUpdateDTO)
        {
            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook == null)
            {
                return false; // Book not found
            }

            // Update only the properties provided in the DTO
            existingBook.Title = bookUpdateDTO.Title ?? existingBook.Title;
            existingBook.Author = bookUpdateDTO.Author ?? existingBook.Author;   
            existingBook.Description = bookUpdateDTO.Description ?? existingBook.Description;
            existingBook.Publisher = bookUpdateDTO.Publisher ?? existingBook.Publisher;
            existingBook.PublishYear = bookUpdateDTO.PublishYear > 0 ? bookUpdateDTO.PublishYear : existingBook.PublishYear;

            try
            {
                await _context.SaveChangesAsync();
                return true; // Update successful
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return false; // Book not found
                }
                else
                {
                    throw;
                }
            }
        }


        //DELETE
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return false; // Book not found
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true; // Deletion successful
        }


        //CHECK EXIST
        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

    }
}
