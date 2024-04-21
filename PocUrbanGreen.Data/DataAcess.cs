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

        public void AtualizarFornecedor(int id, string nome, string cnpj, string email)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                String sql = "UPDATE TBFornecedor SET [Nome] = @Nome, [CNPJ] = @CNPJ, [Email] = @Email WHERE [ID] = @ID";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@CNPJ", cnpj);
                    command.Parameters.AddWithValue("@Email",email);
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool ValidaFornecedorId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                String sql = "SELECT [ID] = @ID FROM TBFornecedor WHERE [ID] = @ID ";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        } 

        public void ExcluirFornecedor(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                String sql = "DELETE FROM TBFornecedor WHERE [ID] = @ID";

                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}