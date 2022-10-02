import type { interfaces } from "inversify";

export interface ContainerAccessor {
    get: <T>(serviceIdentifier: interfaces.ServiceIdentifier<T>) => T
}