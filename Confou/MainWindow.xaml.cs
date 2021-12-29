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
using ConfouLibrary;

namespace Confou
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //TODO: Не оптимальный вариант инициализации нужного класса и работы с самой библиотекой, найти другой вариант
            //var c = new ConfouLibrary.BusinessLogic.Users();
            //c.CreateUser(new Users() { }, out string error);

            
        }
    }
}
