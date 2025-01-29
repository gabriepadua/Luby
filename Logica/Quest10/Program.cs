namespace TransMatriz
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciarComparacao();
        }

        static void IniciarComparacao()
        {
            TestarObterElementosFaltantes();
            do
            {
                Console.WriteLine("Comparar dois vetores:");
                Console.WriteLine("Digite os números do primeiro vetor separados por vírgula:");
                string entrada1 = Console.ReadLine();

                Console.WriteLine("Digite os números do segundo vetor separados por vírgula:");
                string entrada2 = Console.ReadLine();

                int[] vetor1 = TransformarEmVetor(entrada1);
                int[] vetor2 = TransformarEmVetor(entrada2);

                int[] elementosFaltantes = ObterElementosFaltantes(vetor1, vetor2);

                Console.WriteLine("Elementos faltantes em ambos os vetores:");
                Console.WriteLine("[ " + string.Join(", ", elementosFaltantes) + " ]");

                Console.WriteLine("\nPressione ESC para sair ou qualquer outra tecla para continuar.");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            Console.Clear();
        }

        static int[] ObterElementosFaltantes(int[] vetor1, int[] vetor2)
        {
            int[] faltantes1 = Array.FindAll(vetor1, e => Array.IndexOf(vetor2, e) == -1);

            int[] faltantes2 = Array.FindAll(vetor2, e => Array.IndexOf(vetor1, e) == -1);

            int[] resultado = new int[faltantes1.Length + faltantes2.Length];
            Array.Copy(faltantes1, 0, resultado, 0, faltantes1.Length);
            Array.Copy(faltantes2, 0, resultado, faltantes1.Length, faltantes2.Length);

            return resultado;
        }

        static int[] TransformarEmVetor(string entrada)
        {
            string[] numeros = entrada.Split(',');
            return Array.ConvertAll(numeros, int.Parse);
        }

        static void TestarObterElementosFaltantes()
        {
            Console.WriteLine("Testando ObterElementosFaltantes...");

            int[] vetor1 = { 1, 2, 3, 4, 5 };
            int[] vetor2 = { 1, 2, 5 };
            int[] resultado1 = ObterElementosFaltantes(vetor1, vetor2);
            Console.WriteLine("Resultado 1: [ " + string.Join(", ", resultado1) + " ] == Esperado: [ 3, 4 ]");

            int[] vetor3 = { 1, 4, 5 };
            int[] vetor4 = { 1, 2, 3, 4, 5 };
            int[] resultado2 = ObterElementosFaltantes(vetor3, vetor4);
            Console.WriteLine("Resultado 2: [ " + string.Join(", ", resultado2) + " ] == Esperado: [ 2, 3 ]");

            int[] vetor5 = { 1, 2, 3, 4 };
            int[] vetor6 = { 2, 3, 4, 5 };
            int[] resultado3 = ObterElementosFaltantes(vetor5, vetor6);
            Console.WriteLine("Resultado 3: [ " + string.Join(", ", resultado3) + " ] == Esperado: [ 1, 5 ]");

            int[] vetor7 = { 1, 3, 4, 5 };
            int[] vetor8 = { 1, 3, 4, 5 };
            int[] resultado4 = ObterElementosFaltantes(vetor7, vetor8);
            Console.WriteLine("Resultado 4: [ " + string.Join(", ", resultado4) + " ] == Esperado: [ ]");
        }
    }
}
