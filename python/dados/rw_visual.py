import matplotlib.pyplot as plt
from random_walk import RandomWalk


# Cria um passeio aleatório e plota os pontos
rw = RandomWalk(50000)
# rw = RandomWalk()
rw.fill_walk()

# Define o tamanho da janela de plotagem
plt.figure(figsize=(12, 6))

point_numbers = list(range(rw.num_points))
plt.scatter(rw.x_values, rw.y_values, s=2, c=point_numbers, cmap=plt.cm.Reds, edgecolors='none')
# plt.plot(rw.x_values, rw.y_values, linewidth=2)

# Enfatiza o primeiro e o último pontos
plt.scatter(0, 0, c='green', edgecolors='none', s=30)
plt.scatter(rw.x_values[-1], rw.y_values[-1], c='blue', edgecolors='none', s=30)

# Remove os eixos
plt.axes().get_xaxis().set_visible(False)
plt.axes().get_yaxis().set_visible(False)
plt.axes()

plt.show()