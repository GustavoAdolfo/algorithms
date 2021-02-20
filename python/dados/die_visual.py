from die import Die
import pygal

# Cria um D6
die = Die()
# Faz alguns lançamentos e armazena os resultados numa lista
results = []
for roll_num in range(1000):
    results.append(die.roll())

# Analisa os resultados
frequencias = []
for value in range(1, die.num_sides + 1):
    frequencia = results.count(value)
    frequencias.append(frequencia)

# print(frequencias)

# Visualiza os resultados
hist = pygal.Bar()
hist.title = 'Results of rolling one D6 1000 times'
hist.x_labels = ['1', '2', '3', '4', '5', '6']
hist.x_title = 'Result'
hist.y_title = 'Frequency of Result'
hist.add('D6', frequencias)
hist.render_to_file('die_visual.svg')
