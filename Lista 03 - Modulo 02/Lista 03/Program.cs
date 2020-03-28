using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dado;
using Negocio;
using Interfaces;

namespace Lista_03
{
    class Program
    {
        public static List<IPessoa> listaPessoa = new List<IPessoa>();
        public static List<ILivro> listaLivro = new List<ILivro>();
        public static List<IEmprestimo> listaEmprestimo = new List<IEmprestimo>();
        static void Main(string[] args)
        {            
            bool sair = true;            

            while (sair)
            {
                StringBuilder menu = new StringBuilder();
                menu.Append("\n*****BIBLIOTECA*****");
                menu.Append("\nLIVRO");
                menu.Append("\n     11 - Cadastrar livro");
                menu.Append("\n     12 - Pesquisar livro");
                menu.Append("\n     13 - Deletar livro");
                menu.Append("\nPESSOA");
                menu.Append("\n     21 - Cadastrar pessoa");
                menu.Append("\n     22 - Pesquisar pessoa");
                menu.Append("\n     23 - Deletar pessoa");
                menu.Append("\n3 - Emprestar Livro");
                menu.Append("\n4 - Devolver");
                menu.Append("\n5 - Sair");
                Console.WriteLine(menu);
                int opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 11:
                        CadastrarLivro();
                        break;
                    case 12:
                        PesquisarLivro();
                        break;
                    case 13:
                        DeletarLivro();
                        break;                        
                    case 21:
                        CadastrarPessoa();
                        break;
                    case 22:
                        PesquisarPessoa();
                        break;
                    case 23:
                        DeletarPessoa();
                        break;
                    case 3:
                        CadastrarEmprestimo();
                        break;
                    case 4:
                        Devolucao();
                        break;
                    case 5:
                        Console.WriteLine("A Biblioteca agradece a sua visita !!!");
                        sair = false;
                        break;
                    default:
                        Console.WriteLine("OPCAO Invalida !!!");
                        break;
                }
            }

            static void CadastrarLivro()
            {
                Console.WriteLine("*****Cadastro Livro*****");
                Console.WriteLine("Qual o Titulo ?");
                string titulo = Console.ReadLine();
                Console.WriteLine("Qual o Autor ?");
                string autor = Console.ReadLine();
                ILivro livro = new Livro(listaLivro.Count,titulo, autor);                
                listaLivro.Add(livro);
                Console.WriteLine($"     Livro cadastrado com Sucesso, Codigo do Livro = {livro.GetCod()}");                
            }

            static void PesquisarLivro()
            {
                Bibilioteca biblioteca = new Bibilioteca();
                ILivro iLivro;

                do
                {
                    iLivro = new Livro();

                    Console.WriteLine("*****Pesquisa Livro*****");
                    Console.Write("Entre com o Codigo do livro: ");
                    var codigo = Convert.ToInt32(Console.ReadLine());
                    iLivro = biblioteca.BuscarLivro(iLivro, codigo, listaLivro);

                    if (iLivro == null)
                        Console.WriteLine("     Livro nao existente no cadastro. Tente novamente. ");
                    else
                        Console.WriteLine(iLivro.ImprimirLivro());

                } while (iLivro == null);
            }

            static void DeletarLivro()
            {
                ILivro iLivro = new Livro();
                Bibilioteca biblioteca = new Bibilioteca();
                IEmprestimo emp = new Emprestimo();

                Console.WriteLine("*****Deletar Livro*****");
                Console.Write("Entre com o Codigo do livro: ");
                var codigo = Convert.ToInt32(Console.ReadLine());
                iLivro = biblioteca.BuscarLivro(iLivro, codigo, listaLivro);
                emp = biblioteca.DelLivro(emp, iLivro, listaEmprestimo);

                if (emp == null)
                {
                    listaLivro.Remove(iLivro);
                    Console.WriteLine("     Livro Deletado com Sucesso !!! ");
                }
                else
                    Console.WriteLine("     Livro EM USO, nao foi possivel deleta-lo ");

            }

            static void CadastrarPessoa()
            {
                Console.WriteLine("*****Cadastro Usuario*****");
                Console.WriteLine("Qual o seu Nome ?");
                string nome = Console.ReadLine();
                Console.WriteLine("Qual o seu Email ?");
                string email = Console.ReadLine();
                Console.WriteLine("Qual o seu CPF (Apenas Numeros)?");
                string cpf = Console.ReadLine();
                IPessoa pessoa = new Pessoa(cpf, nome, email);                
                listaPessoa.Add(pessoa);
                Console.WriteLine("     Usuario cadastrado com Sucesso");
            }

            static void PesquisarPessoa()
            {
                Console.WriteLine("*****Pesquisa Usuario*****");
                Bibilioteca biblioteca = new Bibilioteca();
                IPessoa iPessoa;

                do
                {
                    iPessoa = new Pessoa();
                                        
                    Console.Write("Entre com o CPF da pessoa: ");
                    var cpf = Console.ReadLine();
                    iPessoa = biblioteca.BuscarPessoa(iPessoa, cpf, listaPessoa);

                    if (iPessoa == null)
                        Console.WriteLine("     Pessoa nao existente no cadastro. Tente novamente. ");
                    else
                        Console.WriteLine(iPessoa.ImprimirPessoa());

                } while (iPessoa == null);
            }

            static void DeletarPessoa()
            {
                IPessoa iPessoa = new Pessoa();
                Bibilioteca biblioteca = new Bibilioteca();
                IEmprestimo emp = new Emprestimo();

                Console.WriteLine("*****Deletar Usuario*****");
                Console.Write("Entre com o CPF da pessoa: ");
                var cpf = Console.ReadLine();
                iPessoa = biblioteca.BuscarPessoa(iPessoa, cpf, listaPessoa);
                emp = biblioteca.DelPessoa(emp, iPessoa, listaEmprestimo);

                if (emp == null)
                {
                    listaPessoa.Remove(iPessoa);
                    Console.WriteLine("     Usuario Deletado com Sucesso !!! ");
                }
                else
                    Console.WriteLine("     Usuario EM USO, nao foi possivel deleta-lo ");
            }

            static void CadastrarEmprestimo()
            {
                Console.WriteLine("*****Alugar Livro*****");
                Bibilioteca biblioteca = new Bibilioteca();
                IEmprestimo emprestimo = new Emprestimo();
                IPessoa iPessoa;
                ILivro iLivro;

                do
                {
                    iPessoa = new Pessoa();
                    iLivro = new Livro();

                    Console.Write("Entre com o CPF do solicitante: ");
                    var cpf = Console.ReadLine();
                    Console.Write("Entre com o Codigo do livro: ");
                    var codigo = Convert.ToInt32(Console.ReadLine());

                    iPessoa = biblioteca.BuscarPessoa(iPessoa, cpf, listaPessoa);
                    iLivro = biblioteca.BuscarLivro(iLivro, codigo, listaLivro);

                    if (iPessoa == null)
                        Console.WriteLine("     Pessoa nao existente no cadastro. Tente novamente. ");

                    if (iLivro == null)
                        Console.WriteLine("     Livro nao existente no cadastro. Tente novamente. ");

                } while (iPessoa == null || iLivro == null);

                emprestimo = biblioteca.Emprestar(iPessoa, iLivro, emprestimo);
                listaEmprestimo.Add(emprestimo);
                Console.WriteLine($"     Emprestimo realizado com sucesso, Codigo do Emprestimo = {emprestimo.GetId()}");
            }

            static void Devolucao()
            {
                Console.WriteLine("*****Devolucao*****");
                Bibilioteca biblioteca = new Bibilioteca();
                IEmprestimo iEmprestimo;

                do
                {
                    iEmprestimo = new Emprestimo();
                    Console.Write("Entre o numero do emprestimo: ");
                    var id = Convert.ToInt32(Console.ReadLine());

                    iEmprestimo = biblioteca.Devolver(iEmprestimo, id, listaEmprestimo);

                    if (iEmprestimo == null)
                        Console.WriteLine("     Devolucao nao existente. Tente novamente. ");

                } while (iEmprestimo == null);
                listaEmprestimo.Remove(iEmprestimo);
                Console.WriteLine("     Devolucao executada com sucesso");
            }
        }
    }
}
