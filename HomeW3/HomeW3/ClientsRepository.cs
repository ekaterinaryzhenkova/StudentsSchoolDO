using Microsoft.Data.SqlClient;

namespace Client
{
    internal class ClientsRepository
    {
        private const string ConnectionString =
      @"Server=localhost\sqlexpress;Database=HomeWork1DB;Trusted_Connection=True;Encrypt=False;";
        private const string GetClientsSQL = @"SELECT * FROM Clients";
        private const string GetClientSQL = @"SELECT * FROM Clients WHERE Id = '{0}'";
        private const string AddClientSQL = @"INSERT INTO Clients (Id, Name, PhoneNumber) VALUES ('{0}', '{1}', '{2}')";
        private const string DeleteClientSQL =
            @"DELETE FROM Clients WHERE Id = '{0}'";
        private const string UpdateClientSQL = @"UPDATE Clients SET Name = '{0}', PhoneNumber = '{1}' WHERE Id = '{2}'";

        public void UpdateClient(string name, string phone, Guid userId)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(UpdateClientSQL, name, phone, userId);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
        }

        public void DeleteClient(Guid userId)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(DeleteClientSQL, userId);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
        }

        public void AddClient(Guid userId, string name, string number)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(AddClientSQL, userId, name, number);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }

        public string GetClientsFromDB()
        {
            var result = string.Empty;

            using var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand(GetClientsSQL, sqlConnection);

            sqlConnection.Open();
            using var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                result += sqlDataReader["Id"];
                result += " ";
                result += sqlDataReader["Name"];
                result += " ";
                result += sqlDataReader["PhoneNumber"];
                result += "\n";
            }

            return result;
        }

        public string GetClient(Guid userId)
        {
            var result = string.Empty;

            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(GetClientSQL, userId);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            using var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                result += sqlDataReader["Id"];
                result += " ";
                result += sqlDataReader["Name"];
                result += " ";
                result += sqlDataReader["PhoneNumber"];
            }

            return result;
        }
    }
}
