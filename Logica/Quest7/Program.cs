namespace Par
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarContadorPar();
        }

        static void IniciarContadorPar()
        {
            TestarObterElementosPares();
            do
            {
                Console.WriteLine("Escreva uma sequência de numeros separados por espaço para obter os elementos pares:");
                string[] numeros = Console.ReadLine().Split(' ');
                int[] vetor = Array.ConvertAll(numeros, int.Parse);
                int[] elementosPares = ObterElementosPares(vetor);
                Console.WriteLine("Elementos pares: " + string.Join(", ", elementosPares));

                Console.WriteLine("\nPressione ESC para sair ou qualquer outra tecla para calcular novamente.");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        static int[] ObterElementosPares(int[] vetor)
        {
            int[] paresTemp = new int[vetor.Length];
            int count = 0;

            foreach (int numero in vetor)
            {
                if (numero % 2 == 0)
                {
                    paresTemp[count] = numero;
                    count++;
                }
            }

            int[] pares = new int[count];
            Array.Copy(paresTemp, pares, count);

            return pares;
        }

        static void TestarObterElementosPares()
        {
            int[] vetor = [1, 2, 3, 4, 5];
            int[] resultadoEsperado = [2, 4];
            int[] resultadoObtido = ObterElementosPares(vetor);

            if (resultadoEsperado.Length == resultadoObtido.Length &&
                resultadoEsperado.SequenceEqual(resultadoObtido))
            {
                Console.WriteLine("Teste passou: ObterElementosPares({ 1, 2, 3, 4, 5 }) == { 2, 4 }");
            }
            else
            {
                Console.WriteLine("Teste falhou: Resultado esperado: { 2, 4 }, Resultado obtido: { " + string.Join(", ", resultadoObtido) + " }");
            }
        }
    }
}
