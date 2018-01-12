import * as admin from "firebase-admin";
import { ServiceAccount } from "firebase-admin";
import * as privateKey from "../privateKey/MyHouse-b9ec08fa574f.json";

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
}

export default FirebaseSDK;
