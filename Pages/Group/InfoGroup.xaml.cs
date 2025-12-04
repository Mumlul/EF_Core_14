using EF_Core.Migrations;
using EF_Core.Models.Service;
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

namespace EF_Core.Pages.Group
{
    /// <summary>
    /// Логика взаимодействия для InfoGroup.xaml
    /// </summary>
    public partial class InfoGroup : Page
    {
        GroupService service=new();

        public InfoGroup(EF_Core.Models.InterestGroup group)
        {
            InitializeComponent();

            service.LoadRelation(group, "UserInterestGroup");

            DataContext = group;
        }

        private void Save_cahnfes(object sender,RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Go_back(object sender,RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
