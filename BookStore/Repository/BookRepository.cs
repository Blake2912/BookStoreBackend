using System;
using BookStore.DataModels;
using BookStore.Data;
namespace BookStore.Repository
{
	public class BookRepository : IBookRepository
	{

		private readonly DataContext _context;
		private readonly ILogger<BookRepository> _logger;

		public BookRepository(DataContext context, ILogger<BookRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

        public async Task<bool> AddBook(Book book)
		{
			string methodName = nameof(AddBook);
			try
			{
				await _context.Books.AddAsync(book);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception ex)
			{
				_logger.LogInformation("In {@method} | Exception Occured, Message: {@message}", methodName, ex.Message);
				return false;
			}
		}

		public List<Book> GetAllBooks()
		{
			string methodName = nameof(GetAllBooks);
			try
			{
				return _context.Books.ToList();
			}
			catch (Exception e)
			{
				_logger.LogInformation("In {@method} | Exception Occurred, Message: {@message}", methodName, e.Message);
				return new List<Book>();
			}
		}

		public Book GetBookWithId(int bookId)
		{
			string methodName = nameof(GetBookWithId);
			try
			{
				return _context.Books.Where(x => x.BookId == bookId).First();
			}
			catch (Exception ex)
			{
                _logger.LogInformation("In {@method} | Exception Occured, Message: {@message}", methodName, ex.Message);
				return new Book();
            }
		}

		public async Task<bool> DeleteBook(int bookId)
		{
			string methodName = nameof(DeleteBook);
			try
			{
				var book = _context.Books.Where(x => x.BookId == bookId).First();
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
				return true;
			}
            catch (Exception ex)
            {
                _logger.LogInformation("In {@method} | Exception Occured, Message: {@message}", methodName, ex.Message);
                return false;
            }
        }


	}
}

