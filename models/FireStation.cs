/*-----------------------------------------------------------------------------------*
 * File Name        : FireStation.cs                                                 *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 26/10/2024                                                     *
 * Description      : Defines the FireStation class, representing a fire station in  *
 *                    the Emergency Management System, managing persons,vehicles,    *
 *                    and equipment.                                                 *
 *-----------------------------------------------------------------------------------*/

using EMS.models.Persons;
using EMS.models.Vehicles;
using EMS.models.Equipments;
using EMS.models.Events;
using Microsoft.EntityFrameworkCore;
using EMS.Data;

namespace EMS.models
{
    /// <summary>
    /// Represents a fire station within the EMS, 
    /// managing resources such as personnel, vehicles, 
    /// and equipment.
    /// </summary>
    public class FireStation
    {
        #region Propreties        
        private readonly EMS_DBContext _DBContext;
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Location { get; set; } 
        public List<FireFighter> FireFighters { get; private set; }
        public List<Doctor> Doctors { get; private set; }
        public List<Nurse> Nurses { get; private set; }
        public List<Paramedic> Paramedics { get; private set; }
        public List<Patient> Patients { get; private set; }
        public List<Vehicle> FireTrucks { get; private set; }
        public List<Vehicle> Ambulance { get; private set; }
        public List<Vehicle> MotorBike { get; private set; }
        public List<Vehicle> Helicopter { get; private set; }
        public List<Equipment> Equipment { get; private set; }
        #endregion

        #region Construters                       
        /// <summary>
        /// Initializes a new instance of the <see cref="FireStation"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="location">The location.</param>
        public FireStation(string name, string location,EMS_DBContext _dbContext)
        {
            _DBContext = _dbContext;
            Name = name;
            Location = location;
            FireFighters = new List<FireFighter>();
            Doctors = new List<Doctor>();
            Nurses = new List<Nurse>();
            Patients = new List<Patient>();
            FireTrucks = new List<Vehicle>();
            Ambulance = new List<Vehicle>();
            MotorBike = new List<Vehicle>();
            Helicopter = new List<Vehicle>();
            Equipment = new List<Equipment>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the fire fighter.
        /// </summary>
        /// <param name="fireFighter">The fire fighter.</param>
        public void AddFireFighter(FireFighter fireFighter){}

        /// <summary>
        /// Adds the doctor.
        /// </summary>
        /// <param name="doctor">The doctor.</param>
        public void AddDoctor(Doctor doctor){}

        /// <summary>
        /// Adds the nurse.
        /// </summary>
        /// <param name="nurse">The nurse.</param>
        public void AddNurse(Nurse nurse){}

        /// <summary>
        /// Adds the fire truck.
        /// </summary>
        /// <param name="fireTruck">The fire truck.</param>
        public void AddFireTruck(Vehicle fireTruck){}
        /// <summary>
        /// Adds the ambulance.
        /// </summary>
        /// <param name="ambulance">The ambulance.</param>
        public void AddAmbulance(Vehicle ambulance){}
        /// <summary>
        /// Adds the motor bike.
        /// </summary>
        /// <param name="motorBike">The motor bike.</param>
        public void AddMotorBike(Vehicle motorBike){}
        /// <summary>
        /// Adds the helicopter.
        /// </summary>
        /// <param name="helicopter">The helicopter.</param>
        public void AddHelicopter(Vehicle helicopter){}

        /// <summary>
        /// Adds the equipment.
        /// </summary>
        /// <param name="equipment">The equipment.</param>
        public void AddEquipment(Equipment equipment){}

        /// <summary>
        /// Responds to emergency.
        /// </summary>
        /// <param name="fireEvent">The fire event.</param>
        public void RespondToEmergency(FireEvent fireEvent){}
        #endregion
    }
}
