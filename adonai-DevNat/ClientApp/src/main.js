import 'bootstrap/dist/css/bootstrap.css'
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import PrimeVue from 'primevue/config'
import Card from 'primevue/card'

import './assets/css/app.scss'
import 'primevue/resources/themes/vela-green/theme.css'
import 'primeflex/primeflex.css'
import 'primeicons/primeicons.css'
import 'primevue/resources/primevue.min.css'

const app = createApp(App)
app.use(PrimeVue)
app.component('Card', Card)
app.use(PrimeVue, { ripple: true })

createApp(App).use(router).mount('#app')
