import { handleOutput } from "../common/handleOutput";
import log from '../common/logger';
import FirebaseSdk from "../firebase/FirebaseSdk";

export const generateCustomToken = (userId: string) => {
    log.info("Generating custom token");

    const firebaseSdk: FirebaseSdk = new FirebaseSdk();
    const ret: Promise<void> = firebaseSdk.generateCustomToken(userId)
        .then((customToken: string) => {
            log.info("Token returned from firebase");
            handleOutput();
            log.info("Token done");

            // Returns the token as the standard output
            process.stdout.write(customToken);
            process.exit(0);

            // For .netcore node services
            // callback(null, customToken);
        }).catch((error: Error) => {
            log.error(error);
            process.stdout.write(error.message);
            process.exit(1);
        });
}