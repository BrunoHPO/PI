const express = require('express');
const fs = require('fs');
const simplifyData = require('./filters');

const app = express();

app.use(express.static('public'));

app.get('/api/legiao', (_, res) => {
  fs.readFile('data/LGN.json', (err, data) => {
    if (err) {
      res.statusCode = 500;
      return res.end('houve um erro inesperado...');
    }
    else {
      res.statusCode = 200;
      return res.end(data);
    }
  })
});

app.get('/api/legiaoSimple', (_, res) => {
  fs.readFile('data/LGN.json', (err, data) => {
    if (err) {
      res.statusCode = 500;
      return res.end('houve um erro inesperado...');
    }
    else {
      res.statusCode = 200;
      const content = JSON.parse(data);
      const cards = content.data.cards;
      const simpleCards = cards.map(simplifyData);
      return res.end(JSON.stringify(simpleCards));
    }
  })
});

app.get('/api/legiaoSimple/color/:color', (req, res) => {

  const { color } = req.params;

  if (!color) {
    res.statusCode = 400;
    return res.end('é necessário passar o parâmetro color pela URL');
  }

  fs.readFile('data/LGN.json', (err, data) => {
    if (err) {
      res.statusCode = 500;
      return res.end('houve um erro inesperado...');
    }
    else {
      res.statusCode = 200;
      const content = JSON.parse(data);
      const cards = content.data.cards;
      const simpleCards = cards.map(simplifyData);
      const result = simpleCards.filter(item => item.color[0].toUpperCase() === color.toUpperCase());
      return res.end(JSON.stringify(result));
    }
  })
});

app.get('/api/investida', (_, res) => {
  fs.readFile('data/ONS.json', (err, data) => {
    if (err) {
      res.statusCode = 500;
      return res.end('houve um erro inesperado...');
    }
    else {
      res.statusCode = 200;
      return res.end(data);
    }
  })
});

app.get('/api/fragelo', (_, res) => {
  fs.readFile('data/SCG.json', (err, data) => {
    if (err) {
      res.statusCode = 500;
      return res.end('houve um erro inesperado...');
    }
    else {
      res.statusCode = 200;
      return res.end(data);
    }
  })
});

app.listen('8080', () => console.info('listening on http://localhost:8080'));