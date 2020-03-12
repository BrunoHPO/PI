using System;

namespace Lista_01___Modulo_02
{
    class Program
    {
        static void Main(string[] args)
        {                    
            bool sair = true;
            while (sair)
            {
                Console.WriteLine("AUTENTICACAO\n" +
                                    "1 - Usar conta do Gmail\n" +
                                    "2 - Usar conta do Facebook\n" +
                                    "3 - Usar conta do Instagram\n" +
                                    "4 - SAIR");
                int opcao = (Convert.ToInt32(Console.ReadLine()))- 1;
                TipoEmail opt = (TipoEmail)opcao;
                switch (opt)
                {
                    case TipoEmail.Gmail:
                        Console.WriteLine("Qual o Usuario ?");
                        string usuarioG = Console.ReadLine();
                        Console.WriteLine("SENHA:");
                        dynamic senhaG = Console.ReadLine();
                        LoginGmail objG = new LoginGmail();
                        bool resultadoG = objG.Login(usuarioG, senhaG);
                        if (resultadoG)
                            Console.WriteLine("Login GMAIL realizado - "+ DateTime.Now);
                        else
                            Console.WriteLine("Login GMAIL falhou - " + DateTime.Now);
                        bool logoutG = objG.Logout(resultadoG);
                        if (logoutG)
                            Console.WriteLine("LoginOUT GMAIL realizado.");
                        else
                            Console.WriteLine("Nao ha nenhum usuario GMAIL logado.");
                        break;

                    case TipoEmail.Facebook:
                        Console.WriteLine("Qual o Usuario ?");
                        string usuarioF = Console.ReadLine();
                        Console.WriteLine("SENHA:");
                        dynamic senhaF = Console.ReadLine();
                        LoginFacebook objF = new LoginFacebook();
                        bool resultadoF = objF.Login(usuarioF, senhaF);
                        if (resultadoF)
                            Console.WriteLine("Login FACEBOOK realizado - " + DateTime.Now);
                        else
                            Console.WriteLine("Login FACEBOOK falhou - " + DateTime.Now);
                        bool logoutF = objF.Logout(resultadoF);
                        if (logoutF)
                            Console.WriteLine("LoginOUT FACEBOOK realizado.");
                        else
                            Console.WriteLine("Nao ha nenhum usuario FACEBOOK logado.");

                        break;

                    case TipoEmail.Instagram:
                        Console.WriteLine("Qual o Usuario ?");
                        string usuarioI = Console.ReadLine();
                        Console.WriteLine("SENHA:");
                        dynamic senhaI = Console.ReadLine();
                        LoginInstagram objI = new LoginInstagram();
                        bool resultadoI = objI.Login(usuarioI, senhaI);
                        if (resultadoI)
                            Console.WriteLine("Login INSTAGRAM realizado - " + DateTime.Now);
                        else
                            Console.WriteLine("Login INSTRAGRAM falhou - " + DateTime.Now);
                        bool logoutI = objI.Logout(resultadoI);
                        if (logoutI)
                            Console.WriteLine("LoginOUT INSTRAGRAM realizado com overloading.");
                        else
                            Console.WriteLine("Nao ha nenhum usuario INSTRAGRAM logado com overloading.");
                        break;

                    case TipoEmail.Sair:
                        sair = false;
                        break;                    
                }
            }
        }
    }

    public abstract class SuperLogin
    {
        public abstract bool Login(string usuario, dynamic senha);
        public abstract bool Logout(bool logado);
        protected virtual bool Autentica(string usuario, dynamic senha, TipoEmail tipo)
        {
            string usuarioGG = "google";
            var senhaGG = 1234;

            string usuarioFF = "facebook";
            var senhaFF = 3456;

            if (tipo == TipoEmail.Gmail)
            {
                if ((usuario == usuarioGG) && (senha == Convert.ToString(senhaGG)))
                    return true;
                else
                    return false;
            }
            else if (tipo == TipoEmail.Facebook)
            {
                if ((usuario == usuarioFF) && (senha == Convert.ToString(senhaFF)))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }

    public class LoginGmail : SuperLogin
    {
        public override bool Login(string usuario, dynamic senha)
        {
            bool resultadoVal = Autentica(usuario, senha, TipoEmail.Gmail);
            if (resultadoVal)
                return true;
            else
                return false;
        }

        public override bool Logout(bool logado)
        {
            if (logado)
                return true;
            else
                return false;
        }
    }

    public class LoginFacebook : SuperLogin
    {
        public override bool Login(string usuario, dynamic senha)
        {
            bool resultadoVal = Autentica(usuario, senha, TipoEmail.Facebook);
            if (resultadoVal)
                return true;
            else
                return false;
        }

        public override bool Logout(bool logado)
        {
            if (logado)
                return true;
            else
                return false;
        }
    }

    public class LoginInstagram : SuperLogin
    {
        public override bool Login(string usuario, dynamic senha)
        {
            bool resultadoVal = Autentica(usuario, senha, TipoEmail.Instagram);
            if (resultadoVal)
                return true;
            else
                return false;
        }

        public override bool Logout(bool logado)
        {
            if (logado)
                return true;
            else
                return false;
        }

        protected override bool Autentica(string usuario, dynamic senha, TipoEmail tipo)
        {
            string usuarioII = "instagram";
            var senhaII = 5678;

            if (tipo == TipoEmail.Instagram)
            {
                if ((usuario == usuarioII) && (senha == Convert.ToString(senhaII)))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }

    public enum TipoEmail
    {
        Gmail,
        Facebook,
        Instagram,        
        Sair
    }
}
