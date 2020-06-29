// Obter a lista de produtos como Elemento (UL)
// Adicionar um eventListener para click na lista
// No evento, filtrar quem é o target, e regir apenas ao botão comprar
// Ler os valores do attr data- e criar um objeto

/*
  const button = document.querySelector('button[data-id]');
  const data = [...button.attributes];//Transforma um nodeMap em [node]
  const produto = data.reduce((obj, node) => {
    const attr = node.nodeName.replace('data-', '');
    const value = node.nodeValue;
    obj[attr] = value;
    return obj;
  }, {});
*/
// Adicionar esse objeto em uma lista "global" que representa o carrinho

/*
  item = [...items, produto]; //opção 1
  item.push(produto);  //opção 2
*/

// Obter a lista de produtos DO CARRINHO como Elemento (UL)
// Obter o template do produto para o carrinho
// Fazer o replace dos valores do objeto no template
// Renderizar - Adicionar todos os items (transformados pelo template) da lista global no innerHTML da lista do carrinho


String.prototype.replaceAll = function(from, to){ return this.split(from).join(to);};
const replaceAll = (from, to, text) => text.split(from).join(to);


let shoppingCartElements = [];

const productList = document.querySelector('#lista-produtos');
const shoppingCartList = document.querySelector('#lista-carrinho')
const templateElement = document.querySelector('#carrinho-item');
const template = templateElement.innerHTML;

const render = () => {
  const shoppingCartElementsHTML = shoppingCartElements.map((item) => templateToHTML(template, item));
  shoppingCartList.innerHTML = shoppingCartElementsHTML.join('\n');
};

const templateToHTML = (template, item) => {
  return template
    .replaceAll('{{IMAGEM}}', item.image)
    .replaceAll('{{NOME}}', item.name)
    .replaceAll('{{PRECO}}', item.price)
    .replaceAll('{{ID}}', item.id)
};

productList.addEventListener('click',(evt)=>{
  const buttonProduct = evt.target;
  if(buttonProduct.nodeName === 'BUTTON' && buttonProduct.innerText === 'Comprar'){
    const data = [...buttonProduct.attributes];
    const product = data.reduce((obj,node)=>{
      const attr = node.nodeName.replace('data-', '');
      const value = node.nodeValue;
      obj[attr]=value;
      return obj;
    },{});      
    shoppingCartElements.push(product);
    render();
  };
});

shoppingCartList.addEventListener('click',(evt)=>{
  const buttonRemove = evt.target;
  if(buttonRemove.nodeName === 'BUTTON'){    
    const productID = parseInt(buttonRemove.attributes['data-id'].nodeValue);    
  };
});

// Adicionar um eventListener para click na lista do carrinho
// Verificar se é o botão remover
// Pegar o data-id, para saber qual item remover
// Fazer um filter na lista global e remover o que tiver o id proveniente do botão
// Rederizar - Adicionar todos os items (transformados pelo template) da lista global no innerHTML da lista do carrinho

// Desafio
// Adicionar um eventListener para change na lista do carrinho
// Verificar se o target é um input
// Pegar o valor do target que é a quantidade
// Pegar o id do data-id do target
// Alterar o item na lista global de mesmo id atualizando a quantidade

/*
  const lista = [
    { id:1, quantidade:2, preco:100.00 },
    { id:2, quantidade:1, preco:150.00 },
    { id:3, quantidade:3, preco:99.00 },
    { id:4, quantidade:1, preco:10.00 }
  ];

  const alterarItem = function(id, qtd){
    const index  = lista.findIndex(x => x.id === id);
    lista[index].quantidade = qtd;
    return lista;
  };
*/

// Calcular o Total (Obter o span com id total e modificar seu innerHTML)

/*
  const total = lista.reduce(
    (acc, item) => acc += parseInt(item.quantidade) * parseFloat(item.preco)
    , 0.0
  );
*/

// Renderizar o total na tela

/*
  const total = 100.0;
  total.toFixed(2).replace('.',',');
*/
























/*
const sortById = function(list){
  list.sort((a, b) => {
    if(a.id > b.id)  return 1;
    if(a.id == b.id) return 0;
    if(a.id < b.id)  return -1;
  });
};

const lista = [
  { id:1, quantidade:'2', preco:'100.00' },
  { id:2, quantidade:'1', preco:'150.00' },
  { id:3, quantidade:'3', preco:'99.00' },
  { id:4, quantidade:'1', preco:'10.00' }
];

const parseNumericProperties = function(lista){
  return lista.map(
    item => 
    ({
        ...item, 
        quantidade : parseInt(item.quantidade), 
        preco : parseFloat(item.preco)
      })
  );
};
*/