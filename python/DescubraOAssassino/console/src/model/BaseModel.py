# BaseModel.py

class BaseModel():
	
	def __init__(self, idItem, nome):
		self.__id = int(idItem)
		self.__nome = nome

	def SetId(self, idItem):
		self.__id = int(idItem)

	def SetNome(self, nome):
		self.__nome = nome

	def GetId(self):
		return self.__id

	def GetNome(self):
		return self.__nome

	def EhValido(self):
		if(self.__id > 0 and len(self.__nome) > 0):
			return True

		return False

