namespace CalcData
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarCalc();
        }

        static void IniciarCalc()
        {
            TestarCalcularDiferencaData();
            do
            {
                Console.WriteLine("Digite a primeira data no formato ddMMyyyy:");
                string data1 = Console.ReadLine();
                Console.WriteLine("Digite a segunda data no formato ddMMyyyy:");
                string data2 = Console.ReadLine();

                string resultado = CalcularDiferencaData(data1, data2);
                if (resultado.StartsWith("Erro"))
                {
                    Console.WriteLine(resultado);
                }
                else
                {
                    Console.WriteLine($"O resultado é: {resultado} dias");
                }

                Console.WriteLine("\nPressione ESC para sair ou qualquer outra tecla para calcular novamente.");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        static string CalcularDiferencaData(string data1, string data2)
        {
            DateTime data1Formatada, data2Formatada;
            bool isData1Valida = DateTime.TryParseExact(data1, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out data1Formatada);
            bool isData2Valida = DateTime.TryParseExact(data2, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out data2Formatada);

            if (!isData1Valida || !isData2Valida)
            {
                return "Erro: Uma ou ambas as datas inseridas são inválidas.";
            }

            int diferencaDias = (data2Formatada - data1Formatada).Days;

            return diferencaDias.ToString();
        }

        static void TestarCalcularDiferencaData()
        {
            string data1 = "10122020";
            string data2 = "25122020";
            string resultado = CalcularDiferencaData(data1, data2);

            if (resultado == "15")
            {
                Console.WriteLine("Teste passou: CalcularDiferencaData(\"10122020\", \"25122020\") == 15");
            }
        }
    }
}