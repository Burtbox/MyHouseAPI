"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var handleOutput_1 = require("../common/handleOutput");
var logger_1 = require("../common/logger");
var FirebaseSdk_1 = require("../firebaseSdk/FirebaseSdk");
exports.getFirebaseUserByEmail = function (callback, email) {
    logger_1.default.info("Checking user email exists");
    if (email) {
        var firebaseSdk = new FirebaseSdk_1.default();
        var ret = firebaseSdk.getFirebaseUserByEmail(email)
            .then(function (user) {
            logger_1.default.info("user returned from firebase");
            handleOutput_1.handleOutput();
            logger_1.default.info("User email exists check done");
            // Returns the token as the standard output
            process.stdout.write(JSON.stringify(user));
            // For .netcore node services
            if (callback) {
                callback(null, user);
            }
        });
    }
    else {
        logger_1.default.error("Must supply an email");
    }
};
//# sourceMappingURL=getFirebaseUserByEmail.js.map