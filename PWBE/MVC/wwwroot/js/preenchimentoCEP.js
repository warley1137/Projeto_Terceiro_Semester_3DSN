window.addEventListener('load', ()=>{
    /* ---------------- PREENCHIMENTO CEP --------------- */
    inpCEP = document.getElementById('cep')
    rua = document.getElementById('rua')
    bairro = document.getElementById('bairro')
    cidade = document.getElementById('cidade')
    estado = document.getElementById('uf')

    console.log(inpCEP)

    inpCEP.addEventListener('change', ()=>{
        cep = inpCEP.value
        console.log(cep)

        //Nova variável "cep" somente com dígitos.
        var cep = cep.replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if(validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                rua.value="...";
                bairro.value="...";
                cidade.value="...";
                uf.value="...";

                //Sincroniza com o callback.
                url = `https://viacep.com.br/ws/${cep}/json/`;

                fetch(url)
                    .then(resultado => {return resultado.json()})
                    .then(dados => {
                        console.log(dados)

                        rua.value= dados.logradouro;
                        bairro.value= dados.bairro;
                        cidade.value= dados.localidade;
                        uf.value= dados.uf;
                    })

            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    })

    function limpa_formulário_cep() {
        rua.value="";
        bairro.value="";
        cidade.value="";
        uf.value="";
    }
})