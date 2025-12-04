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

using EF_Core.Models;
using EF_Core.Models.Service;

namespace EF_Core.Pages.Group
{
    /// <summary>
    /// Логика взаимодействия для View_Group.xaml
    /// </summary>
    public partial class View_Group :Page
    {
        GroupService _service = new();
        InterestGroup? group { get; set; } = new();
        public InterestGroup? selected { get; set; } = null;

        public View_Group()
        {
            InitializeComponent();
            DataContext = this;
            Add_group.DataContext = group;
            //Add_group.DataContext= group;
        }

        private void Add_Group(object sender, RoutedEventArgs e)
        {
            _service.Add(group);
            _service.GetAll();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InfoGroup(selected));
        }

        private void Delete_group(object sender, RoutedEventArgs e)
        {
            if (selected != null) _service.Remove(selected);
            else MessageBox.Show("Выберите группу");
        }

        private void Go_back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
