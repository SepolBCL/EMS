/*-----------------------------------------------------------------------------------*
 * File Name        : ICreateUser.cs                                                 *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Interface for creating a new user, handling username and       *
 *                    password validation and storage.                               *
 *-----------------------------------------------------------------------------------*/


using System;

namespace EMS.services
{
    /// <summary>
    /// Interface for the user creation service.
    /// Defines the contract for creating a new user in the system.
    /// </summary>
    public interface ICreateUser
    {
        /// <summary>
        /// Creates a new user with the specified username and password.
        /// </summary>
        /// <param name="username">The username for the new user.</param>
        /// <param name="password">The password for the new user.</param>
        /// <exception cref="ArgumentException">Thrown if the username or password is empty.</exception>
        /// <exception cref="InvalidOperationException">Thrown if a user with the specified username already exists.</exception>
        void CreateUserx(string username, string password);
    }
}

