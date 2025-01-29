# Vending Machine

Este repositório contém uma implementação de uma máquina de vendas (Vending Machine) utilizando conceitos da Programação Orientada a Objetos (POO) e princípios do SOLID.

## Alguns dos pilares da Programação Orientada a Objetos

### 1. **Encapsulamento**
   - A classe `Produto` protege suas propriedades (`Codigo`, `Nome`, `Preco` e `Quantidade`) com modificadores `private set`, garantindo que apenas a própria classe possa alterá-las.
   - A classe `VendingMachine` gerencia a lista de produtos internamente, sem expor diretamente os detalhes da implementação.

### 2. **Abstração**
   - A interface `IVendingMachine` define um contrato que qualquer implementação de máquina de vendas deve seguir, permitindo que diferentes tipos de máquinas possam ser implementadas sem alterar o código existente.

### 3. **Polimorfismo**
   - A interface `IVendingMachine` permite que diferentes implementações de máquinas de venda possam ser utilizadas de maneira genérica.
   - O objeto `IVendingMachine maquina = new VendingMachine();` demonstra como um objeto pode ser tratado de forma polimórfica.

## Princípios do SOLID

### 1. **Single Responsibility Principle (SRP)**
   - A classe `Produto` tem uma única responsabilidade: representar um produto.
   - A classe `VendingMachine` gerencia as vendas.

### 2. **Open/Closed Principle (OCP)**
   - A interface `IVendingMachine` permite que novas implementações de máquinas de venda possam ser criadas sem modificar o código existente.

### 3. **Interface Segregation Principle (ISP)**
   - A interface `IVendingMachine` está bem definida e foca apenas nas operações essenciais de uma máquina de vendas, evitando métodos desnecessários.

## Executando o Programa

Para executar a aplicação, basta compilar o arquivo e rodar o executável através do comando no terminal: dotnet run. O menu interativo permitirá que o usuário compre produtos, visualize os produtos disponíveis e veja o total de vendas realizadas.
