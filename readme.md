# 📦 Sistema de Despacho e Rotas de Entrega Local

## 📋 Sobre o Projeto
Este é um projeto desenvolvido em **C#** com o objetivo de praticar conceitos fundamentais de **Orientação a Objetos (POO)** e **Estruturas de Dados** lineares implementadas do zero (**Filas** e **Pilhas**). 

O sistema simula a operação de um centro de distribuição logístico, realizando a triagem inteligente de pacotes (priorizando entregas e respeitando o limite de peso), a organização de carga em mochila utilizando o princípio **LIFO** (*Last In, First Out*) e a simulação das entregas em campo.

---

## 🛠️ Tecnologias e Conceitos Utilizados
- **Linguagem:** C#
- **Paradigma:** Orientação a Objetos
- **Estruturas de Dados (Implementadas Manualmente):**
  * **Fila (`Queue`):** Gerencia a ordem de chegada dos pacotes na central, dando prioridade absoluta aos pacotes urgentes e respeitando a capacidade máxima de carga.
  * **Pilha (`Stack`):** Modela a mochila física do entregador, onde o último pacote a ser carregado (o mais ao fundo) é o último a sair, garantindo que o primeiro pacote da rota fique no topo para acesso imediato.
- **Estruturas Auxiliares:** Listas dinâmicas (`List<T>`) para manipulação de coleções.

---

## 🧩 Funcionalidades Principais
1. **Triagem por Prioridade e Peso:** Analisa os pacotes recebidos, selecionando primeiro os itens marcados como prioritários e preenchendo o restante da capacidade da mochila com os pacotes padrão, sem exceder o limite de peso.
2. **Carregamento Inteligente (Inversão LIFO):** Despeja os pacotes da fila da central e os empilha na mochila do entregador na ordem inversa da rota, assegurando que o pacote prioritário fique no topo.
3. **Simulação de Entrega:** Desempilha os pacotes sequencialmente da mochila, atualizando o peso atual e simulando a conclusão de cada entrega no terminal.
4. **Prevenção de Duplicidade:** Utiliza uma flag de controle interna para assegurar que cada pacote seja processado corretamente sem duplicidade de fluxo.

---

## 📁 Estrutura do Código
- **`Models/DispatchCenter.cs`**: Classe principal que gerencia as regras de negócio de recebimento, triagem de prioridade, carregamento do entregador e simulação das entregas.
- **`Models/DeliveryBackpack.cs`**: Modela a mochila do entregador, controlando a capacidade máxima, o peso atual e a instância da pilha de carga.
- **`Models/Package.cs`**: Modela os dados de um pacote (identificador, endereço de destino, peso, prioridade e status de recebimento).
- **`Models/Queue.cs`**: Implementação manual de uma Estrutura de Dados de Fila (*FIFO*) baseada em arrays.
- **`Models/Stack.cs`**: Implementação manual de uma Estrutura de Dados de Pilha (*LIFO*) baseada em arrays.
- **`Program.cs`**: Ponto de entrada da aplicação, instanciando os componentes, alimentando a lista de pacotes e disparando a simulação.

---

## 🚀 Como Executar o Projeto
1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/) instalado na sua máquina.
2. Clone este repositório ou abra a pasta raiz do projeto no seu terminal.
3. Navegue até o diretório do projeto e execute o comando:
   ```bash
   dotnet run
   ```