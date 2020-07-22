//Eg Graph

const labelsByColor = [
  'White',
  'Blue',
  'Green',
  'Red',
  'Black',
  'Uncolored'
]

const backgroundColorMTG = [
  "#F8E7B9",
  "#B3CEEA",
  "#C4D3CE",
  "#EB9F82",
  "#A69F9D",
  "#ff00ff"
]

//Infestida
const data = {
  datasets: [{
    data: [61, 61, 61, 61, 61, 45],
    backgroundColor: backgroundColorMTG
  }],

  labels: labelsByColor
};

const ctx = document.getElementById('ONSGraph');
new Chart(ctx, {
  data: data,
  type: 'polarArea'
});

//Legiao
const data2 = {
  datasets: [{
    data: [29, 29, 29, 29, 29, 0],
    backgroundColor: backgroundColorMTG
  }],

  labels: labelsByColor
};

const ctx2 = document.getElementById('LGNGraph');
new Chart(ctx2, {
  data: data2,
  type: 'polarArea'
});

const drawChart = canvasElement => data => new Chart(canvasElement, { data, type: 'polarArea' });

//Fragelo
const data3 = {
  datasets: [{
    data: [27, 27, 27, 27, 31, 4],
    backgroundColor: backgroundColorMTG
  }],

  labels: labelsByColor
};

const ctx3 = document.getElementById('SCGGraph');
new Chart(ctx3, {
  data: data3,
  type: 'polarArea'
});

//For Real

const responseToJson = response => response.json();
const simplifyData = item => {
  const { name, convertedManaCost, power, toughness, types, colors, uuid } = item;
  return { name: name, manaCost: convertedManaCost, atk: power, def: toughness, type: types, color: colors, id: uuid }
}
const maps = fn => arr => arr.map(fn);
const trace = x => { console.log(x); return x; }
const filters = fn => arr => arr.filter(fn);

//const aggregate = (key, fn) => arr => ({ data : arr, [key] : arr.filter(fn) });
const toDataObject = arr => ({ data: arr });
const aggregate = (key, fn) => obj => ({ ...obj, [key]: obj.data.filter(fn) });

const byWhite = item => item.color[0] === "W";
const aggregateByWhite = aggregate('whiteCards', byWhite);
const byGreen = item => item.color[0] === "G";
const aggregateByGreen = aggregate('greenCards', byGreen);


const gotoCards = response => response.data.cards;
const byBlue = item => item.color[0] === "U";
const byRed = item => item.color[0] === "R";
const byBlack = item => item.color[0] === "B";
const byUncolored = item => item.color[0] === undefined;
const byCreature = item => item.type[0] === "Creature";
const byNotCreature = item => item.type[0] !== "Creature";

const generateData = dados => {
  const data = {
    datasets: [{
      data: dados,
      backgroundColor: backgroundColorMTG
    }],
    labels: labelsByColor
  };

  return data;
}

const canvasElements = document.querySelector('#teste');

(() => {
  fetch('/api/fragelo')
    .then(responseToJson)
    .then(gotoCards)
    .then(maps(simplifyData))
    .then(trace)
    .then(toDataObject)
    .then(trace)
    .then(aggregateByWhite)
    .then(trace)
    .then(aggregateByGreen)
    .then(trace)
    .then(aggregatedData => {
      const { whiteCards, greenCards } = aggregatedData;
      return generateData([whiteCards.length, greenCards.length]);
    })
    .then(trace)
    .then(drawChart(canvasElements))
})();