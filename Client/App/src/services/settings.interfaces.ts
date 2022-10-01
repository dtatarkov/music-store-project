import type AppSettings from "@/types/settings/settings";

export default abstract class ISettingsService {
    abstract getSettingsAsync(): Promise<AppSettings>
}