import 'reflect-metadata';
import SettingsService from "@/services/settings";
import ISettingsService from "@/services/settings.interfaces";
import { Container } from "inversify";

const container = new Container();

container.bind<ISettingsService>(ISettingsService).to(SettingsService);

export default container;