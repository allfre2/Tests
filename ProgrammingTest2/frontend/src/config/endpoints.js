let scheme = 'http';
let server = 'localhost';
let port = 5000;
let apiPath = 'api';

let root = `${scheme}://${server}:${port}/${apiPath}`;

let endpoints = {
    bussiness: root + '/bussiness',
    client: root + '/client',
    address: root + '/address' 
};

export default endpoints;