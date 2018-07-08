"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var admin = require("firebase-admin");
var logger_1 = require("../common/logger");
var FirebaseSDK = /** @class */ (function () {
    function FirebaseSDK() {
        var serviceAccountDetailsPath = "../../privateKey/MyHouse-b9ec08fa574f.json";
        var serviceAccount = require(serviceAccountDetailsPath);
        if (serviceAccount) {
            admin.initializeApp({
                credential: admin.credential.cert(serviceAccount),
                databaseURL: "https://myhouse-a01c7.firebaseio.com"
            });
        }
        else {
            logger_1.default.error("service accound details not found at: " + serviceAccountDetailsPath);
        }
    }
    FirebaseSDK.prototype.generateCustomToken = function (userId) {
        var customToken = admin.auth().createCustomToken(userId);
        return customToken;
    };
    FirebaseSDK.prototype.verifyUserToken = function (idToken) {
        var ver = admin.auth().verifyIdToken(idToken);
        return ver;
    };
    FirebaseSDK.prototype.getFirebaseUserByEmail = function (email) {
        var userDetails = admin.auth().getUserByEmail(email);
        return userDetails;
    };
    return FirebaseSDK;
}());
exports.default = FirebaseSDK;
//# sourceMappingURL=FirebaseSdk.js.map