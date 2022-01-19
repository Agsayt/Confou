using Confou.Logic;
using Confou.UserControls;
using ConfouLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Confou.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {

        bool IsAuthorized = false;
        //public static readonly Basic LogicManager = new Basic();

        public MainPage()
        {
            InitializeComponent();
            OnLoad();
            //CreateAdmin();

        }

        private void CreateAdmin()
        {
            var uGuid = Guid.NewGuid();

            var user = new ConfouLibrary.Users()
            {
                UserId = uGuid,
                 Login = "Admin",
                 Enabled = true,
                 FirstName = "Georgiy",
                 MiddleName = "Vit",
                 LastName = "Beklemishev",
                 CreateAuthor = uGuid,
                 CreateDate = DateTime.Now,
                 IsDoubleAuth = false,
                 PasswordHash = "test",
                 RoleId = (int)ConfouLibrary.UserRole.Administrator,
                 Email = "111ag@rambler.ru"
            };

            var result = StaticResources.LogicManager.UsersManagement.CreateUser(user, out string error);

            if (result)
            {
                MessageBox.Show("Админ создан");
            }
            else if (error != null)
            {
                MessageBox.Show("Ошибка: " + error);
            }
        }
        #region Page basic load

        /// <summary>
        /// Основной метод вызывающий настройку страницы
        /// </summary>
        private void OnLoad()
        {
            OpenBasicUIOptions();

            StaticResources.LogicManager = new Basic();
            var AllOnSale = StaticResources.LogicManager.EventManagement.GetEventsWithStatus(ConfouLibrary.EventStatus.OnSale, out string error);

            if (error != null)
            {
                MessageBox.Show(error);
                return;
            }

            if (AllOnSale == null || AllOnSale.Count() == 0)
            {
                return;
            }

            AuthoAuth();
            LoadAllEvents(AllOnSale, AllEventsPanel);
            LoadNewEvents(AllOnSale, NewEventsPanel);
            LoadPopularEvents(AllOnSale, PopularEventsPanel);            
        }

        /// <summary>
        /// Скрытие по стандарту не нужных "вкладок"
        /// </summary>
        private void OpenBasicUIOptions()
        {
            Statistics.Visibility = Visibility.Collapsed;
            Sells.Visibility = Visibility.Collapsed;
            Events.Visibility = Visibility.Collapsed;
            AdminPanel.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Автоматическая авторизация, если пользователь выбрал
        /// </summary>
        private void AuthoAuth()
        {
            if ((StaticResources.userStatic != null || Properties.Settings.Default.Login != String.Empty) && !IsAuthorized)
            {
                ConfouLibrary.Users user;
                ConfouLibrary.UserRole role;
                if (StaticResources.userStatic != null)
                {
                    role = StaticResources.userStatic.RoleId;
                    user = StaticResources.userStatic;
                }
                else
                {
                    role = (ConfouLibrary.UserRole)Properties.Settings.Default.Role;
                    user = StaticResources.LogicManager.UsersManagement.GetUserByID(Guid.Parse(Properties.Settings.Default.UserID), out string error);

                    if (error != null)
                    {
                        MessageBox.Show(error);
                        return;
                    }
                }

                switch (role)
                {
                    case ConfouLibrary.UserRole.User:
                        Statistics.Visibility = Visibility.Collapsed;
                        Sells.Visibility = Visibility.Collapsed;
                        Events.Visibility = Visibility.Collapsed;
                        break;
                    case ConfouLibrary.UserRole.Administrator:
                        MyTickets.Visibility = Visibility.Collapsed;
                        Statistics.Visibility = Visibility.Collapsed;
                        Sells.Visibility = Visibility.Collapsed;
                        Events.Visibility = Visibility.Collapsed;
                        AdminPanel.Visibility = Visibility.Visible;
                        break;
                    case ConfouLibrary.UserRole.Seller: 
                        AdminPanel.Visibility = Visibility.Collapsed;
                        MyTickets.Visibility = Visibility.Collapsed;
                        break;
                    case ConfouLibrary.UserRole.Buyer:
                        Events.Visibility = Visibility.Collapsed;
                        Sells.Visibility = Visibility.Collapsed;
                        Statistics.Visibility = Visibility.Collapsed;
                        AdminPanel.Visibility = Visibility.Collapsed;
                        break;
                    case ConfouLibrary.UserRole.Organizator: 
                        AdminPanel.Visibility = Visibility.Collapsed;
                        MyTickets.Visibility = Visibility.Collapsed;
                        break;
                }

                IsAuthorized = true;
                AuthText.Visibility = Visibility.Collapsed;
                UserAvatar.Visibility = Visibility.Visible;
                UserName.Visibility = Visibility.Visible;

                

                if (user.Image != null)
                    UserAvatar.Source = StaticResources.GetImage(user.Image);
                UserName.Text = $"{user.Login}";

            }
        }

        /// <summary>
        /// Отрисовка популярных событий (пока не реализовано) 
        /// </summary>
        /// <param name="allOnSale"></param>
        /// <param name="popularEventsPanel"></param>
        private void LoadPopularEvents(List<ConfouLibrary.Events> allOnSale, StackPanel popularEventsPanel)
        {
            //FillerPopular.Visibility = Visibility.Collapsed;
            //var popularEvents = allOnSale.GroupBy(x => x.Tickets.Where(y => y.EventId == x.EventId))
            //                        .OrderByDescending(z => z.Count())
            //                        .Take(4)
            //                        .Select(q => q).ToList();


            //for (int i = 0; i < 4 || i < popularEvents.Count; i++)
            //{
            //    Canvas afisha = new Canvas();
            //    ImageBrush ib = new ImageBrush();
            //    BitmapImage bImg = new BitmapImage();
            //    MemoryStream ms = new MemoryStream(popularEvents[i].Afisha);
            //    bImg.BeginInit();
            //    bImg.StreamSource = ms;
            //    bImg.EndInit();
            //    ib.ImageSource = bImg;
            //    afisha.Background = ib;
            //    afisha.Width = 90;
            //    afisha.Height = 120;
            //    popularEventsPanel.Children.Add(afisha);
            //}
        }

        /// <summary>
        /// Отрисовка новых событий
        /// </summary>
        /// <param name="allOnSale"></param>
        /// <param name="newEventsPanel"></param>
        private void LoadNewEvents(List<ConfouLibrary.Events> allOnSale, StackPanel newEventsPanel)
        {
            FillerNew.Visibility = Visibility.Collapsed;
            var latestEvents = allOnSale.OrderByDescending(p => p.CreateDate).ToList();

            for (int i = 0; i < 4 || i < latestEvents.Count; i++)
            {
                Canvas afisha = new Canvas();
                ImageBrush ib = new ImageBrush();
                BitmapImage bImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(latestEvents[i].Afisha);
                bImg.BeginInit();
                bImg.StreamSource = ms;
                bImg.EndInit();
                ib.ImageSource = bImg;
                afisha.Background = ib;
                afisha.Width = 90;
                afisha.Height = 120;
                newEventsPanel.Children.Add(afisha);
            }
            
        }        

        /// <summary>
        /// Отрисовка всех действительных событий
        /// </summary>
        /// <param name="AllOnSale"></param>
        /// <param name="allEventsPanel"></param>
        private void LoadAllEvents(List<ConfouLibrary.Events> AllOnSale, WrapPanel allEventsPanel)
        {
            FillerAll.Visibility = Visibility.Collapsed;
            foreach (var Event in AllOnSale)
            {
                EventCard card = new EventCard();
                card.SetEventAfishaFromByte(Event.Afisha);
                card.SetEventDate(Event.EventDate);
                card.SetEventName(Event.EventName);
                card.SetEventPlace(Event.HallName);
                card.SetEventPrice(Event.TicketPool.Where(x => x.EventId == Event.EventId).Select(y => y.TicketType.TicketPrice).Min().ToString(), "руб."); // ОМГ! Ужс... Нужны модели.
                card.Width = 300;
                card.Margin = new Thickness(10);
                allEventsPanel.Children.Add(card);
            }
        }
        #endregion

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsAuthorized)
            {
                BlurBitmapEffect bme = new BlurBitmapEffect();
                bme.Radius = 15;
                bme.KernelType = KernelType.Gaussian;

                MainGrid.BitmapEffect = bme;

                AuthPage ap = new AuthPage();
                ap.Owner = this;
                ap.ShowDialog();
                AuthoAuth();

                MainGrid.BitmapEffect = null;
            }
            else
            {
                Profile pr = new Profile();
                this.Hide();
                pr.ShowDialog();
                this.Show();
            }          

        }

        private void AdminPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AdminPage ap = new AdminPage();
            this.Hide();
            ap.ShowDialog();
            this.Show();
        }
    }
}
