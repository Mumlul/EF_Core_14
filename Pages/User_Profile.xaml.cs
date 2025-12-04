using EF_Core.Models;
using EF_Core.Models.Service;
using Microsoft.Win32;
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
    /// Логика взаимодействия для User_Profile.xaml
    /// </summary>
    public partial class User_Profile : Page
    {

        public UserService _service = new();
        public User _user = new();

        public User_Profile(User user)
        {
            InitializeComponent();

            _user=user;

            DataContext = _user.Profile;
        }

        private void Save(object sender,RoutedEventArgs e)
        {
            _service.Commit(); 
            _service.GetAll();
            NavigationService.GoBack();
        }

        private void Go_back(object sender,RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Select_Avaterurl(object sender,RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                _user.Profile.Avaterlurl = openFileDialog.FileName;
        }
    }
}
