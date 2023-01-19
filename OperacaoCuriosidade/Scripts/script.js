function validar(event){

    const formlogin = document.getElementById('formulario');
    formulario.addEventListener('submit', validar);
    
    if((document.formlogin.iemail.value == "") && (document.formlogin.isenha.value == "")){

        alert(" E-mail e Senha precisam ser preenchidos.");

        document.formlogin.email.focus();
        event.preventDefault();

    }

        if((document.formlogin.iemail.value == "")){

            alert("E-mail precisa ser preenchido");

            document.email.focus();

            event.preventDefault();

        }

        if((document.formlogin.isenha.value == "")){

            alert("Senha precisa ser preenchida.");

            document.email.focus();

            event.preventDefault();

        }

}

function validarNome(event){

    const formCadastro = document.getElementById('formC');
    formC.addEventListener('submit', validarNome);

    if((document.novoC.inome.value == "")){

        alert("Nome precisa ser preenchido");

        document.novoC.inome.focus();
        event.preventDefault();
    }

    if(document.novoC.inome.value != ""){

        alert(" Cadastrado! ");

    }

}

