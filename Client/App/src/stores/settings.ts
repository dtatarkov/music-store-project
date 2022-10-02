import { useInjectable } from '@/hooks/useInjectable';
import ISettingsService from '@/services/settings.interfaces';
import type AppSettings from '@/types/settings/settings';
import { defineStore } from 'pinia';
import { computed, ref } from 'vue';

export const useSettingsStore = defineStore('settings', () => {
    const settings = ref<AppSettings | undefined>(undefined);
    const hasSettings = computed(() => settings.value != undefined);
    const isUpdatingSettings = ref(false);

    const settingsService = useInjectable(ISettingsService);

    async function fetchSettings() {
        if (!isUpdatingSettings.value) {
            try {
                isUpdatingSettings.value = true;

                settings.value = await settingsService.getSettingsAsync();
            } catch (ex) {
                console.error(ex);
            } finally {
                isUpdatingSettings.value = false;
            }
        }
    }    

    fetchSettings();

    return { settings, hasSettings, fetchSettings, isUpdatingSettings }
})