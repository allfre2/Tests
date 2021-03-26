<template>
    <div>
        <SearchBar target="permissions" v-on:filter:permissions="triggerSearch" v-on:delete:permission="triggerDelete" />
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">#</th>
                    <th scope="col">Empleado</th>
                    <th scope="col">Tipo</th>
                    <th scope="col">Fecha</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <template v-for="permission in permissions">
                    <Permission v-bind:permission="permission" v-bind:mode="'list'" v-on:delete:permission="confirmation" />
                </template>
            </tbody>
        </table>
        <ConfirmationModal :name="modalId" @delete="" />
    </div>
</template>

<script>
    import SearchBar from '../ui/SearchBar.vue';
    import ConfirmationModal from '../ui/ConfirmationModal.vue';
    import Permission from './Permission';

    export default {
        name: 'PermissionList',
        components: { SearchBar, ConfirmationModal, Permission },
        props: ['permissions'],
        data() {
            return {
                modalId: 'deleteConfirmationModal'
            };
        },
        methods: {
            triggerSearch(query) {
                this.$emit('filter:permissions', query);
            },

            triggerDelete(id) {
                this.$emit('delete:permission', id);
            },

            // TODO: Implement Confirmation Modal Handling
            confirmation(id) {
                this.showConfirmationModal(id);
            },
            showConfirmationModal(id) {
                if (confirm('Seguro de eliminar el permiso #' + id + '?')) {
                    this.triggerDelete(id);
                }
            }
        }
    };
</script>

<style scoped>
</style>