import CleanWebpackPlugin from 'clean-webpack-plugin';
import path from 'path';
import merge from 'webpack-merge';
import common from './webpack.common.js';

const outputPath = 'dist';
module.exports = merge(common, {
    mode: 'development',
    devServer: {
        contentBase: './dist'
    },
    plugins: [
        new CleanWebpackPlugin([outputPath]),
    ],
    output: {
        libraryTarget: 'commonjs',
        path: path.resolve(__dirname, outputPath),
        filename: 'myHouseFirebaseAdmin.js'
    }
});