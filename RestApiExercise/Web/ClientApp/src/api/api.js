'use strict';

const root = '/api';

const EndPoints = {
    Books: root + '/Books',
};

class EndPointAdapter {
    constructor(endpoint) {
        this.endpoint = endpoint;
        this.path = '';
    }

    Cd(dir) {
        this.path = dir;
        return this;
}

    QueryString(params) {
        if (params)
            return '?' + Object.keys(params)
                .map(key => encodeURIComponent(key) + '=' + encodeURIComponent(params[key]))
                .join('&');
        else return '';
    }

    async Get(id) {
        let data = await fetch(this.endpoint + this.path + (id ? "/"+id : ""), { method: 'GET' });
        if (data.redirected) {
            throw data;
        }
        else
            return await data.json();
    }
    
    async Add(entity) {
        let data = await fetch(this.endpoint + this.path, {
            method: 'POST',
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

    async Update(entity) {
        let data = await fetch(this.endpoint + this.path + "/" + entity.id, {
            method: 'PUT',
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
        let data = await fetch(this.endpoint + this.path + '/' + id, { method: 'DELETE' });
        if (data.redirected) {
            throw data;
        }
        else
            return await data.json();
    }
}

export const Books = new EndPointAdapter(EndPoints.Books);