using System;
using System.Collections.Generic;
namespace Vacinas;

class Program
{
    static List<Cidadao> _cidadaosVacinados = new List<Cidadao>();
    static List<Funcionario> _funcionarios = new List<Funcionario>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Bem-vindo ao sistema de vacinação!");
            Console.WriteLine("Você é um cidadão ou funcionário? (Digite 'c' para cidadão ou 'f' para funcionário)");
            char choice = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (choice == 'c')
            {
                CidadaoMenu();
                break;
            }
            else if (choice == 'f')
            {
                FuncionarioMenu();
                break;
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }

    static void CidadaoMenu()
    {
        Console.Clear();
        Console.WriteLine("Criação de conta:");
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();
        Console.Write("Digite sua idade: ");
        int idade = int.Parse(Console.ReadLine());
        Console.Write("Digite seu CPF: ");
        string cpf = Console.ReadLine();

        Cidadao novoCidadao = new Cidadao(nome, cpf, idade, false);
        _cidadaosVacinados.Add(novoCidadao);
        
        Console.WriteLine("Login:");
        Console.Write("Digite seu nome: ");
        string loginNome = Console.ReadLine();
        Console.Write("Digite seu CPF: ");
        string loginCpf = Console.ReadLine();

        Cidadao cidadaoLogado = EncontrarCidadao(loginNome, loginCpf);
        if (cidadaoLogado == null)
        {
            Console.WriteLine("Usuário não encontrado. Tente novamente.");
            return;
        }

        Console.WriteLine("Você foi vacinado? (s/n)");
        bool vacinado = char.ToLower(Console.ReadKey().KeyChar) == 's';
        Console.WriteLine();

        Console.WriteLine($"Nome: {cidadaoLogado.Nome}");
        Console.WriteLine($"Idade: {cidadaoLogado.Idade}");
        Console.WriteLine($"CPF: {cidadaoLogado.CPF}");
        Console.WriteLine($"Vacinado: {(vacinado ? "Sim" : "Não")}");

        Console.WriteLine("Deseja ver a lista de cidadãos vacinados? (s/n)");
        if (char.ToLower(Console.ReadKey().KeyChar) == 's')
        {
            MostrarVacinados();
        }
    }

    static void FuncionarioMenu()
    {
        Console.Clear();
        Console.WriteLine("Criação de conta:");
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();
        Console.Write("Digite sua matrícula: ");
        string matricula = Console.ReadLine();
        Console.Write("Digite o CNPJ da empresa: ");
        string cnpj = Console.ReadLine();

        _funcionarios.Add(new Funcionario(nome, matricula, cnpj));

        Console.WriteLine("Login:");
        Console.Write("Digite sua matrícula: ");
        string loginMatricula = Console.ReadLine();

        Funcionario funcionarioLogado = ProcurarFuncionario(loginMatricula);
        if (funcionarioLogado == null)
        {
            Console.WriteLine("Usuário não encontrado. Tente novamente.");
            return;
        }

        Console.WriteLine($"Nome: {funcionarioLogado.Nome}");
        Console.WriteLine($"Matrícula: {funcionarioLogado.Matricula}");
        Console.WriteLine($"CNPJ da empresa: {funcionarioLogado.CNPJ}");

        Console.WriteLine("Deseja adicionar um cidadão à lista de vacinados? (s/n)");
        if (char.ToLower(Console.ReadKey().KeyChar) == 's')
        {
            AdicionarCidadao();
        }

        Console.WriteLine("Deseja ver a lista de cidadãos vacinados? (s/n)");
        if (char.ToLower(Console.ReadKey().KeyChar) == 's')
        {
            MostrarVacinados();
        }
    }

    static void AdicionarCidadao()
    {
        Console.Clear();
        Console.WriteLine("\nAdicionar cidadão à lista de vacinados:");
        Console.Write("Digite o nome do cidadão: ");
        string cidadaoNome = Console.ReadLine();
        Console.Write("Digite o CPF do cidadão: ");
        string cidadaoCpf = Console.ReadLine();

        _cidadaosVacinados.Add(new Cidadao(cidadaoNome, cidadaoCpf));
        Console.WriteLine($"{cidadaoNome} adicionado à lista de vacinados com sucesso!");
    }

    static void MostrarVacinados()
    {
        Console.Clear();
        Console.WriteLine("\nLista de cidadãos vacinados:");
        foreach (var cidadao in _cidadaosVacinados)
        {
            Console.WriteLine($"Nome: {cidadao.Nome}, CPF: {cidadao.CPF}");
        }
    }

    static Cidadao EncontrarCidadao(string nome, string cpf)
    {
        foreach (var cidadao in _cidadaosVacinados)
        {
            if (cidadao.Nome == nome && cidadao.CPF == cpf)
            {
                return cidadao;
            }
        }
        return null;
    }

    static Funcionario ProcurarFuncionario(string matricula)
    {
        foreach (var funcionario in _funcionarios)
        {
            if (funcionario.Matricula == matricula)
            {
                return funcionario;
            }
        }
        return null;
    }
}


