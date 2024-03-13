namespace ProjetoPOO;

class Funcionario
{
    public string Nome { get; set; }
    public int Matricula { get; set; }
    public int Cnpj { get; set; }
    
    public Funcionario()
    {
    }

    public Funcionario(string nome, int matricula, int cnpj)
    {
        Nome = nome;
        Matricula = matricula;
        Cnpj = cnpj;
    }
}

class Cidadao
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public bool Vacinado { get; set; }

    public Cidadao()
    {
        
    }

    public Cidadao(string cpf, string nome, int idade, bool vacinado)
    {
        Cpf = cpf;
        Nome = nome;
        Idade = idade;
        Vacinado = false;
    }
    
}

class CadastroVacinaConsole
{
    private List<Funcionario> _funcionarios;
    private List<Cidadao> _cidadaos;

    public CadastroVacinaConsole()
    {
        _funcionarios = new List<Funcionario>();
        _cidadaos = new List<Cidadao>();
    }

    public void CadastrarFuncionario()
    {
        Console.WriteLine("Cadastro de Funcionário");
        Console.Write("Seu nome: ");
        string nome = Console.ReadLine();
        Console.Write("Matrícula: ");
        int matricula = Convert.ToInt32(Console.ReadLine());
        Console.Write("CNPJ da Prestadora de Serviço: ");
        int cnpj = Convert.ToInt32(Console.ReadLine());
         
        _funcionarios.Add(new Funcionario());
        
        Funcionario funcionario = new Funcionario();
        funcionario.Nome = nome;
        funcionario.Matricula = matricula;
        funcionario.Cnpj = cnpj;
        _funcionarios.Add(funcionario);


        Console.WriteLine("Funcionário cadastrado com sucesso!\n");
    }

    public void CadastrarCidadao()
    {
        Console.WriteLine("Cadastro de Cidadão");
        Console.Write("Seu nome: ");
        string nome = Console.ReadLine();
        Console.Write("CPF: ");
        string cpf = Console.ReadLine();
        Console.Write("Idade: ");
        int idade = Convert.ToInt32(Console.ReadLine());
        
        Cidadao cidadao = new Cidadao(cpf, nome, idade, false);

        _cidadaos.Add(cidadao);
        
        cidadao.Cpf = cpf;
        cidadao.Nome = nome;
        cidadao.Idade = idade;
        cidadao.Vacinado = false;

        Console.WriteLine("Cidadão cadastrado com sucesso!\n");
    }

    public void MarcarVacinado()
    {
        Console.WriteLine("Marcar a vacina");
        Console.Write("CPF do cidadão a ser marcado como vacinado: ");
        string cpf = Console.ReadLine();

        foreach (Cidadao cidadao in _cidadaos)
        {
            if (cidadao.Cpf == cpf)
            {
                if (cidadao.Cpf == cpf)
                {
                    Console.WriteLine("O cidadão já foi vacinado? (true/false)");
                    string resposta = Console.ReadLine();

                    if (bool.TryParse(resposta, out bool vacinado))
                    {
                        cidadao.Vacinado = vacinado;
                        Console.WriteLine("Cidadão marcado como vacinado com sucesso!\n");
                    }
                    else
                    {
                        Console.WriteLine("Resposta inválida. Utilize 'true' ou 'false'.\n");
                    }

                    return;
                }
            }
        }
        Console.WriteLine($"Cidadão com CPF {cpf} não encontrado.\n");
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Cadastrar Funcionário");
            Console.WriteLine("2 - Cadastrar Cidadão");
            Console.WriteLine("3 - Marcar Cidadão como Vacinado");
            Console.WriteLine("4 - Sair");

            int opcao;
            if (int.TryParse(Console.ReadLine(), out opcao));

            switch (opcao)
            {
                case 1:
                    CadastrarFuncionario();
                    break;
                case 2:
                    CadastrarCidadao();
                    break;
                case 3:
                    MarcarVacinado();
                    break;
                case 4:
                    Console.WriteLine("Tchau!");
                    return;
                default:
                    Console.WriteLine("Opção inválida, por favor tente novamente.\n");
                    break;
            }
        }
    }

    static void Main()
    {
        CadastroVacinaConsole cadastro = new CadastroVacinaConsole();
        cadastro.Menu();
    }
}
