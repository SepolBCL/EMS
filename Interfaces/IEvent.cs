/*-----------------------------------------------------------------------------------*
 * File Name        : IEvent.cs                                                      *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 26/10/2024                                                     *
 * Description      : Interface for defining properties and actions related to       *
 *                    emergency events. It includes event details such as type,      *
 *                    address, dates, severity, and status, allowing for             *
 *                    management and classification of various emergency types.      *
 *-----------------------------------------------------------------------------------*/

using EMS.enums;
using EMS.models.Teams;
using EMS.models.Vehicles;



namespace EMS.interfaces
{
    /// <summary>
    /// Interface to manage emergency events.
    /// </summary>
    public interface IEvent
    {

        public TypeEvent Type { get; set; }
        public string Address { get; set; }
        public DateTime StartEventDate { get; set; }
        public DateTime EndEventDate { get; set; }
        public string Description { get; set; }
        public EventSeverityLevel SeverityLevel { get; set; }
        public StatusEvent Status { get; set; }
        public List<Team> TeamsInvolved { get; set; } 
        public List<Vehicle> VehiclesInvolved { get; set; }

    }
}
