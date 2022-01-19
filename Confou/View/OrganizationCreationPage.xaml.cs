using Confou.Logic;
using ConfouLibrary;
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
    /// Логика взаимодействия для OrganizationCreationPage.xaml
    /// </summary>
    public partial class OrganizationCreationPage : Window
    {

        public List<Users> Users { get; set; }

        public OrganizationCreationPage()
        {
            InitializeComponent();
            DataContext = this;
            Users = StaticResources.LogicManager.UsersManagement.GetUsers(out string error, true);
            UsersCB.ItemsSource = Users;
            UsersCB.DisplayMemberPath = "Login";
            UsersCB.SelectedIndex = 0;

            if (error != null)
                MessageBox.Show(error);
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            Organizations organization = new Organizations()
            {
                AssigneeId = (UsersCB.SelectedItem as Users).UserId,
                OrganizationName = OrgName.Text,
                OrganizationINN = Convert.ToDecimal(OrgINN.Text),
                Fee = Convert.ToDecimal(OrgFee.Text),
                CreateDate = DateTime.Now,
                CreateAuthor = StaticResources.userStatic.UserId,
                Enabled = true,
                Email = OrgEmail.Text
            };

            var result = StaticResources.LogicManager.OrganizationsManagement.CreateOrganization(organization, StaticResources.userStatic, out string error);

            if (result)
            {
                var updResult = StaticResources.LogicManager.UsersManagement.ChangeRole((UsersCB.SelectedItem as Users).UserId, UserRole.Organizator, StaticResources.userStatic.UserId, out string errorTwo);

                if (error != null)
                    MessageBox.Show(errorTwo);

                MessageBox.Show("Организация успешно создана!");
                this.Close();
            }
            
            if (error != null)
            {
                MessageBox.Show(error);
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {

        }
    }
}
