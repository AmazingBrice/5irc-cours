const express = require('express');
const { emit } = require('process');
var app = express();

const io = require('socket.io');
const server = require('http').createServer(app);
const ioServer = io(server);

const stompit = require('stompit');

const connectOptions = {
    'host': 'localhost',
    'port': 61613
};

var allSockets = [];

app.use(express.static('.'))

function sendStompit(data) {
    stompit.connect(connectOptions, (error, client) => {
        if (error) {
            return console.error(error);
        }
        const frame = client.send({'destination': '/queue/fr.cpe.spring-app.in'});
        frame.write(data);
        frame.end();
        client.disconnect();
    });
}

function listenStompit(){
    stompit.connect(connectOptions, (error, client) => {
        if (error) {
            return console.error(error);
        }
        client.subscribe({'destination': '/queue/fr.cpe.nodejs-app.in'}, (error, message) => {
            if (error) {
                return console.error(error);
            }
            message.readString('utf-8', (error, body) => {
                if (error) {
                    return console.error(error);
                }

                const personne = JSON.parse(body);
                personne.node = "OK";
                const data = JSON.stringify(personne);
                console.log(data);
                allSockets[0].emit('dataOut', data);
            });
        });
    });
}

ioServer.on('connection', function (socket) {
    allSockets.push(socket);

    listenStompit();
    
    socket.on('dataIn', function (data) {
        sendStompit(data);
    });

    socket.on('disconnect', function() {  
        var i = allSockets.indexOf(socket);
        allSockets.splice(i, 1);
     });
});

server.listen(3000);