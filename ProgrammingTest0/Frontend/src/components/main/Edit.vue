<template>
    <div class="container">
        <h1>
            <b v-if="$route.params.id">Editar permiso #{{$route.params.id}}</b>
            <b v-else>Crear nuevo permiso</b>
        </h1>
        <form>
            <p v-if="validationErrors.length">
                <ul>
                    <li class="text-danger" v-for="error in validationErrors" :key="error">{{ error }}</li>
                </ul>
            </p>
            <div class="form-group">
                <label for="employeeName">Nombre del empleado</label>
                <input v-model="permission.employeeName" type="text" class="form-control" id="employeeName" placeholder="John">
                <label for="employeeLasName">Apellidos</label>
                <input v-model="permission.employeeLastName" type="text" class="form-control" id="employeeLastName" placeholder="Doe">

            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-md">
                        <label for="">Tipo de permiso</label>
                        <select class="custom-select" v-model="permission.permissionTypeId">
                            <option v-for="permissionType in permissionTypes" v-bind:value="permissionType.id" :key="permissionType.id">{{permissionType.description}}</option>
                        </select>
                    </div>
                    <div v-if="$route.params.id" class="col-md">
                        <label for="permissionDate">Fecha</label>
                        <input :value="permission.permissionDate && new Date(permission.permissionDate).toISOString().slice(0, 10)"
                               @input="permission.permissionDate = $event.target.valueAsDate" type="date" class="form-control" id="permissionDate">
                    </div>
                </div>
            </div>
            <br />
            <button v-if="$route.params.id" @click="submitChanges" class="btn btn-primary">Guardar</button>
            <button v-else @click="submitNew" class="btn btn-secondary">Agregar</button>
            <div class="toast" id="alert">
                <div class="toast-header">
                    Header
                </div>
                <div class="toast-body">
                    Body
                </div>
            </div>
        </form>
    </div>
</template>

<script>
    import { PermissionSource, PermissionTypeSource } from '../../endpoints/adapter';

    export default {
        name: 'Edit',
        components: {},
        data() {
            return {
                permission: {},
                permissionTypes: [],
                validationErrors: []
            };
        },
        beforeMount() {
            this.fetchPermissionData();
        },
        methods: {
            async fetchPermissionData() {
                if (this.$route.params.id) {
                    this.permission = await PermissionSource.Get(this.$route.params.id);
                }
                this.permissionTypes = await PermissionTypeSource.Get();
            },
            async submitChanges() {
                this.validationErrors = this.validate();
                if (this.validationErrors.length < 1) {
                    try {
                        await PermissionSource.Update(this.permission.id, this.permission);
                        this.toast('Se han guardado los cambios correctamente.');
                    } catch (e) {
                        this.toast('No ha sido posible guardar los cambios.');
                    }
                }
            },
            async submitNew() {
                this.validationErrors = this.validate();
                if (this.validationErrors.length < 1) {
                    try {
                        await PermissionSource.Add(this.permission);
                        this.clear();
                        this.toast('El permiso se ha agregado correctamente.');
                    } catch (e) {
                        this.toast('Ha ocurrido un problema al crear el permiso');
                    }
                }
            },
            validate() {
                let errors = [];
                if (!this.permission.employeeName) errors.push('El nombre es requerido');
                if (!this.permission.employeeLastName) errors.push('El apellido es requerido');
                if (!this.permission.permissionTypeId) errors.push('El tipo de permiso es requerido');
                return errors;
            },
            clear() {
                this.permission = {};
            },
            toast(msg) {
                alert(msg);
            }
        }
    };
</script>

<style scoped>
</style>