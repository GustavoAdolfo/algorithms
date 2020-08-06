'''
Created on 30 de dez de 2017

@author: gaas
'''

import uuid
from model.LocalModel import *
from model.ArmaModel import *
from model.CriminosoModel import *

class MisterioModel():
    

    def __init__(self, local, arma, criminoso):
        self.__criminoso = criminoso
        self.__arma = arma
        self.__local = local
        self.__idMisterio = uuid.uuid4() 
        
    def GetLocal(self):
        return self.__local
    
    def GetArma(self):
        return self.__arma
    
    def GetCriminoso(self):
        return self.__criminoso
    
    def GetId(self):
        return self.__idMisterio
