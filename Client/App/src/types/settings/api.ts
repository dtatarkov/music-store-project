export interface JSONAPISettings {
    url: string
}

export default class APISettings {
    url: string

    constructor(data: JSONAPISettings) {
        this.url = data.url;
    }
}