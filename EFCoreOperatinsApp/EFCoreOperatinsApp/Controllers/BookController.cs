using EFCoreOperatinsApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace EFCoreOperatinsApp.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController(AppDbContext appDbContext) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            // Using navigational properties
            var books = await appDbContext.Books.Select(x => new
            {
                x.Id,
                x.Title,
                x.Description,
                x.NoOfPages,
                x.Author,
                x.LanguageId,
                languageName = x.Language == null ? null : x.Language.Title,
            }).AsNoTracking().ToListAsync();

            // Eager loading
            /*var books = await appDbContext.Books
                                           .Where(x => x.IsActive)
                                           .Include(b => b.Language)
                                           .Include(c => c.Author) // can do thenInclude for tables related to Author/Language
                                           .AsNoTracking()
                                           .ToListAsync();*/

            // Explicit Loading
            /*var books = await appDbContext.Books.ToListAsync();
            foreach(var book in books)
            {
                await appDbContext.Entry(book).Reference(x => x.Author).LoadAsync();
                await appDbContext.Entry(book).Reference(x => x.Language).LoadAsync();
            }*/

            // Lazy loading
            /*var book = await appDbContext.Books.FirstOrDefaultAsync();
            var author = book.Author; // Lazy loading - need to make navigation properties virtual and install Microsoft.EntityFrameworkCore.Proxies package and enable it in Program.cs
            return Ok(author);*/

            //Getting data from Queries
            //var books = await appDbContext.Books.FromSql($"select top 3 * from books").ToListAsync();

            // Getting Data from SPs
            /*var bookId = new SqlParameter("@id", 4);
            var book = await appDbContext.Books
                .FromSql($"EXEC sp_GetBookById {bookId}")
                .ToListAsync();
            return Ok(book);*/

            /*var books = await appDbContext.Books
                .FromSql($"EXEC sp_GetAllBooks")
                .ToListAsync();*/

            //var books = await appDbContext.Database.SqlQuery<Book>($"select * from books").ToListAsync();

            return Ok(books);
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBookAsync([FromBody] Book book)
        {
            await appDbContext.Books.AddAsync(book);
            await appDbContext.SaveChangesAsync();
            return Ok(book);
        }

        [HttpPost("AddBooks")]
        public async Task<IActionResult> AddBooksAsync([FromBody] List<Book> books)
        {
            await appDbContext.Books.AddRangeAsync(books);
            await appDbContext.SaveChangesAsync();
            return Ok(books);
        }

        [HttpPut("{bookId}")]
        public async Task<IActionResult> UpdateBooksAsync([FromRoute] int bookId, [FromBody] Book model)
        {
            var book = await appDbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
            if (book is null) return NotFound();

            book.Title = model.Title;
            book.Description = model.Description;
            book.NoOfPages = model.NoOfPages;

            await appDbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("UpdateBooksV2")]
        public async Task<IActionResult> UpdateBooksV2Async([FromBody] Book model)
        {
            //appDbContext.Books.Update(model);
            appDbContext.Entry(model).State = EntityState.Modified;
            await appDbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpPut("UpdateBooksInBulk/{id}")]
        public async Task<IActionResult> UpdateBooksInBulkAsync([FromRoute] int id)
        {
            await appDbContext.Books.Where(x => x.AuthorId == null)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(b => b.AuthorId, id)
                    .SetProperty(b => b.Description, b => b.Description + " - updated")
                );
            return Ok();
        }

        [HttpPut("UpdateBooksInBulkV2/{id}")]
        public async Task<IActionResult> UpdateBooksInBulkV2Async([FromRoute] int id)
        {
            await appDbContext.Database.ExecuteSqlAsync($"update books set NoOfPages = 250 where id > {id}");
            return Ok();
        }

        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBookByIdAsync([FromRoute] int id)
        {
            var book = new Book{ Id = id };
            appDbContext.Entry(book).State = EntityState.Deleted;
            /*var book = await appDbContext.Books.FindAsync(id);
            if (book is null) return NotFound();
            appDbContext.Books.Remove(book); // RemoveRange for multiple
            await appDbContext.SaveChangesAsync();*/
            return Ok();
        }

        [HttpDelete("DeleteBooksInBulk/{id}")]
        public async Task<IActionResult> DeleteBooksInBulkAsync([FromRoute] int id)
        {
            await appDbContext.Books.Where(x => x.Id < id).ExecuteDeleteAsync();
            return Ok();
        }
    }
}
