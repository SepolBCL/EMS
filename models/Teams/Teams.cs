/*-----------------------------------------------------------------------------------*
 * File Name        : Team.cs                                                        *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 26/10/2024                                                     *
 * Description      : Class representing a team within the EMS, with properties      *
 *                    for team identification, type, status, and members.            *
 *-----------------------------------------------------------------------------------*/


using EMS.enums;
using EMS.models.Events;
using EMS.models.Persons;

namespace EMS.models.Teams
{
    /// <summary>
    /// Represents a team within the EMS
    /// </summary>
    public class Team
    {
        #region Properties        

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> Members { get; set; }
        public TypeOfTeam Type { get; set; }
        public StatusTeam Status { get; set; }

        // Relacionamento com a classe Event (muitos-para-muitos)
        public virtual ICollection<Event> EventsInvolved { get; set; } = new List<Event>();

        #endregion

        public Team() { }

        #region Constructors        

        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="status">The status.</param>
        public Team(string name, TypeOfTeam type, StatusTeam status)
        {
            Name = name;
            Type = type;
            Status = status;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                    $"Team: {Name}\n " +
                    $"Type: {Type}\n " +
                    $"Status: {Status}\n " +
                    $"Members: {Members.Count}\n";  // Mostra a quantidade de membros, não a lista completa

        }

        #endregion
    }
}
