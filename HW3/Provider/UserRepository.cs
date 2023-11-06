using DbModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Provider
{
    public class UserRepository
    {
        private readonly UsersDB _dbContext = new();
        private const string ConnectionString =
            @"Server=localhost\sqlexpress;Database=LessonDB;Trusted_Connection=True;Encrypt=False;";
        private const string GetUsersSQL = @"SELECT * FROM Users";
        private const string GetUserSQL = @"SELECT * FROM Users WHERE Id = '{0}'";

        public List<DbUser> GetUsersEF()
        {
            return _dbContext.Users.ToList();
        }

        public DbUser GetUserEF(Guid userId)
        {
            return _dbContext.Users
              .AsNoTracking()// составляем запрос
              .Where(u => u.Id == userId) // модифицируем запрос
              .FirstOrDefault(); // берем один из всех вернувшихся уже из памяти
        }

        public void CreateUser(DbUser user)
        {
            _dbContext.Add(user);

            _dbContext.SaveChanges();
        }

        public void EditUser(Guid userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

            user.FirstName = "AAAAAAAAAAAAAAAAAAAAAAAAAAA";

            _dbContext.SaveChanges();
        }

        public void DeleteUser(Guid userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

            _dbContext.Remove(user);

            _dbContext.SaveChanges();
        }

        public string GetUsersFromDB()
        {
            var result = string.Empty;

            using var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand(GetUsersSQL, sqlConnection);

            sqlConnection.Open();
            using var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                result += sqlDataReader["Id"];
                result += " ";
                result += sqlDataReader["FirstName"];
                result += " ";
                result += sqlDataReader["LastName"];
                result += "\n";
            }

            return result;
        }

        public string GetUser(Guid userId)
        {
            var result = string.Empty;

            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(GetUserSQL, userId);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            using var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                result += sqlDataReader["Id"];
                result += " ";
                result += sqlDataReader["FirstName"];
                result += " ";
                result += sqlDataReader["LastName"];
            }

            return result;
        }
    }
}
