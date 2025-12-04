using EF_Core.Models;
using EF_Core.Models.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Add_User.xaml
    /// </summary>
    public partial class Add_User :Page
    {
        public UserService _service = new();
        public User _user = new();
        public User _selecteduser=new();
        bool isEdit = false;
        ObservableCollection<User> _users = new ObservableCollection<User>();

        public Add_User(User? _edituser=null,UserService? _service=null)
        {
            InitializeComponent();

            StackPanel sidebar = this.FindName("Sidebar") as StackPanel ?? new StackPanel();
            sidebar.Visibility = Visibility.Hidden;

            if (_edituser != null)
            {
                _user=_edituser;
                isEdit = true;
                sidebar.Visibility=Visibility.Visible;
            }

            if (_service != null) this._service = _service;

            if (_user.Profile == null) _user.Profile = new ();

            DataContext = _user;
        }

        private void Save(object sender,RoutedEventArgs e)
        {
            if (isEdit) { _service.Commit();_service.GetAll(); }
            else 
            {
                _user.CreatedAt = DateTime.Today;
                _service.Add(_user);
                _service.GetAll();
            }
            NavigationService.GoBack();
             
        }

        private void Back(object sender,RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void View_Profile(object sender,RoutedEventArgs e)
        {
            NavigationService.Navigate(new User_Profile(_user));
        }

    }
}
