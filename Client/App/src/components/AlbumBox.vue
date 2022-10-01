<script setup lang="ts">
    import defaultImageURL from '@images/album.jpg';
    import type { AlbumBoxProps } from './AlbumBox.interfaces';

    interface AlbumBoxPropsInternal {
        title: AlbumBoxProps["title"]
        description: AlbumBoxProps["description"]
        imageURL: AlbumBoxProps["imageURL"]
    }

    const props = withDefaults(defineProps<AlbumBoxPropsInternal>(), {
        imageURL: defaultImageURL
    });
</script>

<template>
    <div class="album-box">
        <div class="album-box__image">
            <img class="album-box__image__content" :src="props.imageURL" />
        </div>
        <div class="album-box__footer">
            <div class="album-box__title">{{ props.title }}</div>
            <div class="album-box__description">{{ props.description }}</div>
        </div>
    </div>
</template>

<style lang="scss" scoped>
    .album-box {
        display: flex;
        flex-direction: column;
        border-radius: var(--border-radius);
    }

    .album-box__image {
        display: flex;
        flex-direction: column;
    }

    .album-box__image__content {
        max-width: 100%;
        border-top-left-radius: var(--border-radius);
        border-top-right-radius: var(--border-radius);
    }

    .album-box__footer {
        flex-grow: 1;
        display: flex;
        flex-direction: column;
        background-color: var(--color-background-accent-soft);
        padding: var(--fields-gap);
        border-bottom-left-radius: var(--border-radius);
        border-bottom-right-radius: var(--border-radius);
        color: var(--color-text-accent);
        gap: var(--fields-gap);
    }
</style>