/*-----------------------------------------------------------------------------------*
 * File Name        : FireTruck.cs                                                   *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 26/10/2024                                                     *
 * Description      : Defines the FireTruck class, representing a fire truck in the  *
 *                    Emergency Management System. It includes properties for water   *
 *                    tank capacity and crew capacity.                               *
 *-----------------------------------------------------------------------------------*/

using EMS.enums;
using EMS.models.Equipments;
using EMS.models.Events;

namespace EMS.models.Vehicles
{
    /// <summary>
    /// Represents a firetruk in the system.
    /// </summary>
    /// <seealso cref="EMS.models.Vehicles.Vehicle" />
    public class FireTruck : Vehicle
    {
        #region Properties
        /// <summary>
        /// Gets or sets the water tank capacity.
        /// </summary>
        /// <value>
        /// The water tank capacity.
        /// </value>
        public int WaterTankCapacity { get; set; }
        public int CrewCapacity { get; set; }
        #endregion

        #region Construters

        /// <summary>
        /// Initializes a new instance of the <see cref="FireTruck"/> class.
        /// </summary>
        /// <param name="CarRegist">The car regist.</param>
        /// <param name="YearOfRegist">The year of regist.</param>
        /// <param name="Type">The type.</param>
        /// <param name="Brand">The brand.</param>
        /// <param name="InspDate">The insp date.</param>
        /// <param name="Status">The status.</param>
        /// <param name="WaterTankCapacity">The water tank capacity.</param>
        /// <param name="CrewCapacity">The crew capacity.</param>
        public FireTruck(string CarRegist, DateOnly YearOfRegist, TypeVehicle Type, string Brand, DateOnly InspDate, StatusVehicle Status, int WaterTankCapacity, int CrewCapacity)
           : base(CarRegist, YearOfRegist, Type, Brand, InspDate, Status)
        {
            this.WaterTankCapacity = WaterTankCapacity;
            this.CrewCapacity = CrewCapacity;

        }
        #endregion

        #region Metodhs              
        /// <summary>
        /// Types the vehicles.
        /// </summary>
        /// <returns>A string containing the firetrukc's details.</returns>
        public override string TypeVehicles()
        {
            return $"Vehicle register:{CarRegist}\n" +
                    $"Year Of Registration:{YearOfRegist}\n" +
                    $"Age: {Age}\n" +
                    $"Type:{Type} \n" +
                    $"Brand: {Brand} \n" +
                    $"Inspetion Date:{InspDate} \n" +
                    $"Status: {Status} \n"+
                    $"Water Thank Capacity:{WaterTankCapacity} \n"+
                    $"Crew Capacity: {CrewCapacity} people\n";
        }
        #endregion
    }
}
