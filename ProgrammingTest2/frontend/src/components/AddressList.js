import React from 'react';
import Address from './Address';

class AddressList extends React.Component {
    constructor(props) {
        super(props);
    }

    render () {
        let { models } = this.props;
        return <ul>
            {models.map(address => <Address model={address} />)}
        </ul>;
    }
}

export default AddressList;