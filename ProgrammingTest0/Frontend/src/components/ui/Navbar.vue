<template>
    <div>
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <router-link to="/home" class="navbar-brand">Info</router-link>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <router-link to="/edit" class="nav-link">
                            Editar
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <router-link to="/list" class="nav-link">Lista</router-link>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="container-fluid">
            <router-view></router-view>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Navbar'
    };
</script>

<style scoped>
</style>