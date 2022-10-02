export function isDisposable(instance: any): instance is Disposablable {
    return instance != undefined && 'dispose' in instance && typeof instance.dispose === 'function';
}

export interface Disposablable {
    dispose(): void
}