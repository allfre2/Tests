<template>
    <tr :key="permission.id">
        <th scope="row" data-toggle="tooltip" data-placement="top" title="Editar">
            <b></b>{{permission.id}}</b>
        </th>
        <td>{{permission.employeeName}} {{permission.employeeLastName}}</td>
        <td>{{permission.permissionType.description}}</td>
        <td>{{new Date(permission.permissionDate).toLocaleDateString()}}</td>
        <td>
            <ActionMenu :config="actionsConfig" :args="permission" />
        </td>
    </tr>
</template>

<script>
    import ActionMenu from '../ui/ActionMenu.vue';

    export default {
        name: 'Permission',
        components: { ActionMenu },
        props: ['permission', 'mode'],
        data() {
            let self = this;
            return {
                actionsConfig: {
                    actions: [
                        {
                            name: 'editar',
                            run: function (permission) {
                                window.location = '#/edit/' + permission.id; // sorry about this...
                            }
                        },
                        {
                            name: 'eliminar',
                            run: function (permission) {
                                self.$emit('delete:permission', permission.id);
                            }
                        }
                    ]
                }
            };
        },
        methods: {}
    };
</script>

<style scoped>
</style>