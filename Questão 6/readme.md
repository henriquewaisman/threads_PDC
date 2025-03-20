## Questão 06
Nos sistemas modernos, a programação concorrente é essencial para garantir desempenho e escalabilidade.
Muitas aplicações precisam integrar dados de diferentes fontes e processá-los em tempo real. Em serviços de previsão do tempo, por exemplo, as informações meteorológicas são obtidas de múltiplas bases de dados, como estações climáticas, sensores e serviços de terceiros. Para consolidar esses dados
rapidamente, utiliza-se, por exemplo API como “CompletableFuture”. Exemplos de potenciais aplicações que
usam recursos como estes podem ser:
- Serviços de previsão do tempo: Aplicações como o Weather.com ou o Climatempo agregam dados de
diversas fontes para fornecer previsões mais precisas.
- Integração de sensores em cidades inteligentes: Estações meteorológicas distribuem dados em tempo
real, permitindo monitoramento climático mais eficiente.
- Análises climáticas para agricultura: Fazendas utilizam múltiplas fontes de dados para prever secas e
planejar a irrigação.
Dentro deste contexto pede-se: Desenvolver uma aplicação que simule um agregador de informações
meteorológicas. A aplicação deverá coletar dados de diferentes bases de dados simuladas (utilizando
coleções de dados como banco de dados, por exemplo), processá-los concorrentemente e consolidá-los para
exibir um relatório final.
Requisitos
- Bases de dados simuladas: Os dados meteorológicos serão
armazenados em listas ou mapas, simulando bancos de dados
distintos.
- Coleta assíncrona: Buscar os dados das diferentes fontes
concorrentemente, por exemplo, utilizando “CompletableFuture”.
- Processamento de dados: Calcular a média da temperatura
coletada. Sugira outras informações, por exemplo, informações
sobre as localizações de cada base de dados, etc. 