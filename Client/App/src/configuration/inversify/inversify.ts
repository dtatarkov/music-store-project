import 'reflect-metadata';
import SettingsService from "@/services/settings";
import ISettingsService from "@/services/settings.interfaces";
import type { Action } from '@/types/action';
import { isDisposable } from '@/types/disposable';
import { Container, type interfaces } from "inversify";
import { onScopeDispose } from 'vue';
import type { ContainerAccessor } from './inversify.interfaces';

type ModuleActivator<T = any> = Action<[interfaces.Context, T]>

const container = new Container();
const activatorsMap = new Map<interfaces.ServiceIdentifier<any>, Array<ModuleActivator>>();
const disposableScopes = new Array<interfaces.BindingScope>('Transient', 'Request');

container.bind<ISettingsService>(ISettingsService).to(SettingsService);

const registerActivator = <T>(serviceIdentifier: interfaces.ServiceIdentifier<T>) => {
    let activators = activatorsMap.get(serviceIdentifier);

    if (activators == undefined) {
        container.onActivation(serviceIdentifier, (context, module) => {
            normalizedActivators.forEach(activator => activator(context, module));
            activatorsMap.set(serviceIdentifier, []);

            return module;
        });

        activators = new Array<ModuleActivator>();
        activatorsMap.set(serviceIdentifier, activators);
    }

    const activator: ModuleActivator = (context, module) => {
        if (isDisposable(module)) {
            const scope = context.currentRequest.bindings[0].scope;
            console.log(scope, context, module);

            if (disposableScopes.includes(scope))
                onScopeDispose(() => module.dispose());
        }
    }

    const normalizedActivators = activators;
    normalizedActivators.push(activator); 
}

const containerAccessor: ContainerAccessor = {
    get: <T>(serviceIdentifier: interfaces.ServiceIdentifier<T>) => {
        registerActivator(serviceIdentifier);
        return container.get(serviceIdentifier);
    }
}

export default containerAccessor;