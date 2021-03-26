import Vue from 'vue';
import VueRouter from 'vue-router';
import App from './App.vue';

import Home from './components/main/Home.vue';
import Edit from './components/main/Edit.vue';
import List from './components/main/List.vue';

import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import '../node_modules/font-awesome/css/font-awesome.min.css'
import '../node_modules/bootstrap/dist/js/bootstrap.min.js';
import '../node_modules/jquery/dist/jquery.min.js';
import '../node_modules/popper.js/dist/popper.min.js';

Vue.use(VueRouter);
Vue.config.productionTip = true;

const routes = [
    { path: '/', redirect: '/home'},
    { path: '/home', component: Home },
    { path: '/edit', component: Edit },
    { path: '/edit/:id', component: Edit },
    { path: '/list', component: List }
];

const router = new VueRouter({
    routes
});

new Vue({
    render: h => h(App),
    router
}).$mount('#app');

(function () {
    let tooltips = document.querySelector('[data-toggle="tooltip"]');
    tooltips && tooltips.tooltip();
})();
