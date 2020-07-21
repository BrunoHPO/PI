const express = require('express');
const fs = require('fs');

const app = express();

app.use(express.static('../public'));

app.get('/api/legiao', (_, res) => {
    fs.readFile('../data/LGN.json', (err,data) => {
        if(err){
            res.statusCode = 500;
            return res.end('houve um erro inesperado...')
        }
        else{
            res.statusCode = 200;
            return res.end(data);
        }
    })
});

app.get('/api/investida', (_, res) => {
    fs.readFile('../data/ONS.json', (err,data) => {
        if(err){
            res.statusCode = 500;
            return res.end('houve um erro inesperado...')
        }
        else{
            res.statusCode = 200;
            return res.end(data);
        }
    })
});

app.get('/api/fragelo', (_, res) => {
    fs.readFile('../data/SCG.json', (err,data) => {
        if(err){
            res.statusCode = 500;
            return res.end('houve um erro inesperado...')
        }
        else{
            res.statusCode = 200;
            return res.end(data);
        }
    })
});

app.listen('8080', () => console.info('listening on http://localhost:8080'));