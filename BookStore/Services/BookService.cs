using System;
using BookStore.Repository;
using BookStore.DataModels;
namespace BookStore.Services
{
	public class BookService : IBookService
	{
		private readonly IBookRepository _bookRepository;
		private readonly ILogger<BookService> _logger;

		public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
		{
			_bookRepository = bookRepository;
			_logger = logger;
		}

		public async Task<bool> AddBook(Book book)
		{
			var methodName = nameof(AddBook);
			try
			{
				return await _bookRepository.AddBook(book);
			}
			catch (Exception ex)
			{
				_logger.LogInformation("Inside {@method} | Exception Occured with message: {@message}", methodName, ex.Message);
				return false;
			}
		}

		public List<Book> GetAllBooks()
		{
            var methodName = nameof(GetAllBooks);
            try
            {
				return _bookRepository.GetAllBooks();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Inside {@method} | Exception Occured with message: {@message}", methodName, ex.Message);
                return new List<Book>();
            }
        }

		public Book GetBookWithId(int bookId)
		{
            var methodName = nameof(GetBookWithId);
            try
            {
				return _bookRepository.GetBookWithId(bookId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Inside {@method} | Exception Occured with message: {@message}", methodName, ex.Message);
                return new Book();
            }
        }

		public async Task<bool> DeleteBook(int bookId)
		{
            var methodName = nameof(DeleteBook);
            try
            {
				return await _bookRepository.DeleteBook(bookId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Inside {@method} | Exception Occured with message: {@message}", methodName, ex.Message);
                return false;
            }
        }
		
    }
}

