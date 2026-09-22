using System;
using System.Security.Cryptography;

namespace AtlantisBank_BLL
{
    public class clsPasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 400000;

        public static void HashPassword(string password, out string passwordHash, out string passwordSalt)
        {
            byte[] salt = new byte[SaltSize];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                passwordSalt = Convert.ToBase64String(salt);
                passwordHash = Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string password, string passwordHash, string passwordSalt)
        {
            byte[] salt = Convert.FromBase64String(passwordSalt);
            byte[] storedHash = Convert.FromBase64String(passwordHash);

            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA256))
            {
                byte[] computedHash = pbkdf2.GetBytes(HashSize);

                if (computedHash.Length != storedHash.Length)
                    return false;

                int result = 0;

                for (int i = 0; i < computedHash.Length; i++)
                {
                    result |= computedHash[i] ^ storedHash[i];
                }

                return result == 0;
            }
        }
    }
}