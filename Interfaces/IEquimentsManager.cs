/*-----------------------------------------------------------------------------------*
 * File Name        : IEquimentsManager.cs                                           *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Interface for managing equipment in the EMS system.             *
 *-----------------------------------------------------------------------------------*/

using EMS.models.Equipments;


namespace EMS.Interfaces
{
    #region Interface Definition

    /// <summary>
    /// Interface for managing equipment in the Emergency Management System (EMS).
    /// It provides methods for adding, removing, and listing equipment, as well as associating equipment with vehicles.
    /// </summary>
    public interface IEquimentsManager
    {
        #region Add Equipment

        /// <summary>
        /// Adds a new piece of equipment to the system.
        /// </summary>
        /// <param name="equipment">The equipment to add.</param>
        public void AddEquipment(Equipment equipment);

        #endregion

        #region Remove Equipment

        /// <summary>
        /// Removes a piece of equipment from the system.
        /// </summary>
        /// <param name="equipment">The equipment to remove.</param>
        public void RemoveEquipment(Equipment equipment);

        #endregion

        #region Equipment-vehicle Management

        /// <summary>
        /// Adds equipment to a specific vehicle by its registration number.
        /// </summary>
        /// <param name="vehicleCarRegist">The vehicle registration number.</param>
        /// <param name="equipment">The equipment to add.</param>
        public void AddEquipmentToVehicle(string vehicleCarRegist, Equipment equipment);

        /// <summary>
        /// Removes equipment from a specific vehicle by its registration number.
        /// </summary>
        /// <param name="vehicleCarRegist">The vehicle registration number.</param>
        /// <param name="equipment">The equipment to remove.</param>
        public void RemoveEquipmentFromVehicle(string vehicleCarRegist, Equipment equipment);

        #endregion

        #region List Equipment for Vehicle

        /// <summary>
        /// Lists all equipment associated with a specific vehicle by its registration number.
        /// </summary>
        /// <param name="vehicleCarRegist">The vehicle registration number.</param>
        /// <returns>A list of equipment associated with the vehicle.</returns>
        public List<Equipment> ListEquipmentsForVehicle(string vehicleCarRegist);

        #endregion
    }

    #endregion
}
