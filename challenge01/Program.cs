using System.IO;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace challenge01_codember
{
    class chamber
    {
        static void Main(string[] args)
        {
            string users_doc = File.ReadAllText(@"C:\Users\mq-189\Desktop\example\c#\challenge01\users.txt", Encoding.UTF8);
            string[] _users  = users_doc.Split("\r\n\r\n"); // '\r' = ir al principio de la línea, '\n' = salto de línea.
            string[] campos  = { "usr:", "eme:", "psw:", "age:", "loc:", "fll:" };
            string last_valid_user = string.Empty;
            int valid_users  = 0;
            
            for(int x = 0; x < _users.Length; x++)
            {
                int contador = 0;
                for (int y = 0; y < campos.Length; y++)
                {
                    if (_users[x].IndexOf(campos[y]) != -1)
                    {
                        contador++;
                    }
                }
                if (contador == campos.Length)
                {
                    valid_users++;
                    last_valid_user = _users[x];
                }
            }

            int usr_index = last_valid_user.IndexOf("usr:");
            Console.WriteLine(valid_users + last_valid_user.Substring(usr_index + 4, last_valid_user.IndexOf(" ", usr_index + 4) - (usr_index + 4)));
        }
    }
}