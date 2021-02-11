import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import PrimeVue from 'primevue/config'
import './assets/css/app.scss'
import 'primevue/resources/themes/vela-green/theme.css'
import 'primeflex/primeflex.css'
import 'primeicons/primeicons.css'
const app = createApp(App)

app.use(PrimeVue)

createApp(App).use(router).mount('#app')
