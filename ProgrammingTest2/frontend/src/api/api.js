import endpoints from '../config/endpoints';

class EndPointAdapter {
    constructor(endpoint) {
        this.endpoint = endpoint;
    }

    async Get(id) {
        let data = await fetch(this.endpoint + (id ? ('/' + id) : ''), {
            method: 'GET'
        });

        return await data.json();
    }

    async Add(entity) {
        let data = await fetch(this.endpoint, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(entity)
        });
        
        return await data.json();
    }

    async Update(id, entity) {
        let data = await fetch(this.endpoint + '/' + id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(entity)
        });
        
        return await data.json();
    }

    async Remove(id) {
        let data = await fetch(this.endpoint + '/' + id, { method: 'DELETE' });
        
        return await data.json();
    }
}

const Bussinesses = new EndPointAdapter(endpoints.bussiness);
const Clients = new EndPointAdapter(endpoints.client);
const Addresses = new EndPointAdapter(endpoints.address);

export {
    Bussinesses,
    Clients,
    Addresses
}