using PocUrbanGreen.Data;
using System.Configuration;

var connectionString = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
var dataAcess = new DataAcess(connectionString);

Console.WriteLine("// Fazenda Urban Green //\n");

Console.WriteLine("Fornecedores: Digite 1 para cadastrar e 2 para listar");
int opcaoEscolhida = int.Parse(Console.ReadLine());

TrataOpcaoSelecionada(opcaoEscolhida);

void cadastroFornecedor()
{
    Console.Clear();

    Console.WriteLine("Digite o nome do fornecedor: ");
    var nomeFornc = Console.ReadLine();
    Console.WriteLine("Digite o CNPJ do fornecedor: ");
    var cnpjFornc = Console.ReadLine();
    Console.WriteLine("Digite o e-mail do fornecedor: ");
    var emailFornc = Console.ReadLine();

    dataAcess.CadastrarFornecedor(nomeFornc, cnpjFornc, emailFornc);
    Console.Clear();
    Console.WriteLine("As informações foram salvas!");
}

void listarFornecedores()
{
    Console.Clear();
    Console.WriteLine("Aguarde! Realizando leitura de dados...\n");
    dataAcess.ListarFornecedores();
}

void TrataOpcaoSelecionada(int opcaoEscolhida)
{
    if (opcaoEscolhida == 1)
    {
        cadastroFornecedor();
    }
    else if (opcaoEscolhida == 2)
    {
        listarFornecedores();
    }
    else
    {
        Console.WriteLine("A opção escolhida é inválida!");
    }
}