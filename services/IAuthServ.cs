/*-----------------------------------------------------------------------------------*
 * File Name        : IAuthService.cs                                                *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Interface for authentication service, responsible for user     *
 *                    authentication based on username and password.                 *
 *-----------------------------------------------------------------------------------*/


using EMS.models;
using EMS.services;

namespace EMS.Services
{
    /// <summary>
    /// Interface for authentication service.
    /// Responsible for verifying user credentials during the authentication process.
    /// </summary>
    public interface IAuthServ
    {
        /// <summary>
        /// Authenticates a user based on their username and password.
        /// </summary>
        /// <param name="username">The username of the user attempting to authenticate.</param>
        /// <param name="password">The password provided for authentication.</param>
        /// <returns>A <see cref="User"/> object if authentication is successful, otherwise null.</returns>
        User Authenticate(string username, string password);
    }
}
