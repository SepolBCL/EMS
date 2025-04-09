/*-----------------------------------------------------------------------------------*
 * File Name         : FireFighter.cs                                                *
 * Author            : Hugo Lopes                                                    *
 * Creation Date     : 26/10/2024                                                    *
 * Description       : Defines the FireFighter class, representing a firefighter in  *
 *                    the Emergency Management System. It includes properties for    *
 *                    rank, years of experience, certifications, and skills, along   *
 *                    with the implementation of the TypePerson method to return     *
 *                    details of the firefighter.                                    *
 *-----------------------------------------------------------------------------------*/

using EMS.enums;

namespace EMS.models.Persons
{
    /// <summary>
    /// Represents a firefighter in the emergency management system.
    /// </summary>
    /// <seealso cref="Person" />

    public class FireFighter : Person
    {
        #region Properties
        public RankFireFighter Rank { get; set; }
        public int YearsOfExp { get; set; }
        public string Certifications { get; set; }
        public string Skills { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FireFighter"/> class.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="CitCard">The cit card.</param>
        /// <param name="Profession">The profession.</param>
        /// <param name="Status">The status.</param>
        /// <param name="Birthday">The birthday.</param>
        /// <param name="Email">The email.</param>
        /// <param name="Phone">The phone.</param>
        /// <param name="Address">The address.</param>
        /// <param name="Rank">The rank.</param>
        /// <param name="YearsOfExp">The years of exp.</param>
        /// <param name="Certifications">The certifications.</param>
        /// <param name="Skills">The skills.</param>
        public FireFighter(Profession Profession,string Name, string CitCard, StatusPerson Status, DateOnly Birthday, string Email, string Phone, string Address,
            RankFireFighter Rank, int YearsOfExp, string Certifications, string Skills)
            : base( Name, CitCard, Profession, Status, Birthday, Email, Phone, Address)
        {
            this.Rank = Rank;
            this.YearsOfExp = YearsOfExp;
            this.Certifications = Certifications;
            this.Skills = Skills;

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
            return  $"ID: {Id}\n" +
                    $"Name: {Name}\n" +
                    $"CitCard: {CitCard} \n" +
                    $"Profession: {Profession} \n" +
                    $"Status: {Status}\n" +
                    $"Birthday: {Birthday} \n" +
                    $"Age: {Age} \n" +
                    $"Email: {Email} \n" +
                    $"Phone: {Phone}  \n" +
                    $"Address: {Address}  \n" +
                    $"Rank: {Rank}\n" +
                    $"Years of exerience: {YearsOfExp}\n" +
                    $"Certifications: {string.Join(", ", Certifications)}\n" +
                    $"Special Skills: {string.Join(", ", Skills)}\n";
        }

        #endregion
    }
}
