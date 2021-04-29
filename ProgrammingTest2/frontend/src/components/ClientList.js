import React from 'react';
import Client from './Client';

class ClientList extends React.Component {
    constructor (props) {
        super(props);
    }

    render () {
        let { models } = this.props;
        return <table>
          <thead>
            <tr>
                <th>Cliente</th>
                <th>Documento de Id</th>
                <th>Direcciones</th>
                <th></th>
            </tr>
          </thead>
  
          <tbody>
              {models ? models.map(client => <Client model={client}/>) : null}
          </tbody>
        </table>;
    }
}

export default ClientList;