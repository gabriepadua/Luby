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
                TestarCalcularValorComDescontoFormatado();
                Console.WriteLine("Insira o valor do produto: ");
                string valorProduto = Console.ReadLine().Trim();

                Console.WriteLine("Insira o percentual de desconto: ");
                string desconto = Console.ReadLine().Trim();

                string resultado = CalcularValorComDescontoFormatado(valorProduto, desconto);
                Console.WriteLine($"Valor com desconto: {resultado}");
                Console.WriteLine("\nPressione ESC para sair ou qualquer outra tecla para calcular novamente.");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static string CalcularValorComDescontoFormatado(string valorProduto, string desconto)
        {
            valorProduto = valorProduto.Replace("R$", "").Replace(",00","").Trim();
            string valorCalculavel = valorProduto.Replace(".", "").Replace(",", ".");

            if (!double.TryParse(valorCalculavel, out double valor))
            {
                return "Valor do produto inválido";
            }

            desconto = desconto.Replace("%", "").Trim();

            if (!double.TryParse(desconto, out double porcentagem))
            {
                return "Porcentagem inválida";
            }

            double valorComDesconto = valor * (1 - (porcentagem / 100));
            string valorComDescontoFormatado = "R$ " + valorComDesconto.ToString("N2");

            return valorComDescontoFormatado;
        }

        static void TestarCalcularValorComDescontoFormatado()
        {
            string valorProduto = "R$ 6.800,00";
            string desconto = "30%";
            string resultadoEsperado = "R$ 4.760,00";
            string resultadoObtido = CalcularValorComDescontoFormatado(valorProduto, desconto);

            Console.WriteLine($"Teste 1 - Valor do produto: {valorProduto}, Desconto: {desconto}");
            Console.WriteLine($"Resultado esperado: {resultadoEsperado}, Resultado obtido: {resultadoObtido}");
        }
    }
}
