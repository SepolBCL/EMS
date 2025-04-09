/*-----------------------------------------------------------------------------------*
 * File Name        : DataBaseConnection.cs                                           *
 * Author           : Hugo Lopes                                                     *
 * Creation Date    : 19/12/2024                                                     *
 * Description      : Singleton class responsible for managing the database connection. *
 *-----------------------------------------------------------------------------------*/

using Microsoft.Data.SqlClient;


namespace EMS.Data
{
    #region Singleton Implementation

    /// <summary>
    /// The DataBaseConnection class manages the database connection using the Singleton pattern.
    /// It ensures that only one instance of the connection is created during the application's lifetime.
    /// </summary>
    public class DataBaseConnection
    {
        #region Private Fields

        /// <summary>
        /// The single instance of the DataBaseConnection class.
        /// </summary>
        private static DataBaseConnection _instance;

        /// <summary>
        /// Lock object to ensure thread-safety when creating the singleton instance.
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// The SqlConnection object used to interact with the SQL Server database.
        /// </summary>
        private readonly SqlConnection _connection;

        /// <summary>
        /// The connection string used to connect to the database.
        /// </summary>
        private const string ConnectionString = "Server=LAPTOPHUGOLOPES\\SQLEXPRESS;Database=EMS;Trusted_Connection=True;Encrypt=False";

        #endregion

        #region Constructor

        /// <summary>
        /// Private constructor to prevent the direct instantiation of the DataBaseConnection class.
        /// This ensures that only one instance of the class is created (Singleton pattern).
        /// </summary>
        private DataBaseConnection()
        {
            _connection = new SqlConnection(ConnectionString);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the single instance of the DataBaseConnection class.
        /// Ensures that only one instance of the connection is created during the application’s lifetime.
        /// </summary>
        /// <value>
        /// The instance of the DataBaseConnection class.
        /// </value>
        public static DataBaseConnection Instance
        {
            get
            {
                // Double-check locking to ensure thread safety while creating the singleton instance.
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new DataBaseConnection();
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region Connection Management

        /// <summary>
        /// Opens the SQL connection if it is closed or broken, and returns the active connection.
        /// This method ensures that a valid connection is available for database operations.
        /// </summary>
        /// <returns>
        /// The active SqlConnection object.
        /// </returns>
        public SqlConnection GetConnection()
        {
            // Check the connection state and open it if it is closed or broken.
            if (_connection.State == System.Data.ConnectionState.Closed || _connection.State == System.Data.ConnectionState.Broken)
            {
                _connection.Open();
            }
            return _connection;
        }

        #endregion
    }

    #endregion
}
