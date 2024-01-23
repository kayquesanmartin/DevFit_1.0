// DevFit 1.0

// C# é fortemente tipado, definimos o tipo da viarável.
// Toda instrução em C# é finalizada com ponto e vírgula, ficar atento aos indicadores visuais da IDE.
string mensagemDeBoasVindas = "Boas vindas ao DevFit!\n";

// Listas C#
List<string> listaDosProfessores = ["Lucas Marcelo", "Fabiana Mendes"];
List<string> listaDosAlunos = new List<string> { "Kayque", "Amanda",  "Renan", "Guilherme", "João", "Bruna"};

//Isolamos o código em funções para reutilizarmos, evitando uso de repetições. Devemos determinar se a função possui algum tipo de retorno.
// Exibe a mensagem de boas vindas.
void ExibirLogo()
{
    // @ é um Verbatim Literal.
    Console.WriteLine(@"
██████╗░███████╗██╗░░░██╗███████╗██╗████████╗
██╔══██╗██╔════╝██║░░░██║██╔════╝██║╚══██╔══╝
██║░░██║█████╗░░╚██╗░██╔╝█████╗░░██║░░░██║░░░
██║░░██║██╔══╝░░░╚████╔╝░██╔══╝░░██║░░░██║░░░
██████╔╝███████╗░░╚██╔╝░░██║░░░░░██║░░░██║░░░
╚═════╝░╚══════╝░░░╚═╝░░░╚═╝░░░░░╚═╝░░░╚═╝░░░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

// Menu de opções do App
void ExibirMenu()
{
    ExibirLogo();
    Console.WriteLine("[ 1 ] Selecionar Professor\n" +
        "[ 2 ] Novo aluno(a)\n" +
        "[ 3 ] Alunos(as)\n" +
        "[ 4 ] Montar treino\n" +
        "[ 5 ] Sair do App\n");

    Console.Write("Digite uma opção: ");
    int opcaoEscolhida = int.Parse(Console.ReadLine()!);

    // Condicional para adicionar funcionalidade ao App
    switch (opcaoEscolhida)
    {
        case 1:
            ListarProfessores();
            break;
        case 2:
            NovoAluno();
            break;
        case 3:
            MostrarAlunos();
            break;
        case 4:
            Console.WriteLine($"Você escolheu a opção {opcaoEscolhida}");
            break;
        case 5:
            Console.WriteLine($"Finalizando Sessão...");
            break;
        default:
            Console.WriteLine("Opção Inválida.");
            break;
    }
}

void ListarProfessores()
{
    Console.Clear();
    Console.WriteLine("*******************");
    Console.WriteLine("Exibindo Professores");
    Console.WriteLine("*******************\n");

    //for (int i = 0; i < listaDosProfessores.Count; i++)
    //{
    //    Console.WriteLine($"{listaDosProfessores[i]}");
    //}

    foreach (string professores in listaDosProfessores)
    {
        Console.WriteLine($"{professores}");
    }

    Console.WriteLine("\nDigite uma tecla para retornar ao Menu Principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();
}

void NovoAluno()
{
    Console.Clear();
    Console.WriteLine("*******************");
    Console.WriteLine("Registrar Aluno(a)");
    Console.WriteLine("*******************\n");

    Console.Write("Digite o nome do Aluno(a): ");
    string novoAluno = Console.ReadLine()!;
    listaDosAlunos.Add(novoAluno);
    Console.WriteLine($"\nAluno(a) {novoAluno} foi registrado(a) com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();
}

void MostrarAlunos()
{
    Console.Clear();
    Console.WriteLine("*******************");
    Console.WriteLine("Exibindo Alunos(as)");
    Console.WriteLine("*******************\n");

    foreach (string alunos in listaDosAlunos)
    {
        Console.WriteLine($"{alunos}");
    }

    //for (int i = 0; i < listaDosAlunos.Count; i++)
    //{
    //    Console.WriteLine($"{listaDosAlunos[i]}");
    //}

    Console.WriteLine("\nDigite uma tecla para retornar ao Menu Principal.");
    Console.ReadKey();
    Console.Clear();
    ExibirMenu();

}

// Devemos chamar a função para que seja exibido o bloco de código.
ExibirMenu();