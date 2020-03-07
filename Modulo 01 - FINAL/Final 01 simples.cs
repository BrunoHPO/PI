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
            List<int> ListaVotos = new List<int>();
            ListaVotos.Add(0);
            ListaVotos.Add(0);
            ListaVotos.Add(0);
            ListaVotos.Add(0);

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
                else if (opcao == 2)
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
                menu2.Append("1 - Candidato 01\n");
                menu2.Append("2 - Candidato 02\n");
                menu2.Append("3 - Nulo\n");
                menu2.Append("4 - Branco");
                Console.WriteLine(menu2);

                int opcao2 = Convert.ToInt32(Console.ReadLine());

                if (opcao2 == 1)
                {
                    int c1 = ListaVotos[0]++;
                    ListaVotos.Add(c1);
                    Console.WriteLine("Voto computado com sucesso.\n");
                }
                else if (opcao2 == 2)
                {
                    int c2 = ListaVotos[1]++;
                    ListaVotos.Add(c2);
                    Console.WriteLine("Voto computado com sucesso.\n");
                }
                else if (opcao2 == 3)
                {
                    int nu = ListaVotos[2]++;
                    ListaVotos.Add(nu);
                    Console.WriteLine("Voto computado com sucesso.\n");
                }
                else if (opcao2 == 4)
                {
                    int br = ListaVotos[3]++;
                    ListaVotos.Add(br);
                    Console.WriteLine("Voto computado com sucesso.\n");
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.\n");
                }

            }

            void Conferir()
            {
                double total = ListaVotos[0] + ListaVotos[1] + ListaVotos[2] + ListaVotos[3];

                double pernu = (ListaVotos[2]/total)*100;

                double perbr = (ListaVotos[3]/total)*100;

                Console.WriteLine(  "Total de votos: " + total +
                                    "\nPorcentagem de nulos: " + pernu +"%" +
                                    "\nPorcentagem de brancos: " + perbr + "%" +
                                    "\nPontos por candidato: Candidato 01 = " + ListaVotos[0] +" / Candidato 02 = " + ListaVotos[1]);
                if (ListaVotos[0] > ListaVotos[1])
                {
                    Console.WriteLine("\nCandidato vencedor: Candidato 01 !!!\n");
                }
                else if (ListaVotos[0] < ListaVotos[1])
                {
                    Console.WriteLine("\nCandidato vencedor: Candidato 02 !!!\n");
                }
                else
                {
                    Console.WriteLine("\nEMPATE !!!\n");
                }
            }

        }       
    }
}

