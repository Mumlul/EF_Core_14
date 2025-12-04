using EF_Core.Models.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models.Service
{
    public class GroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;

        public static ObservableCollection<InterestGroup> Groups { get; set; } = new();
        public GroupService() { GetAll(); }
        public int Commit() => _db.SaveChanges();
        public void GetAll()
        {
            var groups = _db.InterestGroups.ToList();
            Groups.Clear();
            foreach (var group in groups) {Groups.Add(group); };
        }

        public void Add(InterestGroup group)
        {
            var _group=new InterestGroup 
            {
                Id = group.Id,
                Title = group.Title,
            };
            _db.Add<InterestGroup>(_group);
            Commit();
            Groups.Add(_group);
        }

        public void Remove(InterestGroup group)
        {
            _db.Remove<InterestGroup>(group);
            if(Commit()>0)
                if(Groups.Contains(group))
                    Groups.Remove(group);
        }

        public void LoadRelation(InterestGroup group, string relation)
        {
            var entry = _db.Entry(group);
            var navigation = entry.Metadata.FindNavigation(relation)
                ?? throw new InvalidOperationException($"Navigation '{relation}' not found");

            if (navigation.IsCollection)
                entry.Collection(relation).Load();
            else
                entry.Reference(relation).Load();
        }


    }
}
