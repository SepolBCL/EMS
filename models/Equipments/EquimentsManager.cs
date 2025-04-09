/*-----------------------------------------------------------------------------------*
 * File Name         : EquipmentManager.cs                                           *
 * Author            : Hugo Lopes                                                    *
 * Creation Date     : 26/10/2024                                                    *
 * Description       : Manages a collection of equipment used in rescue activities.  *
 *                    This class provides methods to add, remove, and list equipment.*
 *-----------------------------------------------------------------------------------*/
using EMS.models.Vehicles;
using EMS.models.Equipments;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using EMS.Data;
using EMS.Interfaces;

namespace EMS.services
{
    /// <summary>
    /// Manages equipment and vehicles within the emergency management system.
    /// </summary>
    public class EquimentsManager : IEquimentsManager
    {
        #region Properties

        private readonly EMS_DBContext _dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EquimentsManager"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public EquimentsManager(EMS_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new equipment to the system.
        /// </summary>
        /// <param name="equipment">The equipment to add.</param>
        public void AddEquipment(Equipment equipment)
        {
            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment));

            _dbContext.Equipments.Add(equipment);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Removes equipment from the system.
        /// </summary>
        /// <param name="equipment">The equipment to remove.</param>
        public void RemoveEquipment(Equipment equipment)
        {
            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment));

            _dbContext.Equipments.Remove(equipment);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Adds equipment to a specific vehicle.
        /// </summary>
        /// <param name="vehicleCarRegist">The vehicle registration number.</param>
        /// <param name="equipment">The equipment to add.</param>
        public void AddEquipmentToVehicle(string vehicleCarRegist, Equipment equipment)
        {
            if (string.IsNullOrEmpty(vehicleCarRegist))
                throw new ArgumentException("Vehicle registration number cannot be null or empty.", nameof(vehicleCarRegist));

            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment));

            // Retrieve the vehicle from the database
            var Vehicle = _dbContext.Vehicles.FirstOrDefault(v => v.CarRegist == vehicleCarRegist);

            if (Vehicle == null)
                throw new InvalidOperationException($"Vehicle with registration number {vehicleCarRegist} not found.");

            // Add the equipment to the vehicle
            Vehicle.Equipments.Add(equipment); // Assuming Vehicle has an Equipments collection

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Removes equipment from a specific vehicle.
        /// </summary>
        /// <param name="vehicleCarRegist">The vehicle registration number.</param>
        /// <param name="equipment">The equipment to remove.</param>
        public void RemoveEquipmentFromVehicle(string vehicleCarRegist, Equipment equipment)
        {
            if (string.IsNullOrEmpty(vehicleCarRegist))
                throw new ArgumentException("Vehicle registration number cannot be null or empty.", nameof(vehicleCarRegist));

            if (equipment == null)
                throw new ArgumentNullException(nameof(equipment));

            // Retrieve the vehicle from the database
            var vehicle = _dbContext.Vehicles
                                    .Include(v => v.Equipments)  // Assuming the Vehicle has a navigation property for Equipments
                                    .FirstOrDefault(v => v.CarRegist == vehicleCarRegist);

            if (vehicle == null)
                throw new InvalidOperationException($"Vehicle with registration number {vehicleCarRegist} not found.");

            // Check if the equipment is assigned to the vehicle
            if (!vehicle.Equipments.Any(e => e.Id == equipment.Id))
                throw new InvalidOperationException("This equipment is not assigned to the vehicle.");

            // Remove the equipment from the vehicle
            vehicle.Equipments.Remove(equipment);

            // Save changes to the database
            _dbContext.SaveChanges();
        }





        /// <summary>
        /// Lists all equipment associated with a specific vehicle.
        /// </summary>
        /// <param name="vehicleCarRegist">The vehicle registration number.</param>
        public List<Equipment> ListEquipmentsForVehicle(string vehicleCarRegist)
        {
            if (string.IsNullOrEmpty(vehicleCarRegist))
                throw new ArgumentException("Vehicle registration number cannot be null or empty.", nameof(vehicleCarRegist));

            // Retrieve the vehicle from the database
            var vehicle = _dbContext.Vehicles
                                    .Include(v => v.Equipments)  // Assuming the Vehicle has a navigation property for Equipments
                                    .FirstOrDefault(v => v.CarRegist == vehicleCarRegist);

            if (vehicle == null)
                throw new InvalidOperationException($"Vehicle with registration number {vehicleCarRegist} not found.");

            return vehicle.Equipments.ToList(); // Return the list of equipments associated with the vehicle
        }

        #endregion
    }
}
