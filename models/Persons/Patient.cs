/*-----------------------------------------------------------------------------------*
 * File Name        : Patient.cs                                                     *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 28/10/2024                                                     *
 * Description      : Class representing a patient, inheriting from Person, with     *
 *                    specific details related to patient information.                *
 *-----------------------------------------------------------------------------------*/

using EMS.enums;



namespace EMS.models.Persons
{
    /// <summary>
    /// Represents a patient within the EMS system.
    /// </summary>
    public class Patient : Person
    {
        #region Properties        
       
        public string MedicalRecordNumber { get; private set; }
                
        public string Condition { get; set; }
        
        public DateTime AdmissionDate { get; set; }
        #endregion

        #region Constructors                
        /// <summary>
        /// Initializes a new instance of the <see cref="Patient"/> class.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="CitCard">The cit card.</param>
        /// <param name="Profession">The profession.</param>
        /// <param name="Status">The status.</param>
        /// <param name="Birthday">The birthday.</param>
        /// <param name="Email">The email.</param>
        /// <param name="Phone">The phone.</param>
        /// <param name="Address">The address.</param>
        /// <param name="medicalRecordNumber">The medical record number.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="admissionDate">The admission date.</param>
        public Patient(Profession Profession,string Name, string CitCard,  StatusPerson Status, DateOnly Birthday, string Email, string Phone, string Address, string medicalRecordNumber, string condition, DateTime admissionDate)
            : base(Name, CitCard, Profession, Status, Birthday, Email, Phone, Address)
        {
            MedicalRecordNumber = medicalRecordNumber;
            Condition = condition;
            AdmissionDate = admissionDate;
        }
        #endregion

        #region Methods
        public override string TypePerson()
        {
            return $"ID: {Id}\n" +
                    $"Name: {Name}\n" +
                    $"CitCard: {CitCard} \n" +
                    $"Birthday: {Birthday} \n" +
                    $"Age: {Age} \n" +
                    $"Email: {Email} \n" +
                    $"Phone: {Phone}  \n" +
                    $"Address: {Address}  \n" +
                    $"MedicalRecordNumber: {MedicalRecordNumber} \n"+
                    $"Condition:  {Condition} \n"+
                    $"AdmissionDate: {AdmissionDate}\n";

        }
         #endregion
    }
}
