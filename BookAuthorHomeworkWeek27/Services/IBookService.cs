using System;
using BookAuthorHomeworkWeek27.Models;

namespace BookAuthorHomeworkWeek27.Services
{
	public interface IBookService
	{
		public List<Book> Get();
		public Book Get(int id);
		public Book Create(string name, decimal price, string category, string author);
		public bool Update(int id, string name, decimal price, string category, string author);
		public bool Remove(Book book);
		public bool Remove(int id);
	}
}

