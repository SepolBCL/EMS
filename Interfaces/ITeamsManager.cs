/*-----------------------------------------------------------------------------------*
 * File Name        : ITeamsManager.cs                                                *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Interface for managing teams in the EMS system.                *
 *-----------------------------------------------------------------------------------*/

using EMS.models.Teams;


namespace EMS.Interfaces
{
    #region Interface Definition

    /// <summary>
    /// Interface for managing teams in the Emergency Management System (EMS).
    /// Provides methods for adding, removing, updating, and retrieving teams.
    /// </summary>
    public interface ITeamsManager
    {
        #region Team Management

        /// <summary>
        /// Adds a new team to the system.
        /// </summary>
        /// <param name="team">The team to add.</param>
        public void AddTeam(Team team);

        /// <summary>
        /// Removes a team from the system by its ID.
        /// </summary>
        /// <param name="id">The ID of the team to remove.</param>
        public void RemoveTeam(int id);

        /// <summary>
        /// Updates an existing team in the system with new information.
        /// </summary>
        /// <param name="updatedTeam">The updated team information.</param>
        public void UpdateTeam(Team updatedTeam);

        #endregion

        #region Team Retrieval

        /// <summary>
        /// Gets all teams from the system.
        /// </summary>
        /// <returns>A list of all teams.</returns>
        public List<Team> GetAllTeams();

        /// <summary>
        /// Retrieves a team by its identifier.
        /// </summary>
        /// <param name="id">The ID of the team to retrieve.</param>
        /// <returns>The team with the specified ID.</returns>
        public Team GetTeamById(int id);

        #endregion
    }

    #endregion
}
