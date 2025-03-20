## Questão 02
Uma Universidade precisa saber quais são os alunos que estão se formando no semestre para enviar estas
informações para a empresa de eventos e poder organizar a festa de formatura e a impressão dos diplomas.
Para isso o setor de Tecnologia da Informação da Universidade preparou um arquivo (no formato “.txt”) para cada curso de graduação contendo os dados de todos os alunos do curso. A Universidade tem 15 cursos de graduação. No arquivo existe uma flag indicando a conclusão de curso com o valor "CONCLUIDO".
Cada arquivo base para processamento possui as informações: {matrícula, nome do aluno, curso, flag}. A flag pode ser definida como CURSANDO ou CONCLUÍDO.

Dentro deste contexto pede-se: Elabore um código, com o uso de programação concorrente, para listar todos
os alunos formandos (status da flag como CONCLUÍDO) a partir de uma busca em todos os arquivos dos
cursos de graduação. A base de dados deve ser gerada pelo grupo, de acordo com o modelo apresentado na
questão.