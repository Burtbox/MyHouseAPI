import { LogLevel } from "../../node_modules/@types/bunyan";

export interface IAppSettings {
    logLevel: LogLevel;
    firebaseDbUrl: string;
}