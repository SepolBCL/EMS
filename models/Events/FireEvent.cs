/*-----------------------------------------------------------------------------------*
 * File Name         : FireEvent.cs                                                  *
 * Author            : Hugo Lopes                                                    *
 * Creation Date     : 26/10/2024                                                    *
 * Description       : Represents a fire event in the emergency management system,   *
 *                    including properties for the type of fire, fire intensity,     *
 *                    and affected area. The class inherits from Event and provides  *
 *                    a method to convert its details to a string representation.    *
 *-----------------------------------------------------------------------------------*/

using EMS.enums;
using EMS.models.Teams;
using EMS.models.Vehicles;
using System.Collections.Generic;

namespace EMS.models.Events
{
    /// <summary>
    /// Represents a specific fire event
    /// </summary>
    /// <seealso cref="EMS.models.Events.Event" />
    public class FireEvent : Event
        {
            #region Properties
            
            public TypeOfFire TypeOfFire { get; set; }
            public string FireIntensity { get; set; }
            public double AffectedArea { get; set; }
        #endregion

        #region Construters                   
        /// <summary>
        /// Initializes a new instance of the <see cref="FireEvent"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="address">The address.</param>
        /// <param name="startEventDate">The start event date.</param>
        /// <param name="endEventDate">The end event date.</param>
        /// <param name="description">The description.</param>
        /// <param name="severityLevel">The severity level.</param>
        /// <param name="status">The status.</param>
        /// <param name="typeOfFire">The type of fire.</param>
        /// <param name="fireIntensity">The fire intensity.</param>
        /// <param name="affectedArea">The affected area.</param>
        public FireEvent(TypeEvent type, string address, DateTime startEventDate, DateTime endEventDate, string description, EventSeverityLevel severityLevel, StatusEvent status, TypeOfFire typeOfFire, string fireIntensity, double affectedArea)
                : base(type, address, startEventDate, endEventDate, description, severityLevel, status)
            {
                    {
                        TypeOfFire = typeOfFire;
                        FireIntensity = fireIntensity;
                        AffectedArea = affectedArea;

                    }
            }
            #endregion

            #region Methods
            /*public override string ToString()
            {
                return $"Id: {Id}\n" +
                    $"Type: {Type}\n" +
                    $"Address: {Address}\n" +
                    $"Start Event Date: {StartEventDate}\n" +
                    $"End Event Date: {EndEventDate}\n" +
                    $"Description: {Description}\n" +
                    $"Severity Level: {SeverityLevel}\n" +
                    $"Status: {Status}\n" +
                    $"Type Of Fire: {TypeOfFire}\n" +
                    $"Fire Intensity: {FireIntensity}\n" +
                    $"Affected Area: {AffectedArea}\n";
            }*/
            #endregion
        }
}
