class Program
{
    static void Main(string[] args)
    {
        IniciarBusca();
    }

    static void IniciarBusca()
    {
        TesteBuscarPessoa();

        do
        {
            string[] userVetor = EntradaUsuario();
            string resultado = BuscarPessoaPorNome(userVetor);
            Console.WriteLine($"Lista com pessoas: {resultado}");
            Console.WriteLine("\nPressione ESC para sair ou qualquer outra tecla para calcular novamente.");
        }
        while (Console.ReadKey(true).Key != ConsoleKey.Escape);
    }
    static string[] BuscarPessoa(string[] vetor, string busca)
    {
        var resultados = new List<string>();

        foreach (var pessoa in vetor)
        {
            if (pessoa.IndexOf(busca, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                resultados.Add(pessoa);
            }
        }

        return resultados.ToArray();
    }

    static string[] EntradaUsuario()
    {
        Console.WriteLine("Digite os nomes das pessoas separados por vírgula:");
        string input = Console.ReadLine();
        string[] userVetor = input.Split(',');

        for (int i = 0; i < userVetor.Length; i++)
        {
            userVetor[i] = userVetor[i].Trim();
        }
        return userVetor;
    }

    static string BuscarPessoaPorNome(string[] vetor)
    {
        Console.WriteLine("Digite o termo de busca:");
        string busca = Console.ReadLine();

        string[] resultados = BuscarPessoa(vetor, busca);
        return string.Join(", ", resultados);
    }
    static void TesteBuscarPessoa()
    {
        string[] vetor = new string[] {
            "John Doe",
            "Jane Doe",
            "Alice Jones",
            "Bobby Louis",
            "Lisa Romero"
        };

        string[] result1 = BuscarPessoa(vetor, "Doe");
        string[] result2 = BuscarPessoa(vetor, "Alice");
        string[] result3 = BuscarPessoa(vetor, "James");

        Console.WriteLine("Teste 1 - Buscar 'Doe': " + string.Join(", ", result1)); // Output: John Doe, Jane Doe
        Console.WriteLine("Teste 2 - Buscar 'Alice': " + string.Join(", ", result2)); // Output: Alice Jones
        Console.WriteLine("Teste 3 - Buscar 'James': " + string.Join(", ", result3)); // Output: 
    }
}
