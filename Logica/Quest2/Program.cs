namespace PrizeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarCalculadoraPremio();
        }

        enum TipoPremio
        {
            Basic,
            Vip,
            Premium,
            Deluxe, 
            Special,
            Proprio 
        }

        static void IniciarCalculadoraPremio()
        {
            do
            {
                TestarCalcularPremio();
                Console.WriteLine("Calculadora de Prêmios");

                Console.Write("Digite o valor base do prêmio: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal valorBase))
                {
                    Console.WriteLine("Por favor, digite um valor válido.");
                    continue;
                }

                Console.WriteLine("\nTipos de prêmio disponíveis:");
                foreach (TipoPremio tipo in Enum.GetValues(typeof(TipoPremio)))
                {
                    if (tipo != TipoPremio.Proprio)
                        Console.WriteLine($"- {tipo} ({ObterMultiplicador(tipo)}x)");
                }
                Console.WriteLine("- Proprio (Digite seu próprio multiplicador)");

                Console.Write("\nDigite o tipo do prêmio: ");
                string tipoInput = Console.ReadLine();

                decimal? multiplicadorProprio = null;
                if (tipoInput.Equals("Proprio", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Digite o multiplicador desejado: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal mult) && mult > 0)
                    {
                        multiplicadorProprio = mult;
                    }
                    else
                    {
                        Console.WriteLine("Multiplicador inválido, usando Basic como padrão.");
                        tipoInput = "Basic";
                    }
                }

                if (!Enum.TryParse(tipoInput, true, out TipoPremio tipoPremio))
                {
                    Console.WriteLine("Tipo inválido, usando Basic como padrão.");
                    tipoPremio = TipoPremio.Basic;
                }

                decimal resultado = CalcularPremio(valorBase, tipoPremio, multiplicadorProprio);
                Console.WriteLine($"\nValor final do prêmio: R$ {resultado:F2}");

                Console.WriteLine("\nPressione qualquer tecla para calcular novamente ou ESC para sair...");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static decimal ObterMultiplicador(TipoPremio tipo)
        {
            return tipo switch
            {
                TipoPremio.Basic => 1.0m,
                TipoPremio.Vip => 1.2m,
                TipoPremio.Premium => 1.5m,
                TipoPremio.Deluxe => 1.8m,
                TipoPremio.Special => 2.0m,
                _ => 1.0m
            };
        }

        static decimal CalcularPremio(decimal valor, TipoPremio tipo, decimal? multiplicadorProprio)
        {
            if (valor <= 0)
                return 0;

            if (multiplicadorProprio.HasValue && multiplicadorProprio.Value > 0)
                return valor * multiplicadorProprio.Value;


            decimal multiplicador = ObterMultiplicador(tipo);
            return valor * multiplicador;
        }

         static void TestarCalcularPremio()
        {
            decimal valorBase1 = 100;
            string tipo1 = "Vip";
            decimal? mult1 = null;
            decimal resultadoEsperado1 = 120.00m;
            decimal resultadoCalculado1 = CalcularPremio(valorBase1, Enum.Parse<TipoPremio>(tipo1, true), mult1);

            if (resultadoCalculado1 == resultadoEsperado1)
            {
                Console.WriteLine($"Teste passou: CalcularPremio({valorBase1}, \"{tipo1}\", {mult1}) == {resultadoEsperado1}");
            }
            else
            {
                Console.WriteLine($"Teste falhou: CalcularPremio({valorBase1}, \"{tipo1}\", {mult1}) != {resultadoEsperado1}");
            }

            decimal valorBase2 = 100;
            string tipo2 = "Basic";
            decimal? mult2 = 3;
            decimal resultadoEsperado2 = 300.00m;
            decimal resultadoCalculado2 = CalcularPremio(valorBase2, Enum.Parse<TipoPremio>(tipo2, true), mult2);

            if (resultadoCalculado2 == resultadoEsperado2)
            {
                Console.WriteLine($"Teste passou: CalcularPremio({valorBase2}, \"{tipo2}\", {mult2}) == {resultadoEsperado2}");

            }
            else
            {
                Console.WriteLine($"Teste falhou: CalcularPremio({valorBase2}, \"{tipo2}\", {mult2}) != {resultadoEsperado2}");
                Console.WriteLine($"{resultadoCalculado2}");
            }
        }
    }
}
