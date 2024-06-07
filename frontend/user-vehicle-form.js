class UserVehicleForm extends HTMLElement {
    
    constructor() {
        super();

        this.attachShadow({ mode: 'open' });

        const element = document.createElement("div");
        
        element.innerHTML = `
        <form class="p-2 m-5">
        <div>
            <div class="row">
                <div class="form-group col-md-2">
                    <label for="modelocarro">Modelo</label>
                    <input type="text" class="form-control" id="modelocarro" name="modelocarro" value="Siena"
                        disabled>
                </div>
                <div class="form-group col-md-2">
                    <label for="marcacarro">Marca</label>
                    <input type="text" class="form-control" id="marcacarro" name="marcacarro" value="Fiat" disabled>
                </div>
                <div class="form-group col-md-2">
                    <label for="anocarro">Ano</label>
                    <input type="text" class="form-control" id="anocarro" name="anocarro" value="2019" disabled>
                </div>
                <div class="form-group col-md-2">
                    <label for="placacarro">Placa</label>
                    <input type="text" class="form-control" id="placacarro" name="placacarro" value="APP2024" disabled>
                </div>
                <div class="form-group col-md-2">
                    <label for="estadocarro">UF</label>
                    <select id="estadocarro" name="estadocarro" class="form-control" disabled>
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
                    <input type="text" class="form-control" id="cidade" name="cidade" value="Rio de Janeiro"
                        disabled>
                </div>
            </div>
        </div>
        <button type="submit" class="btn btn-primary">Editar</button>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"
        integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo"
        crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"
        integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49"
        crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"
        integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy"
        crossorigin="anonymous"></script>
        `;
        
        this.setBootstrapLink();
        this.shadowRoot.appendChild(element);
    }
}

/*setBootstrapLink(){
    const link = document.createElement('link');
    link.setAttribute('href', 'https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css');
    link.setAttribute('rel', "stylesheet");
    this.setAttribute('integrity', 'sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO');	
    link.setAttribute('crossorigin', 'anonymous');
    this.shadowRoot.append(link);
}*/

customElements.define('user-vehicle-form', UserVehicleForm);