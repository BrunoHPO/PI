using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lista_02___Modulo_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings _settings = new Settings();
            using (StreamReader file = File.OpenText(@"C:\Users\BrunoHPO\Desktop\PI\Exercicios\MODULO 02\Lista 02 - Modulo 02\jsconfig1.json"))
            {
                _settings = JsonConvert.DeserializeObject<Settings>(file.ReadToEnd());
            }

            bool sairmenu = true;

            while (sairmenu)
            {
                Console.WriteLine("*****AUTENTICACAO*****\n" +
                                    "1 – Configurar Usuario / Senha\n" +
                                    "2 - Logar\n" +
                                    "3 – Limpar base\n" +
                                    "4 - Sair");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        CadastrarSenha(_settings);
                        break;
                    case 2:
                        Logar(_settings);
                        break;
                    case 3:
                        LimparBase(_settings);
                        break;
                    case 4:
                        sairmenu = Sair();
                        break;

                    default:
                        Console.WriteLine("DIGITE UMA OPCAO VALIDA !!!");
                        break;
                }
            }
        }

        static void CadastrarSenha(Settings settings)
        {
            Console.WriteLine("Qual sera o usuario ?");
            string usuario = Console.ReadLine();
            Console.WriteLine("Senha:");
            string senha = Console.ReadLine();

            Cri cript = new Cri();

            string senhacript = cript.CriptografarSenha(SHA512.Create(), senha);

            ArquivosEPastas.CriarPasta(settings);
            bool result = ArquivosEPastas.CriarEscreverArquivo(settings, usuario, senhacript);

            if (result)
            {
                Console.WriteLine("Usuario Registrado com SUCESSO !!!");
            }
            else
            {
                Console.WriteLine("Usuario FALHOU !!!");
            }

        }

        static void Logar(Settings settings)
        {
            Console.WriteLine("Digite nome de usuário:");
            string usuario = Console.ReadLine();
            Console.WriteLine("Digite senha:");
            string senha = Console.ReadLine();

            Cri cript = new Cri();
            string senhaLog = cript.CriptografarSenha(SHA512.Create(), senha);

            bool result = ArquivosEPastas.LerArquivo(settings, usuario, senhaLog);

            if (result)
                Console.WriteLine("Logado com sucesso.");
            else
                Console.WriteLine("Não foi possivel logar.");
        }

        static void LimparBase(Settings settings)
        {
            bool result = ArquivosEPastas.DeletarPasta(settings);

            if (result)
                Console.WriteLine("Base limpa com sucesso.");
            else
                Console.WriteLine("Não foi possivel limpar base.");
        }

        static bool Sair()
        {
            Console.WriteLine("Saindo...");
            return false;
        }
    }

    public class Settings
    {
        public string Caminho { get; set; }
        public string Pasta { get; set; }
        public string Arquivo { get; set; }
    }

    class Cri
    {
        public string CriptografarSenha(HashAlgorithm _algoritmo, string senha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = _algoritmo.ComputeHash(encodedValue);
            var sb = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                sb.Append(caracter.ToString("X2"));
            }
            return sb.ToString();
        }
        
    }

    public class ArquivosEPastas
    {
        public static bool CriarEscreverArquivo(Settings settings, string usuario, string senha)
        {
            try
            {
                if (!File.Exists(settings.Caminho + settings.Pasta + settings.Arquivo))
                {
                    using (StreamWriter sw = File.CreateText(settings.Caminho + settings.Pasta + settings.Arquivo))
                    {
                        sw.WriteLine(usuario);
                        sw.WriteLine(senha);
                    }
                    
                }
                else
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LerArquivo(Settings settings, string usuario, string senha)
        {
            List<string> ALista = new List<string>();

            try
            {
                using (StreamReader sr = File.OpenText(settings.Caminho + settings.Pasta + settings.Arquivo))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        ALista.Add(s);
                    }
                }

                if (ALista[0] == usuario && ALista[1] == senha)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool CriarPasta(Settings settings)
        {
            try
            {
                Directory.CreateDirectory(settings.Caminho + settings.Pasta);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public static bool DeletarPasta(Settings settings)
        {
            try
            {
                Directory.Delete(settings.Caminho + settings.Pasta, true);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
