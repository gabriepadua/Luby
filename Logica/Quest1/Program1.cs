using System;

namespace FactorialCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Chama a func para iniciar o programa
            IniciarFatorial();
        }

        static void IniciarFatorial()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Cálculo de Fatorial");
                Console.WriteLine("--------------------");
                Console.Write("Digite um número para calcular o fatorial: ");

                if (int.TryParse(Console.ReadLine(), out int numero)) // Converte a entrada em um número inteiro
                {
                    if (numero < 0)
                    {
                        Console.WriteLine("Fatorial não é definido para números negativos.");
                    }
                    else
                    {
                        long resultado = CalcularFatorial(numero); // Chama a func Fatorial para fazer os cálculos
                        Console.WriteLine($"O fatorial de {numero} é: {resultado}");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }

                Console.WriteLine("\nPressione qualquer tecla para calcular novamente ou ESC para sair...");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape); // Sai do loop se ESC for pressionado
        }

        static long CalcularFatorial(int n)
        {
            long resultado = 1; // Lógica -> Vai multiplicando de 1 até "n"
            for (int i = 1; i <= n; i++)
            {
                resultado *= i; // Multiplica o resultado acumulado pelo número atual do loop (i).
            }
            return resultado;
        }
    }
}
