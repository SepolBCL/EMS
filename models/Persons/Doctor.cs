/*----------------------------------------------------------------------------------*
 * File Name         : Doctor.cs                                                    *
 * Author            : Hugo Lopes                                                   *
 * Creation Date     : 26/10/2024                                                   *
 * Description       : Defines the Doctor class, representing a doctor in           *
 *                    the Emergency Management System. It includes properties       *
 *                    for card number and specialty, along with the implementation  *
 *                    of the TypePerson method to return details of the doctor.     *
 *----------------------------------------------------------------------------------*/

using EMS.enums;

namespace EMS.models.Persons
{
    /// <summary>
    /// Represents a doctor in the emergency response system.
    /// </summary>
    /// <seealso cref="Person" />
    public class Doctor : Person
    {
        #region Properties
        public string CardNumber {  get; private set; }
        public string Specialty { get; set; }

        #endregion

        #region Constructors                     
        /// <summary>
        /// Initializes a new instance of the <see cref="Doctor"/> class.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="CitCard">The cit card.</param>
        /// <param name="Profession">The profession.</param>
        /// <param name="Status">The status.</param>
        /// <param name="Birthday">The birthday.</param>
        /// <param name="Email">The email.</param>
        /// <param name="Phone">The phone.</param>
        /// <param name="Address">The address.</param>
        /// <param name="CardNumber">The card number.</param>
        /// <param name="Specialty">The specialty.</param>
        public Doctor(Profession Profession,string Name, string CitCard, StatusPerson Status, DateOnly Birthday, string Email, string Phone, string Address,string CardNumber,string Specialty)
           : base(Name, CitCard, Profession, Status, Birthday, Email, Phone, Address) 
        {
            this.CardNumber = CardNumber;
            this.Specialty = Specialty;
            
        }
        #endregion

        #region Methods              
        /// <summary>
        /// Abstract method that must be implemented by any subclass.
        /// It defines the type of person.
        /// </summary>
        /// <returns>
        /// A string representing the specific type of person.
        /// </returns>
        public override string TypePerson()
        {
            return $"ID: {Id}\n" +
                    $"Name: {Name}\n" +
                    $"CitCard: {CitCard} \n" +
                    $"Profession: {Profession} \n" +
                    $"Status: {Status}\n" +
                    $"Birthday: {Birthday} \n" +
                    $"Age: {Age} \n" +
                    $"Email: {Email} \n" +
                    $"Phone: {Phone}  \n" +
                    $"Address: {Address}  \n" +
                    $"Card Number: {CardNumber}\n" +
                    $"Speciality: {Specialty}\n";
        }

        #endregion
    }
}

