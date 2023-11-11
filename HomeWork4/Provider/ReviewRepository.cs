using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider
{
    internal class ReviewRepository
    {
        private readonly HomeWork4DbContext _dbContext = new();

        public List<DbReview> GetReviews()
        {
            return _dbContext.Reviews.ToList();
        }

        public DbReview GetReview(Guid reviewId)
        {
            return _dbContext.Reviews
              .AsNoTracking()
              .Where(u => u.Id == reviewId)
              .FirstOrDefault();
        }

        public void CreateReview(DbReview review)
        {
            _dbContext.Add(review);

            _dbContext.SaveChanges();
        }

        public void EditReview(Guid reviewId, int mark, string comment)
        {
            var review = _dbContext.Reviews.FirstOrDefault(u => u.Id == reviewId);

            review.Mark = mark;
            review.Comment = comment;

            _dbContext.SaveChanges();
        }

        public void DeleteReview(Guid reviewId)
        {
            var review = _dbContext.Reviews.FirstOrDefault(u => u.Id == reviewId);

            _dbContext.Remove(review);

            _dbContext.SaveChanges();
        }
    }
}
