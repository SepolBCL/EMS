/*-----------------------------------------------------------------------*
 * File Name        : Nurse.cs                                           *
 * Author           : Hugo Lopes                                         *
 * Creation Date    : 26/10/2024                                         *
 * Description      : Defines the Nurse class, representing a nurse in   *
 *                    the Emergency Management System. It includes       *
 *                    properties specific to nurses, such as card number *
 *                    and area of activity, and implements the           *
 *                    TypePerson method to return details of the nurse.  *
 *-----------------------------------------------------------------------*/

using EMS.enums;

namespace EMS.models.Persons
{
    /// <summary>
    /// Represents a nurse in the emergency response system.
    /// </summary>
    /// <seealso cref="Person" />
    public class Nurse : Person
    {
        #region Properties

        private string cardNumber {  get; set; }
        private string areaOfActivity { get; set; }
        
        public string CardNumber 
        { 
            get=> cardNumber; 
            set=> cardNumber = value; 
        }

        public string AreaOfActivity 
        { 
            get=> areaOfActivity ; 
            set => areaOfActivity = value; 
        }


        #endregion

        #region Constructors                      
        /// <summary>
        /// Initializes a new instance of the <see cref="Nurse"/> class.
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
        /// <param name="AreaOfActivity">The area of activity.</param>
        public Nurse(Profession Profession, string Name, string CitCard, StatusPerson Status, DateOnly Birthday, string Email, string Phone, string Address, string CardNumber, string AreaOfActivity)
          : base( Name, CitCard, Profession, Status, Birthday, Email, Phone, Address) 
        {
            cardNumber = CardNumber;
            areaOfActivity = AreaOfActivity;

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
                    $"Profession: {Profession}\n" +
                    $"Status: {Status}\n" +
                    $"Birthday: {Birthday} \n" +
                    $"Age: {Age} \n" +
                    $"Email: {Email} \n" +
                    $"Phone: {Phone}  \n" +
                    $"Address: {Address}  \n" +
                    $"Card Number: {cardNumber}\n" +
                    $"Area Of Activity: {areaOfActivity}\n";
        }
        #endregion
    }
}
