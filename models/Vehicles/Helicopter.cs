/*-----------------------------------------------------------------------------------*
 * File Name        : Helicopter.cs                                                  *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 26/10/2024                                                     *
 * Description      : Represents a helicopter in the system, including properties    *
 *                    for maximum altitude, range, medical equipment availability,   *
 *                    and crew capacity.                                             *
 *-----------------------------------------------------------------------------------*/

using EMS.enums;
using EMS.models.Equipments;
using EMS.models.Events;

namespace EMS.models.Vehicles
{
    /// <summary>
    /// Represents an helicopeter in the system.
    /// </summary>
    /// <seealso cref="EMS.models.Vehicles.Vehicle" />
    public class Helicopter : Vehicle
    {
        #region Properties
        public int MaxAltitude { get; set; } 
        public int MaxRange { get; set; } 
        public bool HasMedicalEquipment { get; set; } 
        public int CrewCapacity { get; set; }
        #endregion

        #region Construters        
        /// <summary>
        /// Initializes a new instance of the <see cref="Helicopter"/> class.
        /// </summary>
        /// <param name="CarRegist">The car regist.</param>
        /// <param name="YearOfRegist">The year of regist.</param>
        /// <param name="Type">The type.</param>
        /// <param name="Brand">The brand.</param>
        /// <param name="InspDate">The insp date.</param>
        /// <param name="Status">The status.</param>
        /// <param name="MaxAltitude">The maximum altitude.</param>
        /// <param name="MaxRange">The maximum range.</param>
        /// <param name="HasMedicalEquipment">if set to <c>true</c> [has medical equipment].</param>
        /// <param name="CrewCapacity">The crew capacity.</param>
        public Helicopter(string CarRegist, DateOnly YearOfRegist, TypeVehicle Type, string Brand, DateOnly InspDate, StatusVehicle Status,
                          int MaxAltitude, int MaxRange, bool HasMedicalEquipment, int CrewCapacity)
           : base(CarRegist, YearOfRegist, Type, Brand, InspDate, Status)
        {
            this.MaxAltitude = MaxAltitude;
            this.MaxRange = MaxRange;
            this.HasMedicalEquipment = HasMedicalEquipment;
            this.CrewCapacity = CrewCapacity;

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Abstract method that must be implemented by any subclass.
        /// It defines the type of Vehicle.
        /// </summary>
        /// <returns>
        /// A string representing the specific type of vehicle.
        /// </returns>
        public override string TypeVehicles()
        {
            return  $"Helicopter-register:{CarRegist}" +
                    $"Year Of Registration:{YearOfRegist}" +
                    $"Age: {Age}" +
                    $"Type:{Type}" +
                    $"Brand: {Brand}" +
                    $"Inspetion Date:{InspDate}" +
                    $"Status{Status}"+
                    $"Max Altitude: {MaxAltitude} meters\n" +
                    $"Max Range: {MaxRange} km\n" +
                    $"Has Medical Equipment: {HasMedicalEquipment}\n" +
                    $"Crew Capacity: {CrewCapacity} people\n";
        }
        #endregion
    }
}
