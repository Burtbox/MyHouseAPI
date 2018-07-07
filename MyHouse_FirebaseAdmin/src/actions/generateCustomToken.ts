import { handleOutput } from "../common/handleOutput";
import log from '../common/logger';
import FirebaseSdk from "../firebaseSdk/FirebaseSdk";

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
        });
}