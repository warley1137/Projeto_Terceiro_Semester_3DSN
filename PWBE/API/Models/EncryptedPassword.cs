﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace APP.Models
{
    public class EncryptedPassword
    {

        public static string[] Encrypted(string senha)
        {
            string[] pwdSH = new string[2];

            // Generate a 128-bit salt using a sequence of
            // cryptographically strong random bytes.
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
            //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: senha!,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            //Console.WriteLine($"Hashed: {hashed}");

            pwdSH[0] = Convert.ToBase64String(salt);
            pwdSH[1] = hashed;

            return pwdSH;
        }

        public static string EncryptedNoSalt(string senha, string userSalt)
        {
            string hashed = "";

            try
            {
                byte[] salt = Convert.FromBase64String(userSalt);

                // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

                //Console.WriteLine($"Hashed: {hashed}");
            }
            catch (ArgumentNullException) { }
           
            return hashed;
        }
    }
}
