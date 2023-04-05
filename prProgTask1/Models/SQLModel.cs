using System.Data.SqlClient;

namespace prProgTask1.Models
{
    public class SQLModel
    {
        private static string STRCon = "Server=tcp:wordleapi.database.windows.net,1433;Initial Catalog=wordle;Persist Security Info=False;User ID=st10085170;Password=Estander5!!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; 
        public static void InsertUser(UserDTO user)
            {
            using(SqlConnection connection = new SqlConnection(STRCon))
                {
                connection.Open();
                string sql = "INSERT INTO Users(Name,Password,ImageURL) VALUES(@Name,@Password,@ImageURL)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("Name", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@ImageURL", user.imageURL); 
                cmd.ExecuteNonQuery();
                }
            }
    }
}
