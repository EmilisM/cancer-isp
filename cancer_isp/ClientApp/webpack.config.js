const path = require("path");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const fileLoader = require("file-loader");

module.exports = (env = {}, argv = {}) => {

    const isProd = argv.mode === "production";

    const config = {
        mode: argv.mode || "development", // we default to development when no "mode" arg is passed
        entry: {
            main: "./js/main.js"
        },
        output: {
            filename: "[name].js",
            path: path.resolve(__dirname, "../wwwroot/dist"),
            publicPath: "/dist/"
        },
        plugins: [
            new MiniCssExtractPlugin({
                filename: "styles.css"
            })
        ],
        module: {
            rules: [
                {
                    test: /\.css$/,
                    use: [
                        isProd ? MiniCssExtractPlugin.loader : "style-loader",
                        "css-loader"
                    ]
                },
                {
                    test: /\.(woff(2)?|ttf|eot|svg|otf)(\?v=\d+\.\d+\.\d+)?$/,
                    use: [{
                        loader: "file-loader",
                        options: {
                            name: "[name].[ext]",
                            outputPath: "fonts/"
                        }
                    }]
                }
            ]
        }
    };

    return config;
};