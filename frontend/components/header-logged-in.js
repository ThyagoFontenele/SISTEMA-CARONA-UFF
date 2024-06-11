class HeaderLoggedIn extends HTMLElement {

    constructor() {
        super();

        this.attachShadow({ mode: 'open' });

        const element = document.createElement("div");

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
        <span class="navbar-text">
            <a class="navbar-brand" href="../user-home/user-home.html">
                <font color="white">Voltar</font>
            </a>
        </span>
        <span class="navbar-text">
            <a class="navbar-brand" href="../public-home.html">
                <font color="white">Logout</font>
            </a>
        </span>
    </div>
</nav>
        `;

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

customElements.define('header-logged-in', HeaderLoggedIn );