using Application.DTOs;
using Domain.Entities;


namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<Book> GetBookDetailsAsync(Guid id);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<bool> SaveFavouriteBooksAsync(FavouriteBookDTO bookDTO);
        Task<IEnumerable<FavouriteBook>> GetFavouriteBooksAsync();
        Task<bool> DeleteFavouriteBooksAsync(Guid id);
        Task<Book> SearchBooksAsync(string query);
    }
}
