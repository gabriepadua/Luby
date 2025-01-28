namespace TransMatriz
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarTransformacao();
        }

        static void IniciarTransformacao()
        {
            TestarTransformarEmMatriz();
            do
            {
                Console.WriteLine("Transformar em matriz");
                Console.WriteLine("Digite uma sequência de números separados por vírgula:");

                string entrada = Console.ReadLine();
                int[][] matriz = TransformarEmMatriz(entrada);

                Console.WriteLine("Matriz resultante:");
                foreach (var linha in matriz)
                {
                    Console.WriteLine("[ " + string.Join(", ", linha) + " ]");
                }

                Console.WriteLine("\nPressione ESC para sair ou qualquer outra tecla para continuar.");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.Clear();
        }

        static int[][] TransformarEmMatriz(string entrada)
        {
            string[] numeros = entrada.Split(',');
            int[] vetor = Array.ConvertAll(numeros, int.Parse);

            int tamanhoMatriz = (int)Math.Ceiling(vetor.Length / 2.0);
            int[][] matriz = new int[tamanhoMatriz][];

            for (int i = 0, index = 0; i < tamanhoMatriz; i++)
            {
                int tamanhoLinha = Math.Min(2, vetor.Length - index);
                matriz[i] = new int[tamanhoLinha];
                Array.Copy(vetor, index, matriz[i], 0, tamanhoLinha);
                index += tamanhoLinha;
            }

            return matriz;
        }

        static void TestarTransformarEmMatriz()
        {
            string entrada = "1,2,3,4,5,6";
            int[][] resultadoObtido = TransformarEmMatriz(entrada);

            Console.WriteLine("Matriz do teste:");
            foreach (var linha in resultadoObtido)
            {
                Console.WriteLine("[ " + string.Join(", ", linha) + " ]");
            }
        }
    }
}