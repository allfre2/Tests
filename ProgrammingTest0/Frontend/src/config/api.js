const root = {
    dev: 'https://localhost:5001',
    sqa: '',
    prod: ''
};

export const endpoints = {
    permissions: root.dev + '/api/permissions',
    permissiontypes: root.dev + '/api/permissiontypes'
};