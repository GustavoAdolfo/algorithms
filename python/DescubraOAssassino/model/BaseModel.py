# BaseModel.py

class BaseModel():
	
	def __init__(self, id, nome):
		self.__id = id
		self.__nome = nome

	def SetId(self, id):
		self.__id = id

	def SetNome(self, nome):
		self.__nome = nome

	def GetId(self):
		return self.__id

	def GetNome(self):
		return self.__nome

	def EhValido(self):
		if(self.__id > 0 and len(self.__nome) > 0):
			return true

		return false

