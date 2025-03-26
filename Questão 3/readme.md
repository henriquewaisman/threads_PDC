## Questão 03 
O cinema do Shopping ABC está contratando profissionais de TI para desenvolver uma “solução concorrente” 
no processo de pedidos de lanches no cinema. Basicamente o serviço oferece pipoca e refrigerante que 
funciona da seguinte forma: 
1. No balcão, você pede uma pipoca e um refrigerante; 
2. A atendente pega o pedido e solicita a execução para a sua equipe. Um 
membro da equipe prepara a pipoca e o outro membro prepara o 
refrigerante. Basicamente, ambas as tarefas acontecem simultaneamente. 
O seu pedido só é entregue, e naturalmente é considerado 
completamente realizado, somente quando ambas as tarefas são 
finalizadas; 
3. Ambos os membros da equipe entre os pedidos para o atendente; 
4. Agora você pode receber e se deliciar com o seu lanche. 

#### Dentro deste contexto pede-se: Elabore um código que permita atender a situação descrita anteriormente. 
- **Dica**: Por exemplo, utilizando a API “CompletableFuture” podemos implementar um método “getPipoca()” que 
retorna um “future” com a string “Pipoca Pronta”, um método semelhante, “getRefrigerante()”, que retorna um 
“future” com a string “Refrigerante Pronto” e um método simples “lanchePronto()” que retorna uma string 
informando que o lanche já está pronto e que só deve ser chamado depois que a pipoca e o refrigerante já 
estiverem disponíveis. 

- Importante reforçar: tanto “getPipoca()” quanto “getRefrigerante()”  são executados de forma concorrente. 
Uma vez que ambos tenham completado, as informações são retornadas o que permite a execução do 
“lanchePronto()”