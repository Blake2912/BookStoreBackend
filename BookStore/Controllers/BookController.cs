using System;
using BookStore.DataModels;
using BookStore.Services;
using BookStore.HelperModels;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
	{
		private readonly IBookService _bookService;
		private readonly ILogger<BookController> _logger;

		public BookController(IBookService bookService, ILogger<BookController> logger)
		{
			_bookService = bookService;
			_logger = logger;
		}

		[HttpPost("AddBook")]
		public async Task<IActionResult> AddBook(Book book)
		{
			var controllerName = nameof(AddBook);
			try
			{
				if (await _bookService.AddBook(book) == false)
				{
                    return BadRequest($"Adding {book.BookName} failed");
                }
                return StatusCode(201,$"{book.BookName} was successfully added");
            }
			catch (Exception ex)
			{
				_logger.LogInformation("In {@controller} controller | Exception Occured with Message: {@message}", controllerName, ex.Message);
				return BadRequest($"Exception Occured! | Message: {ex.Message}");
			}
		}

		[HttpGet("GetBooks")]
		public IActionResult GetBooks()
		{
            var controllerName = nameof(GetBooks);
			try
			{
				return Ok(_bookService.GetAllBooks());
			}
            catch (Exception ex)
            {
                _logger.LogInformation("In {@controller} controller | Exception Occured with Message: {@message}", controllerName, ex.Message);
                return BadRequest($"Exception Occured! | Message: {ex.Message}");
            }
        }

		[HttpGet("GetBookWithId")]
		public IActionResult GetBookWithId(int bookId)
		{
            var controllerName = nameof(GetBookWithId);
			try
			{
				return Ok(_bookService.GetBookWithId(bookId));
			}
            catch (Exception ex)
            {
                _logger.LogInformation("In {@controller} controller | Exception Occured with Message: {@message}", controllerName, ex.Message);
                return BadRequest($"Exception Occured! | Message: {ex.Message}");
            }
        }

		[HttpDelete("DeleteBook")]
		public async Task<IActionResult> DeleteBook(int bookId)
		{
            var controllerName = nameof(DeleteBook);
			try
			{
				return Ok(await _bookService.DeleteBook(bookId));
			}
			catch (Exception ex)
            {
                _logger.LogInformation("In {@controller} controller | Exception Occured with Message: {@message}", controllerName, ex.Message);
                return BadRequest($"Exception Occured! | Message: {ex.Message}");
            }
        }

	}
}

