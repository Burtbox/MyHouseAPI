import FirebaseSdk from "./firebaseSdk";
console.log("Firebase admin console app initialised");

const dit: FirebaseSdk = new FirebaseSdk();
const ret: Promise<void> = dit.generateToken("70ajxWmrS6XIU53GL6bj1VcjCsm1")
    .then((token: string) => {
        console.log("Token Generated");
        console.log("Bearer " + token);
    });
