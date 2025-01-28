using System;

namespace PrimeCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarContadorPrimos();
        }

        static void IniciarContadorPrimos()
        {
            do
            {
                Console.Clear();
                Console.Write("Digite um número para contar os primos até ele: ");

                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    if (numero < 2)
                    {
                        Console.WriteLine("Não existem números primos menores que 2.");
                    }
                    else
                    {
                        int totalPrimos = ContarNumerosPrimos(numero);
                        Console.WriteLine($"\nTotal de números primos até {numero}: {totalPrimos}");
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, insira um número válido.");
                }

                Console.WriteLine("\nPressione qualquer tecla para contar novamente ou ESC para sair...");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape); // Sai do loop se ESC for pressionado
        }

        static int ContarNumerosPrimos(int limite)
        {
            int contador = 0;
            for (int i = 2; i <= limite; i++)
            {
                if (EhPrimo(i))
                {
                    Console.WriteLine($"Número primo: {i}");
                    contador++;
                }
            }
            return contador;
        }

        static bool EhPrimo(int numero)
        {
            if (numero <= 1) return false;
            if (numero == 2) return true;
            if (numero % 2 == 0) return false;

            var limite = (int)Math.Floor(Math.Sqrt(numero));

            for (int i = 3; i <= limite; i += 2)
            {
                if (numero % i == 0)
                    return false;
            }

            return true;
        }
    }
}