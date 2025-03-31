import os
import sqlite3
import concurrent.futures  # Biblioteca usada para computação concorrente

# Função para processar um arquivo individual
def processar_arquivo(arquivo):
    alunos = []  # Lista para armazenar os dados extraídos dos alunos
    with open(arquivo, 'r', encoding='utf-8') as f:
        # Para cada linha do arquivo, os dados são extraídos e processados
        for linha in f:
            partes = linha.strip().split()  # Divide a linha em partes
            matricula = partes[0]  # O primeiro item é a matrícula
            nome = ' '.join(partes[1:-2])  # O nome é tudo entre a matrícula e o curso
            curso = partes[-2]  # O penúltimo item é o curso
            flag = partes[-1]  # O último item é o status (CONCLUÍDO ou outro)
            # Se o aluno está "CONCLUÍDO", adiciona os dados à lista
            if flag == 'CONCLUÍDO':
                aluno = (matricula, nome, curso)
                alunos.append(aluno)
                print(f"Aluno encontrado: {aluno[1]} - {aluno[2]} ({aluno[0]}) \n")
    return alunos  # Retorna a lista de alunos processados

# Função para salvar os dados no banco de dados SQLite
def salvar_no_banco(alunos):
    # Conecta ao banco de dados (ou cria, se não existir)
    conexao = sqlite3.connect('formandos.db')
    cursor = conexao.cursor()

    # Deleta todas as linhas da tabela 'formandos' antes de começar o processo
    cursor.execute("DELETE FROM formandos")

    # Cria a tabela 'formandos' caso ainda não exista
    cursor.execute("CREATE TABLE IF NOT EXISTS formandos (matricula TEXT, nome TEXT, curso TEXT)")

    # Insere os dados dos alunos no banco de dados
    cursor.executemany("INSERT INTO formandos (matricula, nome, curso) VALUES (?, ?, ?)", alunos)

    # Salva as mudanças e fecha a conexão com o banco de dados
    conexao.commit()
    conexao.close()

if __name__ == '__main__':
    # Define a pasta onde os arquivos de texto estão localizados
    pasta = 'arquivos_faculdade'
    # Cria uma lista com todos os arquivos .txt na pasta especificada
    arquivos = [os.path.join(pasta, f) for f in os.listdir(pasta) if f.endswith('.txt')]

    # Lista para armazenar os dados de todos os alunos
    todos_alunos = []

    # Usa a computação concorrente com ThreadPoolExecutor
    with concurrent.futures.ThreadPoolExecutor() as executor:
        # Executa a função 'processar_arquivo' para cada arquivo em paralelo
        resultados = executor.map(processar_arquivo, arquivos)
        # Para cada resultado, adiciona os alunos encontrados à lista 'todos_alunos'
        for resultado in resultados:
            todos_alunos.extend(resultado)

    # Salva os dados de todos os alunos no banco de dados
    salvar_no_banco(todos_alunos)
    print(f"Processamento concluído. {len(todos_alunos)} alunos formandos armazenados.")
