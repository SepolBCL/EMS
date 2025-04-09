/*-----------------------------------------------------------------------------------*
 * File Name        : TeamsManager.cs                                                *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 26/10/2024                                                     *
 * Description      : Class for managing a collection of teams within the EMS,       *
 *                    providing methods to add, remove, update, and retrieve teams.  *
 *-----------------------------------------------------------------------------------*/

using EMS.Data;
using EMS.Interfaces;
using EMS.models.Teams;
using Microsoft.EntityFrameworkCore;

namespace EMS.services
{
    /// <summary>
    /// Manages the collection of teams within the Emergency Management System.
    /// </summary>
    public class TeamsManager : ITeamsManager
    {
        #region Properties

        private readonly EMS_DBContext _dbContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamsManager"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public TeamsManager(EMS_DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a new team to the database.
        /// </summary>
        /// <param name="team">The team to add.</param>
        public void AddTeam(Team team)
        {
            if (team == null)
                throw new ArgumentNullException(nameof(team));

            _dbContext.Teams.Add(team);
            _dbContext.SaveChanges();
        }
         
        /// <summary>
        /// Removes a team from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the team to remove.</param>
        public void RemoveTeam(int id)
        {
            var teamToRemove = _dbContext.Teams.Find(id);

            if (teamToRemove == null)
                throw new KeyNotFoundException($"No team found with ID {id}.");

            _dbContext.Teams.Remove(teamToRemove);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates an existing team in the database.
        /// </summary>
        /// <param name="updatedTeam">The updated team object.</param>
        public void UpdateTeam(Team updatedTeam)
        {
            if (updatedTeam == null)
                throw new ArgumentNullException(nameof(updatedTeam));

            var existingTeam = _dbContext.Teams.Find(updatedTeam.Id);

            if (existingTeam == null)
                throw new KeyNotFoundException($"No team found with ID {updatedTeam.Id}.");

            _dbContext.Entry(existingTeam).CurrentValues.SetValues(updatedTeam);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Retrieves all teams from the database.
        /// </summary>
        /// <returns>A list of all teams.</returns>
        public List<Team> GetAllTeams()
        {
            return _dbContext.Teams.Include(t => t.Members).ToList();
        }

        /// <summary>
        /// Retrieves a team by its ID.
        /// </summary>
        /// <param name="id">The ID of the team.</param>
        /// <returns>The team with the specified ID.</returns>
        public Team GetTeamById(int id)
        {
            var team = _dbContext.Teams.Include(t => t.Members).SingleOrDefault(t => t.Id == id);

            if (team == null)
                throw new KeyNotFoundException($"No team found with ID {id}.");

            return team;
        }

        #endregion
    }
}
