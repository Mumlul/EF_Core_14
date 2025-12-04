using EF_Core.Models.Protocols;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class InterestGroup:ObservableObject
    {
        #region Private
        private int _id;
        private string _title="-";
        private string _description="-";
        private ObservableCollection<UserInterestGroup>? _userinterestgroup;
        #endregion

        public int Id { get => _id; set {  _id = value;SetProperty(ref _id, value); } }
        public string Title { get => _title; set { _title = value;SetProperty(ref _title, value); } }
        public string Description { get => _description; set { _description = value;SetProperty(ref _description, value); } }
        public ObservableCollection<UserInterestGroup> UserInterestGroup { get => _userinterestgroup; set => SetProperty(ref _userinterestgroup, value); }
    }
}
