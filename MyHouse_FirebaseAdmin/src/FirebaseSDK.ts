import * as admin from "firebase-admin";
import { ServiceAccount } from "firebase-admin";

class FirebaseSDK {
    constructor() {
        const serviceAccount: ServiceAccount = require("../privateKey/myhouse-a01c7-firebase-adminsdk-sinok-bbb40a4f11.json");
        admin.initializeApp({
            credential: admin.credential.cert(serviceAccount),
            databaseURL: "https://myhouse-a01c7.firebaseio.com"
        });
    }

    generateToken(userId: string): Promise<string> {
        const customToken: Promise<string> = admin.auth().createCustomToken(userId);

        return customToken;
    }

    verifyUserToken(idToken: string): Promise<admin.auth.DecodedIdToken> {
        const ver = admin.auth().verifyIdToken(idToken)
        return ver;
    }
}

export default FirebaseSDK;
