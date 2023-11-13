using DbModels;
using Provider;

namespace CLient
{
    public class ReviewCommand
    {
        ReviewRepository _reviewRepository = new();

        public void AddReview(Guid clientId, Guid masseurId, int mark, string comment)
        {
            var Review = new DbReview
            {
                Id = Guid.NewGuid(),
                ClientId = clientId,
                MasseurId = masseurId,
                Mark = mark,
                Comment = comment
            };

            _reviewRepository.CreateReview(Review);
        }

        public void RemoveReview(Guid id)
        {
            _reviewRepository.DeleteReview(id);
        }

        public string GetReview(Guid id)
        {
            DbReview dbReview = _reviewRepository.GetReview(id);

            string strReview = $"{dbReview.Id} - {dbReview.MasseurId} - {dbReview.ClientId} - {dbReview.Mark} - {dbReview.Comment}";

            Console.WriteLine(strReview);

            return strReview;
        }

        public List<string> GetReviews()
        {
            List<string> _strReviews = new();

            List<DbReview> _reviews = _reviewRepository.GetReviews();

            foreach (DbReview review in _reviews)
            {
                Console.WriteLine($"{review.Id} - {review.MasseurId} - {review.ClientId} - {review.Mark} - {review.Comment}");
                _strReviews.Add($"{review.Id} - {review.MasseurId} - {review.ClientId} - {review.Mark} - {review.Comment}");
            }

            return _strReviews;
        }

        public void UpdateReview(Guid id, int mark, string comment)
        {
            _reviewRepository.EditReview(id, mark, comment);
        }
    }
}
