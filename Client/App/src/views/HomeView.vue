<script setup lang="ts">
    import AlbumsGrid from '../components/AlbumsGrid.vue';
</script>

<template>
    <main class="home-view">
        <AlbumsGrid />
    </main>
</template>

<style lang="scss" scoped>
    .home-view {
        padding: var(--section-padding);
    }
</style>
