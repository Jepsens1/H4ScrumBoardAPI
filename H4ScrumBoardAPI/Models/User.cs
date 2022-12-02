namespace H4ScrumBoardAPI.Models
{
    public class User
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
     
        public User(string username, string password, string passwordSalt)
        {
            Username = username;
            Password = password;
            PasswordSalt = passwordSalt;
        }
        public User(string username, string password)
        {

        }
        public User()
        {

        }

    }
}
