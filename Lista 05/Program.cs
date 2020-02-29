using System;
using System.Collections.Generic;

namespace Lista_05
{
    class Program
    {
        static void Main(string[] args)
        {
            #region PARTE1
            //List<int> objList = new List<int>();
            //int cont = 0;

            //Console.WriteLine("Insirar 5 Numeros");
            //while (cont < 5)
            //{
            //objList.Add(Convert.ToInt32(Console.ReadLine()));
            //cont++;
            //}

            //Console.WriteLine("Ordem ORIGINAL: ");
            //foreach (var item in objList)
            //{
            //    Console.Write(item +"   ");
            //}

            //Console.WriteLine("\n Ordem CRESCENTE: ");
            //objList.Sort();
            //foreach (var item in objList)
            //{
            //    Console.Write(item + "   ");
            //}

            //Console.WriteLine("\nOrdem DECRESCENTE: ");
            //objList.Sort();
            //objList.Reverse();
            //foreach (var item in objList)
            //{
            //    Console.Write(item + "   ");
            //}
            //Console.WriteLine("\nQuantidade de elementos: "+ objList.Count);
            #endregion

            #region PARTE2
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //int cont2 = 0;

            //while (cont2 < 5)
            //{
            //    Console.WriteLine("Digite o nome do site" + (cont2 + 1) + ": ");
            //    string nome = Console.ReadLine();
            //    Console.WriteLine("Digite o URL do site" + (cont2 + 1) + ": ");
            //    string url = Console.ReadLine();

            //    dic.Add(nome, url);
            //    cont2++;
            //}

            //bool sair = true;

            //while (sair)
            //{
            //    Console.WriteLine("Deseja procurar algum site ?" +
            //                    "\nDIGITE 1" +
            //                    "\nDIGITE 2 PARA SAIR !!!");
            //    int opcao = Convert.ToInt32(Console.ReadLine());

            //    if (opcao == 1)
            //    {
            //        Console.WriteLine("\nQual o nome do site ?");
            //        string procura = Console.ReadLine();
            //        foreach (var item in dic)
            //        {
            //            if (item.Key == procura)
            //            {
            //                Console.WriteLine("Essa eh a URL desse site:" + item.Value);
            //            }

            //        }

            //    }
            //    else if (opcao == 2)
            //    {
            //        sair = false;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Digite um valor valido");
            //    }
            //}
            #endregion

            #region PARTE3
            //Stack<int> pilha = new Stack<int>();
            //bool sair = true;

            //while (sair)
            //{
            //    Console.WriteLine("MENU" +
            //                      "\n1 - Inserir um Numero" +
            //                      "\n2 - Remover Numero" +
            //                      "\n3 - SAIR");
            //    int opcao2 = Convert.ToInt32(Console.ReadLine());

            //    if (opcao2 == 1)
            //    {
            //        Console.WriteLine("Qual o numero a ser inserido ?");
            //        pilha.Push(Convert.ToInt32(Console.ReadLine()));
            //        foreach (var item in pilha)
            //        {
            //            Console.WriteLine(item);
            //        }
            //    }
            //    else if (opcao2 == 2)
            //    {
            //        Console.WriteLine("O Ultimo numero foi removido !!!");
            //        pilha.Pop();
            //        foreach (var itemQueue in pilha)
            //        {
            //            Console.WriteLine(itemQueue);
            //        }
            //    }
            //    else if (opcao2 == 3)
            //    {
            //        sair = false;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Digite uma opcao correta !!!");
            //    }
            //}
            #endregion

            #region PARTE4

            Queue<int> fila = new Queue<int>();
            bool sair = true;

            while (sair)
            {
                Console.WriteLine("MENU" +
                                  "\n1 - Inserir um Numero" +
                                  "\n2 - Remover Numero" +
                                  "\n3 - SAIR");
                int opcao2 = Convert.ToInt32(Console.ReadLine());

                if (opcao2 == 1)
                {
                    Console.WriteLine("Qual o numero a ser inserido ?");
                    fila.Enqueue(Convert.ToInt32(Console.ReadLine()));
                    foreach (var item in fila)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (opcao2 == 2)
                {
                    Console.WriteLine("O Primeiro numero foi removido !!!");
                    fila.Dequeue();
                    foreach (var itemQueue in fila)
                    {
                        Console.WriteLine(itemQueue);
                    }
                }
                else if (opcao2 == 3)
                {
                    sair = false;
                }
                else
                {
                    Console.WriteLine("Digite uma opcao correta !!!");
                }
            }
            #endregion
        }
    }
}
