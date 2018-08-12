import path from 'path';
import webpack from 'webpack';
const tsConfigPath = path.join(__dirname, "tsconfig.json");

const common: webpack.Configuration = {
    target: "node",
    entry: './actions/index.ts',
    devtool: 'inline-source-map',
    module: {
        rules: [
            {
                test: /\.jsx?$/,
                include: [path.resolve(process.cwd(), "node-modules")],
                use: [
                    {
                        loader: 'babel-loader',
                        options: {
                            babelrc: false,
                            presets: [
                                "es2015",
                                { modules: false }
                            ],
                            plugins: ['babel-plugin-syntax-dynamic-import']
                        }
                    }]
            },
            {
                test: /\.tsx?$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: 'awesome-typescript-loader',
                        options: {
                            configFileName: tsConfigPath,
                            useBabel: true,
                            useCache: true,
                            babelOptions: {
                                babelrc: false,
                                presets: [
                                    "es2015",
                                    { modules: false }
                                ],
                                plugins: ['babel-plugin-syntax-dynamic-import']
                            }
                        }
                    }]
            }
        ]
    },
    resolve: {
        extensions: ['.tsx', '.ts', '.js', '.json'],
        modules: [
            path.resolve(process.cwd()),
            path.resolve(path.join(process.cwd(), 'node_modules'))
        ]
    },
    plugins: [
        new webpack.ProgressPlugin(),
    ]
};

export default common;