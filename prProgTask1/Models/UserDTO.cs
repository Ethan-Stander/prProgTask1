namespace prProgTask1.Models
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string imageURL { get; set; }

        public static void InsertUsers(List<UserDTO> users)
            {
            foreach (var user in users) {
            SQLModel.InsertUser(user);       
            }
           }
    }
}
