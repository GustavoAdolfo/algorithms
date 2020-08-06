#!/usr/bin/python3
# coding: utf8
# program name FiveLittleDucs.py

print('\n**Five Little Ducs**\n\n')

def getFilhotes():
    return 5;


#patinhos = getFilhotes()
indice = 0
#print("patinhos = %d e indice = %d" % (patinhos, indice))

nomoes = ["Five", "Four", "Three", "Two", "One"];
patos = ["ducks", "duck"];
nominhos = ["five", "four", "three", "two", "one"];

patinhos = len(nominhos)
#print(patinhos)

while(patinhos > 0):
    indice = getFilhotes() - patinhos;
    pato = patos[0]

    if (patinhos > 1):
        pato = patos[0]
    else:
        pato = patos[1]

    nomao = nomoes[indice]
    #print(indice)
    if(indice == len(nominhos) or (indice+1) == len(nominhos)):
        print("(None appears duck times.)\n")
    else:
        nominho = nominhos[indice+1]
        print("(%s appears %s times.)\n" % (nomao, pato))

    print("%s little %s went out one day," % (nomao, pato));
    print("Over the hills and far away.");
    print("Mother duck said \"quack, quack, quack, quack\",");
    if(indice == len(nominhos) or (indice+1) == len(nominhos)):
        print("But none little duck came back from there.\n")
    else:
        print("But only %s little %s came back.\n" % (nominho, pato));
    patinhos = patinhos-1;

nominho = nominhos[getFilhotes() -1]
print("Sad mother duck went out one day,");
print("Over the hills and far away.");
print("Mother duck said \"Quack, quack, quack, quack\",");
print("And all of the %s little ducks came back.\n\n" % (nominho));

print("Ouca a cancao em: https://www.youtube.com/watch?v=tFoUuFq3vHw");

