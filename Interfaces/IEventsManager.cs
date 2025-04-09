/*-----------------------------------------------------------------------------------*
 * File Name        : IEventsManager.cs                                              *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Interface for managing events in the EMS system.                *
 *-----------------------------------------------------------------------------------*/

using EMS.models.Events;


namespace EMS.Interfaces
{
    #region Interface Definition

    /// <summary>
    /// Interface for managing events in the Emergency Management System (EMS).
    /// It provides methods for adding, removing, updating, and retrieving events.
    /// </summary>
    public interface IEventsManager
    {
        #region Event Management

        /// <summary>
        /// Adds a new event to the database.
        /// </summary>
        /// <param name="newEvent">The event to add.</param>
        public void AddEvent(Event newEvent);

        /// <summary>
        /// Removes an event from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the event to remove.</param>
        public void RemoveEvent(int id);

        /// <summary>
        /// Updates an existing event in the database.
        /// </summary>
        /// <param name="updatedEvent">The updated event object.</param>
        public void UpdateEvent(Event updatedEvent);

        #endregion

        #region Event Retrieval

        /// <summary>
        /// Retrieves all events from the database.
        /// </summary>
        /// <returns>A list of all events.</returns>
        public List<Event> GetAllEvents();

        /// <summary>
        /// Gets all fire events from the database.
        /// </summary>
        /// <returns>A list of all fire events.</returns>
        public List<FireEvent> GetAllFireEvents();

        /// <summary>
        /// Gets all medical events from the database.
        /// </summary>
        /// <returns>A list of all medical events.</returns>
        public List<MedicalEvent> GetAllMedicalEvents();

        /// <summary>
        /// Gets all catastrophe events from the database.
        /// </summary>
        /// <returns>A list of all catastrophe events.</returns>
        public List<CatastropheEvent> GetAllCatastropheEvents();

        #endregion

        #region Event By ID

        /// <summary>
        /// Retrieves an event by its ID.
        /// </summary>
        /// <param name="id">The ID of the event to retrieve.</param>
        /// <returns>The event with the specified ID.</returns>
        public Event GetEventById(int id);

        #endregion
    }

    #endregion
}
