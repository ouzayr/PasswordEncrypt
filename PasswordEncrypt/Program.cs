using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordEncrypt
{
    class Program
    {
        static string choice = "";

        static void Main(string[] args)
        {
            Console.Title = "Password Encrypt by Ouzayr";
            Console.WriteLine("******************************************************************");
            Console.WriteLine("***    Project : String encryption MD5 & SHA256");
            Console.WriteLine("***    Author  : Ouzayr Khedun");
            Console.WriteLine("***    Email   : Ouzayr@gmail.com");
            Console.WriteLine("***    Date    : June 2018");
            Console.WriteLine("***");
            Console.WriteLine("******************************************************************");
            Console.WriteLine();

            Console.Write("Enter string/password:");
            string password = Console.ReadLine();

            string md5 = GetMD5HashData(password);
            string sha = GetSHA256HashData(password);
            string md5sha = GetSHA256HashData(md5);
            string shamd5 = GetMD5HashData(sha);
            
            Console.WriteLine("Pass: " + password);
            Console.WriteLine("MD5: " + md5);
            Console.WriteLine("SHA256: " + sha);
            Console.WriteLine("MD5 + SHA256: " + md5sha);
            Console.WriteLine("SHA256 + MD5: " + shamd5);


            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        static string GetMD5HashData(string data)
        {
            //create new instance of md5
            MD5 md5 = MD5.Create();

            //convert the input text to array of bytes
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();

        }

        static string GetSHA256HashData(string data)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(data));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
