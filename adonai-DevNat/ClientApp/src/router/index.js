import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import DashBoard from '../views/DashBoard.vue'
import Code from '../views/Code.vue'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    redirect: { name: 'dashboard', params: { name: 'dashboard' } },
    children: [
      {
        path: '/dashboard',
        component: DashBoard,
        name: 'dashboard'
      },
      {
        path: '/code',
        component: Code,
        name: 'Code'
      }
    ]
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

export default router
