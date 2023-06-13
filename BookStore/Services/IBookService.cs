using System;
using BookStore.DataModels;

namespace BookStore.Services
{
	public interface IBookService
	{
        public Task<bool> AddBook(Book book);
        public List<Book> GetAllBooks();
        public Book GetBookWithId(int bookId);
        public Task<bool> DeleteBook(int bookId);
    }
}

