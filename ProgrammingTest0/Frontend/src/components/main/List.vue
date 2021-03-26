<template>
    <div>
        <PermissionList v-bind:permissions="permissions" v-on:filter:permissions="filter" v-on:delete:permission="remove"/>
    </div>
</template>

<script>
    import PermissionList from '../Permission/PermissionList.vue';
    import { PermissionSource } from '../../endpoints/adapter';

    export default {
        name: 'List',
        components: {
            PermissionList
        },
        data() {
            return {
                permissions: []
            };
        },
        beforeMount() {
            this.getPermissions();
        },
        methods: {
            async getPermissions() {
                this.permissions = await PermissionSource.Get();
            },
            async filter(query) {
                query = query.toLowerCase();
                await this.getPermissions();
                this.permissions = this.permissions
                    .filter(permission => 
                        permission.employeeName.toLowerCase().includes(query) ||
                        permission.employeeLastName.toLowerCase().includes(query) ||
                        (permission.permissionType && permission.permissionType.description.toLowerCase().includes(query)) ||
                        (permission.permissionDate.toLowerCase().includes(query))
                    );
            },
            async remove(id) {
                await PermissionSource.Remove(id);
                this.permissions = this.permissions.filter(permission => permission.id !== id);
            }
        }
    };
</script>

<style scoped>
</style>