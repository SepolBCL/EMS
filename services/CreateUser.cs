/*-----------------------------------------------------------------------------------*
 * File Name        : CreateUserService.cs                                            *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Service responsible for creating a new user in the database,    *
 *                    verifying if the username is unique and hashing the password.   *
 *-----------------------------------------------------------------------------------*/


using EMS.Data;
using System;
using System.Linq;

namespace EMS.services
{
    #region CreateUser    
    /// <summary>
    /// Service responsible for creating a new user in the database.
    /// </summary>
    /// <seealso cref="EMS.services.ICreateUser" />
    public class CreateUser : ICreateUser
    {
        /// <summary>
        /// The database context
        /// </summary>
        private readonly EMS_DBContext _dbContext;
        /// <summary>
        /// The password hasher
        /// </summary>
        private readonly IPasswordHasher _passwordHasher;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUser"/> class with the specified database context and password hasher.
        /// </summary>
        /// <param name="dbContext">The database context used to interact with the database.</param>
        /// <param name="passwordHasher">The service responsible for hashing passwords.</param>
        public CreateUser(EMS_DBContext dbContext, IPasswordHasher passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// Creates a new user in the system after validating input and checking for username uniqueness.
        /// </summary>
        /// <param name="username">The username of the new user.</param>
        /// <param name="password">The password for the new user.</param>
        /// <exception cref="System.ArgumentException">Thrown when the username or password is empty or whitespace.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a user with the specified username already exists in the database.</exception>
        public void CreateUserx(string username, string password)
        {
            // Validate that the username and password are not empty or whitespace
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username and password cannot be empty.");
            }

            // Check if a user with the given username already exists
            if (_dbContext.Users.Any(u => u.UserName == username))
            {
                throw new InvalidOperationException("A user with this username already exists.");
            }

            // Hash the password before storing it
            var passwordHash = _passwordHasher.HashPassword(password);

            // Create a new user object
            var user = new User
            {
                UserName = username,
                PasswordHash = passwordHash
            };

            // Add the new user to the database and save changes
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
    #endregion
}
