import * as path from "path";
import * as webpack from "webpack";
import * as merge from "webpack-merge";
import baseConfig from "./webpack.base.config";

const prodOutputDir: string = "../MyHouse_API/bin/release/netcoreapp2.1/FirebaseAdmin";

const prodConfig: webpack.Configuration = {
    mode: "production",
    output: {
        filename: "firebaseAdmin.js",
        path: path.resolve(__dirname, prodOutputDir)
    },
    resolve: {
        alias: {
            "firebasePvk.json": path.join(__dirname, 'privateKey/myhouse-live.json'),
        }
    }
};

const config: webpack.Configuration = merge(baseConfig, prodConfig);

export default config;
