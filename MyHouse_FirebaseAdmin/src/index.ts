
import * as program from "commander";
import { generateCustomToken } from "./actions/generateCustomToken";
import { handleOutput } from "./common/handleOutput";
// import { getFirebaseUserByEmail } from "./actions/getFirebaseUserByEmail";
import log from './common/logger';
import FirebaseSdk from "./firebaseSdk/FirebaseSdk";



export const getFirebaseUserByEmail = (email: string) => {
    log.info("Checking user email exists")
    const firebaseSdk: FirebaseSdk = new FirebaseSdk();
    const ret = firebaseSdk.getFirebaseUserByEmail(email)
        .then((user) => {
            log.info("user returned from firebase");
            handleOutput();
            log.info("User email exists check done");
            // Returns the token as the standard output
            process.stdout.write(JSON.stringify(user));
        });
}

log.info("Firebase admin console app initialised");

//console app
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

// if program was called with no arguments, show help.
if (program.args.length === 0) {
    log.info("program was called with no arguments")
    program.help();
}

