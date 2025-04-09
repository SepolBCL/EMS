/*-----------------------------------------------------------------------------------*
 * File Name         : Event.cs                                                      *
 * Author            : Hugo Lopes                                                    *
 * Creation Date     : 26/10/2024                                                    *
 * Description       : Defines the Event class, representing an emergency event      *
 *                    or occurrence in the Emergency Management System. This class   *
 *                    maintains details such as the event's identifier, type,        *
 *                    address, dates, description, severity level, and status. It    *
 *                    also manages assigned vehicles and persons involved in the     *
 *                    event.                                                         *
 *-----------------------------------------------------------------------------------*/

using EMS.models.Vehicles;
using EMS.models.Persons;
using EMS.models.Teams;
using EMS.interfaces;
using EMS.enums;
using EMS.models.Teams;
using EMS.models.Equipments;

namespace EMS.models.Events
{
    /// <summary>
    ///  Represents an emergency event or occurrence.
    /// </summary>
    /// <seealso cref="EMS.interfaces.IEvent" />
    public class Event : IEvent
    {
        #region Propreties       
        
        public int Id { get; private set; }
        public TypeEvent Type { get; set; }
        public string Address { get; set; }
        public DateTime StartEventDate { get; set; }
        public DateTime EndEventDate { get; set; }
        public string Description { get; set; }
        public EventSeverityLevel SeverityLevel { get; set; }
        public StatusEvent Status { get; set; }
        public List<Team> TeamsInvolved { get; set; } = new List<Team>();
        public List<Vehicle> VehiclesInvolved { get; set; } = new List<Vehicle>();



        #endregion

        #region Constructors                        
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="address">The address.</param>
        /// <param name="startEventDate">The start event date.</param>
        /// <param name="endEventDate">The end event date.</param>
        /// <param name="description">The description.</param>
        /// <param name="severityLevel">The severity level.</param>
        /// <param name="status">The status.</param>
        /// <param name="teamsInvolved">The teams involved.</param>
        /// <param name="vehiclesInvolved">The vehicles involved.</param>
        public Event( TypeEvent type, string address, DateTime startEventDate, DateTime endEventDate, string description, EventSeverityLevel severityLevel, StatusEvent status)
        {
            Type = type;
            Address = address;
            StartEventDate = startEventDate;
            EndEventDate = endEventDate;
            Description = description;
            SeverityLevel = severityLevel;
            Status = status;
           

        }
        #endregion

        #region Methods         

        /// <summary>
        /// Adds a team to the event.
        /// </summary>
        /// <param name="team">The team to be added.</param>
        public void AddTeam(Team team)
        {
            TeamsInvolved.Add(team);
        }

        /// <summary>
        /// Adds a vehicle to the event.
        /// </summary>
        /// <param name="vehicle">The vehicle to be added.</param>
        public void AddVehicle(Vehicle vehicle)
        {
            VehiclesInvolved.Add(vehicle);
        }

       

        

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Id: {Id}\n" +
                   $"Type: {Type}\n" +
                   $"Address: {Address}\n" +
                   $"Start Date: {StartEventDate}\n" +
                   $"End Date: {EndEventDate}\n" +
                   $"Description: {Description}\n" +
                   $"Severity Level: {SeverityLevel}\n" +
                   $"Status: {Status}\n" +
                   $"Teams Involved: {string.Join(", ", TeamsInvolved.Select(t => t.Name))}\n" +
                   $"Vehicles Involved: {string.Join(", ", VehiclesInvolved.Select(v => v.ToString()))}\n";
                 
        }

        #endregion
    }
}
