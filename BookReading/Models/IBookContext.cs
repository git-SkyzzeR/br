using System.Collections.Generic;

namespace BookReading.Models
{
    public interface IBookContext
    {
        void AddBook(Book newBook);
        void AddReview(Review newReview);
        List<Book> GetAll();
        Book GetBook(int bookId);
        Book Update(Book newBookData);
    }
}