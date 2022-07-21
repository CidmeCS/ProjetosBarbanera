

namespace PCP.DAO

{
    internal class StringConexao
    {
        internal static string sCon()
        {
            string Estoque = "Server = 192.168.0.60;Database=estoque;Uid=root;Pwd=root;default command timeout=360";
            string Synology = "Server = cidme.synology.me;Database=estoque;Uid=root;Pwd=Th@les1010;default command timeout=360";
            return Estoque;

        }
    }
}