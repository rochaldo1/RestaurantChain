using MySqlConnector;
using System.Data;

namespace RestaurantChain.DataBase
{
    /// <summary>
    /// Класс коннектора к базе данных.
    /// </summary>
    public class SQLConnection
    {
        /// <summary>
        /// Данные для подключения к БД.
        /// </summary>
        private readonly string _connectionString = "server=localhost;database=restaurant_chain;uid=root;password=228420;";
        private readonly MySqlConnection _connection;

        private static SQLConnection _instance;

        private SQLConnection()
        {
            _connection = new(_connectionString);
        }

        /// <summary>
        /// Получение объекта класса при вызове метода.
        /// </summary>
        /// <returns>Объект класса.</returns>
        public static SQLConnection GetInstance()
        {
            if (_instance == null)
                _instance = new SQLConnection();
            return _instance;
        }

        /// <summary>
        /// Метод для обработки запросов к БД.
        /// </summary>
        /// <param name="query">Запрос.</param>
        public void Request(string query)
        {
            _connection.Open();

            MySqlCommand command = new(query, _connection);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection.Close();
            }
        }
        
        /// <summary>
        /// Метод для запроса таблиц из БД.
        /// </summary>
        /// <param name="query">Запрос.</param>
        /// <returns>Таблица.</returns>
        public DataTable GetTable(string query)
        {
            _connection.Open();

            MySqlCommand command = new(query, _connection);

            MySqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                _connection.Close();
                throw ex;
            }

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            _connection.Close();
            return dataTable;
        }
    }
}
