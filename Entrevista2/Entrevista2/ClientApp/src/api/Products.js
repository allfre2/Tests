
const endpoint = "/api/Product";

export const ProductsEndpoint = {
    async GetAll() {
        return await (await fetch(endpoint, { method: 'GET' })).json();
    },

    async Get(id) {
        return await (await fetch(`${endpoint}/${id}`, { method: 'GET' })).json();
    },

    async Remove(id) {
        return await (await fetch(`${endpoint}/${id}`, { method: 'DELETE' })).json();
    }
};