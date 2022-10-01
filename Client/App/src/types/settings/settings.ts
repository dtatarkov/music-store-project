import APISettings from "./api";
import type { JSONAPISettings } from "./api";

export interface JSONAppSettings {
    api: JSONAPISettings
}

export default class AppSettings {
    api: APISettings

    constructor(data: JSONAppSettings) {
        this.api = new APISettings(data.api);
    }
}