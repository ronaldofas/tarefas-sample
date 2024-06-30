using System.Security;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public SecureString Password { get; private set; }
        public virtual ICollection<Task> Tasks { get; private set; }

        public User(int id, string username, SecureString password)
        {
            ValidateUsername(username);
            ValidatePassword(password);
            Id = id;
            Username = username;
            Password = password;
        }

        public bool ChangePassword(SecureString password)
        {
            ValidatePassword(password);
            Password = password;
            return true;
        }

        public bool ChangeUsername(string username) 
        { 
            ValidateUsername(username);
            Username = username; 
            return true;
        }

        private void ValidateUsername(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Nome de usuário inválido!");
            }

            if (username.Length < 8 || username.Length > 8)
            {
                throw new ArgumentException("Nome do usuário deve ter oito caracteres!");
            }
        }

        private void ValidatePassword(SecureString username)
        {
            if (String.IsNullOrEmpty(username.ToString()))
            {
                throw new ArgumentNullException("Nome de usuário inválido!");
            }

            if (username.Length < 8 || username.Length > 8)
            {
                throw new ArgumentException("Nome do usuário deve ter oito caracteres!");
            }
        }
    }
}
