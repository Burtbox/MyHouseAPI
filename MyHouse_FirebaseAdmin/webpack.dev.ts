import path from 'path';
import merge from 'webpack-merge';
import common from './webpack.common';

const outputPath = 'dist';

const config = merge(common, {
    mode: 'development',
    // devServer: {
    //     contentBase: path.join(__dirname, 'dist'),
    //     compress: true,
    //     port: 9000
    // },
    output: {
        libraryTarget: 'commonjs',
        path: path.resolve(__dirname, outputPath),
        filename: 'myHouseFirebaseAdmin.js'
    }
});

export default config;