using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Razor;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace BookReading.Models
{
    [Table]
	public class Book
	{
	    /*public Book()
	    {
            Reviews = new List<Review>();
	    }*/

        [PrimaryKey, Identity]
	    public int Id { get; set; }

		[Display(Name = "Название"), Column]
		public string Title { get; set; }

        [Display(Name = "Описание"), Column]
		public string Description { get; set; }

	    [Display(Name = "Автор"), Column]
        public string Author { get; set; }

	    [Display(Name = "Страницы"), Column]
        public int Pages { get; set; }

	    [Display(Name = "Жанр"), Column]
        public string Genre { get; set; }

		public void Update(Book newBookData)
		{
			Title = newBookData.Title;
			Description = newBookData.Description;
			Author = newBookData.Author;
			Pages = newBookData.Pages;
			Genre = newBookData.Genre;
		}

        public List<Review> Reviews
        {
            get
            {
                using (var db = new Database())
                    return (from r in db.Reviews
                            where r.BookId == Id
                            select r).ToList();
            }
        }

        private class Database : DataConnection
        {
            public Database() : base("Main")
            {
            }
            public ITable<Review> Reviews { get { return GetTable<Review>(); } }
        }
    }
}