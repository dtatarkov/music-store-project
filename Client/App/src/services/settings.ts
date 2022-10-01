import type { JSONAppSettings } from "@/types/settings/settings";
import AppSettings from "@/types/settings/settings";
import { injectable } from "inversify";
import type ISettingsService from "./settings.interfaces";

@injectable()
export default class SettingsService implements ISettingsService {
    async getSettingsAsync(): Promise<AppSettings> {
        const response = await fetch('clientsettings');
        const data: JSONAppSettings = await response.json();

        return new AppSettings(data);
    }
}