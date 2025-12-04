using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Models.Protocols;

namespace EF_Core.Models
{
    public class User:ObservableObject
    {
        #region Private
        private int id;
        private string? login;
        private string? name;
        private string? email;
        private string? password;
        private DateTime createdat = DateTime.Today;
        UserProfile _profile;
        int _roleid;
        Role _role; 
        ObservableCollection<UserInterestGroup>? _interestgroup;
        #endregion

        public int Id { get => id; set { id = value; SetProperty(ref id, value); } }
        public string Login { get => login ?? "_"; set { login = string.IsNullOrEmpty(value)? "_":value; SetProperty(ref login, value); } }
        public string Name { get => name ?? "_"; set { name =string.IsNullOrEmpty(value)?"_" : value ; SetProperty(ref name, value); } }
        public string Email { get => email ?? "_"; set { email = value; SetProperty(ref email, value); } }
        public string Password { get => password ?? "_"; set { password = value; SetProperty(ref password, value); } }
        public DateTime CreatedAt { get => createdat; set { createdat = value; SetProperty(ref createdat, value); } }
        public UserProfile Profile { get => _profile;set {_profile = value;SetProperty(ref _profile, value); } }
        public int RoleId { get => _roleid; set { _roleid = value;SetProperty(ref _roleid, value); } }
        public Role Role { get => _role; set { _role = value; SetProperty(ref _role, value); } }
        public ObservableCollection<UserInterestGroup> InterestGroups { get => _interestgroup; set => SetProperty(ref _interestgroup, value); }
    }
}
