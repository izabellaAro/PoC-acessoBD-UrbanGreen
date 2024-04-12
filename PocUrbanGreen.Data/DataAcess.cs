using System.Data.SqlClient;

namespace PocUrbanGreen.Data
{
    public class DataAcess
    {
        private readonly string _connectionString;

        public DataAcess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ListarFornecedores()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                String sql = "SELECT * FROM TBFornecedor";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader.GetInt32(0)}, Nome: {reader.GetString(1)}, CNPJ: {reader.GetString(2)}, Email: {reader.GetString(3)}");
                        }
                    }
                }
            }
        }

        public void CadastrarFornecedor(string nome, string cnpj, string email)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                String sql = "insert into TBFornecedor (Nome, CNPJ, Email) values (@Nome, @CNPJ, @Email)";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@CNPJ", cnpj);
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}