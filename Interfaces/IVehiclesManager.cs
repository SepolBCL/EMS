/*-----------------------------------------------------------------------------------*
 * File Name        : IVehiclesManager.cs                                             *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Interface for managing vehicles in the EMS system.              *
 *-----------------------------------------------------------------------------------*/

using EMS.models.Vehicles;


namespace EMS.Interfaces
{
    #region Interface Definition

    /// <summary>
    /// Interface for managing vehicles in the Emergency Management System (EMS).
    /// Provides methods for adding, removing, updating, and retrieving vehicles.
    /// </summary>
    public interface IVehiclesManager
    {
        #region Vehicle Management

        /// <summary>
        /// Adds a new vehicle to the system.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        public void AddVehicle(Vehicle vehicle);

        /// <summary>
        /// Removes a vehicle from the system by its registration number.
        /// </summary>
        /// <param name="carRegist">The registration number of the vehicle to remove.</param>
        public void RemoveVehicle(string carRegist);

        /// <summary>
        /// Updates an existing vehicle in the system with new information.
        /// </summary>
        /// <param name="updatedVehicle">The updated vehicle object.</param>
        public void UpdateVehicle(Vehicle updatedVehicle);

        #endregion

        #region Vehicle Retrieval

        /// <summary>
        /// Retrieves all vehicles from the system.
        /// </summary>
        /// <returns>A list of all vehicles.</returns>
        public List<Vehicle> GetAllVehicles();

        /// <summary>
        /// Retrieves a vehicle by its registration number.
        /// </summary>
        /// <param name="carRegist">The registration number of the vehicle.</param>
        /// <returns>The vehicle with the specified registration number.</returns>
        public Vehicle GetVehicleByRegist(string carRegist);

        #endregion
    }

    #endregion
}
