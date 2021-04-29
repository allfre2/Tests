import React from 'react';
import BussinessList from '../components/BussinessList';

class Main extends React.Component {
    constructor (props) {
        super(props);
    }

    render() {
        return <div className="container">
            <h1 className="center-align">Listado de Empresas</h1>
            <BussinessList />
            <a class="btn-floating btn-large waves-effect waves-light red"><i class="material-icons">add</i></a>
        </div>;
    }
}

export default Main;