using System;
namespace BookAuthorHomeworkWeek27.Models
{
	public class Book
	{
		//count to store id
		public static int count;

		//public properties
		public int ID { get; set; }
		public string BookName { get; set; }
		public decimal Price { get; set; }
		public string Category { get; set; }
		public string Author { get; set; }

		////assign parameters on instantiation
		//public Book(string name, decimal price, string category, string author)
		//{
		//	this.ID = ++count;
		//	this.BookName = name;
		//	this.Price = price;
		//	this.Category = category;
		//	this.Author = author;
		//}
		public Book()
		{

		}
	}
}

