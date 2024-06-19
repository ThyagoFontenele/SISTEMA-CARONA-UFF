class UserVehicleFormComponent extends HTMLElement {
    
    vehicle;
    formElement;
    editable;

    constructor() {
        super();

        this.attachShadow({ mode: 'open' });

        this.editable = this.hasAttribute('edit') ?? this.getAttribute('edit')

        let submitButtonText = "Cadastrar";

        if (this.editable) {
            this.getVehicle();
            submitButtonText = "Editar";
        }

        const element = document.createElement("div");

        element.innerHTML = `
        <form class="p-2 m-5">
        <div>
            <div class="d-flex gap-3 flex-wrap">
                <div class="form-group col-md-3">
                    <label for="modelocarro">Modelo</label>
                    <input type="text" class="form-control" id="modelocarro" name="modelocarro" placeholder="Modelo">
                </div>
                <div class="form-group col-md-3">
                    <label for="marcacarro">Marca</label>
                    <input type="text" class="form-control" id="marcacarro" name="marcacarro" placeholder="Marca">
                </div>
                <div class="form-group col-md-1">
                    <label for="anocarro">Ano</label>
                    <input type="text" class="form-control" id="anocarro" name="anocarro" placeholder="Ano">
                </div>
                <div class="form-group col-md-2">
                    <label for="placacarro">Placa</label>
                    <input type="text" class="form-control" id="placacarro" name="placacarro" placeholder="Placa">
                </div>
                <div class="form-group col-md-2">
                    <label for="forCor">Cor</label>
                    <input type="text" class="form-control" id="cor" name="cor" placeholder ="Cor">
                </div>
                <div class="d-flex gap-2 justify-content-end align-items-end">
                    <button class="btn btn-primary" type="submit">${submitButtonText}</button>
                    ${this.editable ? "<button class='btn btn-danger'>Excluir</button>" : ""}
                </div>
            </div>
        </div>
    </form>
        `;
        
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
                return;
            }
            
            if (res.status === 409) {
                return res.text().then(text => { throw new Error(text)})
            }
            
        }).catch((e) => alert(e))
    }

    getVehicle() {
        const id = parseInt(this.getAttribute('id'));

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

customElements.define('app-user-vehicle-form', UserVehicleFormComponent);