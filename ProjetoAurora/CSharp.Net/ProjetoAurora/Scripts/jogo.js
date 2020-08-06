
$(document).ready(function montarDados() {
    //Aurora.Inicializar();
    disporDados();
    listarRegras();
    $('#btnLancamento').click(jogar);
});

function listarRegras() {
    var totalRegras = Aurora.Regras.length;
    for (var i = 0; i < totalRegras; i++) {
        var $radio = $('<input>').attr({
            type: "radio",
            value: i,
            name: 'regra'
        });
        var $li = $('<li>').addClass("list-group-item radio");
        $li.append('<label class="radio-inline"><input type="radio" value="0" name="radio" id="regra_' + i + '" />' + Aurora.Regras[i].getNome() + '</label> <span class="badge" title="Total de pontos">' + Aurora.Regras[i].getSomatorioPontos() +'</span>');
        $('#listaRegras').append($li);
    }
}

function disporDados() {
    var cont = 0;
    while (cont < Aurora.MaxDados) {
        Aurora.DadosEmJogo[cont].jogar();
        var $dado = $('<img>').attr({
            src: "/Content/Images/dado0" + Aurora.DadosEmJogo[cont].getValor() + ".png",
            alt: "Dado",
            title: "Dado do jogo",
            id: 'dado' + cont
        }).addClass('dado');
        var $li = $('<li>').addClass('list-group-item').append($dado);
        $('#listaDados').append($li);
        cont++;
    }
}

function jogar() {
    Aurora.lancarDados();
    $('#listaDados').empty();
    disporDados();

    var totalRegras = Aurora.Regras.length;
    for (var i = 0; i < totalRegras; i++) {
        Aurora.Regras[i].aplicarRegra();
        if (!Aurora.Regras[i].atendeRegra()) {
            $('#regra_' + i).prop('disabled', true);
            $('#regra_' + i).parents('li').removeClass('list-group-item-success');
            $('#regra_' + i).parents('li').toggleClass('text-muted');
        } else {
            $('#regra_' + i).prop('disabled', false);
            $('#regra_' + i).parents('li').addClass('list-group-item-success');
            $('#regra_' + i).parents('li').toggleClass('text-muted');
        }
        $('#regra_' + i).val(Aurora.Regras[i].getPontos());
        
        $('#regra_' + i).parents('li').find('.badge').text(Aurora.Regras[i].getPontos());
    }
}

