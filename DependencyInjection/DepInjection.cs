/*-----------------------------------------------------------------------------------*
 * File Name        : DepInjection.cs                                                *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Contains the dependency injection setup for the EMS system.    *
 *-----------------------------------------------------------------------------------*/

using EMS.Data;
using EMS.Interfaces;
using EMS.services;
using EMS.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace EMS.DependencyInjection
{
    /// <summary>
    /// This class configures the dependency injection for the EMS system.
    /// It sets up all the required services that will be injected throughout the application.
    /// </summary>
    public class DepInjection
    {
        #region Dependency Injection Configuration

        /// <summary>
        /// Configures the services for dependency injection.
        /// This method registers all necessary services required by the application,
        /// including database context, logging, and other business logic services.
        /// </summary>
        /// <param name="services">The collection of services to be configured.</param>
        public static void ConfigServ(IServiceCollection services)
        {
            // Configures the database context to use SQL Server with the specified connection string.
            services.AddDbContext<EMS_DBContext>(options =>
                options.UseSqlServer("Server=LAPTOPHUGOLOPES\\SQLEXPRESS;Database=EMS;Trusted_Connection=True;Encrypt=False"));

            // Registers the DataBaseConnection as a Singleton service.
            services.AddSingleton<DataBaseConnection>(DataBaseConnection.Instance);

            // Registers business logic services with the appropriate lifetimes (Scoped).
            services.AddScoped<IAuthServ, AuthServ>();                 // Authentication service
            services.AddScoped<IPasswordHasher, PasswordHasher>();     // Password hashing service
            services.AddScoped<ICreateUser, CreateUser>();             // User creation service
            services.AddScoped<IPersonsManager, PersonsManager>();     // Person management service
            services.AddScoped<IEventsManager, EventsManager>();       // Event management service
            services.AddScoped<IEquimentsManager, EquimentsManager>(); // Equipment management service
            services.AddScoped<IVehiclesManager, VehiclesManager>();   // Vehicle management service
            services.AddScoped<ITeamsManager, TeamsManager>();         // Team management service

            // Configures logging using Serilog.
            services.AddLogging(builder =>
            {
                builder.AddSerilog(); // Adds Serilog as the logging provider
            });
        }

        #endregion
    }
}
