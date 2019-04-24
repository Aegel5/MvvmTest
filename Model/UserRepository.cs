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

        long _nextId = 10;
        public long NextId()
        {
            lock (this)
            {
                _nextId++;
                return _nextId;
            }
        }

        public void AddUser(User user)
        {
            var usr = user.Clone();
            usr.Id = NextId();
            _users.Add(usr);
            this.UserListChanged?.Invoke(this, new UserListChangedEventArg());
        }

        public void ChangeUser(User user)
        {
            var toChange = _users.Where(x => x.Id == user.Id).FirstOrDefault();
            if (toChange == null)
                return;
            toChange.Name = user.Name;
            toChange.Email = user.Email;

            this.UserListChanged?.Invoke(this, new UserListChangedEventArg());
        }

        public event EventHandler<UserListChangedEventArg> UserListChanged;

        List<User> _users;
    }
}
