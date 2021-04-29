import React from 'react';
import AddressList from './AddressList';

class Client extends React.Component {
    constructor (props) {
        super(props);
    }

    render () {
        let { model } = this.props;
        return <tr key={model.id}>
            <td>{ model.name + ' ' + model.lastName }</td>
            <td>{ model.ssn}</td>
            <td>{ (model.addresses && model.addresses.length > 0) ? 
                <AddressList models={model.addresses}/>
                : 'N/A'
            }</td>
            <td><a className="btn-flat red darken-4"><i className="material-icons">delete</i></a></td>
        </tr>;
    }
}

export default Client;