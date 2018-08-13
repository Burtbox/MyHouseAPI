import * as admin from "firebase-admin";
import log from '../common/logger';

class FirebaseSDK {
          constructor() {
            admin.initializeApp({
            credential: admin.credential.cert("../privateKey/myhouse-live.json"),
        	databaseURL: "https://myhouse-live.firebaseio.com"
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

    getFirebaseUserByEmail(email: string): Promise<admin.auth.UserRecord> {
        const userDetails: Promise<admin.auth.UserRecord> = admin.auth().getUserByEmail(email)
        return userDetails;
    }
}

export default FirebaseSDK;
