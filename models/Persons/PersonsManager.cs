/*-----------------------------------------------------------------------------------*
 * File Name        : PersonsManager.cs                                              *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 26/10/2024                                                     *
 * Description      : Manages the collection of persons within the Emergency         *
 *                    Management System. This class provides methods to add, remove, *
 *                    and update person records.                                     *
 *-----------------------------------------------------------------------------------*/


using EMS.Data;
using EMS.Interfaces;
using EMS.models.Persons;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EMS.services
{
    /// <summary>
    /// Manages person records in the database.
    /// </summary>
    public class PersonsManager: IPersonsManager
    {
        #region Properties
        private readonly EMS_DBContext _dbContext;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonsManager"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public PersonsManager(EMS_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a person to the database.
        /// </summary>
        /// <param name="person">The person to add.</param>
        public void AddPerson(Person person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Removes a person from the database by ID.
        /// </summary>
        /// <param name="id">The ID of the person to remove.</param>
        public void RemovePerson(int id)
        {
            var person = _dbContext.Persons.Find(id);

            if (person == null)
                throw new KeyNotFoundException($"No person found with ID {id}.");

            _dbContext.Persons.Remove(person);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates a person in the database.
        /// </summary>
        /// <param name="updatedPerson">The updated person information.</param>
        public void UpdatePerson(Person updatedPerson)
        {
            if (updatedPerson == null)
                throw new ArgumentNullException(nameof(updatedPerson));

            var person = _dbContext.Persons.Find(updatedPerson.Id);

            if (person == null)
                throw new KeyNotFoundException($"No person found with ID {updatedPerson.Id}.");

            _dbContext.Entry(person).CurrentValues.SetValues(updatedPerson);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Gets all persons from the database.
        /// </summary>
        /// <returns>A list of all persons.</returns>
        public List<Person> GetAllPersons()
        {
            return _dbContext.Persons.ToList();
        }

        /// <summary>
        /// Filters persons by a specific type.
        /// </summary>
        /// <typeparam name="T">The type of person to filter.</typeparam>
        /// <returns>A list of persons of the specified type.</returns>
        public List<T> GetPersonsByType<T>() where T : Person
        {
            return _dbContext.Persons.OfType<T>().ToList();

        }

        /// <summary>
        /// Gets the person by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Person GetPersonById(int id) 
        {
            return _dbContext.Persons.Find(id);
        }

        /// <summary>
        /// Gets the fire fighters.
        /// </summary>
        /// <returns></returns>
        public List<FireFighter>GetFireFighters()
        {
            return _dbContext.FireFighters.ToList();
        }

        /// <summary>
        /// Gets the doctors.
        /// </summary>
        /// <returns></returns>
        public List<Doctor> GetDoctors()
        {
            return _dbContext.Doctors.ToList();
        }

        /// <summary>
        /// Gets the nurses.
        /// </summary>
        /// <returns></returns>
        public List<Nurse> GetNurses() 
        {
            return _dbContext.Nurses.ToList();
        }

        /// <summary>
        /// Gets the paramedics.
        /// </summary>
        /// <returns></returns>
        public List<Paramedic> GetParamedics() 
        {
            return _dbContext.Paramedics.ToList();
        }
        /// <summary>
        /// Gets the patients.
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetPatients() 
        {
            return _dbContext.Patients.ToList();
        }
        #endregion
    }
}
