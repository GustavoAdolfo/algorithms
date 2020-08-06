#!/usr/bin/python3
'''
Created on 30 de dez de 2017

@author: gaas
'''
import xml.dom.minidom
import random 
from model.CriminosoModel import *
from model.ArmaModel import *
from model.LocalModel import *
from model.MisterioModel import *
from Crypto.Random.random import randint

listaCriminosos = []
listaArmas = []
listaLocais = []

def NovoMisterio():
    if(len(listaCriminosos) <= 0):
        ObterCriminosos()
        
    if(len(listaArmas) <= 0):
        ObterArmas()
        
    if(len(listaLocais) <= 0):
        ObterLocais()

    arma = randint(0,len(listaArmas) -1)
    local = randint(0, len(listaCriminosos) -1)
    criminoso = randint(0, len(listaLocais) -1)
        
    return MisterioModel(listaLocais[local], listaArmas[arma], listaCriminosos[criminoso])
    

def ObterCriminosos():
    dados = xml.dom.minidom.parse("data/criminosos.xml") #, parser, bufsize)
    nos = dados.documentElement
    #print("Root -> ", nos.nodeName)
    criminosos = [no for no in nos.childNodes if no.nodeType == dados.ELEMENT_NODE]
    for criminoso in criminosos:
        listaCriminosos.append(CriminosoModel(criminoso.getAttribute('id'), criminoso.getAttribute('nome')))

def ListarCriminosos():
    if(len(listaCriminosos) <= 0):
        ObterCriminosos()
                
    for item in listaCriminosos:
        print("Id: %d - Nome: %s" % (int(item.GetId()), item.GetNome()))

def ObterArmas():
    dados = xml.dom.minidom.parse("data/armas.xml") #, parser, bufsize)
    nos = dados.documentElement
    #print("Root -> ", nos.nodeName)
    armas = [no for no in nos.childNodes if no.nodeType == dados.ELEMENT_NODE]
    for arma in armas:
        listaArmas.append(ArmaModel(arma.getAttribute('id'), arma.getAttribute('nome')))
        
def ListarArmas():
    if(len(listaArmas) <= 0):
        ObterArmas()
                
    for item in listaArmas:
        print("Id: %d - Nome: %s" % (int(item.GetId()), item.GetNome()))
        
def ObterLocais():
    dados = xml.dom.minidom.parse("data/locais.xml") #, parser, bufsize)
    nos = dados.documentElement
    #print("Root -> ", nos.nodeName)
    locais = [no for no in nos.childNodes if no.nodeType == dados.ELEMENT_NODE]
    for local in locais:
        listaLocais.append(LocalModel(local.getAttribute('id'), local.getAttribute('nome')))
        
def ListarLocais():
    if(len(listaLocais) <= 0):
        ObterLocais()
                
    for item in listaLocais:
        print("Id: %d - Nome: %s" % (int(item.GetId()), item.GetNome()))        


if __name__ == '__main__':
    print("Você tem um novo caso")
    misterio = NovoMisterio()
    #print("Id = %s" % (misterio.GetId()))
    #print("Criminoso = (%d) %s" % (int(misterio.GetArma().GetId()), misterio.GetArma().GetNome()))
    #print("Local = (%d) %s" % (int(misterio.GetLocal().GetId()), misterio.GetLocal().GetNome()))
    #print("Arma = (%d) %s" % (int(misterio.GetCriminoso().GetId()), misterio.GetCriminoso().GetNome()))
    
    print("Você deve informar um suspeito, uma arma e um local para desvendar o mistério.")
    
    print("\nEstes são os suspeitos:")
    ListarCriminosos()
    
    
    print("\nEstes são os possíveis locais onde o crime ocorreu:")
    ListarLocais()
    
    print("\nEstas são armas que o criminoso pode ter utilizado:")
    ListarArmas()

    resultado = 3
    print("Informe o id de cada item ou -1 em todos para cancelar\n")
    
    while resultado > 0:
        suspeito = input("Informe o Id do seu suspeito: ")
        arma = input("Informe o Id da arma que você acredita ter sido usada no crime: ")
        local = input("Informe o local onde você acredita que o crime foi cometido: ")
        
        if int(suspeito) == -1 and int(arma) == -1 and int(local) == -1:
            break;
        
        if misterio.GetCriminoso().GetId() == int(suspeito):
            if misterio.GetArma().GetId() == int(arma): 
                if misterio.GetLocal().GetId() == int(local): 
                    print("Parabéns! Você desvendou o mistério.")
                    continuar = input("Se quiser desvendar ouro mistério, tecle S: ")
                    if continuar == 'S' or continuar == 's':                
                        resultado = 4
                        misterio = NovoMisterio()
                        print("\nVocê tem um novo caso.\n")
                    else:                
                        resultado = 0
                else:
                    resultado = 2 #Local incorreto
            elif misterio.GetLocal().GetId() == int(local):
                resultado = 3 #Arma incorreta
            else:
                resultado = random.randrange(2,3) #Arma e Local incorretos
        else:
            if misterio.GetArma().GetId() == int(arma): 
                if misterio.GetLocal().GetId() == int(local): 
                    retuldado = 1 #Suspeito incorreto
                else:
                    resultado = random.randrange(1,2) #Local e Suspeito incorretos
            elif misterio.GetLocal().GetId() == int(local):
                resultado = random.randrange(1,3) #Arma e Suspeito incorretos
            else:
                resultado = random.randrange(2,3) #Arma e Local incorretos
            
        if resultado == 1:
            print("Suas suspeitas sobre o criminoso estão equivocadas.")
            continue
        if resultado == 2:
            print("Investigue mais sobre o local do crime.")
            continue
        if resultado == 3:
            print("Verifique novamente os indícios sobre a arma.")
            continue

    print('\nInvestigações encerradas.')
    exit(0)
