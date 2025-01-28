using System;

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
                Console.Clear();
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

            if (tipo == TipoPremio.Proprio && multiplicadorProprio.HasValue && multiplicadorProprio.Value > 0)
                return valor * multiplicadorProprio.Value;

            decimal multiplicador = ObterMultiplicador(tipo);
            return valor * multiplicador;
        }
    }
}