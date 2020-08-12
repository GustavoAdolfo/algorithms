# Criminoso.py

from model.BaseModel import *

class CriminosoModel(BaseModel):

	def Descrever(self):
		print('{"IdCriminoso": %d, "Nome": %s}' % (self.__id, self.__nome))

