using H4ScrumBoardAPI.Models;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace H4ScrumBoardAPI.Database
{
    public class DataAccess
    {
        const string ConnString = "Server=DESKTOP-HT94JHQ\\SQLEXPRESS;Database=H4ScrumBoard;Trusted_Connection=True;";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        public List<ScrumTask> GetScrumTasks()
        {
            List<ScrumTask> list = new List<ScrumTask>();
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM TASKS", conn);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new ScrumTask((int)reader["TaskID"], (string)reader["TaskName"], (string)reader["TaskDescription"], (int)reader["StoryPoints"]
                        , (string)reader["TaskState"]));
                }
                conn.Close();
                return list;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
        public ScrumTask GetScrumTaskByID(int id)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM TASKS WHERE TaskID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    ScrumTask task = new ScrumTask((int)reader["TaskID"], (string)reader["TaskName"], (string)reader["TaskDescription"], (int)reader["StoryPoints"]
                            , (string)reader["TaskState"]);
                    conn.Close();
                    return task;
                }
                conn.Close();
                throw new Exception("Could not get task by id");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ScrumTask CreateNewTask(ScrumTask task)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("INSERT INTO TASKS VALUES(@TaskName, @TaskDescription, @StoryPoints, @TaskState);SELECT SCOPE_IDENTITY()", conn);
                cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                cmd.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                cmd.Parameters.AddWithValue("@StoryPoints", task.StoryPoints);
                cmd.Parameters.AddWithValue("@TaskState", task.TaskState);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                task.ID = result;
                conn.Close();
                return task;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ScrumTask UpdateScrumTask(ScrumTask task)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("UPDATE Tasks SET TaskName = @TaskName, TaskDescription = @TaskDescription," +
                    "StoryPoints = @StoryPoints, TaskState = @TaskState WHERE TaskID = @id", conn);
                cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                cmd.Parameters.AddWithValue("@TaskDescription", task.TaskDescription);
                cmd.Parameters.AddWithValue("@StoryPoints", task.StoryPoints);
                cmd.Parameters.AddWithValue("@TaskState", task.TaskState);
                cmd.Parameters.AddWithValue("@id", task.ID);
                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    conn.Close();
                    throw new Exception("Could not update task");
                }
                conn.Close();
                return task;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string DeleteScrumTask(int id)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("DELETE FROM TASKS WHERE TaskID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    conn.Close();
                    throw new Exception("Could not delete task");
                }
                conn.Close();
                return "Deleted Task";

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string RegisterUser(User user)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("INSERT INTO LoginForm VALUES(@username, @password, @salt)", conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@salt",user.PasswordSalt);
                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    conn.Close();
                    throw new Exception("Failed to create user");
                }
                conn.Close();
                return $"{user.Username} was created";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public User Login(string username)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("SELECT * FROM LoginForm Where Username = @username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    User user = new User((string)reader["Username"], (string)reader["HashedPassword"], (string)reader["UserSalt"]);
                    conn.Close();
                    return user;
                }
                conn.Close();
                throw new Exception("Could not find user");

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateUser(User user)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                cmd = new SqlCommand("UPDATE LoginForm SET UserSalt = @salt, HashedPassword = @password WHERE Username = @username", conn);
                cmd.Parameters.AddWithValue("@salt", user.PasswordSalt);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@username", user.Username);
                int result = cmd.ExecuteNonQuery();
                if (result == 0)
                {
                    conn.Close();
                    throw new Exception("Could not update user password");
                }
                conn.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
