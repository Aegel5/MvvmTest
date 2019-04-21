using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmTest.Model
{
    class UserRepository
    {
        public List<User> GetUsers()
        {
            return new List<User>(_users);
        }

        public UserRepository()
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            _users = new List<User>();
            _users.Add(new User { Email = "Simon@mail.ru", Name = "Simon" });
            _users.Add(new User { Email = "Nikol@mail.ru", Name = "Nikol" });
        }

        public void AddUser(User user)
        {
            _users.Add(user);
            this.UserListChanged(this, new UserListChangedEventArg());
        }

        public event EventHandler<UserListChangedEventArg> UserListChanged;

        List<User> _users;
    }
}
