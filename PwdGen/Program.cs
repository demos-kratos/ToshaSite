using System;
using System.Security.Cryptography;
using System.Text;
using static System.Console;
namespace PwdGen
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введи пароль");
            var password = ReadLine();

            var r = new Random();
            var bytes = new byte[32];
            r.NextBytes(bytes);

            using var sha = SHA256.Create();
            var salt = Convert.ToBase64String(bytes).Replace("=", "").Replace("+", "").Replace("/", "");
            var hash = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(password + salt))).Replace("-", "");
            WriteLine($"PwdHash: {hash}\nPwdSalt: {salt}");
        }
    }
}
