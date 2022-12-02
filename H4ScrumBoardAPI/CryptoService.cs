using System.Security.Cryptography;

namespace H4ScrumBoardAPI
{
    public class CryptoService : ICrypto
    {
        public byte[] GenerateSalt()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[32];
            rng.GetBytes(salt);

            return salt;
        }
        public byte[] CreateHash(string password, byte[] salt)
        {
            using (Rfc2898DeriveBytes hashgenerator = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256))
            {
                return hashgenerator.GetBytes(32);
            }
        }

        public bool Verify(string passwordfromdb, string passwordprovided, byte[] salt)
        {
            passwordprovided = Convert.ToBase64String(CreateHash(passwordprovided, salt));
            if (passwordprovided == passwordfromdb)
                return true;
            return false;
        }
    }
}
