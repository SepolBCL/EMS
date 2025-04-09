/*-----------------------------------------------------------------------------------*
 * File Name        : AuthenticationService.cs                                        *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Authentication service responsible for verifying user credentials *
 *                    and returning the user model if authentication is successful.    *
 *-----------------------------------------------------------------------------------*/


using EMS.Data;
using EMS.services;
using EMS.Services;

#region AuthServ
/// <summary>
/// Authentication service responsible for verifying user credentials.
/// </summary>
public class AuthServ : IAuthServ
{
    private readonly EMS_DBContext _dbContext;
    private readonly IPasswordHasher _passwordHasher;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthServ"/> class with the database context and the password hashing service.
    /// </summary>
    /// <param name="dbContext">The database context to access the users table.</param>
    /// <param name="passwordHasher">Service responsible for verifying and creating password hashes.</param>
    public AuthServ(EMS_DBContext dbContext, IPasswordHasher passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    /// <summary>
    /// Authenticates the user with the provided username and password.
    /// </summary>
    /// <param name="username">The username of the user to be authenticated.</param>
    /// <param name="password">The password provided by the user for authentication.</param>
    /// <returns>Returns the user model if authentication is successful, otherwise returns null.</returns>
    public User Authenticate(string username, string password)
    {
        // Searches for the user in the database with the provided username
        var userData = _dbContext.Users.SingleOrDefault(u => u.UserName == username);

        // Checks if the user does not exist or if the provided password does not match the stored password hash
        if (userData == null || !_passwordHasher.VerifyPassword(password, userData.PasswordHash))
        {
            return null; // Returns null if authentication fails
        }

        // Creates and returns a new user model with the retrieved data from the database
        var userModel = new User(userData.UserName, userData.PasswordHash);
        return userModel;
    }
}
#endregion
