namespace ContadorPrimos
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
                TestarContadorPrimos();
                Console.Write("\n\nDigite um número para contar os primos até ele: ");

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
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
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
        static void TestarContadorPrimos()
        {
            Console.WriteLine("Executando teste do contador de números primos:");
            int limite = 10;
            int resultadoEsperado = 4;
            int resultadoObtido = ContarNumerosPrimos(limite);
            
            Console.WriteLine($"\nTeste para números primos até {limite}:");
            Console.WriteLine($"Resultado esperado: {resultadoEsperado}");
            Console.WriteLine($"Resultado obtido: {resultadoObtido}");
            Console.WriteLine($"Teste passou: {resultadoObtido == resultadoEsperado}");
        }

    }
}
