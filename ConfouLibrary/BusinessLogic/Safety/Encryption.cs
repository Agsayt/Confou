using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfouLibrary.BusinessLogic.Safety
{
    internal class Encryption
    {
        public static string EncryptPassword(string password, string salt)
        {
            byte[] saltToByte = Encoding.UTF8.GetBytes(salt);

            string encryptedPassw = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltToByte,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
            return encryptedPassw;
        }

        public static bool VerifyPassword(string enteredPassword, string salt, string storedPassword)
        {
            byte[] saltToByte = Convert.FromBase64String(salt);

            string encryptedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: enteredPassword,
                salt: saltToByte,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));
            return encryptedPassword == storedPassword;
        }
    }
}
