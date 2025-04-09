/*-----------------------------------------------------------------------------------*
 * File Name        : User.cs                                                        *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Defines the User class, which represents a user in the system. *
 *-----------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.services
{
    /// <summary>
    /// Represents a user in the system.
    /// Contains properties for the user ID, username, and hashed password.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the hashed password of the user.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="userName">The username of the user.</param>
        /// <param name="passwordHash">The hashed password for the user.</param>
        public User(string userName, string passwordHash)
        {
            UserName = userName;
            PasswordHash = passwordHash;
        }

        /// <summary>
        /// Initializes a new, empty instance of the <see cref="User"/> class.
        /// This constructor is typically used for database queries and object mapping.
        /// </summary>
        public User() { }
    }
}
