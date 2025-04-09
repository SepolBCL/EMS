/*-----------------------------------------------------------------------------------*
 * File Name        : EMS_DBContextFactory.cs                                         *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Factory class for creating instances of the EMS_DBContext       *
 *-----------------------------------------------------------------------------------*/

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EMS.Data
{
    #region EMS_DBContext Factory Class

    /// <summary>
    /// Factory class used to create instances of the <see cref="EMS_DBContext"/>.
    /// This is required by the design-time services for the Entity Framework Core tools,
    /// which use it to perform database migrations and other design-time tasks.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory&lt;EMS.Data.EMS_DBContext&gt;" />
    public class EMS_DBContextFactory : IDesignTimeDbContextFactory<EMS_DBContext>
    {
        #region CreateDbContext Method

        /// <summary>
        /// Creates a new instance of the <see cref="EMS_DBContext"/> with the appropriate options.
        /// This method is called at design time by tools like EF Core migrations.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service (usually empty).</param>
        /// <returns>An instance of the <see cref="EMS_DBContext"/>.</returns>
        public EMS_DBContext CreateDbContext(string[] args)
        {
            // Set up the options for the DbContext, specifying the database connection string
            var optionsBuilder = new DbContextOptionsBuilder<EMS_DBContext>();

            // Define the SQL Server connection string for the EMS database
            optionsBuilder.UseSqlServer("Server=LAPTOPHUGOLOPES\\SQLEXPRESS;Database=EMS;Trusted_Connection=True;Encrypt=False");

            // Return a new instance of the EMS_DBContext with the configured options
            return new EMS_DBContext(optionsBuilder.Options);
        }

        #endregion
    }

    #endregion
}

