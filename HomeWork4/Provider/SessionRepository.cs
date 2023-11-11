using DbModels;
using Microsoft.EntityFrameworkCore;

namespace Provider
{
    internal class SessionRepository
    {
        private readonly HomeWork4DbContext _dbContext = new();

        public List<DbSession> GetSessions()
        {
            return _dbContext.Sessions.ToList();
        }

        public DbSession GetSession(Guid sessionId)
        {
            return _dbContext.Sessions
              .AsNoTracking()
              .Where(u => u.Id == sessionId)
              .FirstOrDefault();
        }

        public void CreateSession(DbSession session)
        {
            _dbContext.Add(session);

            _dbContext.SaveChanges();
        }

        public void EditSession(Guid sessionId, DateTime dateTime, string massageType)
        {
            var session = _dbContext.Sessions.FirstOrDefault(u => u.Id == sessionId);

            session.DateTime = dateTime;
            session.TypeOfMassage = massageType;

            _dbContext.SaveChanges();
        }

        public void DeleteSession(Guid sessionId)
        {
            var session = _dbContext.Sessions.FirstOrDefault(u => u.Id == sessionId);

            _dbContext.Remove(session);

            _dbContext.SaveChanges();
        }
    }
}
