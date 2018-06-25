if (process.env.NODE_ENV === 'integrated') {
    if (!window.Vue) {
        var d1 = document.getElementById('main');
        d1.insertAdjacentHTML('beforeend', '<div>Neutronium warning</div><div>npm integrated scripts is not meant to be used in the browser.</div><div>Use Neutronium application in mode -dev to activate hot reload</div><a href="https://github.com/NeutroniumCore/Neutronium/blob/ec6493f27833d3a4dba90e37bd8c29909422f5b1/Documentation/Content/UsesCases/New_project.md">reference</a>');
    }
}