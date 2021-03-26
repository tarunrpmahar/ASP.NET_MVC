using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        public BookController(BookRepository bookRepository, LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
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

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            //by default english will be selected
            var model = new BookModel()
            {
                //Language = "2"
            };

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Text");

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
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    bookModel.CoverImageUrl = await UploadFile(folder, bookModel.CoverPhoto);
                }

                if (bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";
                    bookModel.Gallery = new List<GalleryModel>();

                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URl = await UploadFile(folder, file)
                        };
                        bookModel.Gallery.Add(gallery);
                    }
                }

                if (bookModel.BookPdf != null)
                {
                    string folder = "books/pdf/";
                    bookModel.BookPdfUrl = await UploadFile(folder, bookModel.BookPdf);
                }

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

        private async Task<string> UploadFile(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }

        //private List<LanguageModel> GetLanguages()
        //{
        //    return new List<LanguageModel>()
        //    {
        //        new LanguageModel(){ Id=1, Text="Hindi"},
        //        new LanguageModel(){ Id=2, Text="English"},
        //        new LanguageModel(){ Id=3, Text="Punjabi"}
        //    };
        //}
    }
}
