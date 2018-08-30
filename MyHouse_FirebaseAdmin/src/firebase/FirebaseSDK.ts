import appSettings from "config/appSettings";
import * as admin from "firebase-admin";
import privateKey from "firebasePvk.json";
import log from "../common/logger";

class FirebaseSDK {
    constructor() {
        log.info(`Initialising firebase admin app with creds: ${privateKey} and dbUrl: ${appSettings.firebaseDbUrl}`)
        admin.initializeApp({
            credential: admin.credential.cert(privateKey),
            databaseURL: appSettings.firebaseDbUrl
        });
    }

    generateCustomToken(userId: string): Promise<string> {
        log.info(`Generating custom token for: ${userId}`)
        const customToken: Promise<string> = admin.auth().createCustomToken(userId);
        log.info(`Generated custom token for: ${userId} as: ${customToken}`)
        return customToken;
    }

    verifyUserToken(idToken: string): Promise<admin.auth.DecodedIdToken> {
        log.info(`Verifying custom token: ${idToken}`)
        const ver = admin.auth().verifyIdToken(idToken)
        log.info(`Verified custom token as: ${ver}`)
        return ver;
    }

    getFirebaseUserByEmail(email: string): Promise<admin.auth.UserRecord> {
        log.info(`Getting firebase user from email: ${email}`)
        const userDetails: Promise<admin.auth.UserRecord> = admin.auth().getUserByEmail(email)
        log.info(`Got firebase user details from email: ${email} as: ${userDetails}`)
        return userDetails;
    }
}

export default FirebaseSDK;
