using System;
using System.Linq;
using System.Web.Mvc;
using BookReading.Models;

namespace BookReading.Controllers
{
    public class BookController : Controller
    {
        private IBookContext _bookContext;

        // public BookController() : this(BookContext.Instance)
        public BookController() : this(new DbBookContext())
        {
        }

        public BookController(IBookContext bookContext)
        {
            if (bookContext == null)
                throw new ArgumentNullException();
            _bookContext = bookContext;
        }

        //
        // GET: /Book/

        public ActionResult List()
        {
            return View(_bookContext.GetAll());
        }    
		
		public ActionResult Details(int id = 0)
		{
			ViewBag.Title = "Подробнее о книге";
			var book = _bookContext.GetBook(id);
			
			if (book == null)
				return HttpNotFound();

            return View(book);
        }
		
	    public ActionResult Edit(int id = 0)
	    {
			var book = _bookContext.GetBook(id);

		    if (book == null)
			    return HttpNotFound();

		    return View(book);
	    }

		[HttpPost]
	    public ActionResult Edit(Book editBook)
		{
			Book first = _bookContext.GetBook(editBook.Id);

            if (first == null)
				return HttpNotFound();
			
			_bookContext.Update(editBook);

			return View(editBook);
		}

        public ActionResult Create()
        {
            var book = new Book();
            return View(book);
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookContext.AddBook(book);
            }
            else
            {
                ModelState.AddModelError("Create", "Something wrong!");
            }
            return RedirectToAction("List", "Book");
        }

    }
}
