# Importando as bibliotecas necessárias
import threading
from random import randint
import time
from concurrent.futures import ThreadPoolExecutor

# Função para calcular a soma sequencial de todos os elementos do vetor
# Esta função percorre cada elemento do vetor e acumula a soma total

def soma_sequencial(vetor):
    soma = 0
    for numero in vetor:
        soma += numero
    return soma

# Classe que representa uma thread para realizar a soma de uma parte do vetor
class SomaThread(threading.Thread):
    def __init__(self, vetor, inicio, fim, resultado):
        # Inicializa a classe base threading.Thread
        super().__init__()
        self.vetor = vetor  # Vetor de números inteiros
        self.inicio = inicio  # Índice de início do bloco a ser somado
        self.fim = fim  # Índice de fim do bloco a ser somado
        self.resultado = resultado  # Objeto Resultado para armazenar a soma parcial

    def run(self):
        # Realiza a soma dos elementos do bloco definido
        soma = sum(self.vetor[self.inicio:self.fim])
        # Armazena o resultado parcial de forma thread-safe
        self.resultado.add(soma)

# Classe para armazenar o resultado da soma de forma segura entre as threads
# Utiliza um bloqueio (Lock) para garantir que apenas uma thread atualize o valor por vez
class Resultado:
    def __init__(self):
        self.valor = 0  # Inicializa o valor da soma
        self.lock = threading.Lock()  # Cria um bloqueio para controle de acesso

    def add(self, valor):
        # Garante acesso exclusivo para atualização da soma
        with self.lock:
            self.valor += valor

# Função para calcular a soma utilizando múltiplas threads
# Divide o vetor em blocos, cria threads para cada bloco e acumula os resultados

def soma_com_threads(vetor, num_threads=10):
    tamanho = len(vetor)  # Tamanho do vetor
    bloco = tamanho // num_threads  # Tamanho de cada bloco a ser processado por thread
    resultado = Resultado()  # Objeto para armazenar o resultado final
    threads = []  # Lista para armazenar as threads criadas

    # Criação das threads para realizar a soma em paralelo
    for i in range(num_threads):
        inicio = i * bloco  # Índice de início do bloco
        # Última thread pega o restante dos elementos
        fim = tamanho if i == num_threads - 1 else (i + 1) * bloco
        thread = SomaThread(vetor, inicio, fim, resultado)  # Cria a thread
        threads.append(thread)  # Adiciona a thread na lista
        thread.start()  # Inicia a execução da thread

    # Espera todas as threads terminarem
    for thread in threads:
        thread.join()

    return resultado.valor  # Retorna o valor da soma acumulada


# Função para computação paralela usando ThreadPoolExecutor
def soma_com_threadpool(vetor, num_threads=10):
    tamanho = len(vetor)  # Obtém o tamanho total do vetor
    bloco = tamanho // num_threads  # Define o tamanho de cada bloco para cada thread
    
    def soma_bloco(inicio, fim):
        #Realiza a soma dos elementos de um bloco específico do vetor
        return sum(vetor[inicio:fim])
    
    # Cria um ThreadPoolExecutor para gerenciar a execução das threads
    with ThreadPoolExecutor(max_workers=num_threads) as executor:
        # Cria uma lista de tarefas para somar os blocos do vetor
        futuros = [
            executor.submit(soma_bloco, i * bloco, tamanho if i == num_threads - 1 else (i + 1) * bloco)
            for i in range(num_threads)
        ]
    # Aguarda a finalização de todas as threads e soma os resultados parciais
    return sum(f.result() for f in futuros)

# Geração de um vetor com 1 milhão de números inteiros aleatórios no intervalo de 1 a 100
vetor = [randint(1, 1000) for _ in range(9000000)]

# Soma sequencial
inicio = time.time()
soma_seq = soma_sequencial(vetor)
tempo_seq = time.time() - inicio
print(f"Soma Sequencial: {soma_seq} em {tempo_seq:.4f} segundos")

# Soma com threads
inicio = time.time()
soma_thr = soma_com_threads(vetor)
tempo_thr = time.time() - inicio
print(f"Soma com Threads: {soma_thr} em {tempo_thr:.4f} segundos")

# Soma com threadpool
inicio = time.time()
soma_thr = soma_com_threadpool(vetor)
tempo_thr = time.time() - inicio
print(f"Soma com Threadpool: {soma_thr} em {tempo_thr:.4f} segundos")