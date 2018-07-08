"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var program = require("commander");
var generateCustomToken_1 = require("./actions/generateCustomToken");
var getFirebaseUserByEmail_1 = require("./actions/getFirebaseUserByEmail");
var logger_1 = require("./common/logger");
logger_1.default.info("Firebase admin console app initialised");
//console app
program
    .version('1.0.0')
    .description('MyHouse_FirebaseAdmin');
program
    .command('generateCustomToken [callback] [userId]')
    .alias('g')
    .description('Generate a custom firebase jwt')
    .action(generateCustomToken_1.generateCustomToken);
program
    .command('getFirebaseUserByEmail [callback] [email]')
    .alias('e')
    .description('Gets the firebase auth users details by their email address')
    .action(getFirebaseUserByEmail_1.getFirebaseUserByEmail);
program.parse(process.argv);
// if program was called with no arguments, show help.
if (program.args.length === 0) {
    logger_1.default.info("program was called with no arguments");
    program.help();
}
//# sourceMappingURL=index.js.map