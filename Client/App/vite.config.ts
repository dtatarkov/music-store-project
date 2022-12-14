import { fileURLToPath, URL } from 'node:url'

import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import vueJsx from '@vitejs/plugin-vue-jsx'

// https://vitejs.dev/config/
export default defineConfig({
    base: '/dist/',
    mode: 'development',

    plugins: [vue(), vueJsx()],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url)),
            '@fonts': fileURLToPath(new URL('./fonts', import.meta.url)),
            '@images': fileURLToPath(new URL('./images', import.meta.url)),
        }
    },

    build: {
        outDir: '../wwwroot/dist',
        emptyOutDir: true,
        sourcemap: true
    }    
})
