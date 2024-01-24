// DevFit 1.0

// C# é fortemente tipado, definimos o tipo da viarável.
// Toda instrução em C# é finalizada com ponto e vírgula, ficar atento aos indicadores visuais da IDE.
string mensagemDeBoasVindas = "Boas vindas ao DevFit!\n";
// Variáveis
int id = 0;


// Listas C#
List<string> listaDosProfessores = new List<string> { "Kayque Sanmartin", "Fabiana Mendes" };
Dictionary<int, string> listaDosAlunos = new Dictionary<int, string>
{
    { ++id, "Lucas" },
    { ++id, "Amanda" }
};
Dictionary<int, string> treinosRegistrados = new Dictionary<int, string>
{
    { 1, "AB"},
    { 2, "ABC" },
    { 3, "ABCD" },
    { 4, "ABCDE" },
    { 5, "ABCDEF" }
};

Dictionary<string, string> treinosMontados = new Dictionary<string, string>();

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
    Console.WriteLine("[ 1 ] Exibir Professores\n" +
        "[ 2 ] Novo aluno(a)\n" +
        "[ 3 ] Alunos(as)\n" +
        "[ 4 ] Montar Treino\n" +
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
            MontarTreino();
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
    ExibirTituloDaOpcao("Exibindo Professores");

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
    ExibirTituloDaOpcao("Registrar Aluno(a)");

    Console.Write("Digite o nome do Aluno(a): ");
    string novoAluno = Console.ReadLine()!;
    listaDosAlunos.Add(++id, novoAluno);
    Console.WriteLine($"\nAluno(a) {novoAluno} foi registrado(a) com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirMenu();
}

void MostrarAlunos()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo Alunos(as)");

    foreach (KeyValuePair<int, string> alunos in listaDosAlunos)
    {
        Console.WriteLine($"ID: {alunos.Key} | Nome: {alunos.Value}");
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

void MenuTreinos()
{
    Console.Clear();
    ExibirTituloDaOpcao("Lista de Treinos Padrão");

    foreach (KeyValuePair<int, string> treino in treinosRegistrados)
    {
        Console.WriteLine($"[ {treino.Key} ] {treino.Value}");
    }
}

void MontarTreino()
{
    // digitar o aluno
    // se o aluno existir no dicionario >> atribuir um treino
    // se não, volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Montar Treinos");

    foreach (var alunos in listaDosAlunos)
    {
        Console.WriteLine($"ID: {alunos.Key}: {alunos.Value}");
    }

    Console.WriteLine("\nDigite o ID do Aluno que gostaria de montar o treino:");
    Console.Write("ID: ");
    int idDoAluno = int.Parse(Console.ReadLine()!);

    if (listaDosAlunos.ContainsKey(idDoAluno))
    {
        MenuTreinos();

        Console.WriteLine($"\nSelecione o tipo de treino que gostaria de montar:");
        int opcaoTreino = int.Parse(Console.ReadLine()!);

        switch (opcaoTreino)
        {
            case 1:
                if (treinosRegistrados.ContainsKey(opcaoTreino))
                {
                    treinosMontados.Add(treinosRegistrados[opcaoTreino], listaDosAlunos[idDoAluno]);
                }
                Console.Clear();
                ExibirTituloDaOpcao("Histórico de Treinos Montados");
                foreach (var treinos in treinosMontados)
                {
                    Console.WriteLine($"{treinos.Key}: {treinos.Value}");
                }
                Console.WriteLine("\nDigite uma tecla para retornar ao Menu Principal.");
                Console.ReadKey();
                Console.Clear();
                ExibirMenu();
                break;
            case 2:
                if (treinosRegistrados.ContainsKey(opcaoTreino))
                {

                    treinosMontados.Add(treinosRegistrados[opcaoTreino], listaDosAlunos[idDoAluno]);
                }
                Console.Clear();
                ExibirTituloDaOpcao("Histórico de Treinos Montados");
                foreach (var treinos in treinosMontados)
                {
                    Console.WriteLine($"{treinos.Key}: {treinos.Value}");
                }
                Console.WriteLine("\nDigite uma tecla para retornar ao Menu Principal.");
                Console.ReadKey();
                Console.Clear();
                ExibirMenu();
                break;
            case 3:
                if (treinosRegistrados.ContainsKey(opcaoTreino))
                {
                    treinosMontados.Add(treinosRegistrados[opcaoTreino], listaDosAlunos[idDoAluno]);
                }
                Console.Clear();
                ExibirTituloDaOpcao("Histórico de Treinos Montados");
                foreach (var treinos in treinosMontados)
                {
                    Console.WriteLine($"{treinos.Key}: {treinos.Value}");
                }
                Console.WriteLine("\nDigite uma tecla para retornar ao Menu Principal.");
                Console.ReadKey();
                Console.Clear();
                ExibirMenu();
                break;
            case 4:
                if (treinosRegistrados.ContainsKey(opcaoTreino))
                {
                    treinosMontados.Add(treinosRegistrados[opcaoTreino], listaDosAlunos[idDoAluno]);
                }
                Console.Clear();
                ExibirTituloDaOpcao("Histórico de Treinos Montados");
                foreach (var treinos in treinosMontados)
                {
                    Console.WriteLine($"{treinos.Key}: {treinos.Value}");
                }
                Console.WriteLine("\nDigite uma tecla para retornar ao Menu Principal.");
                Console.ReadKey();
                Console.Clear();
                ExibirMenu();
                break;
            case 5:
                if (treinosRegistrados.ContainsKey(opcaoTreino))
                {
                    treinosMontados.Add(treinosRegistrados[opcaoTreino], listaDosAlunos[idDoAluno]);
                }
                Console.Clear();
                ExibirTituloDaOpcao("Histórico de Treinos Montados");
                foreach (var treinos in treinosMontados)
                {
                    Console.WriteLine($"{treinos.Key}: {treinos.Value}");
                }
                Console.WriteLine("\nDigite uma tecla para retornar ao Menu Principal.");
                Console.ReadKey();
                Console.Clear();
                ExibirMenu();
                break;
            default:
                Console.WriteLine("Opção Inválida!");
                Console.WriteLine("\nDigite uma tecla para retornar ao Menu Principal.");
                Console.ReadKey();
                Console.Clear();
                ExibirMenu();
                break;
        }
    }
    else
    {
        Console.WriteLine($"\nAluno {idDoAluno} não foi encontrado!");
        Console.WriteLine("Digite uma tecla para voltar ao Menu Principal.");
        Console.ReadKey();
        Console.Clear();
        ExibirMenu();
    }
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine($"{asteriscos}\n" +
        $"{titulo}\n" +
        $"{asteriscos}\n");
}

// Devemos chamar a função para que seja exibido o bloco de código.
ExibirMenu();