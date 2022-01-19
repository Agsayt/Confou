using Confou.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace Confou.View.Frames
{
    /// <summary>
    /// Логика взаимодействия для RegistrationFrame.xaml
    /// </summary>
    public partial class RegistrationFrame : Page
    {
        public RegistrationFrame()
        {
            InitializeComponent();
            DataContext = this;
            
        }

        #region vars
        private string email { get; set; }
        private string login { get; set; }
        private string password, passwordVerify;

        #endregion

        private void PasswordVerifyChanged(object sender, RoutedEventArgs e)
        {
            passwordVerify = ((PasswordBox)sender).Password;
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            password = ((PasswordBox)sender).Password;
        }

        private void CreateButton(object sender, RoutedEventArgs e)
        {
            var uGuid = Guid.NewGuid();

            var user = new ConfouLibrary.Users()
            {
                UserId = uGuid,
                Login = Login.Text,
                Enabled = true,
                CreateAuthor = uGuid,
                CreateDate = DateTime.Now,
                IsDoubleAuth = false,
                PasswordHash = password,
                RoleId = ConfouLibrary.UserRole.User,
                Email = Email.Text
            };

            var result = StaticResources.LogicManager.UsersManagement.CreateUser(user, out string error);

            if (error != null)
            {
                MessageBox.Show("Ошибка: " + error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
