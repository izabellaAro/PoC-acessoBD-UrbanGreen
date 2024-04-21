using PocUrbanGreen.Data;
using System.Configuration;

var connectionString = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
var dataAcess = new DataAcess(connectionString);

Console.WriteLine("// Fazenda Urban Green //\n");

Console.WriteLine("Fornecedores: Digite 1 para cadastrar, 2 para listar, 3 para atualizar ou 4 para deletar");
int opcaoEscolhida = int.Parse(Console.ReadLine());

TrataOpcaoSelecionada(opcaoEscolhida);

void CadastroFornecedor()
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

void ListarFornecedores()
{
    Console.Clear();
    Console.WriteLine("Aguarde! Realizando leitura de dados...\n");
    dataAcess.ListarFornecedores();
}

void AtualizarFornecedor()
{
    Console.Clear();
    Console.Write("Qual o número ID do fornecedor que deseja atualizar os dados? ");
    int idFornec = int.Parse(Console.ReadLine());
    if (dataAcess.ValidaFornecedorId(idFornec) == false)
    {
        Console.WriteLine("O número ID informado é inválido.");
        return;
    }
    Console.WriteLine("Informe o novo nome deste fornecedor: ");
    var nomeForn = Console.ReadLine();
    Console.WriteLine("Informe o novo CNPJ deste fornecedor: ");
    var cnpjForn = Console.ReadLine();
    Console.WriteLine("Informe o novo email deste fornecedor: ");
    var emailForn = Console.ReadLine();

    dataAcess.AtualizarFornecedor(idFornec, nomeForn, cnpjForn, emailForn);
    Console.Clear();
    Console.WriteLine("As atualizações foram realizadas!");
}

void TrataOpcaoSelecionada(int opcaoEscolhida)
{
    if (opcaoEscolhida == 1)
    {
        CadastroFornecedor();
    }
    else if (opcaoEscolhida == 2)
    {
        ListarFornecedores();
    }else if (opcaoEscolhida == 3)
    {
        AtualizarFornecedor();
    }
    else
    {
        Console.WriteLine("A opção escolhida é inválida!");
    }
}