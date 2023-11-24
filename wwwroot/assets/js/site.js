
//Capturar ID da pessoa para carregar os orçamentos
//function capturar(id) {
//    var codigoUsuario = id

//    $.ajax({
//        type: 'GET',
//        url: '/Pessoa/ListarOrcamentosPessoaId/' + codigoUsuario,
//        success: function (result) {
//            console.log(result);
//            $("#ListaOrcamento").html(result);
//            var modal = new bootstrap.Modal(document.querySelector('.modal'));
//            modal.show(codigoUsuario);
//        }
//    });
//}



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


function mascaraCpfCnpj(input) {
    var value = input.value;
    // Remove tudo que não é dígito
    value = value.replace(/\D/g, '');
    if (value.length <= 11) { // CPF
        // Coloca a máscara do CPF (XXX.XXX.XXX-XX)
        value = value.replace(/(\d{3})(\d)/, '$1.$2');
        value = value.replace(/(\d{3})(\d)/, '$1.$2');
        value = value.replace(/(\d{3})(\d{1,2})$/, '$1-$2');
    } else { // CNPJ
        // Coloca a máscara do CNPJ (XX.XXX.XXX/XXXX-XX)
        value = value.replace(/^(\d{2})(\d)/, '$1.$2');
        value = value.replace(/^(\d{2})\.(\d{3})(\d)/, '$1.$2.$3');
        value = value.replace(/\.(\d{3})(\d)/, '.$1/$2');
        value = value.replace(/(\d{4})(\d)/, '$1-$2');
    }
    input.value = value;
}

function mascaraTelefone(input) {
    var value = input.value;
    // Remove tudo que não é dígito
    value = value.replace(/\D/g, '');
    if (value.length === 11) { // Celular
        // Coloca a máscara do telefone celular (DDD 9XXXX-XXXX)
        value = value.replace(/^(\d{2})(\d{5})(\d{4})$/, '($1) $2-$3');
    } else if (value.length === 10) { // Telefone fixo
        // Coloca a máscara do telefone fixo (DDD XXXX-XXXX)
        value = value.replace(/^(\d{2})(\d{4})(\d{4})$/, '($1) $2-$3');
    }
    input.value = value;
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

// Formatar moeda
function formatarMoeda(input) {
    // Obtém o valor do campo de entrada
    var valor = input.value;

    // Remove caracteres não numéricos
    var valorNumerico = parseFloat(valor.replace(/\D/g, ''));

    // Verifica se o valor é um número válido
    if (!isNaN(valorNumerico)) {
        // Formata o número como moeda brasileira
        var numeroFormatado = (valorNumerico / 100).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });

        // Atualiza o valor no campo de entrada
        input.value = numeroFormatado;
    } else {
        // Caso o valor não seja um número válido, limpa o campo de entrada
        input.value = '';
    }
}
