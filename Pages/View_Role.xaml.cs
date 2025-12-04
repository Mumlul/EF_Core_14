using EF_Core.Models;
using EF_Core.Models.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для View_Role.xaml
    /// </summary>
    public partial class View_Role : Page
    {
        public RoleService _service = new();
        public Role role = new();

        private Role? _newRole;
        public Role NewRole => test != null ? test : (_newRole ??= new Role());


        public Role? test { get; set; } = null;

        private bool isEdit = false;

        public View_Role()
        {
            InitializeComponent();
            DataContext = this;
            Add_role_place.DataContext = role;
        }

        private void Go_back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Add_Role(object sebnder, RoutedEventArgs e)
        {
            if (test == null)
            {
                _service.Add(role);
                _service.GetAll();
            }
            else
            {
                role = test;
            }
        }

        private void View_Users_List(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Users_role(test));
        }

        private void Delete_Role(object sender,RoutedEventArgs e)
        {
            if (test == null) MessageBox.Show("Выберите элемент");
            else _service.Remove(test);
        }
    }
}
