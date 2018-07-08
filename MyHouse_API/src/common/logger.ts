import * as bunyan from 'bunyan';

const logLevel = 'error';
const logFilePath = process.cwd() + '\\log.txt'
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

export default log;
