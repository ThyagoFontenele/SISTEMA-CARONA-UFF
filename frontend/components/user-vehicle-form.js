class UserVehicleForm extends HTMLElement {
    
    /*vehicle;
    formElement;
    editable;*/

    constructor() {
        super();

        this.attachShadow({ mode: 'open' });

        this.editable = this.hasAttribute('edit') ?? this.getAttribute('edit')

        let submitButtonText = "Cadastrar";

        if (this.editable) {
            //this.getVehicle();
            submitButtonText = "Editar";
        }

        const element = document.createElement("div");

        element.innerHTML = `
        <form class="p-2 m-5">
        <div>
            <div class="row">
                <div class="form-group col-md-2">
                    <label for="modelocarro">Modelo</label>
                    <input type="text" class="form-control" id="modelocarro" name="modelocarro" placeholder ="Modelo">
                </div>
                <div class="form-group col-md-2">
                    <label for="marcacarro">Marca</label>
                    <input type="text" class="form-control" id="marcacarro" name="marcacarro" placeholder ="Marca">
                </div>
                <div class="form-group col-md-2">
                    <label for="anocarro">Ano</label>
                    <input type="text" class="form-control" id="anocarro" name="anocarro" placeholder ="Ano">
                </div>
                <div class="form-group col-md-2">
                    <label for="placacarro">Placa</label>
                    <input type="text" class="form-control" id="placacarro" name="placacarro" placeholder ="Placa">
                </div>
                <div class="form-group col-md-2">
                    <label for="estadocarro">UF</label>
                    <select id="estadocarro" name="estadocarro" class="form-control" placeholder ="UF">
                        <option selected>Escolher...</option>
                        <option>AC</option>
                        <option>AM</option>
                        <option>RR</option>
                        <option>PA</option>
                        <option>RO</option>
                        <option>AP</option>
                        <option>TO</option>
                        <option>MA</option>
                        <option>PI</option>
                        <option>CE</option>
                        <option>RN</option>
                        <option>PB</option>
                        <option>PE</option>
                        <option>AL</option>
                        <option>SE</option>
                        <option>BA</option>
                        <option>MG</option>
                        <option>ES</option>
                        <option>RJ</option>
                        <option>SP</option>
                        <option>PR</option>
                        <option>SC</option>
                        <option>RS</option>
                        <option>MS</option>
                        <option>MT</option>
                        <option>GO</option>
                        <option>DF</option>
                    </select>
                </div>
                <div class="form-group col-md-2">
                    <label for="forCidade">Cidade</label>
                    <input type="text" class="form-control" id="cidade" name="cidade" placeholder ="Cidade">
                </div>
            </div>
        </div>
        <br>
        <button type="submit" class="btn btn-primary">${submitButtonText}</button>
    </form>
        `;
        
        /*this.formElement = element.querySelector('form');
        this.formElement.addEventListener("submit", e => {
            e.preventDefault()
            const object = {}

            if (this.editable) {
                object['id'] = this.user.id;
            }

            this.formElement.querySelectorAll('.form-control').forEach(i => object[i.name] = i.value)
            var json = JSON.stringify(object)
            this.request(json);
        })        */

        this.setBootstrapLink();
        this.shadowRoot.appendChild(element);
    }

    setBootstrapLink() {
        const link = document.createElement('link');
        link.setAttribute('href', 'https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css');
        link.setAttribute('rel', "stylesheet");
        this.setAttribute('integrity', 'sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO');	
        link.setAttribute('crossorigin', 'anonymous');
        this.shadowRoot.append(link);
    }

    /*

    request(json) {
        let baseUrl = 'http://localhost:5125/api/Veiculo';
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

    getVehicle() {
        const id = localStorage.getItem('id')
        const token = localStorage.getItem('token')
        fetch(`http://localhost:5125/api/Veiculo/${id}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*',
                'Authorization': `Bearer ${token}`
            }
        }).then(res => {
            if (res.ok) {
                res.json().then(res => {
                    this.vehicle = res
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
    } */

}

customElements.define('user-vehicle-form', UserVehicleForm);