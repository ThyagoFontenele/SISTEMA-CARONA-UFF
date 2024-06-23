class UserVehicleFormComponent extends HTMLElement {
    
    vehicle;
    formElement;
    editable;
    id;

    constructor(id) {
        super();

        this.attachShadow({ mode: 'open' });

        this.editable = this.hasAttribute('id') || id;

        let submitButtonText = "Cadastrar";
        
        if (this.editable) {
            this.id = id ?? this.getAttribute('id')
            this.getVehicle();
            submitButtonText = "Editar";
        }

        const element = document.createElement("div");

        element.innerHTML = `
    <form class="m-5">
        <h4>${submitButtonText} Veículo</h4>
        <div>
            <div class="d-flex gap-3 flex-wrap">
                <div class="form-group col-md-3">
                    <label for="modelo">Modelo</label>
                    <input required type="text" class="form-control" id="modelo" name="modelo" placeholder="Modelo">
                </div>
                <div class="form-group col-md-3">
                    <label for="marca">Marca</label>
                    <input required type="text" class="form-control" id="marca" name="marca" placeholder="Marca">
                </div>
                <div class="form-group col-md-1">
                    <label for="ano">Ano</label>
                    <input required type="text" class="form-control" id="ano" name="ano" placeholder="Ano">
                </div>
                <div class="form-group col-md-2">
                    <label for="placa">Placa</label>
                    <input required type="text" class="form-control" id="placa" name="placa" placeholder="Placa">
                </div>
                <div class="form-group col-md-2">
                    <label for="forCor">Cor</label>
                    <input required type="text" class="form-control" id="cor" name="cor" placeholder ="Cor">
                </div>
                <div class="d-flex gap-2 justify-content-end align-items-end">
                    <button class="btn btn-primary" type="submit">${submitButtonText}</button>
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
                object['id'] = this.vehicle.id;
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
            'Access-Control-Allow-Origin': '*',
            'Authorization': `Bearer ${localStorage.getItem('token')}`
        }

        if (this.editable) {
            method = 'PUT';
        }

        fetch(baseUrl, {
            method: method,
            body: json,
            headers: headers
        }).then(async res => {
            if (res.ok) {
                
                await res.json().then(res => {
                    if (this.editable) {
                        editVehicle(res)
                        editVehicleComponentToggle(res.id)
                        return;
                    }

                    addVehicle(res)
                });

                this.formElement.querySelectorAll('.form-control').forEach(i => i.value = '')
                return;
            }
            
            if (res.status === 400) {
                alert('Dados incorretos')
                return;
            }

            if (res.status === 409) {
                return res.text().then(text => alert(text))
            }
            
        }).catch((e) => alert(e))
    }

    getVehicle() {
        const token = localStorage.getItem('token')
        fetch(`http://localhost:5125/api/Veiculo/${this.id}`, {
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
        this.formElement.querySelectorAll('.form-control').forEach(i => i.value = this.vehicle[i.name])
    }
}

customElements.define('app-user-vehicle-form', UserVehicleFormComponent);