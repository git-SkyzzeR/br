using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LinqToDB.Mapping;

namespace BookReading.Models
{
    public class Review
    {
        [PrimaryKey, Identity]
		public int Id { get; set; }

        [Column]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Поле Автор обязательно для заполнения")]
        [Display(Name = "Автор"), Column]
		public String Name { get; set; }
		
		[Required (ErrorMessage = "Поле Отзыв обязательно для заполнения")]
		[Display(Name = "Отзыв")]
		public String Text { get; set; }

        [Column]
        public int Likes { get; set; }

        [Column]
        public bool IsOffensive { get; set; }

        [Column]
        public string Report { get; set; }
    }
}