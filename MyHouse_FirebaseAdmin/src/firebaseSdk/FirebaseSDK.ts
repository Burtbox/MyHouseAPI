import * as admin from "firebase-admin";
import log from '../common/logger';

class FirebaseSDK {
    constructor() {
        const serviceAccountDetailsPath = "../../privateKey/MyHouse-b9ec08fa574f.json";
        const serviceAccount: any = require(serviceAccountDetailsPath);
        if (serviceAccount) {
            admin.initializeApp({
                credential: admin.credential.cert(serviceAccount),
                databaseURL: "https://myhouse-a01c7.firebaseio.com"
            });
        } else {
            log.error(`service accound details not found at: ${serviceAccountDetailsPath}`);
        }
    }

    generateCustomToken(userId: string): Promise<string> {
        const customToken: Promise<string> = admin.auth().createCustomToken(userId);
        return customToken;
    }

    verifyUserToken(idToken: string): Promise<admin.auth.DecodedIdToken> {
        const ver = admin.auth().verifyIdToken(idToken)
        return ver;
    }

    getFirebaseUserByEmail(email: string): Promise<admin.auth.UserRecord> {
        const userDetails: Promise<admin.auth.UserRecord> = admin.auth().getUserByEmail(email)
        return userDetails;
    }
}

export default FirebaseSDK;
