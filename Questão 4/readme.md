## Questão 04
Existem várias situações em que o cálculo da soma de números inteiros armazenados em um grande vetor é
necessário. Algumas das aplicações práticas incluem:
- Análise de dados: Em análise de dados, a soma de valores é um cálculo muito comum e importante.
Por exemplo, podemos ter um grande vetor de vendas de uma empresa e precisamos calcular a soma
total de vendas em um determinado período.
- Processamento de imagens: Em processamento de imagens, o cálculo da soma de valores de pixels
em uma imagem pode ser útil para determinar a intensidade média ou total de luz na imagem.
- Simulação de Monte Carlo: A simulação de Monte Carlo é uma técnica estatística usada para avaliar a
incerteza em modelos matemáticos através da geração de muitas amostras aleatórias. Em algumas
aplicações, como finanças, a soma dos valores aleatórios é necessária para calcular uma média ou
desvio padrão.
- Aprendizado de Máquina: Em muitas aplicações de aprendizado de máquina, os dados são
armazenados em grandes vetores e o cálculo da soma de valores é necessário para treinar o modelo
ou fazer previsões.
- Criptografia: Alguns algoritmos criptográficos usam somas de valores como parte do processo de
criptografia ou descriptografia, especialmente em algoritmos baseados em criptografia de blocos.
Suponha que temos um vetor de 1 milhão de números inteiros e queremos
calcular a soma de todos eles:
- Podemos resolver esse problema de forma sequencial, percorrendo o
vetor e somando cada número, o que pode ser muito lento.
- Uma abordagem mais eficiente é dividir o vetor em várias partes, por
exemplo, em 10 partes, e calcular a soma de cada parte em uma
thread separada, para aproveitar o poder de processamento de vários
núcleos.
Dentro deste contexto pede-se: Elabore os códigos que permitam atender as duas abordagens propostas.
Dica: Para isso, por exemplo, podemos criar uma classe SomaThread que implementa a interface Runnable e
recebe como parâmetros o vetor de números inteiros, o índice do início e do fim da parte do vetor que será somada, e um objeto AtomicInteger para armazenar o resultado parcial da soma. Mais informações sobre
essa classe pode ser encontrada aqui. Dica → addAndGet(int delta): Adiciona atomicamente o valor fornecido ao valor atual.