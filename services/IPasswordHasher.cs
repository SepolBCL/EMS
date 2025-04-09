/*-----------------------------------------------------------------------------------*
 * File Name        : IPasswordHasher.cs                                              *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Interface for password hashing and verification.               *
 *-----------------------------------------------------------------------------------*/


using System;

namespace EMS.services
{
    /// <summary>
    /// Interface for password hashing and verification.
    /// Defines methods for securely hashing passwords and verifying them.
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        /// Hashes the provided password using a secure hashing algorithm.
        /// </summary>
        /// <param name="password">The plain-text password to hash.</param>
        /// <returns>The hashed password.</returns>
        string HashPassword(string password);

        /// <summary>
        /// Verifies whether the input password matches the stored hashed password.
        /// </summary>
        /// <param name="inputPassword">The plain-text password to verify.</param>
        /// <param name="hashPassword">The stored hashed password to compare against.</param>
        /// <returns>True if the input password matches the hash; otherwise, false.</returns>
        bool VerifyPassword(string inputPassword, string hashPassword);
    }
}
