using Microsoft.Data.SqlClient;

namespace Client
{
    internal class ProductsRepository
    {
        private const string ConnectionString =
     @"Server=localhost\sqlexpress;Database=HomeWork1DB;Trusted_Connection=True;Encrypt=False;";
        private const string GetProductsSQL = @"SELECT * FROM Products";
        private const string GetProductSQL = @"SELECT * FROM Products WHERE Id = '{0}'";
        private const string AddProductSQL = @"INSERT INTO Products (Id, Name, Price) VALUES ('{0}', '{1}', '{2}')";
        private const string DeleteProductSQL =
            @"DELETE FROM Products WHERE Id = '{0}'";
        private const string UpdateProductSQL = @"UPDATE Products SET Name = '{0}', Price = '{1}' WHERE Id = '{2}'";

        public void UpdateProduct(string name, string phone, Guid userId)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(UpdateProductSQL, name, phone, userId);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
        }

        public void DeleteProduct(Guid userId)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(DeleteProductSQL, userId);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteReader();
        }

        public void AddProduct(Guid userId, string name, string number)
        {
            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(AddProductSQL, userId, name, number);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
        }

        public string GetProducts()
        {
            var result = string.Empty;

            using var sqlConnection = new SqlConnection(ConnectionString);
            var sqlCommand = new SqlCommand(GetProductsSQL, sqlConnection);

            sqlConnection.Open();
            using var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                result += sqlDataReader["Id"];
                result += " ";
                result += sqlDataReader["Name"];
                result += " ";
                result += sqlDataReader["Price"];
                result += "\n";
            }

            return result;
        }

        public string GetProduct(Guid userId)
        {
            var result = string.Empty;

            using var sqlConnection = new SqlConnection(ConnectionString);
            var formatedSQL = string.Format(GetProductSQL, userId);
            var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

            sqlConnection.Open();
            using var sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                result += sqlDataReader["Id"];
                result += " ";
                result += sqlDataReader["Name"];
                result += " ";
                result += sqlDataReader["Price"];
            }

            return result;
        }
    }
}
}
