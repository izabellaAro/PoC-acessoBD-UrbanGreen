namespace PocUrbanGreen
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }

        public Fornecedor(string nome, string cnpj, string email) 
        {
            Nome = nome;
            CNPJ = cnpj;
            Email = email;
        }
    }
}
