using Confou.Logic;
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

namespace Confou.View.Frames
{
    /// <summary>
    /// Логика взаимодействия для AuthFrame.xaml
    /// </summary>
    public partial class AuthFrame : Page
    {
        public AuthFrame()
        {
            InitializeComponent();
        }

        

        private void RegisterButton(object sender, MouseButtonEventArgs e)
        {
            AuthPage window = Application.Current.Windows.OfType<AuthPage>().FirstOrDefault();
            if (window != null)
            {
                window.MainFrame.Source = new Uri("Frames/RegistrationFrame.xaml", UriKind.Relative);
            }
        }

        private void AuthButton(object sender, MouseButtonEventArgs e)
        {
            
            var IsVerified = StaticResources.LogicManager.UsersManagement.VerifyUser(Login.Text, Password.Password, out Guid userId, out string error);
            
            if (error != null)
            {
                MessageBox.Show(error);
            }

            if(IsVerified)
            {
                StaticResources.userStatic = StaticResources.LogicManager.UsersManagement.GetUserByID(userId, out string errorUser);

                if(errorUser != null)
                {
                    MessageBox.Show(errorUser);
                }

                if (RememberCheck.IsChecked == true)
                {
                    Properties.Settings.Default.Login = StaticResources.userStatic.Login;
                    Properties.Settings.Default.Password = StaticResources.userStatic.PasswordHash;
                    Properties.Settings.Default.Role = (int)StaticResources.userStatic.RoleId;
                    Properties.Settings.Default.UserID = StaticResources.userStatic.UserId.ToString();
                }

                AuthPage window = Application.Current.Windows.OfType<AuthPage>().FirstOrDefault();
                if (window != null)
                {
                    window.Close();
                }
            }
        }
    }
}
