using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReading.Models
{
    public interface IReviewContext
    {
        List<Review> GetAll();
        int IncrementAndGetLikes(int reviewId);
        void Report(int reviewId, bool isOffensive, string report);
    }
}
