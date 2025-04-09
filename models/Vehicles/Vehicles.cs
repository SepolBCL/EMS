/*-----------------------------------------------------------------------------------*
 * File Name        : Vehicles.cs                                                    *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 26/10/2024                                                     *
 * Description      : Defines the abstract Vehicle class, representing a vehicle in  *
 *                    the Emergency Management System.                               *
 *-----------------------------------------------------------------------------------*/

using EMS.enums;
using EMS.models.Equipments;
using EMS.models.Events;
using Utils;

namespace EMS.models.Vehicles
{
    /// <summary>
    /// Represents a generic vehicle
    /// </summary>
    public abstract class Vehicle
    {
        #region Private Properties 
        /// <summary>
        /// The age calculator
        /// </summary>
        private readonly CalAge ageCalculator = new CalAge();
        private string carRegist { get; set; }
        private DateOnly yearOfRegist { get; set; }
        private TypeVehicle type { get; set; }
        private string brand { get; set; }
        private DateOnly inspDate { get; set; }
        private StatusVehicle status { get; set; }
        
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the car regist.
        /// </summary>
        /// <value>
        /// The car regist.
        /// </value>
        public string CarRegist
        {
            get => carRegist;
            private set => carRegist = value;
        }
        public DateOnly YearOfRegist
        {
            get => yearOfRegist;
            set => yearOfRegist = value;
        }
        public int Age => CalAge.Age(YearOfRegist);
        public TypeVehicle Type
        {
            get => type;
            set => type = value;
        }
        public string Brand
        {
            get => brand;
            set => brand = value;
        }
        public DateOnly InspDate
        {
            get => inspDate;
            set => inspDate = value;
        }
        public StatusVehicle Status
        {
            get => status;
            set => status = value;
        }
        /// <summary>
        /// Equipments associated with the vehicle.
        /// This is a many-to-many relationship with Equipment.
        /// </summary>
        public List<Equipment> Equipments { get; set; } = new List<Equipment>();
        public List<Event> EventsInvolved { get; set; } = new List<Event>();


        public Vehicle() { }
        #endregion

        #region Constructors                              
        /// <summary>
        /// Initializes a new instance of the <see cref="Vehicle"/> class.
        /// </summary>
        /// <param name="carRegist">The car regist.</param>
        /// <param name="yearOfRegist">The year of regist.</param>
        /// <param name="type">The type.</param>
        /// <param name="brand">The brand.</param>
        /// <param name="inspDate">The insp date.</param>
        /// <param name="status">The status.</param>
        /// <param name="Equipments">The equipments.</param>
        public Vehicle(string carRegist,DateOnly yearOfRegist, TypeVehicle type, string brand, DateOnly inspDate, StatusVehicle status)
        {
            CarRegist = carRegist;
            YearOfRegist = yearOfRegist;
            Type = type;
            Brand = brand;
            InspDate = inspDate;
            Status = status;
           
         
        }
        #endregion

        #region Abstract Method

     
        /// <summary>
        /// Abstract method that must be implemented by any subclass.
        /// It defines the type of Vehicle.
        /// </summary>
        /// <returns>A string representing the specific type of vehicle.</returns>
        public abstract string TypeVehicles();
        #endregion
    }
}
