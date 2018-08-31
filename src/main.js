import '@babel/polyfill'
import Vue from 'vue'
import './plugins/vuetify'
import App from './App.vue'
import VueRouter from 'vue-router'

// index.js or main.js
import 'vuetify/dist/vuetify.min.css' // Ensure you are using css-loader

Vue.config.productionTip = false

Vue.use(VueRouter)

import Home from './components/Home'
import Courses from './components/Courses'
import insideCourse from './components/insideCourse'
import lesson from './components/lesson'

// инициализируем роуты
const routes = [
// указываем, что компонент Home будет отображаться на нашей главной странице
{ path: '/', component: Home },
{ path: '/courses', component: Courses },
{ name: 'insideCourse', path: '/courses/:courseName',  component: insideCourse },
{ name: 'lesson', path: '/courses/:courseName/:lessonName',  component: lesson }
]
// Создаем экземпляр роутера и передайте опцию `routes`
const router = new VueRouter({
  routes,
  mode: 'history'
})

// Создаем экземпляр vue
new Vue({
	render: h => h(App),
// Определяем селектор для корневого компонента
  el: '#app',
  // передаем шаблон корневому компаненту
  template: '<App/>',
  // Объявляем компоненты, к которым может обращаться корневой компонент;
  components: { App },
  // Передаем в роутер экземпляр Vue
  router
}).$mount('#app')
/*
new Vue({
  render: h => h(App)
}).$mount('#app')
*/