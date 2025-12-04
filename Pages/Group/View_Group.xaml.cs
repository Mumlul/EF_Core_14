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
        InterestGroup group = new();
        InterestGroup? selected { get; set; } = null;

        bool isEdit = false;

        public View_Group(InterestGroup? _group=null)
        {
            InitializeComponent();
            if(_group != null ) 
            {
                group = _group;
                isEdit = true;
            }
            DataContext = group;
        }

        private void Add_Group(object sender, RoutedEventArgs e)
        {
            if(isEdit) _service.Commit();
            else _service.Add(group);
            _service.GetAll();
        }

        private void Edit(object sender,RoutedEventArgs e)
        {
        }
    }
}
