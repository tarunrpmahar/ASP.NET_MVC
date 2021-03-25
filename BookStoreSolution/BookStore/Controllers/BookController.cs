using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("book-details/{id}")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            //by default english will be selected
            var model = new BookModel()
            {
                //Language = "2"
            };

            ViewBag.Language =new SelectList(await _languageRepository.GetLanguages(), "Id", "Text");

            //var group1 = new SelectListGroup() { Name="Group 1"};
            //var group2= new SelectListGroup() { Name = "Group 2" };
            //var group3 = new SelectListGroup() { Name = "Group 3" };
            //var group4 = new SelectListGroup() { Name = "Group 4" };
            //ViewBag.Language = new List<SelectListItem>()
            //{
            //     new SelectListItem(){Text="Hindi", Value="1", Group=group1},
            //     new SelectListItem(){Text="English", Value="2", Group=group1},
            //     new SelectListItem(){Text="Punjabi", Value="3", Group=group2},
            //     new SelectListItem(){Text="Tamil", Value="4", Group=group2,Selected=true},
            //     new SelectListItem(){Text="Urdu", Value="5", Group=group3},
            //     new SelectListItem(){Text="Chinese", Value="6", Group=group3},
            //     new SelectListItem(){Text="Telgu", Value="6", Group=group4, Disabled=true}
            //};
            /*GetLanguages().Select(x => new SelectListItem()
        {
            Text = x.Text,
            Value = x.Id.ToString()
        }).ToList();*/

            //ViewBag.Language = new SelectList(GetLanguages(), "Id", "Text" );


            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            //if viewbag not used here than it will give error during post of the form that it is null
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Text");
            return View();
        }

        private List<LanguageModel> GetLanguages()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){ Id=1, Text="Hindi"},
                new LanguageModel(){ Id=2, Text="English"},
                new LanguageModel(){ Id=3, Text="Punjabi"}
            };
        }
    }
}
