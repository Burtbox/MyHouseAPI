var admin = require("firebase-admin");

module.exports = function (callback, email) {
    const config = {
        // put config from pvtkey here to test!
    }
    admin.initializeApp({
        credential: admin.credential.cert(config),
        databaseURL: "https://myhouse-a01c7.firebaseio.com"
    });
    const userDetails = admin.auth().getUserByEmail(email)
        .then(deets => {
            callback(null, deets),
                process.exit(0)
        }
        );
}
