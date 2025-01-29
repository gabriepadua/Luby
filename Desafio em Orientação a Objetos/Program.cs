public interface IVendingMachine
{
    void MostrarProdutos();
    void RealizarVenda();
    void MostrarTotalVendas();
}

public class Produto
{
    public int Codigo { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public int Quantidade { get; private set; }

    public Produto(int codigo, string nome, decimal preco, int quantidade)
    {
        Codigo = codigo;
        Nome = nome;
        Preco = preco;
        Quantidade = quantidade;
    }

    public void DiminuirQuantidade()
    {
        if (Quantidade > 0)
            Quantidade--;
    }
}

public class VendingMachine : IVendingMachine
{
    private List<Produto> _produtos;
    private decimal _totalVendas;

    public VendingMachine()
    {
        _produtos = new List<Produto>
        {
            new Produto(1, "Pepsi", 5.00m, 7),
            new Produto(2, "RedBull", 12.50m, 3),
            new Produto(3, "Guaraná", 4.00m, 15)
        };
        _totalVendas = 0;
    }

    public void MostrarProdutos()
    {
        Console.WriteLine("\nProdutos Disponíveis:");
        Console.WriteLine("----------------------");

        foreach (var produto in _produtos)
        {
            Console.WriteLine($"Código {produto.Codigo} | {produto.Nome} | R${produto.Preco} | Qtd: {produto.Quantidade}");
        }
    }

    public void RealizarVenda()
    {
        MostrarProdutos();

        Console.WriteLine("\nDigite o código do produto:");
        if (!int.TryParse(Console.ReadLine(), out int codigoProduto))
        {
            Console.WriteLine("Código inválido!");
            return;
        }

        Produto produto = null;
        foreach (var p in _produtos)
        {
            if (p.Codigo == codigoProduto)
            {
                produto = p;
                break;
            }
        }

        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado!");
            return;
        }

        if (produto.Quantidade == 0)
        {
            Console.WriteLine("Produto esgotado!");
            return;
        }

        Console.WriteLine($"\nProduto escolhido: {produto.Nome}");
        Console.WriteLine($"Preço: R${produto.Preco}");

        decimal valorPago = 0;

        while (valorPago < produto.Preco)
        {
            decimal valorFaltante = produto.Preco - valorPago;
            Console.WriteLine($"\nValor faltante: R${valorFaltante}");
            Console.WriteLine("Insira o dinheiro:");

            if (!decimal.TryParse(Console.ReadLine(), out decimal valorInserido) || valorInserido <= 0)
            {
                Console.WriteLine("Valor inválido! Tente novamente.");
                continue;
            }

            valorPago += valorInserido;
        }

        decimal troco = valorPago - produto.Preco;
        if (troco > 0)
        {
            Console.WriteLine($"\nTroco: R${troco}");
        }
        produto.DiminuirQuantidade();
        _totalVendas += produto.Preco;
        Console.WriteLine("Venda realizada com sucesso!");
    }

    public void MostrarTotalVendas()
    {
        Console.WriteLine($"\nTotal de vendas: R${_totalVendas}");
    }
}


public class Program
{
    public static void Main()
    {
        IVendingMachine maquina = new VendingMachine();
        MenuPrincipal(maquina);
    }

    private static void MenuPrincipal(IVendingMachine maquina)
    {
        while (true)
        {
            Console.WriteLine("\n=== MÁQUINA DE VENDAS ===");
            Console.WriteLine("1 - Comprar Produto");
            Console.WriteLine("2 - Ver Produtos");
            Console.WriteLine("3 - Ver Total de Vendas");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("Escolha uma opção:");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                switch (opcao)
                {
                    case 1:
                        maquina.RealizarVenda();
                        break;
                    case 2:
                        maquina.MostrarProdutos();
                        break;
                    case 3:
                        maquina.MostrarTotalVendas();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}
