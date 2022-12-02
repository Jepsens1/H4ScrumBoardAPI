using H4ScrumBoardAPI.Database;
using H4ScrumBoardAPI.Models;

namespace H4ScrumBoardAPI.Managers
{
    public class UserManager
    {
        private ICrypto _crypto;
        DataAccess _database = new DataAccess();
        public UserManager(ICrypto crypto)
        {
            _crypto = crypto;
        }
        public string RegisterUser(string username, string password)
        {
            try
            {
                 byte[] salt =  _crypto.GenerateSalt();
                return _database.RegisterUser(new User(username, Convert.ToBase64String(_crypto.CreateHash(password, salt)), Convert.ToBase64String(salt)));
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public User Login(string username, string password)
        {
            try
            {
                User dbclient = _database.Login(username);
                if (dbclient == null)
                {
                    return null;
                }
                if (_crypto.Verify(dbclient.Password, password, Convert.FromBase64String(dbclient.PasswordSalt)))
                {
                    dbclient.PasswordSalt = Convert.ToBase64String(_crypto.GenerateSalt());
                    dbclient.Password = Convert.ToBase64String(_crypto.CreateHash(password, Convert.FromBase64String(dbclient.PasswordSalt)));
                    _database.UpdateUser(dbclient);
                    return dbclient;
                }
                throw new Exception("Either username or pasword is incorrect");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
