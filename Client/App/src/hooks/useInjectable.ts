import type { ContainerAccessor } from "@/configuration/inversify/inversify.interfaces";
import type { interfaces } from "inversify";
import { inject } from "vue";

export const useInjectable = <T>(serviceIdentifier: interfaces.ServiceIdentifier<T>) => {
    const container = <ContainerAccessor>inject('container');    

    return container.get(serviceIdentifier);
}