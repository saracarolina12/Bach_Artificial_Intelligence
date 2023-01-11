var http = require('http');
var date = require('./dataModule')

http.createServer(function (req, res) {
  res.writeHead(200, {'Content-Type': 'text/html'});
  res.end("Current Time and Date: " + date.myDateTime());
}).listen(8080);