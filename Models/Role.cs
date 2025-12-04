using EF_Core.Models.Protocols;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class Role:ObservableObject
    {
        #region Prrivate
        int _id;
        string _title;
        ObservableCollection<User> _users;

        #endregion

        public int Id { get { return _id; } set { _id = value; SetProperty(ref _id, value); } }
        public string Title { get { return _title; } set { _title = value; SetProperty(ref _title, value); } }
        public ObservableCollection<User> Users { get { return _users; } set { _users = value; SetProperty(ref _users, value); } }
    }
}
