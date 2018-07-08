"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var bunyan = require("bunyan");
var logLevel = 'error';
var logFilePath = process.cwd() + '\\log.txt';
var loggerStreams = [
    // {
    //     level: logLevel,
    //     stream: process.stdout  // log to stdout - only use this if debugging locally!
    // },
    {
        level: logLevel,
        path: logFilePath // log a file
    }
];
var loggerOptions = {
    name: "MyHouse_FirebaseAdmin",
    streams: loggerStreams,
    level: logLevel,
};
var log = bunyan.createLogger(loggerOptions);
exports.default = log;
//# sourceMappingURL=logger.js.map