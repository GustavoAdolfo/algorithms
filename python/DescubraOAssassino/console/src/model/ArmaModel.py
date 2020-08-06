# ArmaModel.py

from model.BaseModel import *

class ArmaModel(BaseModel):

	def Descrever(self):
		print('{"IdArma": %d, "Nome": %s}' % (self.__id, self.__nome))

