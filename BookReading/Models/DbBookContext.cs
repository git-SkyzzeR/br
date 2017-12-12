using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;

namespace BookReading.Models
{
    public class DbBookContext : IBookContext
    {
        public void AddBook(Book newBook)
        {
            using (var db = new Database())
            {
                db.Insert(newBook);
                // db.InsertWithIdentity()
            }
        }

        public void AddReview(Review newReview)
        {
            //throw new System.NotImplementedException();
            using (var db = new Database())
            {
                db.InsertWithIdentity(newReview);
            }
        }

        public List<Book> GetAll()
        {
            using (var db = new Database())
            {
                return db.Books.ToList();
            }
        }

        public Book GetBook(int bookId)
        {
            using (var db = new Database())
            {
                return db.Books.SingleOrDefault(x => x.Id == bookId);
            }
        }

        public Book Update(Book newBookData)
        {
            if (newBookData == null)
                throw new ArgumentNullException(nameof(newBookData));

            using (var db = new Database())
            {
                var book =
                    db.Books.SingleOrDefault(x => x.Id == newBookData.Id);

                if (book == null)
                    return null;

                db.Update(newBookData);

                book.Update(newBookData);
                return book;
            }

        }

        private class Database : DataConnection
        {
            public Database() : base("Main")
            {
            }

            public ITable<Book> Books { get { return GetTable<Book>(); } }
        }
    }
}