/*-----------------------------------------------------------------------------------*
 * File Name         : CatastropheEvent.cs                                           *
 * Author            : Hugo Lopes                                                    *
 * Creation Date     : 26/10/2024                                                    *
 * Description       : Represents a catastrophe event in the emergency management    *
 *                    system. This class includes details about the event such as    *
 *                    its identifier, type, address, start and end dates,            *
 *                    description, severity level, status, affected area, type of    *
 *                    catastrophe, and number of victims involved.                   *
 *-----------------------------------------------------------------------------------*/

using EMS.enums;
using EMS.models.Teams;
using EMS.models.Vehicles;
using System.Collections.Generic;

namespace EMS.models.Events
{
    /// <summary>
    ///  Represents a specific catastrophe event
    /// </summary>
    /// <seealso cref="EMS.models.Events.Event" />
    public class CatastropheEvent : Event
    {
        #region Propreties
        
        public double AffectedArea { get; set; }
        public TypeOfCatastrophe TypeCat { get; set; }
        public int NumberOfVictims { get; set; }
        #endregion
       
        #region Construters               
        /// <summary>
        /// Initializes a new instance of the <see cref="CatastropheEvent"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="address">The address.</param>
        /// <param name="startEventDate">The start event date.</param>
        /// <param name="endEventDate">The end event date.</param>
        /// <param name="description">The description.</param>
        /// <param name="severityLevel">The severity level.</param>
        /// <param name="status">The status.</param>
        /// <param name="AffectedArea">The affected area.</param>
        /// <param name="typeCat">The type cat.</param>
        /// <param name="numberOfVictims">The number of victims.</param>
        public CatastropheEvent(TypeEvent type, string address, DateTime startEventDate, DateTime endEventDate, string description, EventSeverityLevel severityLevel, StatusEvent status,double affectedArea, TypeOfCatastrophe typeCat , int numberOfVictims)
            : base(type, address, startEventDate, endEventDate, description, severityLevel, status)
        {
            AffectedArea = affectedArea;
            TypeCat = typeCat;
            NumberOfVictims = numberOfVictims;
        }
        #endregion

        #region Methods
       /* public override string ToString()
        {
            return $"Id: {Id}\n" +
                    $"Type: {Type}\n" +
                    $"Address: {Address}\n" +
                    $"Start Event Date: {StartEventDate}\n" +
                    $"End Event Date: {EndEventDate}\n" +
                    $"Description: {Description}\n" +
                    $"Severity Level: {SeverityLevel}\n" +
                    $"Status: {Status}\n" +
                    $"Type of Catatrophe:{TypeCat}\n" +
                    $"Number of Victimes: {NumberOfVictims}\n";
                    
        }*/
        #endregion
    }
}
