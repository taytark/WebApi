$(document).ready(function () {
    $("#CEP").mask("00000-000");
    $("#CEP").focusout(function () {
        $.ajax({
            url: 'https://ws.apicep.com/cep/' + $("#CEP").val() + '.json',
            type: 'GET',
            success: function (retorno) {
                $('#Logradouro').val(retorno.address);
                $('#Bairro').val(retorno.district);
                $('#Cidade').val(retorno.city);
                $('#UF').val(retorno.state);
            }
        });
    });
});

function abrirModalExclusao(id) {
    $("#imovelExclusao").val(id);
    $("#modalExclusaoImovel").show();
}

function excluirImovel() {
    $.ajax({
        url: '/Imoveis/Delete',
        data: 'id=' + $("#imovelExclusao").val(),
        type: 'POST',
        success: function () {
            $("#modalExclusaoImovel").hide();
            location.reload();
        }
    });
}

function cancelarExclusao() {
    $("#modalExclusaoImovel").hide();
}