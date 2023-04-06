$(document).ready(function () {
    $('#Pessoa').DataTable();
});

$('.close.alert').click(function () {
    $('.alert').hide('hide');
})

$('#Pessoa').DataTable({
    "ordering": true,
    "paging": true,
    "searching": true,
    "Language": {
        "sEmptyTable": "Nenhum registro encontrado na tabela",
        "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
        "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "Mostrar _MENU_ registros por pagina",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
        "oPaginate": {
            "sNext": "Proximo",
            "sPrevious": "Anterior",
            "sFirst": "Primeiro",
            "sLast": "Ultimo"
        },
        "oAria": {
            "sSortAscending": ": Ordenar colunas de forma ascendente",
            "sSortDescending": ": Ordenar colunas de forma descendente"
        }
    }
});




function limpa_formulario_cep() {
    //Limpa valores do formulário de cep.
    document.getElementById('rua').value = ("");
    document.getElementById('bairro').value = ("");
    document.getElementById('cidade').value = ("");
    document.getElementById('estado').value = ("");

}

function meu_callback(conteudo) {
    if (!("erro" in conteudo)) {
        //Atualiza os campos com os valores.
        document.getElementById('rua').value = (conteudo.logradouro);
        document.getElementById('bairro').value = (conteudo.bairro);
        document.getElementById('cidade').value = (conteudo.localidade);
        document.getElementById('estado').value = (conteudo.uf);
    } //end if.
    else {
        //CEP não Encontrado.
        limpa_formulario_cep();
        alert("CEP não encontrado.");
        document.getElementById('cep').value = ("");
    }
}

function pesquisacep(valor) {

    //Nova variável "cep" somente com dígitos.
    var cep = valor.replace(/\D/g, '');

    //Verifica se campo cep possui valor informado.
    if (cep !== "") {

        //Expressão regular para validar o CEP.
        var validacep = /^[0-9]{8}$/;

        //Valida o formato do CEP.
        if (validacep.test(cep)) {

            //Preenche os campos com "..." enquanto consulta webservice.
            document.getElementById('rua').value = "...";
            document.getElementById('bairro').value = "...";
            document.getElementById('cidade').value = "...";
            document.getElementById('estado').value = "...";

            //Cria um elemento javascript.
            var script = document.createElement('script');

            //Sincroniza com o callback.
            script.src = '//viacep.com.br/ws/' + cep + '/json/?callback=meu_callback';

            //Insere script no documento e carrega o conteúdo.
            document.body.appendChild(script);

        } //end if.
        else {
            //cep é inválido.
            limpa_formulario_cep();
            alert("Formato de CEP inválido.");
        }
    } //end if.
    else {
        //cep sem valor, limpa formulário.
        limpa_formulario_cep();
    }
}

//Controle de formatação dos campos
function mascaraCpf(i) {

    var v = i.value;

    if (isNaN(v[v.length - 1])) { //Não deixa a pessoa incluir letras
        i.value = v.substring(0, v.length - 1);
        return;
    }

    i.setAttribute("maxlength", "14");
    if (v.length == 3 || v.length == 7) i.value += ".";
    if (v.length == 11) i.value += "-";

}

function mascaraCnpj(i) {

    var valor = i.value;

    if (isNaN(valor[valor.length - 1])) { //Não deixa a pessoa incluir letras
        i.value = valor.substring(0, valor.length - 1);
        return;
    }

    i.setAttribute("maxlength", "18");
    if (valor.length == 2 || valor.length == 6) i.value += ".";
    if (valor.length == 10) i.value += "/";
    if (valor.length == 15) i.value += "-"
}

function mascaraCep(i) {

    var valor = i.value;

    if (isNaN(valor[valor.length - 1])) { //Não deixa a pessoa incluir letras
        i.value = valor.substring(0, valor.length - 1);
        return;
    }

    i.setAttribute("maxlength", "9");
    if (valor.length == 5) i.value += "-";
}

//Telefone1
function mascaraFone1(event) {
    var valor = document.getElementById("telefone1").attributes[0].ownerElement['value'];
    var retorno = valor.replace(/\D/g, "");
    retorno = retorno.replace(/^0/, "");
    if (retorno.length > 10) {
        retorno = retorno.replace(/^(\d\d)(\d{5})(\d{4}).*/, "($1) $2-$3");
    } else if (retorno.length > 5) {
        if (retorno.length == 6 && event.code == "Backspace") {
            // necessário pois senão o "-" fica sempre voltando ao dar backspace
            return;
        }
        retorno = retorno.replace(/^(\d\d)(\d{4})(\d{0,4}).*/, "($1) $2-$3");
    } else if (retorno.length > 2) {
        retorno = retorno.replace(/^(\d\d)(\d{0,5})/, "($1) $2");
    } else {
        if (retorno.length != 0) {
            retorno = retorno.replace(/^(\d*)/, "($1");
        }
    }
    document.getElementById("telefone1").attributes[0].ownerElement['value'] = retorno;
}

//Telefone 2
function mascaraFone2(event) {
    var valor = document.getElementById("telefone2").attributes[0].ownerElement['value'];
    var retorno = valor.replace(/\D/g, "");
    retorno = retorno.replace(/^0/, "");
    if (retorno.length > 10) {
        retorno = retorno.replace(/^(\d\d)(\d{5})(\d{4}).*/, "($1) $2-$3");
    } else if (retorno.length > 5) {
        if (retorno.length == 6 && event.code == "Backspace") {
            // necessário pois senão o "-" fica sempre voltando ao dar backspace
            return;
        }
        retorno = retorno.replace(/^(\d\d)(\d{4})(\d{0,4}).*/, "($1) $2-$3");
    } else if (retorno.length > 2) {
        retorno = retorno.replace(/^(\d\d)(\d{0,5})/, "($1) $2");
    } else {
        if (retorno.length != 0) {
            retorno = retorno.replace(/^(\d*)/, "($1");
        }
    }
    document.getElementById("telefone2").attributes[0].ownerElement['value'] = retorno;
}
