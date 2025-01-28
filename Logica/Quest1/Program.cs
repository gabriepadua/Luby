namespace FactorialCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarFatorial();
        }

        static void IniciarFatorial()
        {
            do
            {
                TestarCalcularFatorial();
                Console.WriteLine("Cálculo de Fatorial");
                Console.WriteLine("Digite um número para calcular o fatorial: ");

                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    if (numero < 0)
                    {
                        Console.WriteLine("Fatorial não é definido para números negativos.");
                    }
                    else
                    {
                        long resultado = CalcularFatorial(numero);
                        Console.WriteLine($"O fatorial de {numero} é: {resultado}");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }

                Console.WriteLine("\nPressione qualquer tecla para calcular novamente ou ESC para sair...");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static long CalcularFatorial(int n)
        {
            long resultado = 1;
            for (int i = 1; i <= n; i++)
            {
                resultado *= i;
            }
            return resultado;
        }

         static void TestarCalcularFatorial()
        {
            int numeroTeste = 5;
            long resultadoEsperado = 120;
            long resultadoCalculado = CalcularFatorial(numeroTeste);

            if (resultadoCalculado == resultadoEsperado)
            {
                Console.WriteLine($"Teste passou: CalcularFatorial({numeroTeste}) == {resultadoEsperado}");
            }
        }
    }
}
