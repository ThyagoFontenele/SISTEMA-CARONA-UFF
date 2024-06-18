class UserFormComponent extends HTMLElement {
    
    user;
    formElement;
    editable;

    constructor() {
        super();

        this.attachShadow({ mode: "open" });

        this.editable = this.hasAttribute('edit') ?? this.getAttribute('edit')

        let submitButtonText = "Registrar";

        if (this.editable) {
            this.getUser();
            submitButtonText = "Editar";
        }

        const element = document.createElement("div");
        const content = `
        <form class="p-2 m-5" id="user-form">
            <div>
                <div class="row">
                    <div class="form-group col-md-4">
                        <label for="forNome">Nome</label>
                        <input required type="text" class="form-control" id="nome" name="nome" placeholder="Nome">
                    </div>
                    <div class="form-group col-md-4">
                        <label for="forCPF">CPF</label>
                        <input required type="text" class="form-control" id="cpf" name="cpf" placeholder="CPF">
                    </div>
                    <div class="form-group col-md-4">
                        <label for="inputCEP">Telefone</label>
                        <input required type="text" class="form-control" id="telefone" name="telefone" placeholder="Telefone">
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-2">
                        <label for="inputCEP">CEP</label>
                        <input required type="text" class="form-control" id="cep" name="cep" placeholder="CEP">
                    </div>
                    <div class="form-group col-md-2">
                        <label for="dataNascimento">Data de nascimento</label>
                        <input required type="date" id="dataNascimento" name="dataNascimento" class="form-control">
                    </div>
                    <div class="form-group col-md-2">
                        <label for="forCidade">Cidade</label>
                        <input required type="text" class="form-control" id="cidade" name="cidade" placeholder="Cidade">
                    </div>
                    <div class="form-group col-md-2">
                        <label for="forBairro">Bairro</label>
                        <input required type="text" class="form-control" id="bairro" name="bairro" placeholder="Bairro">
                    </div>
                    <div class="form-group col-md-4">
                        <label for="forEndereco">Endereço</label>
                        <input required type="text" class="form-control" id="endereco" name="endereco" placeholder="Rua dos Bobos, nº 0">
                    </div>
                </div>
                <div class="row">
                    <div class="form-group col-md-4">
                        <label for="exampleInputEmail1">Email</label>
                        <input required type="email" class="form-control" id="email" name="email" aria-describedby="emailHelp" placeholder="Email">
                    </div>
                    <div class="form-group col-md-4">
                        <label for="exampleInputPassword1">Senha</label>
                        <input required type="password" class="form-control" id="senha" name="senha" placeholder="Senha">
                    </div>
                </div>
            </div>

            <button type="submit" class="btn btn-primary mt-2">${submitButtonText}</button>
        </form>`;

        element.innerHTML = content;
        this.formElement = element.querySelector('form');
        this.formElement.addEventListener("submit", e => {
            e.preventDefault()
            const object = {}

            if (this.editable) {
                object['id'] = this.user.id;
            }

            this.formElement.querySelectorAll('.form-control').forEach(i => object[i.name] = i.value)
            var json = JSON.stringify(object)
            this.request(json);
        })        

        this.setBootstrapLink();
        this.shadowRoot.append(element)
    }

    setBootstrapLink() {
        const link = document.createElement('link');
        link.setAttribute('href', 'https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css');
        link.setAttribute('rel', "stylesheet");
        this.setAttribute('integrity', 'sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO');	
        link.setAttribute('crossorigin', 'anonymous');
        this.shadowRoot.append(link);
    }

    request(json) {
        let baseUrl = 'http://localhost:5125/api/Usuario';
        let method = 'POST';
        const headers = {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*'
        }

        if (this.editable) {
            method = 'PUT';
            headers['Authorization'] = `Bearer ${localStorage.getItem('token')}`
        }

        fetch(baseUrl, {
            method: method,
            body: json,
            headers: headers
        }).then(res => {
            if (res.ok) {
                alert('Sucesso!');
                if (method === 'POST') {
                    window.location.href = '/login/login.html';  
                }
                return;
            }
            
            if (res.status === 409) {
                return res.text().then(text => { throw new Error(text)})
            }

            alert('Erro!');
            
        }).catch((e) => alert(e))
    }

    getUser() {
        const id = localStorage.getItem('id')
        const token = localStorage.getItem('token')
        fetch(`http://localhost:5125/api/Usuario/${id}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'Authorization': `Bearer ${token}`
            }
        }).then(res => {
            if (res.ok) {
                res.json().then(res => {
                    this.user = res
                    this.setFormValues()
                })
                return;
            }
            
            if (res.status === 409) {
                return res.text().then(text => { throw new Error(text)})
            }

            alert('Erro!');
            
        }).catch((e) => alert(e))
    }

    setFormValues() {
        this.formElement.querySelectorAll('.form-control').forEach(i => {
            if (i.name === 'senha') {
                return;
            }

            if (i.name === 'dataNascimento') {
                i.value = new Date(this.user[i.name]).toISOString().substring(0,10);
                return;
            }

            i.value = this.user[i.name]
        })
    }
}

customElements.define("app-user-form", UserFormComponent);