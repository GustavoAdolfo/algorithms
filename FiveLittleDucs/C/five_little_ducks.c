#include <stdio.h>

const int FILHOTES = 5;

int main()
{
    int patinhos = FILHOTES;
    int indice;
    char nomoes[5][6] ={{"Five\0"}, {"Four\0"}, {"Three\0"}, {"Two\0"}, {"One\0"}};
    char patos[2][6] = {{"ducks\0"}, {"duck\0"}};
    char nominhos[5][6] ={{"five\0"}, {"four\0"}, {"three\0"}, {"two\0"}, {"one\0"}};
    while(patinhos > 0) {
        indice = FILHOTES - patinhos;
        printf("%s little %s went out one day,\n", nomoes[indice], patinhos > 1 ? patos[0] : patos[1]);
        printf("Over the hills and far away.\n");
        printf("Mother duck said \"quack, quack, quack, quack\",\n");
        printf("But only %s little %s came back.\n\n", nominhos[indice], patinhos > 1 ? patos[0] : patos[1]);
        patinhos--;
    }

    printf("Sad mother duck went out one day,\n");
    printf("Over the hills and far away.\n");
    printf("Mother duck said \"Quack, quack, quack, quack\",\n");
    printf("And all of the %s little ducks came back.\n\n", nominhos[FILHOTES -1]);

	printf("https://www.youtube.com/watch?v=tFoUuFq3vHw");
    return 0;
}