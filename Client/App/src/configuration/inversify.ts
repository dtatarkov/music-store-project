import 'reflect-metadata';
import SettingsService from "@/services/settings";
import ISettingsService from "@/services/settings.interfaces";
import { Container } from "inversify";

const appContainer = new Container();

appContainer.bind<ISettingsService>(ISettingsService).to(SettingsService);

export default appContainer;