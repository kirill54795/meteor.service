import { createApp } from 'vue'
import { createPinia } from 'pinia'

import { App, routerModel } from '!'
import axios from 'axios'
import VueAxios from 'vue-axios'
import Antd from "ant-design-vue";

const app = createApp(App)


app.use(createPinia())
app.use(Antd)
app.use(routerModel.router)
app.use(VueAxios, axios)
app.provide('axios', app.config.globalProperties.axios)


app.mount('#app')
