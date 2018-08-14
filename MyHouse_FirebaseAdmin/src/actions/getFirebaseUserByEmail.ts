import { handleOutput } from "../common/handleOutput";
import log from '../common/logger';
import FirebaseSdk from "../firebase/FirebaseSdk";

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
            process.exit(0);

            // For .netcore node services
            // callback(null, user)
        });
}
