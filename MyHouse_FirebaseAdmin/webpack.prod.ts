import CleanWebpackPlugin from 'clean-webpack-plugin';
import path from 'path';
import webpack from 'webpack';

const outputPath = '../../MyHouse_API/node_services';
const config: webpack.Configuration = {
    mode: 'production',
    plugins: [
        new CleanWebpackPlugin([outputPath]),
    ],
    output: {
        libraryTarget: 'commonjs',
        path: path.resolve(__dirname, outputPath),
        filename: 'myHouseFirebaseAdmin.js'
    }
};

export default config;