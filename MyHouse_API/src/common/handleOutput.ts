import chalk from "chalk";
import log from './logger';

export const handleOutput = () => {
    let output: any = (error: Error, stdout: string, stderr: Error) => {
        if (error) {
            log.error(chalk.red.bold.underline("exec error:") + error);
        }
        if (stderr) {
            log.error(chalk.red("Error: ") + stderr);
        }
    };
}