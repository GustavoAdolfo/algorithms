# LocalModel.py

import BaseModel

class LocalModel(BaseModel):
	
	def Descrever(self):
		print('{"IdLocal": %d, "Nome": %s}' % (self.__id, self.__nome))



