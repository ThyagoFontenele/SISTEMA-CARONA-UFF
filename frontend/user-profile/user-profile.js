function loaded() {
    const main = document.getElementsByTagName('main')[0];
    const spinner = document.getElementsByClassName('spinner')[0];
    spinner.classList.add('d-none');
    main.classList.remove('d-none');
}

function hasCar() {
    const noVehiclesDiv = document.getElementById('no-vehicles');
    noVehiclesDiv.classList.add('d-none');
    const vehiclesTable = document.getElementById('vehicles-table');
    vehiclesTable.classList.remove('d-none');
}

function addVehicle(vehicle) {
    const tbody = document.getElementsByTagName('tbody')[0];

    if (tbody.getElementsByTagName('tr').length === 0) {
        hasCar();
    }

    const tr = document.createElement('tr');
    tr.id = vehicle.id;
    tr.innerHTML = `
        <td>${vehicle.modelo}</td>
        <td>${vehicle.marca}</td>
        <td>${vehicle.ano}</td>
        <td>${vehicle.placa}</td>
        <td>${vehicle.cor}</td>
        <td>
            <button class="btn btn-primary edit-car">Editar</button> 
            <button class="btn btn-danger delete-car">Excluir</button>
        </td>
    `;

    tr
    .querySelector('.edit-car')
    .addEventListener('click', e => editVehicleComponentToggle(vehicle.id));

    tr.querySelector('.delete-car').addEventListener('click', e => deleteVehicle(e));

    tbody.append(tr);
}

function deleteVehicle(e) {
    destroyVehicleComponent();
    const tr = e.target.closest('tr');
    
    fetch('http://localhost:5125/api/Veiculo/'+tr.id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'Authorization': `Bearer ${localStorage.getItem('token')}`
        }
    }).then(res => {
        if (res.ok) {
            tr.remove();

            if (document.getElementsByTagName('tbody')[0].getElementsByTagName('tr').length === 0) {
                const noVehiclesDiv = document.getElementById('no-vehicles');
                noVehiclesDiv.classList.remove('d-none');
                const vehiclesTable = document.getElementById('vehicles-table');
                vehiclesTable.classList.add('d-none');
            }
        }  
    }).catch((e) => alert(e))
}

function getAll() {
    fetch('http://localhost:5125/api/Veiculo', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'Authorization': `Bearer ${localStorage.getItem('token')}`
        }
    }).then(res => {
        if (res.ok) {
            res.json().then(res => {
                if (res.length === 0) {
                    return;
                }

                hasCar();
                res.forEach(vehicle => addVehicle(vehicle));
            })
            return;
        }
        
        if (res.status === 409) {
            return res.text().then(text => { throw new Error(text)})
        }
        
    }).catch((e) => alert(e))
}

function editVehicleComponentToggle(vehicleId) {
    const div = document.getElementsByClassName('edit-vehicle')[0]
    const component = div.getElementsByTagName('app-user-vehicle-form')[0];

    if (component) { 
        component.remove();

        if (component.id === vehicleId) {
            return;
        }
    }

    div.append(new UserVehicleFormComponent(vehicleId)); 
}

function destroyVehicleComponent() {
    const div = document.getElementsByClassName('edit-vehicle')[0]
    const component = div.getElementsByTagName('app-user-vehicle-form')[0];

    if (component) {
        component.remove();
    }
}

function editVehicle(vehicle) {
   const tbody = document.getElementsByTagName('tbody')[0];
   const trs = tbody.getElementsByTagName('tr');

   for (let i = 0; i < trs.length; i++) {
        const tr = trs[i];
        if (tr.id == vehicle.id) {
            const datas = tr.getElementsByTagName('td')
            console.log(datas)
            datas[0].innerText = vehicle.modelo;
            datas[1].innerText = vehicle.marca;
            datas[2].innerText = vehicle.ano;
            datas[3].innerText = vehicle.placa;
            datas[4].innerText = vehicle.cor;
        }
   }
}

getAll();