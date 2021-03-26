<template>
    <div id="app">
        <Navbar />
    </div>
</template>

<script>
    import Home from './components/main/Home.vue';
    import Navbar from './components/ui/Navbar.vue';

    export default {
        name: 'app',
        components: {
            Home,
            Navbar
        },
        beforeMount() {
        }
    };
</script>

<style>
</style>

