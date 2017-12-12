using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;
using BookReading.Models;

namespace BookReading.Controllers
{
    public class ReviewController : Controller
    {
        private IBookContext _bookContext;
        private IReviewContext _reviewContext;

        public ReviewController() : this(new DbBookContext(), new DbReviewContext())
        {
        }

        public ReviewController(IBookContext bookContext, IReviewContext reviewContext)
        {
            if (bookContext == null)
                throw new ArgumentNullException();
            if (reviewContext == null)
                throw new ArgumentNullException();
            _bookContext = bookContext;
            _reviewContext = reviewContext;
        }
        //
        // GET: /Review/

        public ActionResult Create(int bookId)
        {
	        if (_bookContext.GetBook(bookId) == null)
		        return HttpNotFound();
			
			var review = new Review() {BookId = bookId};
            
			return View(review);
        }

		[HttpPost]
	    public ActionResult Create(Review review)
	    {
		    if (ModelState.IsValid)
		    {
                _bookContext.AddReview(review);
		    }
		    else
		    {
			    ModelState.AddModelError("Create", "Something wrong!");
		    }
		    return RedirectToAction("Details", "Book", new { id = review.BookId });
	    }

        [HttpPost]
        public void ReportOffensiveReview(int reviewId, string report)
        {
            _reviewContext.Report(reviewId, true, report);
        }

        [HttpPost]
        public int IncrementAndGetLikes(int reviewId)
        {
            var likes = _reviewContext.IncrementAndGetLikes(reviewId);
            return likes;
        }

    }
}
