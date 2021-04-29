import React from 'react';
import { Bussinesses } from '../api/api';
import Bussiness from './Bussiness';
import Loader from './Loader';

class BussinessList extends React.Component {
    constructor (props) {
        super(props);
        this.state = {
            bussinesses: [],
            loading: false
        };

        this.fetchBussinesses = this.fetchBussinesses.bind(this);
    }

    async fetchBussinesses() {
        this.setState({ loading: true });
        let result = await Bussinesses.Get();
        await this.setState({
            loading: false,
            bussinesses: result
        });
    }

    componentDidMount () {
        this.fetchBussinesses();
    }

    render () {
        let { loading, bussinesses } = this.state;

        if (loading) {
            return <Loader />;
        } else return <div className="row"> {
            bussinesses.map(bussiness => <Bussiness model={bussiness}/>)
        } </div>;
    }
}

export default BussinessList;