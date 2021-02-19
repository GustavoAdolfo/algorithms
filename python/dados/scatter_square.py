import matplotlib.pyplot as plt


x_values = list(range(1, 50))
y_values = [x**2 for x in x_values]
plt.scatter(x_values, y_values, c=y_values, cmap=plt.cm.Greens, s=25, edgecolors='none')

# Define o título do gráfico e nomeia os eixos
plt.title('Square Numbers', fontsize=16)
plt.xlabel('Value', fontsize=10)
plt.ylabel('Square of Value', fontsize=10)

# Define o tamanho dos rótulos das marcações
plt.tick_params(axis='both', which='major', labelsize=10)

# Define o intervalo para cada eixo
plt.axis([0, 55, 0, 2700])

# plt.show()
plt.savefig('squares_plot.png', bbox_inches='tight')
