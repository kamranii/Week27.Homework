using System;
using BookAuthorHomeworkWeek27.Models;

namespace BookAuthorHomeworkWeek27.Services
{
	public class BookService: IBookService
	{
        //list of all books
        public static List<Book> Books = new List<Book>(0);
		public BookService()
		{
		}

        public Book Create(string name, decimal price, string category, string author)
        {
            //instantiate the book
            Book book = new Book()
            {
                ID = ++Book.count,
                BookName = name,
                Category = category,
                Author = author
            };
            //validate price
            if (price > 0)
                book.Price = price;
            //Add to Db
            BookService.Books.Add(book);
            return book;
        }

        public List<Book> Get()
        {
            //all books
            return BookService.Books;
        }

        public Book Get(int id)
        {
            //search for the book
            Book? bookToSearch = BookService.Books.FirstOrDefault(b => b.ID == id);
            return bookToSearch;
        }

        public bool Remove(Book book)
        {
            //check equality
            var bookToRemove = BookService.Books.FirstOrDefault(
                b =>
                    b.ID == book.ID &&
                    b.BookName == book.BookName &&
                    b.Author == book.Author
                );
            //check the book
            if (bookToRemove == null)
                return false;
            BookService.Books.Remove(bookToRemove);
            return true;
        }

        public bool Remove(int id)
        {
            //search for the book
            Book? bookToRemove = BookService.Books.FirstOrDefault(b => b.ID == id);
            if (bookToRemove == null)
            {
                return false;
            }
            BookService.Books.Remove(bookToRemove);
            return true;
        }

        public bool Update(int id, string newName, decimal newPrice, string newCategory, string newAuthor)
        {
            //find the book
            Book? bookToSearch = BookService.Books.FirstOrDefault(b => b.ID == id);
            //check the book
            if (bookToSearch != null)
            {
                bookToSearch.BookName = newName;
                //custom validations
                //price
                if (newPrice > 0)
                    bookToSearch.Price = newPrice;
                else
                    bookToSearch.Price = 0;
                bookToSearch.Category = newCategory;
                bookToSearch.Author = newAuthor;
                return true;
            }
            return false;
        }
    }
}

