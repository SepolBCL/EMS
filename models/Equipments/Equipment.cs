/*-----------------------------------------------------------------------------------*
 * File Name         : Equipment.cs                                                  *
 * Author            : Hugo Lopes                                                    *
 * Creation Date     : 26/10/2024                                                    *
 * Description       : Represents an equipment item used in rescue activities.       *
 *                    This class contains properties for the equipment's identifier, *
 *                    name, description, quantity, maintenance date, and status.     *
 *-----------------------------------------------------------------------------------*/

using EMS.enums;
using EMS.models.Vehicles;

namespace EMS.models.Equipments
{
        
    /// <summary>
    /// Represents an equipment item used in rescue activities. 
    /// </summary>
    public class Equipment
    {
        #region Propreties
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public DateOnly MaintenanceDate { get; set; }
        public StatusEquipment Status { get; set; }
        
        // Many-to-Many relationship with Vehicle
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        #endregion

        #region Constructors                
        /// <summary>
        /// Initializes a new instance of the <see cref="Equipment"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="maintenanceDate">The maintenance date.</param>
        /// <param name="status">The status.</param>
        public Equipment(string name, string description, int quantity, DateOnly maintenanceDate, StatusEquipment status)
        {
            
            Name = name;
            Description = description;
            Quantity = quantity;
            MaintenanceDate = maintenanceDate;
            Status = status;

        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return  $"Id: {Id}\n" +
                    $"Name:{Name}\n" +
                    $"Description:{Description}\n" +
                    $"Quantity: {Quantity}\n" +
                    $"Maintenaince: {MaintenanceDate}\n" +
                    $"Status: {Status}\n";
        }
        #endregion
    }
}
