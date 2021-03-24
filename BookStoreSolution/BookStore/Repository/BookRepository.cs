using BookStore.data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };
            await _context.tbl_Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.tbl_Books.ToListAsync();
            if(allbooks?.Any()==true)
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author=book.Author,
                        Category=book.Category,
                        Description=book.Description,
                        Id=book.Id,
                        Language=book.Language,
                        Title=book.Title,
                        TotalPages=book.TotalPages
                       
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.tbl_Books.FindAsync(id);

            if(book!=null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            //_context.tbl_Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            return null;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
            //return DataSource().Where(x => x.Title == title && x.Author == authorName).ToList();    matches exact word
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ Id=1, Title= "MVC", Author= "Tarun", Description="This is description of the MVC entered by Tarun.", Category="Arch", Language="English", TotalPages=200},
                new BookModel(){ Id=2, Title= "Django", Author= "Singh", Description="This is description of the Django entered by Singh.", Category="Framework", Language="English", TotalPages=500},
                new BookModel(){ Id=3, Title= "Machine Learning", Author= "Mahar", Description="This is description of the Machine Learning entered by Mahar.", Category="Course", Language="English", TotalPages=1000},
                new BookModel(){ Id=4, Title= "C-sharp", Author= "TSM", Description="This is description of the C# entered by TSM.", Category="Programming", Language="English", TotalPages=600},
                new BookModel(){ Id=5, Title= "Dotnet", Author= "tarunrpmahar", Description="This is description of the Dotnet entered by tarunrpmahar.", Category="Framework", Language="English", TotalPages=700},
            };
        }
    }
}
