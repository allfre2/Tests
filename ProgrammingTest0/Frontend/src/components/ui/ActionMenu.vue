<template>
    <div class="dropdown">
        <button class="btn btn-sm" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-three-dots-vertical" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                <path fill-rule="evenodd" d="M9.5 13a1.5 1.5 0 1 1-3 0 1.5 1.5 0 0 1 3 0zm0-5a1.5 1.5 0 1 1-3 0 1.5 1.5 0 0 1 3 0zm0-5a1.5 1.5 0 1 1-3 0 1.5 1.5 0 0 1 3 0z" />
            </svg>
        </button>
        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <a v-for="action in config.actions" class="dropdown-item" @click="action.run(args)">
                {{action.name}}
            </a>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'ActionMenu',
        props: ['config', 'args']
    };
</script>

<style scoped>
</style>