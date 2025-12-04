using EF_Core.Models.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EF_Core.Models.Service
{
    public class UserService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public ObservableCollection<User> Users { get; set; } = new();

        public UserService() 
        {
            GetAll();
        }
        public int Commit() => _db.SaveChanges();
        public void Add(User user)
        {
            var _user = new User
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                Profile = user.Profile,
                RoleId= user.RoleId,
                Role=user.Role,
            };

            _db.Add<User>(_user);
            Commit();
        }

        public void GetAll()
        {
            var users = _db.Users
                .Include(s=> s.Profile)
                .Include(s=> s.Role)
                .ToList();
            Users.Clear();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }
        
    }
}
