import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueJsx from '@vitejs/plugin-vue-jsx'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [
    vue(),
    vueJsx(),
  ],
  resolve: {
    alias: {
      //TODO: тут просто статические роуты. Чтобы в коде не было относительных путей. Типа - ../../*.
      '~': fileURLToPath(new URL('./src', import.meta.url)),
      '!': fileURLToPath(new URL('./src/app', import.meta.url)),
      "#": fileURLToPath(new URL('./src/pages', import.meta.url)),
      '@': fileURLToPath(new URL('./src/widgets', import.meta.url)),
      '$': fileURLToPath(new URL('./src/entities', import.meta.url)),
    }
  },
  server: {
    proxy: {
      //TODO: заменить /users на /api, а https://jsonplaceholder.typicode.com на свой бэк. В коде, где будет дергаться - api роут,
      //по-факту будет прокси к твоему бэку. Пример: axios.get(/api/meteors) => вызов https://your.back/api/meteors.
      '/users': 'https://jsonplaceholder.typicode.com'
    }
  }
})
