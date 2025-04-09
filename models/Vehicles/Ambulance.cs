/*-------------------------------------------------------------------------------------*
 * File Name        : Ambulance.cs                                                     *
 * Author           : Hugo Lopes                                                       *
 * Creation Date    : 26/10/2024                                                       *
 * Description      : Defines the Ambulance class, representing an ambulance in the    *
 *                    Emergency Management System. It includes properties for crew     *
 *                    capacity and overrides the method for displaying vehicle details.*
 *-------------------------------------------------------------------------------------*/

using EMS.enums;
using EMS.models.Equipments;
using EMS.models.Events;

namespace EMS.models.Vehicles
{
    /// <summary>
    /// Represents an ambulance in the system. 
    /// </summary>
    /// <seealso cref="EMS.models.Vehicles.Vehicle" />
    public class Ambulance : Vehicle
        {
        #region Properties
        public int CrewCapacity { get; set; } // Capacidade de tripulação

        #endregion

        #region Construters       
        /// <summary>
        /// Initializes a new instance of the <see cref="Ambulance"/> class.
        /// </summary>
        /// <param name="CarRegist">The car regist.</param>
        /// <param name="YearOfRegist">The year of regist.</param>
        /// <param name="Type">The type.</param>
        /// <param name="Brand">The brand.</param>
        /// <param name="InspDate">The insp date.</param>
        /// <param name="Status">The status.</param>
        /// <param name="CrewCapacity">The crew capacity.</param>
        public Ambulance(string CarRegist, DateOnly YearOfRegist, TypeVehicle Type, string Brand, DateOnly InspDate, StatusVehicle Status, int CrewCapacity)
           : base(CarRegist, YearOfRegist, Type, Brand, InspDate, Status)
        {
            this.CrewCapacity = CrewCapacity;

        }

        #endregion

        #region Metodhs

        /// <summary>
        /// Types the vehicles.
        /// </summary>
        /// <returns>A string containing the ambulance's details.</returns>
        public override string TypeVehicles()
        {
            return  $"Vehicle register:{CarRegist}\n" +
                    $"Year Of Registration:{YearOfRegist}\n" +
                    $"Age: {Age} \n" +
                    $"Type:{Type} \n" +
                    $"Brand: {Brand} \n" +
                    $"Inspetion Date: {InspDate} \n" +
                    $"Status: {Status} \n"+
                    $"Crew Capacity: {CrewCapacity}\n";
        }
        #endregion
    }
}
