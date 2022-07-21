using ConsultasERP.IWTpBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace ConsultasERP.Controller
{
    public class LogInOut
    {
        static public string tokenId = string.Empty;
        static TWRemStatus ret;
        static WTpBaseClient tpBase = new WTpBaseClient();
        static TWRemConfigLogin cfgLogin = new TWRemConfigLogin();

        public static List<object> DoLogInAlt()
        {
            List<object> lo = new List<object>();
            do
            {
                cfgLogin.Empresa = 332;
                cfgLogin.Filial = 99;  //TESTE
                cfgLogin.Alias = "DB0332_0099";
                cfgLogin.Depto = "TI";
                cfgLogin.Usuario = "CID";
                cfgLogin.Senha = "THALES10"; // TESTE
                ret = tpBase.DoLoginAlt(cfgLogin, ref tokenId);

                if (ret.Code == -2)
                {
                    MessageBox.Show(ret.Msg);
                }

            } while (ret.Code != 0);

            lo.Add(tokenId);
            lo.Add(cfgLogin);

            return lo;
        }
        public static void DoLogOut()
        {
            tpBase.DoLogout(tokenId);
        }

        public static List<object> DoLogin()
        {
            // nao funciona
            return null;
            List<object> lo = new List<object>();
            do
            {
                cfgLogin.Empresa = 332;
                cfgLogin.Filial = 1;  //TESTE
                cfgLogin.Alias = "DB0332_001";
                cfgLogin.Depto = "TI";
                cfgLogin.Usuario = "CID";
                cfgLogin.Senha = "THALES10"; // TESTE
                ret = tpBase.DoLogin(cfgLogin.Usuario, cfgLogin.Senha, ref tokenId);

                if (ret.Code == -2)
                {
                    MessageBox.Show(ret.Msg);
                }

            } while (ret.Code != 0);

            lo.Add(tokenId);
            lo.Add(cfgLogin);

            return lo;

        }

        internal static void CheckSession()
        {
            var s = tpBase.CheckSession(tokenId);
            Debug.WriteLine($@"{s.Code} >> {s.Extra} >> {s.Msg}");
        }

        internal static void GetServerHealth()
        {
            string jsonHealth = string.Empty;
            var s = tpBase.GetServerHealth(tokenId, ref jsonHealth);
            Debug.WriteLine($@"{s.Code} >> {s.Extra} >> {s.Msg} >> {jsonHealth}");
        }
    }
}
