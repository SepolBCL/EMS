/*-----------------------------------------------------------------------------------*
 * File Name        : VehiclesManager.cs                                             *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 26/10/2024                                                     *
 * Description      : Class for managing vehicles in the Emergency Management System.*
 *-----------------------------------------------------------------------------------*/

using EMS.Data;
using EMS.Interfaces;
using EMS.models.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace EMS.services
{
    /// <summary>
    /// Manages a collection of vehicles within the Emergency Management System.
    /// </summary>
    public class VehiclesManager : IVehiclesManager
    {
        #region Properties

        private readonly EMS_DBContext _dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VehiclesManager"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public VehiclesManager(EMS_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new vehicle to the database.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            _dbContext.Vehicles.Add(vehicle);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Removes a vehicle from the database by its registration number.
        /// </summary>
        /// <param name="carRegist">The registration number of the vehicle to remove.</param>
        public void RemoveVehicle(string carRegist)
        {
            var vehicleToRemove = _dbContext.Vehicles.SingleOrDefault(v => v.CarRegist == carRegist);

            if (vehicleToRemove == null)
                throw new KeyNotFoundException($"No vehicle found with registration number {carRegist}.");

            _dbContext.Vehicles.Remove(vehicleToRemove);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates an existing vehicle in the database.
        /// </summary>
        /// <param name="updatedVehicle">The updated vehicle object.</param>
        public void UpdateVehicle(Vehicle updatedVehicle)
        {
            if (updatedVehicle == null)
                throw new ArgumentNullException(nameof(updatedVehicle));

            var existingVehicle = _dbContext.Vehicles.Find(updatedVehicle.CarRegist);

            if (existingVehicle == null)
                throw new KeyNotFoundException($"No vehicle found with ID {updatedVehicle.CarRegist}.");

            _dbContext.Entry(existingVehicle).CurrentValues.SetValues(updatedVehicle);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Retrieves all vehicles from the database.
        /// </summary>
        /// <returns>A list of all vehicles.</returns>
        public List<Vehicle> GetAllVehicles()
        {
            return _dbContext.Vehicles.ToList();
        }

        /// <summary>
        /// Retrieves a vehicle by its registration number.
        /// </summary>
        /// <param name="carRegist">The registration number of the vehicle.</param>
        /// <returns>The vehicle with the specified registration number.</returns>
        public Vehicle GetVehicleByRegist(string carRegist)
        {
            var vehicle = _dbContext.Vehicles.SingleOrDefault(v => v.CarRegist == carRegist);

            if (vehicle == null)
                throw new KeyNotFoundException($"No vehicle found with registration number {carRegist}.");

            return vehicle;
        }

        #endregion
    }
}
