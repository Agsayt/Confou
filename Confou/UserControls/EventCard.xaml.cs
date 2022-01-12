using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    /// Логика взаимодействия для EventCard.xaml
    /// </summary>
    public partial class EventCard : UserControl
    {
        public EventCard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// На случай, если необходимо будет встроить дополнительные проверки или ещё чего. Пока не знаю.
        /// </summary>
        #region Приватные свойства
        private string eventName 
        { 
            get => EventName.Text; 
            set => EventName.Text = value; 
        }

        private string eventDate
        { 
            get => EventDate.Text; 
            set => EventDate.Text = value; 
        }

        private string eventPrice
        {
            get => EventPrice.Text;
            set => EventPrice.Text = value;
        }

        private string eventPlace
        {
            get => EventPlace.Text;
            set => EventPrice.Text= value;
        }

        private ImageSource eventAfisha
        {
            get => EventAfisha.Source;
            set => EventAfisha.Source = value;
        }
        #endregion

        /// <summary>
        /// Устанавливает значения согласно названию метода
        /// </summary>
        #region Методы назначения данных
        public void SetEventName(string name)
        {
            eventName = name;
        }

        public void SetEventDate(DateTime time)
        {
            eventDate = time.Date.Day + " " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(time.Month);
        }

        public void SetEventPrice(string cost, string priceSign)
        {
            eventPrice = $"{cost} {priceSign}";
        }

        public void SetEventPlace(string place)
        {
            eventPlace = place;
        }

        public void SetEventAfishaFromByte(byte[] image)
        {
            BitmapImage bImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(image);
            bImg.BeginInit();
            bImg.StreamSource = ms;
            bImg.EndInit();

            EventAfisha.Source = bImg;
        }
        #endregion
    }
}
