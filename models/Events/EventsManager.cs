/*------------------------------------------------------------------------------------*
 * File Name         : EventsManager.cs                                               *
 * Author            : Hugo Lopes                                                     *
 * Creation Date     : 26/10/2024                                                     *
 * Description       : Manages emergency events by providing methods to add, remove,  *
 *                    and update events in the system. This class maintains a list of *
 *                    events and handles their lifecycle.                             *
 *------------------------------------------------------------------------------------*/

using EMS.Data;
using EMS.Interfaces;
using EMS.models.Events;
using Microsoft.EntityFrameworkCore;

namespace EMS.services
{
    /// <summary>
    /// Manages the collection of events within the emergency management system.
    /// </summary>
    public class EventsManager : IEventsManager
    {
        #region Properties

        private readonly EMS_DBContext _dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsManager"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public EventsManager(EMS_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new event to the database.
        /// </summary>
        /// <param name="newEvent">The event to add.</param>
        public void AddEvent(Event newEvent)
        {
            if (newEvent == null)
                throw new ArgumentNullException(nameof(newEvent));

            _dbContext.Event.Add(newEvent);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Removes an event from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the event to remove.</param>
        public void RemoveEvent(int id)
        {
            var eventToRemove = _dbContext.Event.Find(id);

            if (eventToRemove == null)
                throw new KeyNotFoundException($"No event found with ID {id}.");

            _dbContext.Event.Remove(eventToRemove);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates an existing event in the database.
        /// </summary>
        /// <param name="updatedEvent">The updated event object.</param>
        public void UpdateEvent(Event updatedEvent)
        {
            if (updatedEvent == null)
                throw new ArgumentNullException(nameof(updatedEvent));

            var existingEvent = _dbContext.Event.Find(updatedEvent.Id);

            if (existingEvent == null)
                throw new KeyNotFoundException($"No event found with ID {updatedEvent.Id}.");

            _dbContext.Entry(existingEvent).CurrentValues.SetValues(updatedEvent);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Retrieves all events from the database.
        /// </summary>
        /// <returns>A list of all events.</returns>
        public List<Event> GetAllEvents()
        {
            return _dbContext.Event.ToList();
        }


        /// <summary>
        /// Gets all fire events.
        /// </summary>
        /// <returns></returns>
        public List<FireEvent> GetAllFireEvents()
        {
            return _dbContext.Fire_Events.ToList();
        }

        /// <summary>
        /// Gets all medical events.
        /// </summary>
        /// <returns></returns>
        public List<MedicalEvent> GetAllMedicalEvents()
        {
            return _dbContext.Medical_Events.ToList();
        }

        /// <summary>
        /// Gets all catastrophe events.
        /// </summary>
        /// <returns></returns>
        public List<CatastropheEvent> GetAllCatastropheEvents()
        {
            return _dbContext.Catastrophes_Event.ToList();
        }

        /// <summary>
        /// Retrieves an event by its ID.
        /// </summary>
        /// <param name="id">The ID of the event to retrieve.</param>
        /// <returns>The event with the specified ID.</returns>
        public Event GetEventById(int id)
        {
            var eventResult = _dbContext.Event.Find(id);

            if (eventResult == null)
                throw new KeyNotFoundException($"No event found with ID {id}.");

            return eventResult;
        }

        #endregion
    }
}
