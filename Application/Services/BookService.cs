using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Application.Services
{
    public class BookService : IBookService
    {
        public readonly IApplicationDbContext _applicationDb;
        private readonly IMapper _mapper;

        public BookService(IApplicationDbContext applicationDb, IMapper mapper)
        {
            _applicationDb = applicationDb;
            _mapper = mapper;
        }
        public async Task<Book> GetBookDetailsAsync(Guid id)
         {
            var result = await _applicationDb.book_tbl.FindAsync(id);
            return result!;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            var result = await _applicationDb.book_tbl.ToListAsync();
            return result!;
        }

        public async Task<bool> SaveFavouriteBooksAsync(FavouriteBookDTO bookDTO)
        {
            var book = _mapper.Map<FavouriteBook>(bookDTO);

            await _applicationDb.favouriteBook_tbl.AddAsync(book);
            await _applicationDb.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteFavouriteBooksAsync(Guid id)
        {
            var book = await _applicationDb.favouriteBook_tbl.FirstOrDefaultAsync(x => x.Id == id);
            if (book is null)
            {
                return false;
            }

            _applicationDb.favouriteBook_tbl.Remove(book);
            await _applicationDb.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<FavouriteBook>> GetFavouriteBooksAsync()
        {
            var result = await _applicationDb.favouriteBook_tbl.ToListAsync();
            return result;
        }
        public async Task<Book> SearchBooksAsync(string query)
        {
            var results = await _applicationDb.book_tbl.Where(x => x.Title == query).FirstOrDefaultAsync();
            return results;
        }
    }
}
