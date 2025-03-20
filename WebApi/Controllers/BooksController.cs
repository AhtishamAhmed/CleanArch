using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookDetails(Guid id)
        {
            var book = await _bookService.GetBookDetailsAsync(id);
            return Ok(book);
        }


        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var book = await _bookService.GetBooksAsync();
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> SaveFavouriteBooks(FavouriteBookDTO bookDTO)
        {
            var book = await _bookService.SaveFavouriteBooksAsync(bookDTO);
            return Ok(book);
        }
        [HttpGet]
        public async Task<IActionResult> GetFavouriteBooks()
        {
            var book = await _bookService.GetFavouriteBooksAsync();
            return Ok(book);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFavouriteBooks(Guid id)
        {
            var book = await _bookService.DeleteFavouriteBooksAsync(id);
            return Ok(book);
        }
        [HttpGet]
        public async Task<IActionResult> SearchBooks([FromQuery] string query)
        {
            
            var book = await _bookService.SearchBooksAsync(query);
            return Ok(book);
          
        }
    }
}
