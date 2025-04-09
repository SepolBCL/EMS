/*-----------------------------------------------------------------------------------*
 * File Name        : IPersonsManager.cs                                              *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Interface for managing persons in the EMS system.              *
 *-----------------------------------------------------------------------------------*/

using EMS.models.Persons;


namespace EMS.Interfaces
{
    #region Interface Definition

    /// <summary>
    /// Interface for managing persons in the Emergency Management System (EMS).
    /// It provides methods for adding, removing, updating, and retrieving persons.
    /// </summary>
    public interface IPersonsManager
    {
        #region Person Management

        /// <summary>
        /// Adds a person to the database.
        /// </summary>
        /// <param name="person">The person to add.</param>
        public void AddPerson(Person person);

        /// <summary>
        /// Removes a person from the database by ID.
        /// </summary>
        /// <param name="id">The ID of the person to remove.</param>
        public void RemovePerson(int id);

        /// <summary>
        /// Updates a person in the database with the new information.
        /// </summary>
        /// <param name="updatedPerson">The updated person information.</param>
        public void UpdatePerson(Person updatedPerson);

        #endregion

        #region Person Retrieval

        /// <summary>
        /// Gets all persons from the database.
        /// </summary>
        /// <returns>A list of all persons.</returns>
        public List<Person> GetAllPersons();

        /// <summary>
        /// Filters persons by a specific type, such as Nurse, Doctor, Firefighter, etc.
        /// </summary>
        /// <typeparam name="T">The type of person to filter. It must inherit from Person.</typeparam>
        /// <returns>A list of persons of the specified type.</returns>
        public List<T> GetPersonsByType<T>() where T : Person;

        /// <summary>
        /// Retrieves a person by their ID.
        /// </summary>
        /// <param name="id">The ID of the person to retrieve.</param>
        /// <returns>The person with the specified ID.</returns>
        public Person GetPersonById(int id);

        /// <summary>
        /// Gets the fighters.
        /// </summary>
        /// <returns></returns>
        public List<FireFighter> GetFireFighters();

        /// <summary>
        /// Gets the doctors.
        /// </summary>
        /// <returns></returns>
        public List<Doctor> GetDoctors();

        /// <summary>
        /// Gets the nurses.
        /// </summary>
        /// <returns></returns>
        public List<Nurse> GetNurses();

        /// <summary>
        /// Gets the paramedic.
        /// </summary>
        /// <returns></returns>
        public List<Paramedic> GetParamedics();

        /// <summary>
        /// Gets the patients.
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetPatients();

        #endregion
    }

    #endregion
}
