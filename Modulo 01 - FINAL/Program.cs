using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo_01___FINAL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("###  URNA ELETRONICA  ###");
                        
            Dictionary<int, string> ListaCandidato = new Dictionary<int, string>();
            Dictionary<int, int> ListaNumeros = new Dictionary<int, int>();
            List<int> ListaVotos = new List<int>();
            ListaVotos.Add(0);
            ListaVotos.Add(0);

            bool candok = true;
            int ncand = 2;

            while (candok)
            {              
                Console.WriteLine("Adicionando os Candidatos" +
                                  "\nQual o nome do mesmo ?");
                string nomecand = Console.ReadLine();
                Console.WriteLine("Qual sera o Numero do mesmo ?");
                int numcand = Convert.ToInt32(Console.ReadLine());

                Candidato candidato = new Candidato(numcand, nomecand);
                ListaCandidato.Add(numcand, nomecand);
                ListaNumeros.Add(ncand, numcand);
                ListaVotos.Add(0);

                Console.WriteLine("Deseja adicionar mais Candidatos ? 1 - SIM 2 - NAO");
                int mais = Convert.ToInt32(Console.ReadLine());
                if (mais == 1)
                {
                    ncand++;
                    continue;
                }
                else
                    candok = false;                               
            }
            
            bool sair = true;

            while (sair)
            {
                StringBuilder menu1 = new StringBuilder();
                menu1.Append("1 - Votar\n");
                menu1.Append("2 - Conferir contagem\n");
                menu1.Append("3 - Sair");
                Console.WriteLine(menu1);

                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 1)
                {
                    Votar();
                }
                else if (opcao == ncand)
                {
                    Conferir();
                }
                else if (opcao == 3)
                {
                    sair = false;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.\n");
                }

            }
           
            void Votar ()
            {
                StringBuilder menu2 = new StringBuilder();
                foreach (var item in ListaCandidato)
                {
                menu2.Append(item.Key + " - " + item.Value + "\n");            
                }
               
                menu2.Append("3 - Nulo\n");
                menu2.Append("4 - Branco");
                Console.WriteLine(menu2);

                int opcao2 = Convert.ToInt32(Console.ReadLine());

                try
                {
                 foreach (var item in ListaNumeros)
                                {
                                    if (opcao2 == 3)
                                    {
                                        ListaVotos[0]++;
                                        Console.WriteLine("Voto computado com sucesso.\n");
                                        break;

                                    }
                                    else if (opcao2 == 4)
                                    {
                                        ListaVotos[1]++;
                                        Console.WriteLine("Voto computado com sucesso.\n");
                                        break;
                                    }
                                    else if (opcao2==item.Value)
                                    {                    
                                        ListaVotos[item.Key]++;
                                        Console.WriteLine("Voto computado com sucesso.\n");
                                        break;
                                    }
                                    
                                }                                  
                }
                catch (Exception)
                {
                    Console.WriteLine("ERRO AO VOTAR !!!");
                    throw;
                }
               

            }
                        
            void Conferir()
            {
                double total = 0;
                foreach (var item in ListaVotos)
                {
                    double parcial = item;
                    total = total + parcial;
                }
                
                double pernu = (ListaVotos[0] / total) * 100;

                double perbr = (ListaVotos[1] / total) * 100;

                Console.WriteLine("Total de votos: " + total +
                                    "\nPorcentagem de "+TipoCandidato.Nulo +" nulos: " + pernu + "%" +
                                    "\nPorcentagem de "+ TipoCandidato.Branco + " : " + perbr + "%");
                                    //"\nPontos por candidato: Candidato 01 = " + ListaVotos[0] +" / Candidato 02 = " + ListaVotos[1]);
                //if (ListaVotos[0] > ListaVotos[1])
                //{
                //    Console.WriteLine("\nCandidato vencedor: Candidato 01 !!!\n");
                //}
                //else if (ListaVotos[0] < ListaVotos[1])
                //{
                //    Console.WriteLine("\nCandidato vencedor: Candidato 02 !!!\n");
                //}
                //else
                //{
                //    Console.WriteLine("\nEMPATE !!!\n");
                //}
            }
           
        }
    }
    class Candidato
    {
        public int Numero { get; }
        public string Nome { get; set; }

        public Candidato(int n, string nom)
        {
            Numero = n;
            Nome = nom;
        }
    }
    enum TipoCandidato
    {
        Valido,
        Branco,
        Nulo
    }
}

