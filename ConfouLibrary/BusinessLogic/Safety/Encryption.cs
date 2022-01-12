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


        /// <summary>
        /// Шифрование пароля
        /// </summary>
        /// <param name="password">Пароль</param>
        /// <param name="salt">Соль для пароля</param>
        /// <returns>Зашифрованный пароль</returns>
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


        /// <summary>
        /// Подтверждение пароля
        /// </summary>
        /// <param name="enteredPassword">Пароль на проверку</param>
        /// <param name="salt">Соль</param>
        /// <param name="storedPassword">Хранящийся пароль</param>
        /// <returns></returns>
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
