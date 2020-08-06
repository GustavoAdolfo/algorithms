## Conceitos Básicos de "Descubra o Assassino"

Um crime foi cometido. Uma pessoa foi assassinada e o corpo dela foi deixado na frente da delegacia de polícia. Um detetive foi escolhido para investigar este caso. Após uma série de investigações, ele organizou uma lista com prováveis assassinos, os locais do crime e quais armas poderiam ter sido utilizadas.

#### Suspeitos:

1. Esqueleto                                                                                                                                                                                                                                                      
2. Khan                                                                                                                                                                                                                                                           
3. Darth vader                                                                                                                                                                                                                                                    
4. Sideshow Bob                                                                                                                                                                                                                                                   
5. Coringa                                                                                                                                                                                                                                                        
6. Duende Verde                                                                                                                                                                                                                                                   
7. Zé do Caixão
8. Muh-Ha
9. Vetor
10. Bizarro

#### Locais:

1. Etérnia                                                                                                                                                                                                                                                        
2. Vulcano                                                                                                                                                                                                                                                        
3. Tatooine                                                                                                                                                                                                                                                       
4. Springfield                                                                                                                                                                                                                                                    
5. Gotham                                                                                                                                                                                                                                                         
6. Nova York                                                                                                                                                                                                                                                      
7. Sibéria                                                                                                                                                                                                                                                        
8. Machu Picchu                                                                                                                                                                                                                                                   
9. Acre
10. São Paulo                                                                                                                                                                                                                                                      

#### Armas:

1. Cajado Devastador                                                                                                                                                                                                                                              
2. Phaser                                                                                                                                                                                                                                                         
3. Peixeira                                                                                                                                                                                                                                                       
4. Trezoitão                                                                                                                                                                                                                                                      
5. Sabre de Luz                                                                                                                                                                                                                                                   
6. Bomba
7. Pistola de Peixe-Piranha
8. Marreta
9. Visão de Calor
10. Anel do Poder

Uma testemunha foi encontrada, mas ela só consegue responder se o detetive fornecer uma teoria. Para cada teoria ele "chuta" um assassino, um local e uma arma. A testemunha então responde com um número. 

Para preservar sua segurança a testemunha responde à hipótese apenas com números que vão de 0 a 3. Se a hipótese do detetive estiver correta (assassino, local e arma corretos), a testemunha responde apenas 0. Se está errada, um valor 1,2 ou 3 é retornado, sendo que:

1. indica que o assassino está incorreto; 
2. indica que o local está incorreto; 
3. indica que a arma está incorreta. 

Se mais de uma suposição está incorreta, ela retorna um valor arbitrário entre 1 e 3.

Por exemplo, se o assassino for Khan em Springfield usando uma Peixeira:

- Hipótese: 1, 1, 1 (Esqueleto, Etérnia, Cajado Devastador) => Retorno: 1, ou 2, ou 3 (todos estão incorretos) 
- Hipótese: 6, 4, 5 (Duende Verde, Springfield, Sabre de Luz) => Retorno: 1, ou 3 (somente o local está correto)
- Hipótese: 5, 4, 3 (Coringa, Springfield, Peixeira) => Retorno: 1 (somente o assassino está incorreto)
- Hipótese: 2, 4, 3 => Retorno: 0 (todos corretos, você solucionou o caso)

