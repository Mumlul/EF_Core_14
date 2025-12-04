using EF_Core.Models;
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

namespace EF_Core.Pages
{
    /// <summary>
    /// Логика взаимодействия для Users_role.xaml
    /// </summary>
    public partial class Users_role : Page
    {
        public RoleService _service = new();
        public Role role { get; set; } = new();

        private Role editRole=new();

        public Users_role(Role? role=null)
        {
            InitializeComponent();

            if(role != null)
            {
                _service.LoadRelation(role, "Users");
                editRole = role;
            }
            DataContext = role;
        }

        private void Go_back(object sender,RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Save_change(object sender, RoutedEventArgs e)
        {
            if (role != editRole)
            {
                _service.Commit();
                _service.GetAll();
                NavigationService.GoBack();
            }
            else MessageBox.Show("Сначало поменяйте название");
        }

    }
}
