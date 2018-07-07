
import chalk from "chalk";
import * as program from "commander";
import FirebaseSdk from "./firebaseSdk";
import log from './logger';

log.info("Firebase admin console app initialised");

const generateCustomToken = (userId: string) => {
    log.info("Generating custom token");
    const firebaseSdk: FirebaseSdk = new FirebaseSdk();
    const ret: Promise<void> = firebaseSdk.generateCustomToken(userId)
        .then((customToken: string) => {
            log.info("Token returned from firebase");
            handleOutput();
            log.info("Token done");
            // Returns the token as the standard output
            process.stdout.write(customToken);
        });
}

const checkEmailExists = (email: string) => {
    log.info("Checking user email exists")
    const firebaseSdk: FirebaseSdk = new FirebaseSdk();
    const ret = firebaseSdk.checkEmailExists(email)
        .then((user) => {
            log.info("user returned from firebase");
            handleOutput();
            log.info("User email exists check done");
            // Returns the token as the standard output
            process.stdout.write(JSON.stringify(user));
        });
}

const handleOutput = () => {
    let output: any = (error: Error, stdout: string, stderr: Error) => {
        if (error) {
            log.error(chalk.red.bold.underline("exec error:") + error);
        }
        if (stderr) {
            log.error(chalk.red("Error: ") + stderr);
        }
    };
}

//console app
program
    .version("1.0")
    .command('generateCustomToken [userId]')
    .action(generateCustomToken)
    .command('checkEmailExists [email]')
    .action(checkEmailExists);

program.parse(process.argv);

// if program was called with no arguments, show help.
if (program.args.length === 0) {
    log.info("program was called with no arguments")
    program.help();
}
