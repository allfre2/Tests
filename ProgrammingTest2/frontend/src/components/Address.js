import React from 'react';

class Address extends React.Component {
    constructor (props) {
        super(props);
    }

    render () {
        let { model } = this.props;
        return <li key={model.id}>
            <span>(<b>ZipCode: </b>{model.zipCode}) <mark>{model.addressLine1}</mark></span>
        </li>;
    }
}

export default Address;