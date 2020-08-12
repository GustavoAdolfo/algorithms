#settings.py

class Settings():
    """ Uma classe para armazenar todas as configurações do Invasão Alienígena """

    def __init__(self):
        """ Inicializa as configurações do jogo """
        # Configurações de tela
        self.screen_width = 1300
        self.screen_height = 700
        self.bg_color = (20,20,60)

        # Configurações da espaçonave
        self.ship_speed_factor = 1.5
        self.ship_limit = 3

        # Configurações dos projéteis
        self.bullet_speed_factor = 3
        self.bullet_width = 5
        self.bullet_height = 15
        self.bullet_color = 160, 140, 120
        self.bullets_allowed = 5

        # Configurações dos alienígenas
        self.alien_spped_factor = 1.5
        self.fleet_drop_speed = 10
        # fleet_direction igual a 1 representa a direta; -1 representa a esquerda
        self.fleet_direction = 1

