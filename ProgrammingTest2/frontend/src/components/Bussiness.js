import React from 'react';
import ClientList from './ClientList';

class Bussiness extends React.Component {
    constructor (props) {
        super(props);
    }

    render () {
        let { model } = this.props;
        return <div className="card hoverable" key={model.id}>
            <div className="card-content">
                <span className="card-title activator grey-text text-darken-4">
                    {model.name}
                    <a className="btn-flat btn-small transparent right">
                        <i className="material-icons">account_circle</i>
                    </a>
                </span>
                <br /><br /><br /><br /><br /><br />
                <div>
                    <p>{model.description}</p>
                    <p className="btn-flat btn-small transparent right"><i className="material-icons">delete_forever</i></p>
                </div>
            </div>
            <div className="card-reveal">
                <span className="card-title">
                    {model.name}
                    <p className="btn-flat btn-small right"><i className="material-icons">close</i></p>
                </span>
                <ClientList models={model.clients}/>
                <div>
                    <a className="btn green darken-4 left"><i className="material-icons">add</i></a>
                </div>
            </div>
        </div>;
    }
}

export default Bussiness;