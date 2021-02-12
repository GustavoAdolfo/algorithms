#settings.py

class Settings():
    """ Uma classe para armazenar todas as configurações do Invasão Alienígena """

    def __init__(self):
        """ Inicializa as configurações do jogo """
        # Configurações de tela
        self.screen_width = 1200
        self.screen_height = 700
        self.bg_color = (20,20,60)

        # Configurações da espaçonave
        self.ship_limit = 3

        # Configurações dos projéteis
        self.bullet_height = 40
        self.bullet_color = 160, 140, 120
        self.bullets_allowed = 7

        # Configurações dos alienígenas
        self.fleet_drop_speed = 10 
        self.alien_spped_factor = 1.25

        # A taxa com que a velocidade do jogo aumenta
        self.speedup_scale = 1.1
        # A taxa com que os pontos para cada alienígena aumentam
        self.score_scale = 1.5

        self.initialize_dynamic_settings()

    def initialize_dynamic_settings( self):
        """ Inicializa as configurações que mudam no decorrer do jogo."""
        self.ship_speed_factor = 1.5
        self.bullet_speed_factor = 3
        self.alien_speed_factor = 1
        # fleet_direction igual a 1 representa a direta; -1 representa a esquerda
        self.fleet_direction = 1
        self.bullet_width = 3
        # Pontuação
        self.alien_points = 50

    def increase_speed( self):
        """ Aumenta as configurações de velocidade."""
        self.ship_speed_factor *= self.speedup_scale
        self.bullet_speed_factor *= self.speedup_scale
        self.alien_speed_factor *= self.speedup_scale
        self.alien_points = int(self.alien_points * self.score_scale)
