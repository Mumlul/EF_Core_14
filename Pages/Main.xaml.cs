using EF_Core.Models;
using EF_Core.Models.Service;
using EF_Core.Pages.Group;
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

namespace EF_Core.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main :Page
    {
        public UserService service { get; set; } = new();
        public User? user { get; set; } = null;

        public Main()
        {
            InitializeComponent();
        }

        private void Add_user(object sender,RoutedEventArgs e)
        {
            NavigationService.Navigate(new Add_User(null,service));
        }

        private void Edit(object sender,RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            NavigationService.Navigate(new Add_User(user,service));
        }

        private void View_Roles(object sender,RoutedEventArgs e)
        {
            NavigationService.Navigate(new View_Role());
        }

        private void View_Groups(object sender,RoutedEventArgs e)
        {
            NavigationService.Navigate(new View_Group());
        }
    }
}
