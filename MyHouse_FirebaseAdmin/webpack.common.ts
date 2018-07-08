import CleanWebpackPlugin from 'clean-webpack-plugin';
import path from 'path';
import webpack from 'webpack';

const outputPath = 'dist';
const config: webpack.Configuration = {
    entry: './index.js',
    devtool: 'inline-source-map',
    plugins: [
        new CleanWebpackPlugin([outputPath]),
    ],
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                use: 'ts-loader',
                exclude: /node_modules/
            }
        ]
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js']
    },
    output: {
        path: path.resolve(__dirname, outputPath),
        filename: 'index.bundle.js'
    }
};

export default config;