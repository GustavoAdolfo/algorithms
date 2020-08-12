class GameStats():
    """ Armazena dados estatísticos da Invasão Alienígena """

    def __init__(self, ai_settings):
        """ Inicializa os dados estatísticos """
        self.game_active = True
        self.ai_settings = ai_settings
        self.reset_stats()

        # Inicia o jogo em um estado inativo
        self.game_active = False


    def reset_stats(self):
        """ Inicializa os dados estatíticos que podem mudar durante o jogo """
        self.ships_left = self.ai_settings.ship_limit
