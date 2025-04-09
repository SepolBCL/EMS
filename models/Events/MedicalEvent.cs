/*-----------------------------------------------------------------------------------*
 * File Name         : MedicalEvent.cs                                               *
 * Author            : Hugo Lopes                                                    *
 * Creation Date     : 26/10/2024                                                    *
 * Description       : Represents a medical event in the emergency management system,*
 *                    including properties for the number of victims and type of     *
 *                    emergency. The class inherits from Event and implements        *
 *                    a method to convert its details to a string representation.    *
 *-----------------------------------------------------------------------------------*/

using EMS.enums;
using EMS.models.Teams;
using EMS.models.Vehicles;
using System.Collections.Generic;

namespace EMS.models.Events
{
    /// <summary>
    /// Represents a medical emergency event
    /// </summary>
    /// <seealso cref="EMS.models.Events.Event" />
    public class MedicalEvent : Event
    {
        #region Properties        
        
        public int NumberOfVictims { get; set; }
        public TypeOfEmergency TypeOfEmergency { get; set; }

        #endregion

        #region Construters       
        /// <summary>
        /// Initializes a new instance of the <see cref="MedicalEvent"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="address">The address.</param>
        /// <param name="startEventDate">The start event date.</param>
        /// <param name="endEventDate">The end event date.</param>
        /// <param name="description">The description.</param>
        /// <param name="severityLevel">The severity level.</param>
        /// <param name="status">The status.</param>
        /// <param name="numberOfVictims">The number of victims.</param>
        /// <param name="typeOfEmergency">The type of emergency.</param>
        public MedicalEvent( TypeEvent type, string address, DateTime startEventDate, DateTime endEventDate, string description, EventSeverityLevel severityLevel, StatusEvent status,  int numberOfVictims,TypeOfEmergency typeOfEmergency)
            : base(type, address, startEventDate, endEventDate, description, severityLevel, status)
        {
            NumberOfVictims = numberOfVictims;
            TypeOfEmergency = typeOfEmergency;

        }
        #endregion

        #region Methods
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /*public override string ToString()
        {
            return  $"Id: {Id}\n" +
                    $"Type: {Type}\n" +
                    $"Address: {Address}\n" +
                    $"Start Event Date: {StartEventDate}\n" +
                    $"End Event Date: {EndEventDate}\n" +
                    $"Description: {Description}\n" +
                    $"Severity Level: {SeverityLevel}\n" +
                    $"Status: {Status}\n" +
                    $"Number of Victimes: {NumberOfVictims}\n" +
                    $"Type of Emergency: {TypeOfEmergency}\n";
                    
                   
        }*/
        #endregion

    }
}
