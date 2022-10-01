import { createApp } from 'vue';
import App from './App.vue';
import router from './router';
import './assets/main.scss';
import { createPinia } from 'pinia';
import appContainer from './configuration/inversify';

const pinia = createPinia();
const app = createApp(App)

app.use(router);
app.use(pinia);
app.provide('container', appContainer);

app.mount('#app')