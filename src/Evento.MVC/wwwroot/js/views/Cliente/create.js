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