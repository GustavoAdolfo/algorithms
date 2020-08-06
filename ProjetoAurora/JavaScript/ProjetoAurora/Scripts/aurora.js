// core do projeto aurora

var Aurora = Aurora || {};

Aurora.MaxDados = 5;
Aurora.DadosEmJogo = [];
Aurora.Regras = [];

Aurora.Inicializar = function() {
    for (var i = 0; i < Aurora.MaxDados; i++) {
        Aurora.DadosEmJogo[i] = new Aurora.Dado('Dado' + i);
    }
    Aurora.Regras[0] = Aurora.RegraUm;
    Aurora.Regras[1] = Aurora.RegraDois;
    Aurora.Regras[2] = Aurora.RegraTres;
    Aurora.Regras[3] = Aurora.RegraQuatro;
    Aurora.Regras[4] = Aurora.RegraCinco;
    Aurora.Regras[5] = Aurora.RegraSeis;
    Aurora.Regras[6] = Aurora.RegraPar;
    Aurora.Regras[7] = Aurora.RegraDoisPares;
    Aurora.Regras[8] = Aurora.RegraTrio;
    Aurora.Regras[9] = Aurora.RegraSequenciaMenor;
    Aurora.Regras[10] = Aurora.RegraSequenciaMaior;
    Aurora.Regras[11] = Aurora.RegraFullHouse;
    Aurora.Regras[12] = Aurora.RegraAurora;
};

Aurora.Dado = function(n) {
    var valor = 1;
    var nome = '';

    this.setNome = function(nm) {
        nome = nm;
    }

    this.getValor = function() {
        return valor;
    }

    this.jogar = function() {
        valor = Math.floor(Math.random() * (7 - 1)) + 1;
        //return valor;
    }

    if (n != null && n !== "undefined") {
        this.setNome(n);
    }
};

Aurora.faces = {
    um: 0,
    dois: 0,
    tres: 0,
    quatro: 0,
    cinco: 0,
    seis: 0
};

Aurora.contabilizarFaces = function() {
    var totalDados = Aurora.DadosEmJogo.length;
    Aurora.faces.um = 0;
    Aurora.faces.dois = 0;
    Aurora.faces.tres = 0;
    Aurora.faces.quatro = 0;
    Aurora.faces.cinco = 0;
    Aurora.faces.seis = 0;

    for (var i = 0; i < totalDados; i++) {
        //debugger;
        if (Aurora.DadosEmJogo[i].getValor() === 1) {
            Aurora.faces.um += 1;
            continue;
        }
        if (Aurora.DadosEmJogo[i].getValor() === 2) {
            Aurora.faces.dois += 1;
            continue;
        }
        if (Aurora.DadosEmJogo[i].getValor() === 3) {
            Aurora.faces.tres += 1;
            continue;
        }
        if (Aurora.DadosEmJogo[i].getValor() === 4) {
            Aurora.faces.quatro += 1;
            continue;
        }
        if (Aurora.DadosEmJogo[i].getValor() === 5) {
            Aurora.faces.cinco += 1;
            continue;
        }
        if (Aurora.DadosEmJogo[i].getValor() === 6) {
            Aurora.faces.seis += 1;
            continue;
        }
    }
}

Aurora.lancarDados = function() {
    if (Aurora.DadosEmJogo == null || Aurora.DadosEmJogo === "undefined") {
        //debugger;
        return;
    }
    var total = Aurora.DadosEmJogo.length;

    for (var i = 0; i < total; i++) {
        Aurora.DadosEmJogo[i].jogar();
    }

    Aurora.contabilizarFaces();
}

Aurora.obterResultadoDoLance = function() {
    return parseJSON(Aurora.DadosEmJogo);
}

Aurora.CategoriaDePontuacao = function() {
    var nomeRegra = "";
    var regra;
    var pontos = 0;

    this.definirRegra = function(metodo) {
        if ($.isFunction(metodo)) {
            regra = metodo;
        } else {
            regra = null;
            throw new Error("A definição da regra precisa ser uma função.");
        }
    }
    this.setNomeRegra = function(nome) {
        nomeRegra = nome;
    }
    this.getNome = function() {
        return nomeRegra;
    }

    this.getSomatorioPontos = function() {
        return pontos;
    }

    //this.setPontos = function (p) {
    //    pontos = p;
    //}

    this.aplicarRegra = function() {
        regra();
    }
};

Aurora.CategoriaDePontuacao.prototype.setPontos = function(p) {
    alert(p);
    this.pontos = p;
}

Aurora.CategoriaDePontuacao.prototype.getPontos = function() {
    return this.pontos;
}

Aurora.CategoriaDePontuacao.prototype.atendeRegra = function() {
    return this.getPontos() > 0;
}

Aurora.RegraUm = new Aurora.CategoriaDePontuacao();
Aurora.RegraUm.setNomeRegra("Um");
Aurora.RegraUm.definirRegra(function() {
    var totalDados = Aurora.DadosEmJogo.length;
    var pontos = 0;
    for (var i = 0; i < totalDados; i++) {
        if (Aurora.DadosEmJogo[i].getValor() === 1) {
            pontos++;
        }
    }
    Aurora.RegraUm.setPontos(pontos);
});

Aurora.RegraDois = new Aurora.CategoriaDePontuacao();
Aurora.RegraDois.setNomeRegra("Dois");
Aurora.RegraDois.definirRegra(function() {
    var totalDados = Aurora.DadosEmJogo.length;
    var pontos = 0;
    for (var i = 0; i < totalDados; i++) {
        if (Aurora.DadosEmJogo[i].getValor() === 2) {
            pontos += 2;
        }
    }
    Aurora.RegraDois.setPontos(pontos);
});

Aurora.RegraTres = new Aurora.CategoriaDePontuacao();
Aurora.RegraTres.setNomeRegra("Tres");
Aurora.RegraTres.definirRegra(function() {
    var totalDados = Aurora.DadosEmJogo.length;
    var pontos = 0;
    for (var i = 0; i < totalDados; i++) {
        if (Aurora.DadosEmJogo[i].getValor() === 3) {
            pontos += 3;
        }
    }
    Aurora.RegraTres.setPontos(pontos);
});

Aurora.RegraQuatro = new Aurora.CategoriaDePontuacao();
Aurora.RegraQuatro.setNomeRegra("Quatro");
Aurora.RegraQuatro.definirRegra(function() {
    var totalDados = Aurora.DadosEmJogo.length;
    var pontos = 0;
    for (var i = 0; i < totalDados; i++) {
        if (Aurora.DadosEmJogo[i].getValor() === 4) {
            pontos += 4;
        }
    }
    Aurora.RegraQuatro.setPontos(pontos);
});

Aurora.RegraCinco = new Aurora.CategoriaDePontuacao();
Aurora.RegraCinco.setNomeRegra("Cinco");
Aurora.RegraCinco.definirRegra(function() {
    var totalDados = Aurora.DadosEmJogo.length;
    var pontos = 0;
    for (var i = 0; i < totalDados; i++) {
        if (Aurora.DadosEmJogo[i].getValor() === 5) {
            pontos += 5;
        }
    }
    Aurora.RegraCinco.setPontos(pontos);
});

Aurora.RegraSeis = new Aurora.CategoriaDePontuacao();
Aurora.RegraSeis.setNomeRegra("Seis");
Aurora.RegraSeis.definirRegra(function() {
    var totalDados = Aurora.DadosEmJogo.length;
    var pontos = 0;
    for (var i = 0; i < totalDados; i++) {
        if (Aurora.DadosEmJogo[i].getValor() === 6) {
            pontos += 6;
        }
    }
    Aurora.RegraSeis.setPontos(pontos);
});

//Par[Haver pelo menos 2 dados de mesmo valor no rolamento]: Pontue a soma dos dois dados de mesmo valor 
Aurora.RegraPar = new Aurora.CategoriaDePontuacao();
Aurora.RegraPar.setNomeRegra("Par");
Aurora.RegraPar.definirRegra(function() {
    var pontos = 0;
    // Considerando o maior valor de pares
    if (Aurora.faces.seis >= 2) {
        pontos = 12;
    } else if (Aurora.faces.cinco >= 2) {
        pontos = 10;
    } else if (Aurora.faces.quatro >= 2) {
        pontos = 8;
    } else if (Aurora.faces.tres >= 2) {
        pontos = 6;
    } else if (Aurora.faces.dois >= 2) {
        pontos = 4;
    } else if (Aurora.faces.um >= 2) {
        pontos = 2;
    } else {
        pontos = 0;
    }
    Aurora.RegraPar.setPontos(pontos);
});

//Haver pelo menos 2 pares de dados distintos no rolamento]: Pontue a soma dos quatro dados que integram os pares 
Aurora.RegraDoisPares = new Aurora.CategoriaDePontuacao();
Aurora.RegraDoisPares.setNomeRegra("DoisPares");
Aurora.RegraDoisPares.definirRegra(function() {
    //debugger;
    // Considerando o maior valor de pares
    if (Aurora.faces.seis >= 2) {
        if (Aurora.faces.cinco >= 2) {
            Aurora.RegraDoisPares.setPontos(12 + 10);
        }
        if (Aurora.faces.quatro >= 2) {
            Aurora.RegraDoisPares.setPontos(12 + 8);
        }
        if (Aurora.faces.tres >= 2) {
            Aurora.RegraDoisPares.setPontos(12 + 6);
        }
        if (Aurora.faces.dois >= 2) {
            Aurora.RegraDoisPares.setPontos(12 + 4);
        }
        if (Aurora.faces.um >= 2) {
            Aurora.RegraDoisPares.setPontos(12 + 2);
        }
    } else if (Aurora.faces.cinco >= 2) {
        if (Aurora.faces.quatro >= 2) {
            Aurora.RegraDoisPares.setPontos(10 + 8);
        }
        if (Aurora.faces.tres >= 2) {
            Aurora.RegraDoisPares.setPontos(10 + 6);
        }
        if (Aurora.faces.dois >= 2) {
            Aurora.RegraDoisPares.setPontos(10 + 4);
        }
        if (Aurora.faces.um >= 2) {
            Aurora.RegraDoisPares.setPontos(10 + 2);
        }
    } else if (Aurora.faces.quatro >= 2) {
        if (Aurora.faces.tres >= 2) {
            Aurora.RegraDoisPares.setPontos(10 + 6);
        }
        if (Aurora.faces.dois >= 2) {
            Aurora.RegraDoisPares.setPontos(10 + 4);
        }
        if (Aurora.faces.um >= 2) {
            Aurora.RegraDoisPares.setPontos(10 + 2);
        }
    } else if (Aurora.faces.tres >= 2) {
        if (Aurora.faces.dois >= 2) {
            Aurora.RegraDoisPares.setPontos(10 + 4);
        }
        if (Aurora.faces.um >= 2) {
            Aurora.RegraDoisPares.setPontos(10 + 2);
        }
    } else if (Aurora.faces.dois >= 2) {
        if (Aurora.faces.um >= 2) {
            Aurora.RegraDoisPares.setPontos(10 + 2);
        }
    } else {
        Aurora.RegraDoisPares.setPontos(0);
    }
});

//Haver pelo menos 3 dados de mesmo valor no rolamento]: Pontue a soma dos três dados de mesmo valor 
Aurora.RegraTrio = new Aurora.CategoriaDePontuacao();
Aurora.RegraTrio.setNomeRegra("Trio");
Aurora.RegraTrio.definirRegra(function() {

    // Considerando o maior valor de pares
    if (Aurora.faces.seis >= 3) {
        Aurora.RegraTrio.setPontos(18);
    } else if (Aurora.faces.cinco >= 3) {
        Aurora.RegraTrio.setPontos(15);
    } else if (Aurora.faces.quatro >= 3) {
        Aurora.RegraTrio.setPontos(12);
    } else if (Aurora.faces.tres >= 3) {
        Aurora.RegraTrio.setPontos(9);
    } else if (Aurora.faces.dois >= 3) {
        Aurora.RegraTrio.setPontos(6);
    } else if (Aurora.faces.um >= 3) {
        Aurora.RegraTrio.setPontos(3);
    } else {
        Aurora.RegraTrio.setPontos(0);
    }
});

//Haver pelo menos 4 dados de mesmo valor no rolamento]: Pontue a soma dos quatro dados de mesmo valor 
Aurora.RegraQuadra = new Aurora.CategoriaDePontuacao();
Aurora.RegraQuadra.setNomeRegra("Quadra");
Aurora.RegraQuadra.definirRegra(function() {

    // Considerando o maior valor de pares
    if (Aurora.faces.seis >= 3) {
        if (Aurora.faces.cinco >= 3) {
            Aurora.RegraQuadra.setPontos(18 + 15);
        }
        if (Aurora.faces.quatro >= 3) {
            Aurora.RegraQuadra.setPontos(18 + 12);
        }
        if (Aurora.faces.tres >= 3) {
            Aurora.RegraQuadra.setPontos(18 + 9);
        }
        if (Aurora.faces.dois >= 3) {
            Aurora.RegraQuadra.setPontos(18 + 6);
        }
        if (Aurora.faces.um >= 3) {
            Aurora.RegraQuadra.setPontos(18 + 3);
        }
    } else if (Aurora.faces.cinco >= 3) {
        if (Aurora.faces.quatro >= 3) {
            Aurora.RegraQuadra.setPontos(15 + 12);
        }
        if (Aurora.faces.tres >= 3) {
            Aurora.RegraQuadra.setPontos(15 + 9);
        }
        if (Aurora.faces.dois >= 3) {
            Aurora.RegraQuadra.setPontos(15 + 6);
        }
        if (Aurora.faces.um >= 3) {
            Aurora.RegraQuadra.setPontos(15 + 3);
        }
    } else if (Aurora.faces.quatro >= 3) {
        if (Aurora.faces.tres >= 3) {
            Aurora.RegraQuadra.setPontos(12 + 9);
        }
        if (Aurora.faces.dois >= 3) {
            Aurora.RegraQuadra.setPontos(12 + 6);
        }
        if (Aurora.faces.um >= 3) {
            Aurora.RegraQuadra.setPontos(12 + 3);
        }
    } else if (Aurora.faces.tres >= 3) {
        if (Aurora.faces.dois >= 3) {
            Aurora.RegraQuadra.setPontos(9 + 6);
        }
        if (Aurora.faces.um >= 3) {
            Aurora.RegraQuadra.setPontos(9 + 3);
        }
    } else if (Aurora.faces.dois >= 3) {
        if (Aurora.faces.um >= 3) {
            Aurora.RegraQuadra.setPontos(6 + 3);
        }
    } else {
        Aurora.RegraQuadra.setPontos(0);
    }
});

//Haver pelo menos 4 dados em ordem numérica no rolamento]: Pontue 15 pontos 
Aurora.RegraSequenciaMenor = new Aurora.CategoriaDePontuacao();
Aurora.RegraSequenciaMenor.setNomeRegra("Sequência Menor");
Aurora.RegraSequenciaMenor.definirRegra(function() {

    var sequenciado = (Aurora.faces.um > 0 && Aurora.faces.dois > 0 && Aurora.faces.tres > 0 && Aurora.faces.quatro > 0);
    sequenciado = sequenciado || (Aurora.faces.dois > 0 && Aurora.faces.tres > 0 && Aurora.faces.quatro > 0 && Aurora.faces.cinco > 0);
    sequenciado = sequenciado || (Aurora.faces.tres > 0 && Aurora.faces.quatro > 0 && Aurora.faces.cinco && Aurora.faces.seis > 0);
    if (sequenciado === true) {
        Aurora.RegraSequenciaMenor.setPontos(15);
    } else {
        Aurora.RegraSequenciaMenor.setPontos(0);
    }
});

//[Haver os 5 dados em ordem numérica no rolamento]: Pontue 20 pontos
Aurora.RegraSequenciaMaior = new Aurora.CategoriaDePontuacao();
Aurora.RegraSequenciaMaior.setNomeRegra("Sequência Maior");
Aurora.RegraSequenciaMaior.definirRegra(function() {

    var sequenciado = (Aurora.faces.um > 0 && Aurora.faces.dois > 0 && Aurora.faces.tres > 0 && Aurora.faces.quatro > 0 && Aurora.faces.cinco > 0);
    sequenciado = sequenciado || (Aurora.faces.dois > 0 && Aurora.faces.tres > 0 && Aurora.faces.quatro > 0 && Aurora.faces.cinco && Aurora.faces.seis > 0);
    if (sequenciado === true) {
        Aurora.RegraSequenciaMaior.setPontos(20);
    } else {
        Aurora.RegraSequenciaMaior.setPontos(0);
    }
});

//Full House[Haver 1 par e 1 trio no rolamento]: Pontue a soma de todos os 5 dados 
Aurora.RegraFullHouse = new Aurora.CategoriaDePontuacao();
Aurora.RegraFullHouse.setNomeRegra("Full House");
Aurora.RegraFullHouse.definirRegra(function() {

    // Considerando o maior valor de pares
    if (Aurora.faces.seis === 2) {
        if (Aurora.faces.cinco >= 3) {
            Aurora.RegraFullHouse.setPontos(12 + 15);
            return;
        }
        if (Aurora.faces.quatro >= 3) {
            Aurora.RegraFullHouse.setPontos(12 + 12);
            return;
        }
        if (Aurora.faces.tres >= 3) {
            Aurora.RegraFullHouse.setPontos(12 + 9);
            return;
        }
        if (Aurora.faces.dois >= 3) {
            Aurora.RegraFullHouse.setPontos(12 + 6);
            return;
        }
        if (Aurora.faces.um >= 3) {
            Aurora.RegraFullHouse.setPontos(12 + 3);
            return;
        }
    } else if (Aurora.faces.cinco === 2) {
        if (Aurora.faces.seies >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 18);
            return;
        }
        if (Aurora.faces.quatro >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 12);
            return;
        }
        if (Aurora.faces.tres >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 9);
            return;
        }
        if (Aurora.faces.dois >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 6);
            return;
        }
        if (Aurora.faces.um >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 3);
            return;
        }
    } else if (Aurora.faces.quatro === 2) {
        if (Aurora.faces.seis >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 18);
            return;
        }
        if (Aurora.faces.cinco >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 15);
            return;
        }
        if (Aurora.faces.tres >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 9);
            return;
        }
        if (Aurora.faces.dois >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 6);
            return;
        }
        if (Aurora.faces.um >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 3);
            return;
        }
    } else if (Aurora.faces.tres === 2) {
        if (Aurora.faces.seis >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 18);
            return;
        }
        if (Aurora.faces.cinco >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 15);
            return;
        }
        if (Aurora.faces.quatro >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 12);
            return;
        }
        if (Aurora.faces.dois >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 6);
            return;
        }
        if (Aurora.faces.um >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 3);
            return;
        }
    } else if (Aurora.faces.dois === 2) {
        if (Aurora.faces.seis >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 18);
            return;
        }
        if (Aurora.faces.cinco >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 15);
            return;
        }
        if (Aurora.faces.quatro >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 12);
            return;
        }
        if (Aurora.faces.tres >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 9);
            return;
        }
        if (Aurora.faces.um >= 3) {
            Aurora.RegraFullHouse.setPontos(10 + 3);
            return;
        }
    } else if (Aurora.faces.um === 2) {
        if (Aurora.faces.seis >= 3) {
            Aurora.RegraFullHouse.setPontos(2 + 18);
            return;
        }
        if (Aurora.faces.cinco >= 3) {
            Aurora.RegraFullHouse.setPontos(2 + 15);
            return;
        }
        if (Aurora.faces.quatro >= 3) {
            Aurora.RegraFullHouse.setPontos(2 + 12);
            return;
        }
        if (Aurora.faces.tres >= 3) {
            Aurora.RegraFullHouse.setPontos(2 + 9);
            return;
        }
        if (Aurora.faces.dois >= 3) {
            Aurora.RegraFullHouse.setPontos(2 + 6);
            return;
        }
    } else {
        Aurora.RegraFullHouse.setPontos(0);
    }
});

//Aurora[Haver 5 dados de mesmo valor no rolamento]: Pontue 50 pontos
Aurora.RegraAurora = new Aurora.CategoriaDePontuacao();
Aurora.RegraAurora.setNomeRegra("Aurora");
Aurora.RegraAurora.definirRegra(function() {

    var aurora = (Aurora.faces.um === 5 || Aurora.faces.dois === 5 || Aurora.faces.tres === 5 || Aurora.faces.quatro === 5 || Aurora.faces.cinco === 5 || Aurora.faces.seis === 5);
    if (aurora === true) {
        Aurora.RegraAurora.setPontos(50);
    } else {
        Aurora.RegraAurora.setPontos(0);
    }
});