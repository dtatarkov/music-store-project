<script setup lang="ts">
    import { useSettingsStore } from '@/stores/settings';
    import AlbumBox from '../components/AlbumBox.vue';
    import { useAlbumsStore } from '../stores/albums';

    const { albums } = useAlbumsStore();
</script>

<template>
    <div class="albums-grid">
        <AlbumBox v-for="album in albums" :title="album.title" :description="album.description" />
    </div>
</template>

<style lang="scss" scoped>
    .albums-grid {
        display: grid;
        grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
        gap: 10px;
    }
</style>
