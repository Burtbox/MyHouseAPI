import path from 'path';
import merge from 'webpack-merge';
import common from './webpack.common';

const outputPath = '../../MyHouse_API/bin/release/netcoreapp2.1/FirebaseAdmin';

const config = merge(common, {
    mode: 'production',
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