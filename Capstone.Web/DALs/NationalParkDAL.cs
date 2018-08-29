using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DALs
{
    public class NationalParkDAL : INationalParkDAL
    {
        private string _connectionString = "";

        #region constructor
        public NationalParkDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        #region add survey to database
        /// <summary>
        /// add survey to database
        /// </summary>
        /// <param name="survey"></param>
        /// <returns></returns>
        public bool AddSurvey(Survey survey)
        {
            bool wasSuccessful = true;

            const string CreateSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel)" +
                                                "VALUES (@ParkCode, @Email, @State, @ActivityLevel); SELECT CAST(SCOPE_IDENTITY() as int);";


            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(CreateSurvey, conn);
                command.Parameters.AddWithValue("@ParkCode", survey.ParkCode);
                command.Parameters.AddWithValue("@Email", survey.Email);
                command.Parameters.AddWithValue("@State", survey.State);
                command.Parameters.AddWithValue("@ActivityLevel", survey.ActivityLevel);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    wasSuccessful = false;
                    throw new Exception("Error, review not saved");
                }
            }
            return wasSuccessful;
        }
        #endregion

        #region get weather forecast
        /// <summary>
        /// gets forecast from database
        /// </summary>
        public List<Weather> weather = new List<Weather>();
        public List<Weather> GetFiveDayWeather(string parkCode)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM weather " +
                                                "WHERE weather.parkCode = @parkCode", conn);

                cmd.Parameters.AddWithValue("@parkCode", parkCode);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    weather.Add(MapRowToWeather(reader));
                }
            }
            return weather;
        }

        private Weather MapRowToWeather(SqlDataReader reader)
        {
            return new Weather()
            {
                ParkCode = Convert.ToString(reader["parkCode"]),
                FiveDayForcastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                LowTemp = Convert.ToInt32(reader["low"]),
                HighTemp = Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"]),
            };
        }
        #endregion

        #region Get park for detail display
        /// <summary>
        /// get park for detail display
        /// </summary>

        public Park GetPark(string parkCode)
        {
            Park park = new Park();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE park.parkCode = @parkCode", conn);

                cmd.Parameters.AddWithValue("@parkCode", parkCode);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    park.Code = Convert.ToString(reader["parkCode"]);
                    park.Name = Convert.ToString(reader["parkName"]);
                    park.State = Convert.ToString(reader["state"]);
                    park.Size = Convert.ToInt32(reader["acreage"]);
                    park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
                    park.MilesOfTrails = Convert.ToDouble(reader["milesOfTrail"]);
                    park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                    park.Climate = Convert.ToString(reader["climate"]);
                    park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                    park.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                    park.Quote = Convert.ToString(reader["inspirationalQuote"]);
                    park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                    park.Description = Convert.ToString(reader["parkDescription"]);
                    park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                    park.Species = Convert.ToInt32(reader["numberOfAnimalSpecies"]);
                }
            }
            return park;
        }
        #endregion

        #region get favorite parks
        /// <summary>
        /// Gets favorite parks for display
        /// </summary>

        public Dictionary<string, int> GetParkResults()
        {
            Dictionary<string, int> results = new Dictionary<string, int>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(survey_result.parkCode) AS surveyCount, park.parkName " +
                                                "From survey_result " +
                                                "JOIN park ON survey_result.parkCode = park.parkCode " +
                                                "GROUP BY park.parkName " +
                                                "ORDER BY surveyCount desc, park.parkName;", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    results[Convert.ToString(reader["parkName"])] = Convert.ToInt32(reader["surveyCount"]);
                }
            }
            return results;
        }
        #endregion

        #region get all parks
        /// <summary>
        /// Get all parks from database for homepage display
        /// </summary>
        public List<Park> parks = new List<Park>();
        public List<Park> GetParks()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM park ORDER BY parkName", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parks.Add(MapRowToPark(reader));
                }
            }
            return parks;
        }

        private Park MapRowToPark(SqlDataReader reader)
        {
            return new Park()
            {
                Code = Convert.ToString(reader["parkCode"]),
                Name = Convert.ToString(reader["parkName"]),
                State = Convert.ToString(reader["state"]),
                Size = Convert.ToInt32(reader["acreage"]),
                Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrails = Convert.ToDouble(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]),
                Quote = Convert.ToString(reader["inspirationalQuote"]),
                QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                Description = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                Species = Convert.ToInt32(reader["numberOfAnimalSpecies"]),
            };
        }
        #endregion
    }
}