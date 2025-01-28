using System;

namespace Porcentagem
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecutarCalculadoraDesconto();
        }
        static void ExecutarCalculadoraDesconto()
        {
            do
            {
                Console.Clear();
                string resultado = CalcularValorComDescontoFormatado();
                Console.WriteLine($"Valor com desconto: {resultado}");
                Console.WriteLine("\nPressione ESC para sair ou qualquer outra tecla para calcular novamente.");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        static string CalcularValorComDescontoFormatado()
        {
            Console.WriteLine("Insira o valor do produto: ");
            string valorProduto = Console.ReadLine().Trim();

            // Solicita o valor do desconto
            Console.WriteLine("Insira o percentual de desconto: ");
            string desconto = Console.ReadLine().Trim();

            valorProduto = valorProduto.Replace("R$", "").Trim();
            valorProduto = valorProduto.Replace(".", "").Replace(",", ".");

            if (!double.TryParse(valorProduto, out double valor))
            {
                return "Valor do produto inválido";
            }

            desconto = desconto.Replace("%", "").Trim();

            if (!double.TryParse(desconto, out double porcentagem))
            {
                return "Porcentagem inválida";
            }

            double valorComDesconto = valor * (1 - (porcentagem / 100));

            string valorComDescontoFormatado = "R$ " + valorComDesconto.ToString("0.00").Replace('.', ',');

            return valorComDescontoFormatado;
        }
    }
}
