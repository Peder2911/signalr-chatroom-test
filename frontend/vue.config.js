
module.exports = {
   devServer: {
      hot: false,
      liveReload: false
   },
   configureWebpack: {
      devServer: {
         headers: {
            "Access-Control-Allow-Origin": "*",
            "Access-Control-Allow-Methods": "GET, POST, PUT, DELETE, PATCH, OPTIONS",
            "Access-Control-Allow-Headers": "X-Requested-With, content-type, Authorization"
         },
         proxy: {
            '^/chat': {
               target:"http://localhost:5093/",
               changeOrigin: true,
               secure: false,
               pathRewrite: {"^/chat": "/chatHub"},
               logLevel: "debug"
            }
         }
      }
   }
}
