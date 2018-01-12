
import * as program from "commander";
import chalk from "chalk";
import * as childprocess from "child_process";
import * as pkg from "../package.json";
import FirebaseSdk from "./firebaseSdk";
//console.log("Firebase admin console app initialised");

let generateCustomToken = (userId: string) => {
    //console.log("Generating custom token");
    const firebaseSdk: FirebaseSdk = new FirebaseSdk();
    const ret: Promise<void> = firebaseSdk.generateCustomToken(userId)
        .then((customToken: string) => {
            //console.log("Token returned from firebase");
            let output: any = (error: Error, stdout: string, stderr: Error) => {
                if (error) {
                    console.log(chalk.red.bold.underline("exec error:") + error);
                }
                if (stdout) {
                    console.log(chalk.green.bold.underline("Result: \n") + customToken);
                }
                if (stderr) {
                    console.log(chalk.red("Error: ") + stderr);
                }
            };
            //console.log("Token done");
            // Returns this as the standard output
            process.stdout.write(customToken);
        });
}

//console app
program
    .version("1.0")
    .command('generateCustomToken [userId]')
    .action(generateCustomToken);

program.parse(process.argv);

// if program was called with no arguments, show help.
if (program.args.length === 0) program.help();
