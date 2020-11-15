# Algorithm.Logic
 
PROBLEMA:

Implementar um algoritmo para o controle de posição de um drone emum plano cartesiano (X, Y).

O ponto inicial do drone é "(0, 0)" para cada execução do método Evaluate ao ser executado cada teste unitário.

A string de entrada pode conter os seguintes caracteres N, S, L, e O representando Norte, Sul, Leste e Oeste respectivamente.
Estes catacteres podem estar presentes aleatóriamente na string de entrada.
Uma string de entrada "NNNLLL" irá resultar em uma posição final "(3, 3)", assim como uma string "NLNLNL" irá resultar em "(3, 3)".

Caso o caracter X esteja presente, o mesmo irá cancelar a operação anterior. 
Caso houver mais de um caracter X consecutivo, o mesmo cancelará mais de uma ação na quantidade em que o X estiver presente.
Uma string de entrada "NNNXLLLXX" irá resultar em uma posição final "(1, 2)" pois a string poderia ser simplificada para "NNL".

Além disso, um número pode estar presente após o caracter da operação, representando o "passo" que a operação deve acumular.
Este número deve estar compreendido entre 1 e 2147483647.
Deve-se observar que a operação 'X' não suporta opção de "passo" e deve ser considerado inválido. Uma string de entrada "NNX2" deve ser considerada inválida.
Uma string de entrada "N123LSX" irá resultar em uma posição final "(1, 123)" pois a string pode ser simplificada para "N123L"
Uma string de entrada "NLS3X" irá resultar em uma posição final "(1, 1)" pois a string pode ser siplificada para "NL".

Caso a string de entrada seja inválida ou tenha algum outro problema, o resultado deve ser "(999, 999)".

OBSERVAÇÕES:
Realizar uma implementação com padrões de código para ambiente de "produção". 
Comentar o código explicando o que for relevânte para a solução do problema.
Adicionar testes unitários para alcançar uma cobertura de testes relevânte.


# Considerações

- Todas as considerações presentes deveriam ter sido discutidas responsável pela tarefa,seja gestor, líder ou cliente. 

LIMITE PLANO CARTESIANO:
Como não foi passada tal informação, foi trabalhado com os valores de limite Int32 [-2147483647 - +2147483647].
Levando em conta que o código faria a tragetória de um drone no plano cartesiano, foram criadas validações para este número sempre ser respeitado. 
Devido a isso, em qualquer operação do drone, mesmo antes do final do percurso, não ocerrerá situações de o drone estar temporariamente em uma zona inexistente no plano.

CARACTERES MINÚSCULOS:
Como não estava explícito na descrição e tendo em vista que era um desafio... 
Foram considerados aceitos apenas caracteres maiúsculos, o que gera mais regras de negócio e testes.

"PASSOS" COM ZERO À ESQUERDA:
Como não estava explícito na descrição e tendo em vista que era um desafio... 
Foram considerados aceitos, o que gera mais regras de negócio e testes.
Exemplo1: "N00000000001" [Válido]
Exemplo2: "N0" [Inválido]

TESTES UNITÁRIOS:
Como foi solicitado, resultados inválidos retornam "(999, 999)".
Em outra situação seria sugerido modificar isto, a posição do drone no intervalo (999, 999) é válida, porém, também é um retorno de falha.
Poderiam ser modificados todos os testes, deixando mais clara a situação da falha.
