using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Core.Models.Context;

namespace EF_Core.Models.Service
{
    public  class InteresGroupUserService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public void Add(UserInterestGroup user_group)
        {
            var _user_group=new UserInterestGroup
            {
                Userid=user_group.Userid,
                InterestGroupId=user_group.InterestGroupId,
                JoinedAt=user_group.JoinedAt,
                IsModerator=user_group.IsModerator,
            };
            _db.Add(_user_group);
            _db.SaveChanges();
        }

    }
}
