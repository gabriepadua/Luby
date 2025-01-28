using System;

namespace VowelCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarContadorVogais();
        }

        static void IniciarContadorVogais()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Contador de Vogais");

                Console.Write("Digite o texto para contar as vogais: ");
                string texto = Console.ReadLine();

                int totalVogais = CalcularVogais(texto);
                
                Console.WriteLine($"\nTotal de vogais encontradas: {totalVogais}");

                Console.Write("Vogais encontradas: ");
                MostrarVogaisEncontradas(texto);

                Console.WriteLine("\nPressione qualquer tecla para contar novamente ou ESC para sair...");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static int CalcularVogais(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return 0;

            int contador = 0;
            string vogais = "aeiouáéíóúâêîôûãõ";
            
            texto = texto.ToLower();

            for (int i = 0; i < texto.Length; i++)
            {
                if (vogais.IndexOf(texto[i]) != -1)
                {
                    contador++;
                }
            }

            return contador;
        }

        static void MostrarVogaisEncontradas(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return;

            string vogais = "aeiouáéíóúâêîôûãõ";
            texto = texto.ToLower();
            bool primeiraVogal = true;

            for (int i = 0; i < texto.Length; i++)
            {
                if (vogais.IndexOf(texto[i]) != -1)
                {
                    if (!primeiraVogal)
                        Console.Write(", ");
                    Console.Write(texto[i]);
                    primeiraVogal = false;
                }
            }
            Console.WriteLine();
        }
    }
}