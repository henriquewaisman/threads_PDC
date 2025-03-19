## Questão 01
A) Deve-se criar uma aplicação que modele o funcionamento de sua conta bancária. Esta conta será o recurso compartilhado e deverá ser acessada/modificada por três threads: a thread AEsperta, a thread AEconomica e a thread AGastadora, concorrentemente.
  - AGastadora: esta thread (de atitude voraz) deverá, a cada 3000 milesegundos verificar se há saldo suficiente, e retirar 10 reais da sua conta. Esta thread deve disputar por dinheiro, com
as demais threads, concorrentemente.
  - AEsperta: esta thread será mais comedido que a anterior: somente a cada 6000 milesegundos, irá verificar o seu saldo. Mas não se engane: se houver saldo suficiente, esta thread irá retirar 50 reais da sua conta. Esta thread deve disputar com outras threads, concorrentemente.
  - AEconomica: de todas as threads, esta será a que mais prezará por você e suas finanças. Ela irá verificar o saldo de sua conta apenas a cada 12000 milesegundos. Se houver fundos, a thread econômica irá tentar retirar apenas 5 reais da sua conta. Esta thread deve disputar com outras threads, concorrentemente.

B) A classe Conta (recurso compartilhado) deverá ter pelo menos:
  - Os seguintes atributos: número da conta, titular da conta e saldo.
  - Quando necessário, implemente também algumas regras básicas de integridade (número de conta negativos, etc.).
  - Finalmente, implemente os principais métodos que vão manipular o saldo da conta: deposito e saque. Inicie o saldo (recurso compartilhado) da conta depositando uma quantia de R$ 1.000,00.

- DICA: Faça um esboço de um diagrama inicial de classes para lhe ajudar a pensar melhor antes de ir diretamente para o código. O diagrama ajuda você a visualizar quantas classes precisará e como elas se relacionam.

- IMPORTANTE: Sempre que uma thread movimentar fundos da sua conta, o sistema deve informar não apenas qual thread efetuou a operação (saque ou depósito), mas, principalmente, qual é o seu saldo atual final (após o saque). Isso permitirá que você acompanhe a situação financeira em tempo real.

- LEMBRE-SE: Nesta aplicação, não defina prioridades (todos devem ter as mesmas chances). Além disso, não permita que haja corrupção de dados (ou seja, cada thread deve conseguir retirar sua quantia sem ser interrompido por outro thread materialista). Use synchronized ou outro modelo, por exemplo.

C) Quando a conta estiver com saldo zero, todas as threads deverão ser colocados em estado de espera. Ao ser colocado em espera, cada thread deverá imprimir a quantidade de saques efetuados e o valor total retirado da conta. Execute e veja o resultado

D) Acrescente agora mais uma thread de nome APatrocinadora. Esta thread deverá depositar 100 reais sempre que a conta estiver zerada. Veja que este thread será “produtora”. E as demais serão “consumidoras”. (verifique a possibilidade de usar wait e notifyAll ou outro modelo, por exemplo)

E) Fica a critério do grupo se irá ou não usar GUI.
