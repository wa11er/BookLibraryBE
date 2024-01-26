using BookLibraryBE.Models;

namespace BookLibraryBE.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookAsync(int id);

        Task<Book> CreateBookAsync(BookAddDTO bookAddDTO);

        Task<bool> UpdateBookAsync(int id, BookUpdateDTO bookUpdateDTO);

        Task<bool> DeleteBookAsync(int id);
    }
}
