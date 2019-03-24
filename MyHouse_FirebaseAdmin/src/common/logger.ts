import * as bunyan from 'bunyan';
import appSettings from "config/appSettings";

const logLevel = appSettings.logLevel;
const logFilePath = process.cwd() + '/firebaseAdminApp.log'
const loggerStreams: bunyan.Stream[] = [
    // {
    //     level: logLevel,
    //     stream: process.stdout  // log to stdout - only use this if debugging locally!
    // },
    {
        level: logLevel,
        path: logFilePath  // log a file
    }
];

const loggerOptions: bunyan.LoggerOptions = {
    name: "MyHouse_FirebaseAdmin",
    streams: loggerStreams,
    level: logLevel,
}

const log = bunyan.createLogger(loggerOptions);
log.info("Logging initialised");

export default log;
