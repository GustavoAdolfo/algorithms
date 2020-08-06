//var urlBaseApi = 'http://handson.eniwine.com.br/api/descubraoassassino/';
var urlBaseApi = 'http://localhost:8035/api/descubraoassassino/';

$(document).ready(function() {

    //alert('Consumindo dados de: ' + urlBaseApi);

    obterNovoCaso();
    $('#btnSuspeita').click(enviarSuspeita);
});

function obterNovoCaso() {

    exibirPreloaders();

    //Obtendo ID do novo caso a se desvendar
    $.getJSON(urlBaseApi, function(data) {
        var misterio = $.parseJSON(data);
        sessionStorage.setItem("misterio", misterio.misterioId);
    });

    listarCriminosos();
    listarArmas();
    listarLocais();
}

function listarCriminosos() {
    $.getJSON(urlBaseApi + 'criminosos/', function(data) {
        var criminosos = $.parseJSON(data);
        $('#listaSuspeitos').empty();
        $(criminosos).each(function(index) {
            var id = criminosos[index].Id;
            var nome = criminosos[index].Nome;
            var $li = $("<li>").addClass('list-group-item text-primary');
            var $radio = $("<input>").attr({ type: 'radio', id: 'rdSuspeito_' + id, name: 'rdSuspeito', value: id });
            var $label = $("<label>").attr({ for: 'rdSuspeito_' + id }).text(nome);
            $li.append($radio);
            $li.append($label);
            $('#listaSuspeitos').append($li);
        });
    }).fail(function() {
        $('#listaSuspeitos').empty();
        var $li = $("<li>").addClass('list-group-item text-warning');
        $li.text('Houve um erro de comunicação');
        $('#listaSuspeitos').append($li);
    });
}

function listarLocais() {
    $.getJSON(urlBaseApi + 'locais/', function(data) {
        var criminosos = $.parseJSON(data);
        $('#listaLocais').empty();
        $(criminosos).each(function(index) {
            var id = criminosos[index].Id;
            var nome = criminosos[index].Nome;
            var $li = $("<li>").addClass('list-group-item text-primary');
            var $radio = $("<input>").attr({ type: 'radio', id: 'rdLocal_' + id, name: 'rdLocal', value: id });
            var $label = $("<label>").attr({ for: 'rdLocal_' + id }).text(nome);
            $li.append($radio);
            $li.append($label);
            $('#listaLocais').append($li);
        });
    }).fail(function() {
        $('#listaLocais').empty();
        var $li = $("<li>").addClass('list-group-item text-warning');
        $li.text('Houve um erro de comunicação');
        $('#listaLocais').append($li);
    });
}

function listarArmas() {
    $.getJSON(urlBaseApi + 'armas/', function(data) {
        var criminosos = $.parseJSON(data);
        $('#listaArmas').empty();
        $(criminosos).each(function(index) {
            var id = criminosos[index].Id;
            var nome = criminosos[index].Nome;
            var $li = $("<li>").addClass('list-group-item text-primary');
            var $radio = $("<input>").attr({ type: 'radio', id: 'rdArma_' + id, name: 'rdArma', value: id });
            var $label = $("<label>").attr({ for: 'rdArma_' + id }).text(nome);
            $li.append($radio);
            $li.append($label);
            $('#listaArmas').append($li);
        });
    }).fail(function() {
        $('#listaArmas').empty();
        var $li = $("<li>").addClass('list-group-item text-warning');
        $li.text('Houve um erro de comunicação');
        $('#listaArmas').append($li);
    });
}

function exibirPreloaders() {
    var $preloader1 = $("<img>").attr({
        src: 'imgs/Infinity.gif',
        title: 'Buscando informações',
        alt: 'Aguarde...'
    }).addClass('img-thumbnail img-fluid');
    var $preloader2 = $("<img>").attr({
        src: 'imgs/Infinity.gif',
        title: 'Buscando informações',
        alt: 'Aguarde...'
    }).addClass('img-thumbnail img-fluid');
    var $preloader3 = $("<img>").attr({
        src: 'imgs/Infinity.gif',
        title: 'Buscando informações',
        alt: 'Aguarde...'
    }).addClass('img-thumbnail img-fluid');

    var $li1 = $("<li>").addClass('list-group-item text-center');
    var $li2 = $("<li>").addClass('list-group-item text-center');
    var $li3 = $("<li>").addClass('list-group-item text-center');
    $li1.append($preloader1);
    $li2.append($preloader2);
    $li3.append($preloader3);

    $('#listaSuspeitos').append($li1);
    $('#listaArmas').append($li2);
    $('#listaLocais').append($li3);
}

function enviarSuspeita() {
    var suspeito = $("input[name='rdSuspeito']:checked").val();
    var arma = $("input[name=rdArma]:checked").val();
    var local = $("input[name=rdLocal]:checked").val();
    var idMisterio = sessionStorage.getItem("misterio");

    var obj = '{"IdSuspeito": ' + suspeito + ', "IdArma": ' + arma + ', "IdLocal": ' + local + ', "IdMisterio": "' + idMisterio + '" }';
    jQuery.support.cors = true;
    $.ajax({
        type: "POST",
        url: urlBaseApi,
        data: obj,
        //crossDomain: true,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function(response) {
            var retorno = parseInt(response);
            var resposta = "";
            switch (retorno) {
                case 1:
                    resposta = "Sua suposição está incorreta. Investigue mais sobre o suspeito.";
                    break;
                case 2:
                    resposta = "Sua suposição está incorreta. Talvez você deva investigar mais sobre o local do crime.";
                    break;
                case 3:
                    resposta = "Sua suposição está incorreta. Reexamine a arma do crime.";
                    break;
                default:
                    resposta = "Parabéns! Você é um ótimo detetive.";
                    break;
            }

            $('#modalResultado').on('shown.bs.modal',
                function() {
                    $('#modalResultado .modal-body').empty();
                    var $p = $('<p>').text(resposta);
                    $('#modalResultado .modal-body').append($p);
                    $('#modalResultado .modal-footer button').removeClass('btn-success btn-danger')
                    switch (retorno) {
                        case 1:
                        case 2:
                        case 3:
                            $('#modalResultado .modal-header h1').text("Quase... Não deixe o suspeito escapar!");
                            $('#modalResultado .modal-footer button').toggleClass('btn-danger');
                            $('#modalResultado').off('hidden.bs.modal');
                            break;
                        default:
                            $('#modalResultado .modal-header h1').text("Bom trabalho!");
                            $('#modalResultado .modal-footer button').toggleClass('btn-success');

                            $('#modalResultado').on('hidden.bs.modal', function() {
                                obterNovoCaso();
                                alert('Você tem um novo caso.');
                            });

                            break;
                    }
                });

            $('#modalResultado').modal();


        },
        failure: function(response) {
            alert(response.responseText);
        },
        error: function(response) {
            alert(response.responseText);
        }
    });
}