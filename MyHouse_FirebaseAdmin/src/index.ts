import FirebaseSdk from "./firebaseSdk";
console.log("Firebase admin console app initialised");

const dit: FirebaseSdk = new FirebaseSdk();
const ret: Promise<string> = dit.generateToken("70ajxWmrS6XIU53GL6bj1VcjCsm1")
    .then((token: string) => {
        console.log("Token Generated");
        console.log("Bearer " + token);
        return token;
    });
// const vt: Promise<void> = dit.verifyUserToken("eyJhbGciOiJSUzI1NiIsImtpZCI6IjM4NjlhMTliNjdiNDY3YTQ4NjQ3YWFjNTMxYmUxZmIxZTFlYTI5ZTAifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vbXlob3VzZS1hMDFjNyIsIm5hbWUiOiJEaWNrQnV0dCIsImF1ZCI6Im15aG91c2UtYTAxYzciLCJhdXRoX3RpbWUiOjE1MTU2MjAwMzcsInVzZXJfaWQiOiI3MGFqeFdtclM2WElVNTNHTDZiajFWY2pDc20xIiwic3ViIjoiNzBhanhXbXJTNlhJVTUzR0w2YmoxVmNqQ3NtMSIsImlhdCI6MTUxNTYyMDA1MCwiZXhwIjoxNTE1NjIzNjUwLCJlbWFpbCI6ImRpY2tidXR0QGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjpmYWxzZSwiZmlyZWJhc2UiOnsiaWRlbnRpdGllcyI6eyJlbWFpbCI6WyJkaWNrYnV0dEBnbWFpbC5jb20iXX0sInNpZ25faW5fcHJvdmlkZXIiOiJwYXNzd29yZCJ9fQ.StPwgFY4oRToNcymlGhS3sLTTHXQ-WQ35vzrL8Cu1o6CWUH96Q7xynMDYeF0P_eqhsVqWa-9AfWXsC7QQDlHty1q-7MQbj8tW7nzq6CM8n4ZIvJvt08OxA7dVLfDVptP72Pg7iGeHL59rdgdhcuRbVGbmVfNMP9-vNDdAuq5XlRl2IMPM05QQZUAxYJPNOpd3TkDWC_9DPFLw9zXJuP3CRzUQUjv01c31RG2JSdhssXcPxl5EGEaiytLE1qrD06q79mEMjBPqjWxhhY029uNzhcBn0e1KayuaTw3v7OgRLH7MdJcXTQoRX2se0P4oFFf8o_CIc3Y3XgCJ5OXVzWrnQ")
//     .then((dectoken: any) => {
//         console.log("Token verified");
//         console.log(dectoken);
//     });
