import * as webpack from "webpack";

const baseConfig: webpack.Configuration = {
    entry: "./src/index.ts",
    devtool: "inline-source-map",
    target: 'node',
    module: {
        rules: [
            {
                test: /\.ts?$/,
                use: "ts-loader",
                exclude: [/node_modules/, /.vscode/]
            }
        ]
    },
    resolve: {
        extensions: [".tsx", ".ts", ".js", ".json"],
    },
};

export default baseConfig;
