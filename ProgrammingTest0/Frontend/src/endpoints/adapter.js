import { endpoints } from '../config/api';

class EndPointAdapter {
    constructor(endpoint) {
        this.endpoint = endpoint;
    }

    async Get(id) {
        let data = await fetch(this.endpoint + (id ? ('/' + id) : ''), {
            method: 'GET', mode: 'cors'
        });

        if (data.redirected) {
            throw data;
        }
        else
            return await data.json();
    }

    async Add(entity) {
        let data = await fetch(this.endpoint, {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(entity)
        });
        if (data.redirected) {
            throw data;
        }
        else
            return await data.json();
    }

    async Update(id, entity) {
        let data = await fetch(this.endpoint + '/' + id, {
            method: 'PUT',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(entity)
        });
        if (data.redirected) {
            throw data;
        }
        else
            return await data.json();
    }

    async Remove(id) {
        let data = await fetch(this.endpoint + '/' + id, { method: 'DELETE', mode: 'cors' });
        if (data.redirected) {
            throw data;
        }
        else
            return await data.json();
    }
}

export const PermissionSource = new EndPointAdapter(endpoints.permissions);
export const PermissionTypeSource = new EndPointAdapter(endpoints.permissiontypes);
