/*-------------------------------------------------------------------------------------*
 * File Name        : Person.cs                                                        *
 * Author           : Hugo Lopes                                                       *
 * Creation Date    : 26/10/2024                                                       *
 * Description      : Represents a generic person with common properties shared        *
 *                    by all individuals in the system, such as ID, name, contact      *
 *                    details, and other identifying information. It serves as an      *
 *                    abstract base class for specific person types (e.g., doctor,     *
 *                    nurse, firefighter) and defines a method to specify the type of  *
 *                    person.                                                          *
 *-------------------------------------------------------------------------------------*/

using EMS.enums;
using Utils;

namespace EMS.models.Persons
{
    /// <summary>
    /// Represents a generic person with common properties shared by all individuals in the system, 
    /// such as ID, name, contact details, and other identifying information.
    /// </summary>
    public abstract class Person
    {
        #region Private Properties
        /// <summary>
        /// The age calculator
        /// </summary>
        private readonly CalAge ageCalculator = new CalAge();
        private int id { get; set; }
        private string name { get; set; }
        private string citCard { get; set; }
        private Profession profession { get; set; }
        private StatusPerson status { get; set; }
        private DateOnly birthday { get; set; }
        private string email { get; set; }
        private string phone { get; set; }
        private string address { get; set; }




        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get => id;
            private set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }

        public string CitCard
        {
            get => citCard;
            set => citCard = value;
        }
        public Profession Profession
        {
            get => profession;
            set => profession = value;
        }
        public StatusPerson Status
        {
            get => status;
            set => status = value;
        }
        public DateOnly Birthday
        {
            get => birthday;
            set => birthday = value;
        }

        public int Age => CalAge.Age(Birthday);



        public string Email
        {
            get => email;
            set => email = value;
        }

        public string Phone
        {
            get => phone;
            set => phone = value;
        }
        public string Address
        {
            get => address;
            set => address = value;
        }

        #endregion

        #region Constructors 

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="citCard">The cit card.</param>
        /// <param name="profession">The profession.</param>
        /// <param name="status">The status.</param>
        /// <param name="birthday">The birthday.</param>
        /// <param name="email">The email.</param>
        /// <param name="phone">The phone.</param>
        /// <param name="address">The address.</param>
        public Person(string name, string citCard, Profession profession, StatusPerson status, DateOnly birthday, string email, string phone, string address)
        {
            Name = name;
            CitCard = citCard;
            Profession = profession;
            Status = status;
            Birthday = birthday;
            Email = email;
            Phone = phone;
            Address = address;

        }


        #endregion

        #region Abstract Method
        /// <summary>
        /// Abstract method that must be implemented by any subclass.
        /// It defines the type of person (doctor, nurse, firefighter).
        /// </summary>
        /// <returns>A string representing the specific type of person.</returns>
        public abstract string TypePerson();
    }  
                #endregion;
}
