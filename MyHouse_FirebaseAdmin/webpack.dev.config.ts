import * as path from "path";
import * as webpack from "webpack";
import * as merge from "webpack-merge";
import baseConfig from "./webpack.base.config";

const devOutputDir: string = "../MyHouse_API/bin/debug/netcoreapp2.1/FirebaseAdmin";

const devConfig: webpack.Configuration = {
    mode: "development",
    output: {
        filename: "firebaseAdmin.js",
        path: path.resolve(__dirname, devOutputDir)
    },
    resolve: {
        alias: {
            "firebasePvk.json": path.join(__dirname, 'privateKey/myhouse-test.json'),
            "config/appSettings": path.join(__dirname, 'src/config/appSettings.dev.ts'),
        }
    }

};

const config: webpack.Configuration = merge(baseConfig, devConfig);

export default config;
