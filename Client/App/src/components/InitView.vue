<template>
    <div class="init-view">
        <div class="init-view__spinner">
            <i class="fa-duotone fa-spinner-third fa-spin"></i>
        </div>
    </div>
</template>

<style lang="scss" scoped>
    .init-view {
        --fa-primary-color: var(--color-background-accent);
        --fa-secondary-color: var(--color-background-accent-soft);
    }

    .init-view {
        flex-grow: 1;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }

    .init-view__spinner {
        display: flex;
        justify-content: center;
        align-items: center;
        font-size: var(--spinner-font-size);
    }
</style>
