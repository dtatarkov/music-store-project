<script setup lang="ts">
    import { computed } from 'vue';
    import { RouterLink, RouterView } from 'vue-router';
    import { useSettingsStore } from './stores/settings';

    const settingsStore = useSettingsStore();

    const isReady = computed(() => settingsStore.hasSettings);
</script>

<template>
    <template v-if="isReady">
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

    <div class="app__init-view" v-else="isReady">
        <div class="app__spinner">
            <i class="fa-duotone fa-spinner-third fa-spin"></i>
        </div>
    </div>
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

    .app__init-view {
        flex-grow: 1;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }

    .app__spinner {
        display: flex;
        justify-content: center;
        align-items: center;
        font-size: var(--spinner-font-size);
    }
</style>
