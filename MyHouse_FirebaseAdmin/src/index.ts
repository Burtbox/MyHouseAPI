
import * as program from "commander";
import { generateCustomToken, getFirebaseUserByEmail } from './actions';
import log from './common/logger';

log.info("Firebase admin console app initialised");

program
    .version('1.0.0')
    .description('MyHouse_FirebaseAdmin')

program
    .command('generateCustomToken [userId]')
    .alias('g')
    .description('Generate a custom firebase jwt')
    .action(generateCustomToken)

program
    .command('getFirebaseUserByEmail [email]')
    .alias('e')
    .description('Gets the firebase auth users details by their email address')
    .action(getFirebaseUserByEmail);

program.parse(process.argv);

if (program.args.length === 0) {
    log.info("program was called with no arguments")
    program.help();
}

