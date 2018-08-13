import * as path from "path";
import * as webpack from "webpack";
import * as merge from "webpack-merge";
import baseConfig from "./webpack.base.config";

const devOutputDir: string = "dist";

const devConfig: webpack.Configuration = {
    mode: "development",
    output: {
        filename: "firebaseAdmin.js",
        path: path.resolve(__dirname, devOutputDir)
    }
};

const config: webpack.Configuration = merge(baseConfig, devConfig);

export default config;
