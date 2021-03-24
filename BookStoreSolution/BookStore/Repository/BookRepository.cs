using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
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
