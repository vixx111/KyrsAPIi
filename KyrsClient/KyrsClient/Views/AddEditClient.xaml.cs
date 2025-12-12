using KyrsClient.Models;
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

namespace KyrsClient.Views
{
    /// <summary>
    /// Логика взаимодействия для AddEditClient.xaml
    /// </summary>
    public partial class AddEditClient : Window
    {
        public Client Client { get;  private set; }
        public AddEditClient(Client _client)
        {
            InitializeComponent();
            Client = _client;
            DataContext = Client;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}
