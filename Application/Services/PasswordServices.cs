using Application.Interfaces.IServices;
using System.Security.Cryptography;

namespace Application.Services
{
    internal class PasswordServices : IPasswordService
    {
        public async Task<string> GenerateSaltAsync()
        {
            byte[] saltBytes = new byte[32]; // Adjusted to 256 bits

            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }
       

        public async Task<string> HashPasswordAsync(string password, string salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000, HashAlgorithmName.SHA256))
            {
                byte[] hashedBytes = pbkdf2.GetBytes(32); // Adjusted to a 256-bit hash output
                return   Convert.ToBase64String(hashedBytes);
            }
        }

        public async Task<bool> VerifyPasswordAsync(string password, string hashedPassword, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000, HashAlgorithmName.SHA256))
            {
                byte[] computedHash = pbkdf2.GetBytes(32); // Adjusted to a 256-bit hash output

                // Compare the computed hash with the stored hashed password
                return hashedPasswordBytes.SequenceEqual(computedHash);
            }
        }
    }
}
