using ConfouLibrary;
using ConfouLibrary.BusinessLogic.Models;
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
using System.Windows.Shapes;

namespace Confou.View
{
    /// <summary>
    /// Логика взаимодействия для BuyPage.xaml
    /// </summary>
    public partial class BuyPage : Window
    {

        #region vars
        public TicketToBuy[] TicketsToBuy { get; set; } 
        #endregion

        public BuyPage()
        {
            InitializeComponent();
            DataContext = TicketsToBuy;
        }

        private void BuyTicket(object sender, RoutedEventArgs e)
        {

        }

        private void BackClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
