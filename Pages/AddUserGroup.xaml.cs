using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EF_Core.Models.Service;
using EF_Core.Models;

namespace EF_Core.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUserGroup.xaml
    /// </summary>
    public partial class AddUserGroup : Page
    {
        InteresGroupUserService _intservis = new();
        User User { get; set; } = new();
        public InterestGroup? Group { get; set; } = null;
        UserInterestGroup itgroup  = new();
        UserService userservice = new();

        public AddUserGroup(User user)
        {
            InitializeComponent();

            User = user;
            User_Info.DataContext= User;
            List_group.DataContext = this;
            Info.DataContext = itgroup;
        }

        private void Go_Back(object sender,RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SelectGroup(object sender,RoutedEventArgs e)
        {
            var user_group=new UserInterestGroup
            {
                Userid=User.Id,
                InterestGroupId=Group.Id,
                JoinedAt= itgroup.JoinedAt,
                IsModerator= itgroup.IsModerator,
            };

            _intservis.Add(user_group);
            Group = null;
            NavigationService.GoBack();
        }
    }
}
