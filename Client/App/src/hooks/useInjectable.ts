import type { interfaces } from "inversify";
import { inject } from "vue";

export const useInjectable = <T>(serviceIdentifier: interfaces.ServiceIdentifier<T>) => {
    const container = <interfaces.Container>inject('container');

    return container.get<T>(serviceIdentifier);
}