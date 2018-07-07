import * as admin from "firebase-admin";

class FirebaseSDK {
    constructor() {
        const serviceAccount: any = require("../privateKey/MyHouse-b9ec08fa574f.json");
        admin.initializeApp({
            credential: admin.credential.cert(serviceAccount),
            databaseURL: "https://myhouse-a01c7.firebaseio.com"
        });
    }

    generateCustomToken(userId: string): Promise<string> {
        const customToken: Promise<string> = admin.auth().createCustomToken(userId);

        return customToken;
    }

    verifyUserToken(idToken: string): Promise<admin.auth.DecodedIdToken> {
        const ver = admin.auth().verifyIdToken(idToken)
        return ver;
    }

    checkEmailExists(email: string): Promise<admin.auth.UserRecord> {
        const emailExists: Promise<admin.auth.UserRecord> = admin.auth().getUserByEmail(email)
        return emailExists;
    }
}

export default FirebaseSDK;
