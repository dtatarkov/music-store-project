<script setup lang="ts">
    import { RouterLink, RouterView } from 'vue-router';    
</script>

<template>
    <header class="app__header">
        <div class="app__header__inner">
            <div class="app__header__logo">
                <i class="fa-regular fa-music"></i>
            </div>

            <nav class="app__header__navigation">
                <RouterLink class="app__header__navigation__link" :to="{ name:'home' }">Home</RouterLink>
                <RouterLink class="app__header__navigation__link" :to="{ name:'about' }">About</RouterLink>
            </nav>
        </div>
    </header>

    <RouterView />
</template>

<style lang="scss" scoped>
    .app__header {
        display: flex;
        justify-content: center;
        background-color: var(--color-background-accent);
        font-size: 1.2em;
        color: var(--color-text-accent);        
    }

    .app__header__inner {
        flex-grow: 1;
        display: flex;
        padding: var(--section-padding);
        max-width: var(--viewport-size);
        gap: var(--row-gap-big);
    }

    .app__header__navigation {
        display: flex;
        gap: var(--row-gap);
    }

    .app__header__navigation__link {
        color: var(--color-text-accent);
        text-decoration: none;
        text-shadow: 0 1px var(--color-text-shadow);
        font-weight: 500;

        &.router-link-active {
            color: var(--color-text-accent-active);
        }
    }
</style>
