using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LinqToDB;
using LinqToDB.Data;

namespace BookReading.Models
{
    public class DbReviewContext : IReviewContext
    {
        public List<Review> GetAll()
        {
            using (var db = new Database())
            {
                return db.Reviews.ToList();
            }
        }

        public int IncrementAndGetLikes(int reviewId)
        {
            using (var db = new Database())
            {
                var review = db.Reviews.SingleOrDefault(x => x.Id == reviewId);
                if (review == null)
                    return -1;
                review.Likes += 1;
                db.Update(review);
                return review.Likes;
            }
        }

        public void Report(int reviewId, bool isOffensive, string report)
        {
            using (var db = new Database())
            {
                var review = db.Reviews.SingleOrDefault(x => x.Id == reviewId);
                if (review == null)
                    return;
                review.IsOffensive = isOffensive;
                review.Report = report;
                db.Update(review);
                return;
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