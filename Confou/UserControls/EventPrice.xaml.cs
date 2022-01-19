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

namespace Confou.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EventPrice.xaml
    /// </summary>
    public partial class EventPrice : UserControl
    {
        public EventPrice()
        {
            InitializeComponent();
        }

        public event EventHandler BuyClick;
        public int TicketsLeft { get; set; }

        private void ToBuyTicket(object sender, RoutedEventArgs e)
        {
            if (this.BuyClick != null)
                this.BuyClick(this, e);
        }

        private void RiseAmount(object sender, RoutedEventArgs e)
        {
            if (int.Parse(TicketsToBuyBlock.Text) == TicketsLeft)
                return;

            TicketsToBuyBlock.Text = (int.Parse(TicketsToBuyBlock.Text) + 1).ToString();
        }

        private void DecreaseAmount(object sender, RoutedEventArgs e)
        {
            if (int.Parse(TicketsToBuyBlock.Text) == 1)
                return;

            TicketsToBuyBlock.Text = (int.Parse(TicketsToBuyBlock.Text) + 1).ToString();
        }
    }
}
