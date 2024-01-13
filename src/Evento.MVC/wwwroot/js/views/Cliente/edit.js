
//$(function () {
//    $("#loaderbody").addClass('hide');

//    $(document).bind('ajaxStart', function () {
//        $("#loaderbody").removeClass('hide');
//    }).bind('ajaxStop', function () {
//        $("#loaderbody").addClass('hide');
//    });
//});

var clienteID = $('#frmCliente .card-body input[type=hidden]').val();

//Listamos todos os dados Existentes
//Listar();

//FUNCOES 
/*    Funções do Cliente e máscaras   */

/* Mascara dos campos específicos */
$('.CPF').mask('000.000.000-00');
$(".CEP").mask("00.000-000");
$(".nascimento").mask("00/00/0000");

var masks = ['(00) 00000-0000', '(00) 0000-00009'];
$(".telefone").mask(masks[1], {
    onKeyPress: function (val, e, field, options) {
        field.mask(val.length > 14 ? masks[0] : masks[1], options);
    }
});

//Bind City dropdownlist
$("#EstadoId").change(function () {
    var estadoId = $("#EstadoId").val();

    $.ajax({
        type: "GET",
        url: "/Clientes/GetCityList",
        data: { id: estadoId },
        success: function (result) {
            var item = "";
            $("#CidadeId").empty();
            item = "<option value='0'>Selecione a Cidade ...</option>";
            $(result).each(function () {
                //bootbox.alert(this.value + " - " + this.text);
                item += '<option value="' + this.value + '">' + this.text + '</option>'
            });
            $("#CidadeId").html(item);
        },
        error: function () {
            bootbox.alert("Erro ao tentar carregar cidades!");
        }
    });
});

//$(".nascimento").change(function () {
//    var data = new Date($(this).val()); //cria um objeto de data com o valor inserido no input
//    data = data.toLocaleDateString('pt-BR'); // converte em uma string de data no formato pt-BR
//    $(this).val(data); // insere o novo valor no input
//});

/*  Funções do Dependente */

function Cadastrar() {
    //com a função serialize(), pegamos todo o objeto do formulario e transformamos em uma string em serie
    var dadosSerializados = $('#formDados').serialize();
    
    var form = $('#formDados');

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
            url: "/Clientes/Cadastrar",
            //os parametros que serao enviados por parametro, no nosso caso é o objeto PessoaModel que temos no formulario
            //a partir dos names, ele reconhece que é daquele objeto.
            data: dadosSerializados,
            success: function () {
                //caso tudo de certo, exibe a mensagem       
                bootbox.alert(" Dados salvos com Sucesso!");
                //chamamos o metodo de listagem dos objetos
                Listar();
            },
            error: function () {
                bootbox.alert("Erro ao tentar salvar do dados!");
            }
        });
    }
}


function Listar() {
    //Limpa todos os inputs
    LimparFormulario();

    debugger

    clienteId = $('#frmCliente .card-body input[type=hidden]').val();

    //criamos a funcao ajax
    $.ajax({
        type: "GET",
        url: "/Clientes/Listar",
        data: { id: clienteId },
        success: function (dadosPessoa) {
            if (dadosPessoa != null) {
                $('#tabelaDados').children().remove();
                $(dadosPessoa).each(function (i) {
                    //nosso objeto do c# vem em JSON como /Date(1424220388445)/, removemos as strings e chars, deixamos somente numero
                    //neste caso aparenta ser um pouco complexo, existem diversas maneiras de fazer o parse, esta é somente
                    //para fins de estudo
                    //pega a data de nascimento, troca os '/Date(' por vazio feito isso troca os '')/' por vazio, para manter somente os inteiros
                    //var dataMiliSegundos = dadosPessoa[i].DataNascimento.replace('/Date(', '').replace(')/', '');
                    var dataFormatoLocal = dadosPessoa[i].dataNascimento.replace(/(\d*)-(\d*)-(\d*).*/, '$3-$2-$1');

                    //pegamos os milisegundos, transformamos em inteiro, feito isso formatamos para o formato dia/mes/ano - dd/mm/yyyy
                    //com o metodo do hs toLocaleDateString
                    //var dataNascimento = new Date(parseInt(dataMiliSegundos)).toLocaleDateString('pt-BR');
                    var dataNascimento = "";
                    dataNascimento += dataFormatoLocal.substring(0, 2) + '/';
                    dataNascimento += dataFormatoLocal.substring(3, 5) + '/';
                    dataNascimento += dataFormatoLocal.substring(6, 10);

                    var parente = "";
                    if (dadosPessoa[i].parente == 0) {
                        parente = "Filho"
                    } else if (dadosPessoa[i].parente == 1) {
                        parente = "Conjuge"
                    } else if (dadosPessoa[i].parente == 2) {
                        parente = "Primo"
                    } else if (dadosPessoa[i].parente == 3) {
                        parente = "Sobrinho"
                    } else if (dadosPessoa[i].parente == 4) {
                        parente = "Neto"
                    } else if (dadosPessoa[i].parente == 5) {
                        parente = "Outros"
                    }

                    //criação dos dados em html
                    //pegamos todo nosso tbody da tabela
                    var tbody = $('#tabelaDados');
                    //inicializamos a variavel
                    var tr = "<tr>";
                    //adicionando os registros manualmente, cada td com o item daquela posicao
                    tr += "<td>" + dadosPessoa[i].dependenteId + "</td>";
                    tr += "<td>" + dadosPessoa[i].nome + "</td>";
                    tr += "<td>" + dataNascimento + "</td>";
                    tr += "<td>" + parente + "</td>";

                    //usado para criar os botoes, como o intuito é trabalhar com jquery, faremos na mão.
                    //cria os botoes com as classes do BOOTSTRAP, no atributo ONCLICK do HTML, passamos o ID daquele item
                    //para ser usado nos outros métodos
                    tr += "<td class='mnuTable'><div class='btn-group btn-group-table'>"
                    tr += " " + "<a class='btn btn-default fa fa-folder-open'";
                    tr += " " + "data-ajax='true' data-ajax-method='GET' data-ajax-mode='replace' data-ajax-update='#divDependente'";
                    tr += " " + "data-ajax-update='#divDependente' data-ajax-success='adicionaDependente' data-ajax-failure='Failure'";
                    tr += " " + "href='/Clientes/Editar/" + dadosPessoa[i].dependenteId + "') > " + " </a > ";
                    tr += " " + "<button class='btn btn-default fa fa-trash' onclick=Deletar(" + dadosPessoa[i].dependenteId + ")>" + " ";
                    tr += "</div></td></tr > ";

                    //a cada posicao, criamos a linha do TBODY com os dados
                    tbody.append(tr);

                });
            }
        }
    });
}

function Editar(DependenteId) {

    if (DependenteId != null && DependenteId > 0) {
        adicionaDependente();
        $.ajax({
            type: 'GET',
            url: '/Clientes/Editar',
            data: { id: DependenteId },
            success: function (dados) {
                // faz a formatacao novamente da data que vem do C# em formado JSON
                //var dataMiliSegundos = dados.dataNascimento.replace('/Date(', '').replace(')/', '');
                var data = dados.dataNascimento;
                //var dataMiliSegundos = data.replace(/(\d*)-(\d*)-(\d*).*/, '$3-$2-$1');
                //var dataFormatoLocal = new Date(parseInt(dataMiliSegundos)).toLocaleDateString('pt-BR');
                var dataFormatoLocal = data.replace(/(\d*)-(\d*)-(\d*).*/, '$3-$2-$1');

                //como nosso atributo TYPE=DATE suporta o somente o formato yyyy-mm-dd (ano-mes-dia)
                //faremos a formatacao do mesmo.
                var dataFormatada = "";
                //com o metodo SUBSTRING do JAVASCRIPT, pegamos os Indexes da string. no exemplo
                //10-01-12 - a substring inicia-se em 0 entao, se queremos pegar o valor apenas do dia, será de
                //0 a 2 pois no primeiro parametro informamos o indice e no segundo a posicao do valor
                dataFormatada += dataFormatoLocal.substring(0, 2) + '/';
                dataFormatada += dataFormatoLocal.substring(3, 5) + '/';
                dataFormatada += dataFormatoLocal.substring(6, 10);

                //feito isso, pega os valores e manda para os inputs com os determinados dados
                $('#DependenteId').val(dados.dependenteId);
                $('#ClienteId').val(dados.clienteId);
                $('#formDados .card-body #Nome').val(dados.nome);
                $('#formDados .card-body #DataNascimento').val(dataFormatada);
                //$('#formDados .card-body #DataNascimento').val(dados.dataNascimento);
                $('#Idade').val(dados.idade);
                $('#Parente').val(dados.parente);
                $('#Escola').val(dados.escola);
                $('#PlanoSaude').val(dados.planoSaude);
                $('#GrupoSanguineo').val(dados.grupoSanguineo);
                $('#EmergenciaHospital').val(dados.emergenciaHospital);
                $('#Medico').val(dados.medico);
                $('#FoneMedico').val(dados.foneMedico);
                $('#RestricaoMedicamento').prop("checked",dados.restricaoMedicamento);
                $('#QualMedicamento').val(dados.qualMedicamento);
                $('#RestricaoAlimentar').prop("checked",dados.restricaoAlimentar);
                $('#QualAlimento').val(dados.qualAlimento);
                $('#PiscinaRestricao').prop("checked",dados.piscinaRestricao);
                $('#AutorizaPasseio').prop("checked",dados.autorizaPasseio);
                $('#Observacao').val(dados.observacao);                
            }
        });
    }
}

function Atualizar() {

    var dadosSerializados = $('#formDados').serialize();
    $.ajax({
        type: "POST",
        url: "/Clientes/Cadastrar",
        data: dadosSerializados,
        success: function () {            
            adicionaDependente();
            Listar();
        },
        error: function myfunction() {
            bootbox.alert("Erro ao tentar salvar os dados!");
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
                    url: "/Clientes/DeleteDependente",
                    //envia por parametro o id da Pessoa, no caso entre chaves { } o primeiro ítem é o mesmo
                    //item definido em nossa controller (nome do parametro a ser recebido)
                    data: { id: idPessoa },
                    success: function (data) {
                        //após tudo ocorrer bem, ele lista novamente os resultados
                        Listar();
                        bootbox.alert(data);
                    },
                    error: function (data) {
                        bootbox.alert(data);
                    }
                });
            }
        }
    })
}

function LimparFormulario() {
    //Limpar formulario
    //pega todos os ítens do form e limpa
    //$('#formDados .card-body').each(function () {
    //    this.reset();
    //});

    $('#formDados .card-body input[type=hidden]').val('');
    $('#formDados .card-body #Nome').val('');    
    $('#formDados .card-body #DataNascimento').val('');    
    $('#formDados .card-body #Idade').val('');
    $('#formDados .card-body #Parente').val(0);
    $('#formDados .card-body #Escola').val('');
    $('#formDados .card-body #PlanoSaude').val('');
    $('#formDados .card-body #GrupoSanguineo').val('');
    $('#formDados .card-body #EmergenciaHospital').val('');
    $('#formDados .card-body #Medico').val('');
    $('#formDados .card-body #FoneMedico').val('');
    $('#formDados .card-body #RestricaoMedicamento')..prop("checked", false);
    $('#formDados .card-body #QualMedicamento').val('');
    $('#formDados .card-body #RestricaoAlimentar')..prop("checked", false);
    $('#formDados .card-body #QualAlimento').val('');
    $('#formDados .card-body #PiscinaRestricao')..prop("checked", false);
    $('#formDados .card-body #AutorizaPasseio')..prop("checked", false);
    $('#formDados .card-body #Observacao').val('');
}

function adicionaDependente() {
    $("#divDependente").slideToggle("slow");
    clienteId = $('#frmCliente .card-body input[type=hidden]').val();
    $("#formDados .card-body #ClienteId").val(clienteId);
};

function ConfirmaDel() {
    var confirma = bootbox.confirm("Confirma exclusão do registro?");
    return confirma;
}

function DelSuccess() {
    bootbox.alert("Deletado com Sucesso !");
}

function DelFailure() {
    bootbox.alert("Erro ao deletar registro !");
}

function Success() {
    bootbox.alert("Dados Salvos com Sucesso !");
    LimparFormulario();
    //adicionaDependente();
    clienteId = $('#frmCliente .card-body input[type=hidden]').val();
}

function Failure() {
    bootbox.alert("Erro ao tentar salvar dados!");
}

$(function () {

    clienteID = $('#frmCliente .card-body input[type=hidden]').val();

    
    $(".btn-dependente").on("click", function () {
        //e.preventDefault();     
        LimparFormulario();
        adicionaDependente();
        clienteId = $('#frmCliente .card-body input[type=hidden]').val();
        $("#formDados .card-body #ClienteId").val(clienteId);
        $("#formDados .card-body #DependenteId").val(0);
    });

    $(".btn-dependente-voltar").on("click", function () {
        //e.preventDefault();
        LimparFormulario()
        adicionaDependente();
    });    

    
});