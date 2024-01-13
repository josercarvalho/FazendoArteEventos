﻿
$(function () {
    $("#loaderbody").addClass('hide');


    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

//Listamos todos os dados Existentes
//Listar();

//FUNCOES

var clienteID;
/*    Funções do Cliente    */

/* Mascara dos campos específicos */
$('#CPF').mask('000.000.000-00');
$("#CEP").mask("00.000-000");
//$("#DataNascimento").mask("00/00/0000");

var masks = ['(00) 00000-0000', '(00) 0000-00009'];
$("#Telefone").mask(masks[1], {
    onKeyPress: function (val, e, field, options) {
        field.mask(val.length > 14 ? masks[0] : masks[1], options);
    }
});

$("#Celular").mask(masks[1], {
    onKeyPress: function (val, e, field, options) {
        field.mask(val.length > 14 ? masks[0] : masks[1], options);
    }
});

$("#btn-submit-cliente").click(function (e) {
    e.preventDefault();
    SubmitCliente();
});

function SubmitCliente() {

    //com a função serialize(), pegamos todo o objeto do formulario e transformamos em uma string em serie
    var dadosSerializados = $('#frmCliente').serialize();

    //debugger

    var form = $('#frmCliente');

    //Desabilitando a validação de compos desabilitados ou escondidos
    form.validate().settings.ignore = ":disabled,:hidden";

    //Verifica campos obrigatõrios
    $.validator.unobtrusive.parse(form);

    if (form.valid()) {
        //inicializamos o AJAX
        //por padrao ele recebe JSON portanto nao é preciso informar
        $.ajax({
            //informamos o tipo de solicitacao (GET, POST, PUT, DELETE)
            type: "POST",
            //url para onde enviaremos os dados
            url: "/Clientes/Create",
            //os parametros que serao enviados por parametro, no nosso caso é o objeto PessoaModel que temos no formulario
            //a partir dos names, ele reconhece que é daquele objeto.
            data: dadosSerializados,
            contentType: "appication/json: charset-utf-8",
            dataType: "json",
            success: function (json) {
                //caso tudo de certo, exibe a mensagem
                //bootbox.alert("Dados salvos com Sucesso!");                
                var clienteID = json;
                bootbox.alert(clienteID + " Dados salvos com Sucesso!");
                //chamamos o metodo de listagem dos objetos
                //Listar();
            },
            error: function () {
                bootbox.alert("Erro ao tentar salvar do dados!");
            }
        });
    }
}

function ValidaCliente() {
    $("#frmCliente")
}

/*  Funções do Dependente */

function CadastrarDependente() {

    //com a função serialize(), pegamos todo o objeto do formulario e transformamos em uma string em serie
    var dadosSerializados = $('#formDados').serialize();

    //inicializamos o AJAX
    //por padrao ele recebe JSON portanto nao é preciso informar
    $.ajax({
        //informamos o tipo de solicitacao (GET, POST, PUT, DELETE)
        type: "POST",
        //url para onde enviaremos os dados
        url: "/App/Cadastrar",
        //os parametros que serao enviados por parametro, no nosso caso é o objeto PessoaModel que temos no formulario
        //a partir dos names, ele reconhece que é daquele objeto.
        data: dadosSerializados,
        success: function () {
            //caso tudo de certo, exibe a mensagem
            bootbox("Cadastrado com Sucesso!");
            //chamamos o metodo de listagem dos objetos
            Listar();
        },
        error: function () {
            bootbox("Erro ao tentar salvar do dados!");
        }

    });
}

function Listar() {
    //Limpa todos os inputs
    LimparFormulario();

    //criamos a funcao ajax
    $.ajax({
        //informamos que a requisição será do tipo GET
        //ou seja, estamos pedindo dados ao servidor, para nosso html
        type: "GET",
        //informamos a CONTROLLER e ACTION para onde queremos os dados
        url: "/App/Listar",
        //repare que nao precisamos passar o atributo DATA quando nossa action nao possui parâmetros
        //feita a requisição, recebemos os dados em JSON
        success: function (dadosPessoa) {

            if (dadosPessoa != null) {

                //para fins de estudo, removeremos todo conteudo da tr, a cada chamada na listagem
                //caso nao existir as 'tr' ele ignora este metodo
                $('#tbody').children().remove();

                //utilizamos a funcao EACH do JQUERY, funciona como o FOREACH do C# mas parece como o FOR pois trabalha com index
                //pois pegamos a lista vinda por parametro, a função servirá como um index, ou seja, a cada objeto,
                //esse 'i' receberá +1
                $(dadosPessoa).each(function (i) {

                    //nosso objeto do c# vem em JSON como /Date(1424220388445)/, removemos as strings e chars, deixamos somente numero
                    //neste caso aparenta ser um pouco complexo, existem diversas maneiras de fazer o parse, esta é somente
                    //para fins de estudo
                    //pega a data de nascimento, troca os '/Date(' por vazio feito isso troca os '')/' por vazio, para manter somente os inteiros
                    var dataMiliSegundos = dadosPessoa[i].DataNascimento.replace('/Date(', '').replace(')/', '');

                    //pegamos os milisegundos, transformamos em inteiro, feito isso formatamos para o formato dia/mes/ano - dd/mm/yyyy
                    //com o metodo do hs toLocaleDateString
                    var dataNascimento = new Date(parseInt(dataMiliSegundos)).toLocaleDateString();

                    //criação dos dados em html
                    //pegamos todo nosso tbody da tabela
                    var tbody = $('#tbody');
                    //inicializamos a variavel
                    var tr = "<tr>";
                    //adicionando os registros manualmente, cada td com o item daquela posicao
                    tr += "<td>" + dadosPessoa[i].Id + "</td>";
                    tr += "<td>" + dadosPessoa[i].Nome + "</td>";
                    tr += "<td>" + dataNascimento + "</td>";
                    tr += "<td>" + dadosPessoa[i].Email + "</td>";

                    //usado para criar os botoes, como o intuito é trabalhar com jquery, faremos na mão.
                    //cria os botoes com as classes do BOOTSTRAP, no atributo ONCLICK do HTML, passamos o ID daquele item
                    //para ser usado nos outros métodos
                    tr += "<td>" + "<button class='btn btn-info fa fa-edit' onclick=Editar(" + dadosPessoa[i].Id + ")>" + "</td>";
                    tr += "<td>" + "<button class='btn btn-danger fa fa-trash' onclick=Deletar(" + dadosPessoa[i].Id + ")>" + "</td></tr>";

                    //a cada posicao, criamos a linha do TBODY com os dados
                    tbody.append(tr);

                });
            }
        }
    });
}

function Editar(idPessoa) {

    if (idPessoa != null && idPessoa > 0) {

        $.ajax({
            type: 'GET',
            url: '/App/Editar',
            data: { id: idPessoa },
            success: function (dados) {
                // faz a formatacao novamente da data que vem do C# em formado JSON
                var dataMiliSegundos = dados.DataNascimento.replace('/Date(', '').replace(')/', '');
                var dataFormatoLocal = new Date(parseInt(dataMiliSegundos)).toLocaleDateString();

                //como nosso atributo TYPE=DATE suporta o somente o formato yyyy-mm-dd (ano-mes-dia)
                //faremos a formatacao do mesmo.
                var dataFormatada = "";
                //com o metodo SUBSTRING do JAVASCRIPT, pegamos os Indexes da string. no exemplo
                //10-01-12 - a substring inicia-se em 0 entao, se queremos pegar o valor apenas do dia, será de
                //0 a 2 pois no primeiro parametro informamos o indice e no segundo a posicao do valor
                dataFormatada += dataFormatoLocal.substring(6, 10) + '-';
                dataFormatada += dataFormatoLocal.substring(3, 5) + '-';
                dataFormatada += dataFormatoLocal.substring(0, 2);

                //feito isso, pega os valores e manda para os inputs com os determinados dados
                $('#idPessoa').val(dados.Id);
                $('#nome').val(dados.Nome);
                $('#DataNascimento').val(dataFormatada);
                $('#Email').val(dados.Email);

                //como queremos EDITAR um determinado contato, ocultaremos o botao SALVAR
                //e mostraremos o botao ATUALIZAR usando a funcao do JQUERY
                $("#salvar").addClass("hidden");
                $("#atualizar").removeClass("hidden");
                $("#limpar").removeClass("hidden");
            }
        });
    }
}

function Atualizar() {

    var dadosSerializados = $('#formDados').serialize();
    $.ajax({
        type: "POST",
        url: "/App/Atualizar",
        data: dadosSerializados,
        success: function () {

            $("#salvar").removeClass("hidden");
            $("#atualizar").addClass("hidden");

            Listar();
        },
        error: function myfunction() {
            alert("Erro!");
        }
    });
}

function Deletar(idPessoa) {
    //Usando o CONFIRM do js, temos uma resposta booleana, caso true(clicar em OK), ele executa nossa funcao
    bootbox.confirm("Deseja Realmente Apagar ?", function (confirmar) {
        if (confirmar) {

            if (idPessoa != null || idPessoa > 0) {
                $.ajax({
                    type: 'POST',
                    url: "/App/Deletar",
                    //envia por parametro o id da Pessoa, no caso entre chaves { } o primeiro ítem é o mesmo
                    //item definido em nossa controller (nome do parametro a ser recebido)
                    data: { id: idPessoa },
                    success: function () {
                        //após tudo ocorrer bem, ele lista novamente os resultados
                        Listar();
                        bootbox.alert("Deletado com Sucesso !");
                    },
                    error: function () {
                        bootbox.alert("Erro ao deletar registro !");
                    }
                });
            }
        }
    })
}

function LimparFormulario() {
    //Limpar formulario
    //pega todos os ítens do form e limpa
    $('#formDados').each(function () {
        this.reset();
    });
    $("#salvar").removeClass("hidden");
    $("#atualizar").addClass("hidden");
    $('#limpar').addClass('hidden');

}

$(function () {

    $("#submit-cliente").on("click", function (e) {
        e.preventDefault();
        CadastraCliente();
    });

    $("#submit-dependente").on("click", function (e) {
        e.preventDefault();
        CadastrarDependente();
    });

    $(".btn-dependente").on("click", function (e) {
        e.preventDefault();
        adicionaDependente();
    });

    $(".btn-dependente-voltar").on("click", function (e) {
        e.preventDefault();
        adicionaDependente();
    });

    function adicionaDependente() {
        $("#divDependente").slideToggle("slow");
    };
});