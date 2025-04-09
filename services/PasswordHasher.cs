/*-----------------------------------------------------------------------------------*
 * File Name        : PasswordHasher.cs                                              *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Class responsible for hashing and verifying passwords.          *
 *-----------------------------------------------------------------------------------*/


using EMS.services;
using System.Security.Cryptography;
using System.Text;

namespace EMS.services
{
    #region PasswordHasher    
    /// <summary>
    /// Class responsible for securely hashing and verifying passwords.
    /// Implements the <see cref="IPasswordHasher"/> interface to provide hashing and verification functionality.
    /// </summary>
    /// <seealso cref="EMS.services.IPasswordHasher" />
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// Hashes the provided password using the SHA-256 algorithm.
        /// </summary>
        /// <param name="password">The password to be hashed.</param>
        /// <returns>The hashed password as a Base64-encoded string.</returns>
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Convert the password to a byte array
                var bytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash from the byte array
                var hash = sha256.ComputeHash(bytes);

                // Return the hashed value as a Base64 string
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Verifies if the provided password matches the hashed password.
        /// </summary>
        /// <param name="password">The plain-text password to verify.</param>
        /// <param name="hashPassword">The stored hashed password to compare against.</param>
        /// <returns>True if the input password matches the hash; otherwise, false.</returns>
        public bool VerifyPassword(string password, string hashPassword)
        {
            // Hash the input password and compare it to the stored hash
            var hashedInput = HashPassword(password);
            return hashedInput == hashPassword;
        }
    }
    #endregion
}
