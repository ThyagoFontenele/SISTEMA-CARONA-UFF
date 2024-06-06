function login(json) {
    fetch('http://localhost:5125/api/Login', {
            method: 'POST',
            body: json,
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            }
        }).then(res => {
            if (res.ok) {
                alert('Logado com sucesso');

                res.json().then(r => {
                    localStorage.setItem('id', r.user.id);
                    localStorage.setItem('token', r.token)
                })
                
                return;
            }
            
            if (res.status >= 400) {
                alert("Email ou senha inválidos!");
            } 
        }).catch((e) => alert(e))
}

const form = document.querySelector('form');

form.addEventListener("submit", e => {
    e.preventDefault()
    const object = {}

    form.querySelectorAll('.form-control').forEach(i => object[i.name] = i.value)
    var json = JSON.stringify(object)
    this.login(json);
})