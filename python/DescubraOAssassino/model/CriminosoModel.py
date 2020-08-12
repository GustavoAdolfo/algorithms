# Criminoso.py

import BaseModel

class CriminosoModel(BaseModel):

	def Descrever(self):
		print('{"IdCriminoso": %d, "Nome": %s}' % (self.__id, self.__nome))

