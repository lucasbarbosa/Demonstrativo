<b>Instruções:</b><br>
Por favor, leia atentamente as informações abaixo. Siga as instruções para
completar esta avaliação prática utilizando a linguagem de sua preferência. Ao
terminar, você deverá publicar seu código no GitHub, e enviar o link do repositório
para o recrutador.<br><br>
<b>O código-fonte será avaliado pelos seguintes critérios:</b>
 1. Object Oriented Design
 2. Readability
 3. Maintainability
 4. Testability<br><br>
<b>Requisitos técnicos:</b>
 1. Crie esta solução como uma aplicação console.
 2. A solução deve conter testes unitários.
 3. A solução deverá conter um script que permita compilar a aplicação e executar os
testes unitários a partir da linha de comando.
 4. Publique sua solução no GitHub e envie o link do repositório quando terminar.<br><br>
<b>Regras:</b>
 1. Você deverá informar o período do dia como “manhã” ou “noite”.
 2. Você deve informar uma lista de tipos de pratos delimitada por vírgula, com pelo
menos uma opção selecionada.
 3. O output deverá apresentar as opções selecionadas pelo usuário da seguinte
sequência: entrada, acompanhamento, bebida e sobremesa.
 4. Não há sobremesa para o período da manhã.
 5. A entrada de dados não é caso sensitivo.
 6. Caso o usuário informe uma seleção inválida, a solução deverá apresentar uma
lista de opções válidas, e apresentar a mensagem ‘erro’ na sequência.
 7. No período da manhã, o usuário pode selecionar múltiplos pedidos de café.
 8. No período noturno, o usuário poderá selecionar múltiplos pedidos de batata.
 9. Com exceção das regras anteriores, o usuário pode selecionar 1 pedido de cada
tipo de prato.
<br><br>
Tipos de Pratos para cada período
Tipo de Prato Manhã Noite
1 (entrada) ovos carne
2 (acompanhamento0 torrada batata
3 (bebida) café vinho
4 (sobremesa) Não se aplica bolo
Exemplos de entrada e saída:

- Entrada: manhã, 1, 2, 3
- Saída: ovos, torrada, café

- Entrada: manhã, 2, 1, 3
- Saída: ovos, torrada, café

- Entrada: manhã, 1, 2, 3, 4
- Saída: ovos, torrada, café, erro

- Entrada: manhã, 1, 2, 3, 3, 3
- Saída: ovos, torrada, café (x3)

- Entrada: noite, 1, 2, 3, 4
- Saída: carne, batata, vinho, bolo

- Entrada: noite, 1, 2, 2, 4
- Saída carne, batata (x2), bolo
