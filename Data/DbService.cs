using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class DbService
    {
        private readonly string SQLConnString;

        public DbService()
        {
            SqlConnectionStringBuilder sqlConStringBuilder = new SqlConnectionStringBuilder();
            sqlConStringBuilder["server"] = @"(localdb)\MSSQLLocalDB";
            sqlConStringBuilder["Trusted_Connection"] = true;
            sqlConStringBuilder["Integrated Security"] = "SSPI";
            sqlConStringBuilder["Initial Catalog"] = "PROG455SP23";

            SQLConnString = sqlConStringBuilder.ToString();
        }

        public List<Participant> GetAllParticipants()
        {
            using (SqlConnection connection = new SqlConnection(SQLConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetAllParticipants", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Participant> participants = new List<Participant>();

                        while (reader.Read())
                        {
                            participants.Add(new Participant
                            {
                                ID = (int)reader["ID"],
                                Name = (string)reader["Name"],
                                GemStone = (string)reader["GemStone"]
                            });
                        }

                        return participants;
                    }
                }
            }
        }

        public List<Participant> GetParticipantsByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(SQLConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("GetParticipantsByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Participant> participants = new List<Participant>();

                        while (reader.Read())
                        {
                            participants.Add(new Participant
                            {
                                ID = (int)reader["ID"],
                                Name = (string)reader["Name"],
                                GemStone = (string)reader["GemStone"]
                            });
                        }

                        return participants;
                    }
                }
            }
        }

        public void DeleteParticipant(int id)
        {
            using (SqlConnection connection = new SqlConnection(SQLConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DeleteParticipant", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateParticipant(int id, string name, string gemStone)
        {
            using (SqlConnection connection = new SqlConnection(SQLConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UpdateParticipant", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@GemStone", gemStone);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddParticipant(string name, string gemStone)
        {
            using (SqlConnection connection = new SqlConnection(SQLConnString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("AddParticipant", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@GemStone", gemStone);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
