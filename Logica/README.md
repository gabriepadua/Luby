# Desafios de Lógica de Programação

Este repositório contém uma série de desafios de lógica de programação resolvidos em C#. Cada desafio é acompanhado de uma função que resolve o problema proposto.
Além do comportamento esperado que foi fornecido no PDF, o usuário também poderá entrar com valores personalizados através do console.

## Desafios

### 1.1 Calcular Fatorial
Implemente uma função para calcular o fatorial de um número.  
Exemplo:
```csharp
CalcularFatorial(5) == 120; // true
```

### 1.2 Calcular Prêmio
Implemente uma função que calcula o valor total do prêmio somando o fator do tipo do prêmio conforme os valores:
- Tipo: "basic" fator multiplicação do prêmio: 1
- Tipo: "vip" fator multiplicação do prêmio: 1.2
- Tipo: "premium" fator multiplicação do prêmio: 1.5
- Tipo: "deluxe" fator multiplicação do prêmio: 1.8
- Tipo: "special" fator multiplicação do prêmio: 2

A função também deve permitir um parâmetro para um fator de multiplicação próprio. Quando informado e válido, este deve sobrescrever o cálculo do tipo de prêmio. O prêmio nunca deve ter um valor negativo ou igual a zero.

Exemplos:
```csharp
CalcularPremio(100, "vip", null) == 120.00; // true
CalcularPremio(100, "basic", 3) == 300.00; // true
```

### 1.3 Contar Números Primos
Implemente uma função para contar quantos números primos existem até o número informado.

Exemplo:
```csharp
ContarNumerosPrimos(10) == 4; // true
```

### 1.4 Calcular Vogais
Implemente uma função que conta e calcula a quantidade de vogais dentro de uma string.

Exemplo:
```csharp
CalcularVogais("Luby Software") == 4; // true
```

### 1.5 Calcular Valor com Desconto Formatado
Implemente uma função que aplica uma porcentagem de desconto a um valor e retorna o resultado. As entradas e saídas dos dados são strings que devem ser tratadas.

Exemplo:
```csharp
CalcularValorComDescontoFormatado("R$ 6.800,00", "30%") == "R$ 4.760,00"; // true
```

### 1.6 Calcular Diferença de Datas
Implemente uma função que obtém duas strings de datas e calcula a diferença de dias entre elas.

Exemplo:
```csharp
CalcularDiferencaData("10122020", "25122020") == 15; // true
```

### 1.7 Obter Elementos Pares
Implemente uma função que retorna um novo vetor com todos os elementos pares do vetor informado.

Exemplo:
```csharp
int[] vetor = new int[] { 1, 2, 3, 4, 5 };
ObterElementosPares(vetor) == new int[] { 2, 4 }; // true
```

### 1.8 Buscar Pessoa
Implemente uma função que deve buscar um ou mais elementos no vetor que contém o valor ou parte do valor informado na busca.

Exemplos:
```csharp
string[] vetor = new string[] {
    "John Doe",
    "Jane Doe",
    "Alice Jones",
    "Bobby Louis",
    "Lisa Romero"
};
BuscarPessoa(vetor, "Doe") == new string[] { "John Doe", "Jane Doe" }; // true
BuscarPessoa(vetor, "Alice") == new string[] { "Alice Jones" }; // true
BuscarPessoa(vetor, "James") == new string[] { }; // true
```

### 1.9 Transformar em Matriz
Implemente uma função que obtém uma string com números separados por vírgula e transforma em um array de arrays de inteiros com no máximo dois elementos.

Exemplo:
```csharp
TransformarEmMatriz("1,2,3,4,5,6") == new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 }, new int[] { 5, 6 } }; // true
```

### 1.10 Obter Elementos Faltantes
Implemente uma função que compara dois vetores e cria um novo vetor com os elementos faltantes de ambos.

Exemplos:
```csharp
int[] vetor1 = new int[] { 1, 2, 3, 4, 5 };
int[] vetor2 = new int[] { 1, 2, 5 };
ObterElementosFaltantes(vetor1, vetor2) == new int[] { 3, 4 }; // true

int[] vetor3 = new int[] { 1, 4, 5 };
int[] vetor4 = new int[] { 1, 2, 3, 4, 5 };
ObterElementosFaltantes(vetor3, vetor4) == new int[] { 2, 3 }; // true

int[] vetor5 = new int[] { 1, 2, 3, 4 };
int[] vetor6 = new int[] { 2, 3, 4, 5 };
ObterElementosFaltantes(vetor5, vetor6) == new int[] { 1, 5 }; // true

int[] vetor7 = new int[] { 1, 3, 4, 5 };
int[] vetor8 = new int[] { 1, 3, 4, 5 };
ObterElementosFaltantes(vetor7, vetor8) == new int[] { }; // true
```




