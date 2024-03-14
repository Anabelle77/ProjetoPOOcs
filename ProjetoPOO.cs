namespace ProjetoPOO
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Cnpj { get; set; }

        public Funcionario(string nome, string matricula, string cnpj)
        {
            Nome = nome;
            Matricula = matricula;
            Cnpj = cnpj;
        }
    }

    public class Cidadao
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool Vacinado { get; set; }

        public Cidadao(string cpf, string nome, int idade, bool vacinado)
        {
            Cpf = cpf;
            Nome = nome;
            Idade = idade;
            Vacinado = vacinado;
        }
        
        public void EstaVacinado()
        {
            Console.WriteLine("A pessoa está vacinada? (Digite 'sim' ou 'nao'):");
            string resposta = Console.ReadLine().ToLower();

            if (resposta == "sim")
            {
                Vacinado = true;
                
            }
            else if (resposta == "nao")
            {
                Vacinado = false;
            }
            else
            {
                Console.WriteLine("Resposta inválida. Por favor, digite 'sim' ou 'nao'.");
                EstaVacinado();
            }
        }
    }

    public class CadastroVacina
    {
        List<Funcionario> _funcionarios = new List<Funcionario>();
        List<Cidadao> _cidadaos = new List<Cidadao>();

        public CadastroVacina()
        {
            _funcionarios = new List<Funcionario>();
            _cidadaos = new List<Cidadao>();
        }

        public void cadastrarFuncionario()
        {
            Console.WriteLine("Cadastro de funcionário");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Matrícula: ");
            string matricula = Console.ReadLine();
            Console.WriteLine("CNPJ: ");
            string cnpj = Console.ReadLine();
            
            _funcionarios.Add(new Funcionario(nome, matricula, cnpj));
            Console.WriteLine("Cidadão cadastrado com sucesso!");

        }
    }
    
    
}
