"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var handleOutput_1 = require("../common/handleOutput");
var logger_1 = require("../common/logger");
var FirebaseSdk_1 = require("../firebaseSdk/FirebaseSdk");
exports.generateCustomToken = function (callback, userId) {
    logger_1.default.info("Generating custom token");
    if (userId) {
        var firebaseSdk = new FirebaseSdk_1.default();
        var ret = firebaseSdk.generateCustomToken(userId)
            .then(function (customToken) {
            logger_1.default.info("Token returned from firebase");
            handleOutput_1.handleOutput();
            logger_1.default.info("Token done");
            // Returns the token as the standard output
            process.stdout.write(customToken);
            // For .netcore node services
            if (callback) {
                callback(null, customToken);
            }
        });
    }
    else {
        logger_1.default.error("Must supply a user id");
    }
};
//# sourceMappingURL=generateCustomToken.js.map