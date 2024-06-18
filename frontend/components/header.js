class HeaderComponent extends HTMLElement {

    loggedButtons = `
<span class="navbar-text">
    <a class="navbar-brand" href="../user-home/user-home-profile.html">
        <font color="white">Perfil</font>
    </a>
</span>
<span class="navbar-text">
    <a class="navbar-brand" id="logout" href="#">
        <font color="white">Logout</font>
    </a>
</span>`;

    notLoggedButtons = `
<span class="navbar-text">
    <a class="navbar-brand" href="../register/register.html">
        <font color="white">Cadastro</font>
    </a>
</span>
<span class="navbar-text">
    <a class="navbar-brand" id="login" href="../login/login.html">
        <font color="white">Login</font>
    </a>
</span>`;

    constructor() {
        super();

        this.attachShadow({ mode: 'open' });

        const element = document.createElement("div");

        const buttons = localStorage.getItem('token') ? this.loggedButtons : this.notLoggedButtons;

        element.innerHTML = `
<nav class="navbar navbar-expand-lg navbar-light" style="background-color: #016086;">
    <div class="collapse navbar-collapse" id="textoNavbar">
        <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
                <a href="../user-home/user-home.html">
                    <img src="../src/logo.png" height="70" />
                </a>
            </li>
        </ul>
        ${buttons}
    </div>
</nav>`;

        element.querySelector('#logout')?.addEventListener('click', () => {
            localStorage.removeItem('token');
            localStorage.removeItem('id');
            window.location.href = '../login/login.html';
        });
        
        this.setBootstrapLink();
        this.shadowRoot.appendChild(element);
    }

    setBootstrapLink() {
        const link = document.createElement('link');
        link.setAttribute('href', 'https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/css/bootstrap.min.css');
        link.setAttribute('rel', "stylesheet");
        this.setAttribute('integrity', 'sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO');	
        link.setAttribute('crossorigin', 'anonymous');
        this.shadowRoot.append(link);
    }

}

customElements.define('app-header', HeaderComponent );