using EF_Core.Models.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class UserInterestGroup :ObservableObject
    {
        #region Private 
        private int _userid;
        private int _iterestgroupid;
        private DateTime _joinedat;
        private bool _ismoderator;
        private User? _user;
        InterestGroup? _interesetgroup;
        #endregion

        public int Userid { get => _userid; set { _userid = value; SetProperty(ref _userid, value); } }
        public int InterestGroupId { get => _iterestgroupid; set { _iterestgroupid = value; SetProperty(ref _iterestgroupid, value); } }
        public DateTime JoinedAt { get => _joinedat; set { _joinedat = value; SetProperty(ref _joinedat, value); } }
        public bool IsModerator { get => _ismoderator; set { _ismoderator = value; SetProperty(ref _ismoderator, value); } }
        public User User { get => _user; set => SetProperty(ref _user, value); }
        public InterestGroup InterestGroup { get => _interesetgroup; set => SetProperty(ref _interesetgroup, value); }
    }
}
