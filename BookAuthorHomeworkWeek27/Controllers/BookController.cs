using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAuthorHomeworkWeek27.Models;
using BookAuthorHomeworkWeek27.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookAuthorHomeworkWeek27.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        //inject service in costructor
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allBooks = _bookService.Get();
            if (allBooks.Count == 0)
                return NotFound("No books were found");
            return Ok(allBooks);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var bookFound = _bookService.Get(id);
            //check the response
            if (bookFound == null)
                return NotFound("No books to return");
            return Ok(bookFound);
        }

        [HttpPost]
        public IActionResult Create(string name, decimal price, string category, string author)
        {
            var bookCreated = _bookService.Create(name, price, category, author);
            return Created($"{bookCreated.ID}", bookCreated);
        }

        [HttpPut]
        public IActionResult Update(int id, string name, decimal price, string category, string author)
        {
            bool isSuccessful = _bookService.Update(id, name, price, category, author);
            if (!isSuccessful)
                return NotFound("Update was Unsuccessful!");
            return Ok();
        }

        [HttpDelete]
        public IActionResult Remove(Book book)
        {
            bool isSuccessful = _bookService.Remove(book);
            if (isSuccessful)
                return Ok($"{book.BookName} was successfully removed");
            return BadRequest("Invalid input");
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            bool isSuccessfullyRemoved = _bookService.Remove(id);
            if (isSuccessfullyRemoved)
                return Ok($"Book with {id} was Successfully removed");
            return NotFound("No book mathces the id");
        }
    }
}

