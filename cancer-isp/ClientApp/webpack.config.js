const path = require("path");

module.exports = (env = {}, argv = {}) => {

    const config = {
        mode: argv.mode || "development", // we default to development when no 'mode' arg is passed
        devtool: "inline-source-map",
        entry: {
            main: "./js/main.tsx",
            hello: "./js/hello.tsx"
        },
        output: {
            filename: "[name].js",
            path: path.resolve(__dirname, "../wwwroot/dist"),
            publicPath: "/dist/"
        },
        resolve: {
            // Add `.ts` and `.tsx` as a resolvable extension.
            extensions: [".ts", ".tsx", ".js"]
        },
        module: {
            rules: [
                {
                    test: /\.css$/,
                    use: [
                        "style-loader",
                        "css-loader"
                    ]
                },
                {
                    test: /\.tsx?$/,
                    loader: "ts-loader"
                }
            ]
        }
    };

    return config;
};