import type { JSONAppSettings } from '@/types/settings/settings';
import AppSettings from '@/types/settings/settings';
import { defineStore } from 'pinia';
import { computed, ref, watch } from 'vue';

export const useSettingsStore = defineStore('settings', () => {
    const settings = ref<AppSettings | undefined>(undefined);
    const hasSettings = computed(() => settings.value != undefined);
    const isUpdatingSettings = ref(false);

    async function fetchSettings() {
        if (!isUpdatingSettings.value) {
            try {
                isUpdatingSettings.value = true;

                const response = await fetch('clientsettings');
                const data: JSONAppSettings = await response.json();

                settings.value = new AppSettings(data);
            } catch (ex) {
                console.error(ex);
            } finally {
                isUpdatingSettings.value = false;
            }
        }
    }

    watch(hasSettings, (hasSettings, prevHasSettings) => console.log({ hasSettings, prevHasSettings }))

    fetchSettings();

    return { settings, hasSettings, fetchSettings, isUpdatingSettings }
})