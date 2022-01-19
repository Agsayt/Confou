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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {

        #region vars
        public List<Organizations> OrgList { get; set; } 
        #endregion

        public AdminPage()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            LoadOrganizations();
        }

        private void LoadOrganizations()
        {
            OrgList = StaticResources.LogicManager.OrganizationsManagement.GetAllOrganizations(out string error);
            OrganizationTable.ItemsSource = OrgList;
            if (error != null)
                MessageBox.Show(error);

        }

        private void CreateOrganizator(object sender, RoutedEventArgs e)
        {
            OrganizationCreationPage ocp = new OrganizationCreationPage();
            this.Hide();
            ocp.ShowDialog();
            this.Show();
        }
    }
}
